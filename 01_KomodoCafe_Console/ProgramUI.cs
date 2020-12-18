using _01_KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedMealsToMenu();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Please select an option from the menu below (i.e. 1, 2, 3, etc.):\n\n" +
                    "1. Add New Meal to Menu\n" +
                    "2. View All Meals on Menu\n" +
                    "3. View Meals on Menu by Number\n" +
                    "4. Delete Meal from Menu\n" +
                    "5. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Create New Meal
                        CreateNewMeal();
                        break;
                    case "2":
                        //View All Meals
                        ViewAllMeals();
                        break;
                    case "3":
                        //View Meals by Number
                        ViewMealByNumber();
                        break;
                    case "4":
                        //Delete Meal
                        DeleteMeal();
                        break;
                    case "5":
                        //Exit
                        Console.WriteLine("\nNow exiting application. Keep up the great work!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease select a valid number option from the menu above.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create New Meal
        private void CreateNewMeal()
        {
            Console.Clear();

            //View Existing Meals
            ViewAllMeals();

            Menu newMenuItem = new Menu();

            //Assign Meal Number
            bool tryAgain = true;
            while (tryAgain)
            {
                tryAgain = false;

                Console.WriteLine("\nAssign a unique Meal Number:");
                var mealNumber = Console.ReadLine();
                newMenuItem.MealNumber = int.Parse(mealNumber);

                foreach (Menu menuItem in _menuRepo.GetMenuItems())
                {
                    if (menuItem.MealNumber == newMenuItem.MealNumber)
                    {
                        Console.WriteLine($"\nMeal # {newMenuItem.MealNumber} already exists.\n\n" +
                            $"Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        ViewAllMeals();
                        tryAgain = true;
                    }
                }
            }

            //Assign Meal Name
            Console.WriteLine("\nAssign a unique Meal Name:");
            newMenuItem.MealName = Console.ReadLine();

            //Assign Meal Description
            Console.WriteLine("\nEnter a brief description of this Meal:");
            newMenuItem.MealDescription = Console.ReadLine();

            //Assign Meal Price
            bool needsCorrectPrice = true;
            while (needsCorrectPrice)
            {
                needsCorrectPrice = false;

                Console.WriteLine("\nAssign a price for this meal (i.e. 4.99, 3.32, etc.):");
                string mealPrice = Console.ReadLine();

                if (decimal.TryParse(mealPrice, out decimal d))
                {
                    //Valid
                    newMenuItem.MealPrice = decimal.Parse(mealPrice);
                    needsCorrectPrice = false;
                }
                else
                {
                    //Invalid
                    Console.WriteLine("\nPlease enter a valid price (must be a decimal number i.e. 2.99).");
                    needsCorrectPrice = true;
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            _menuRepo.AddMenuItemsToList(newMenuItem);

            //Assign List of Ingredients
            List<string> listOfIngredients = new List<string>();
            bool keepAdding = true;
            while (keepAdding)
            {
                keepAdding = false;

                Console.WriteLine("\nEnter an ingredient you would like to add to Meal:");
                string ingredientInput = Console.ReadLine();
                listOfIngredients.Add(ingredientInput);

                Console.WriteLine("\nWould you like to add another ingredient to Meal (yes/no)?");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "yes" || userInput == "y")
                {
                    keepAdding = true;
                }
            }

            _menuRepo.AddIngredientToMenu(newMenuItem.MealNumber, listOfIngredients);
        }

        //View All Meals
        private void ViewAllMeals()
        {
            Console.Clear();

            Console.WriteLine("List of all Meals:");
            List<Menu> listOfMeals = _menuRepo.GetMenuItems();
            foreach (Menu mealInfo in listOfMeals)
            {
                Console.WriteLine($"\nMeal Number: {mealInfo.MealNumber}\n" +
                    $"Meal Name: {mealInfo.MealName}\n" +
                    $"Meal Description: {mealInfo.MealDescription}\n" +
                    $"Meal Price: {mealInfo.MealPrice}\n" +
                    $"Ingredient(s): {string.Join(", ", mealInfo.ListOfIngredients.ToArray())}");
            }
        }

        //View Meal by Number
        private void ViewMealByNumber()
        {
            bool keepViewing = true;
            while (keepViewing)
            {
                Console.Clear();

                keepViewing = false;

                Menu seeMenuItems = new Menu();
                Console.WriteLine("Enter a valid Meal Number (i.e. 1, 2, 3, etc.):");
                string userInput = Console.ReadLine();
                seeMenuItems.MealNumber = int.Parse(userInput);

                var mealNumber = _menuRepo.GetMenuItemByNumber(seeMenuItems.MealNumber);
                if (mealNumber != null)
                {
                    Console.WriteLine($"\nMeal Number: {mealNumber.MealNumber}\n" +
                        $"Meal Name: {mealNumber.MealName}\n" +
                        $"Meal Description: {mealNumber.MealDescription}\n" +
                        $"Meal Price: {mealNumber.MealPrice}\n" +
                        $"Ingredient(s): {string.Join(", ", mealNumber.ListOfIngredients.ToArray())}\n");
                }
                else
                {
                    Console.WriteLine("\nNo Meal identified by that Meal Number.");
                }

                Console.WriteLine("\nWould you like to view another Meal Number (yes/no)?");
                string userInput2 = Console.ReadLine().ToLower();

                if (userInput2 == "yes" || userInput2 == "y")
                {
                    keepViewing = true;
                }
            }
        }

        //Delete Meal
        private void DeleteMeal()
        {
            Console.Clear();

            bool keepDeleting = true;
            while (keepDeleting)
            {
                ViewAllMeals();

                keepDeleting = false;

                Menu seeMenuItems = new Menu();
                Console.WriteLine("\nEnter the Meal Number that you would like deleted:");
                string userInput = Console.ReadLine();
                seeMenuItems.MealNumber = int.Parse(userInput);

                bool wasDeleted = _menuRepo.RemoveMenuItem(seeMenuItems.MealNumber);
                if (wasDeleted)
                {
                    Console.WriteLine("\nThe Meal was successfully removed from Menu.");
                }
                else
                {
                    Console.WriteLine("\nThe Meal could not be removed from the Menu.");
                }

                Console.WriteLine("\nWould you like to delete another Meal (yes/no)?");
                string userInput2 = Console.ReadLine().ToLower();

                if (userInput2 == "yes" || userInput2 == "y")
                {
                    keepDeleting = true;
                }
            }
        }

        //Seed Method
        private void SeedMealsToMenu()
        {
            var meal1 = new Menu(1, "Single Burger", "Single patty burger with a drink and a side.", 5.95m, new List<string> { "patty", "mustard","cheese","onions" });

            _menuRepo.AddMenuItemsToList(meal1);
        }
    }
}