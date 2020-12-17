using System;
using System.Collections.Generic;
using _01_KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class KomodoCafeRepositoryTests
    {
        private MenuRepository _repo;
        private Menu _menuItems;

        //Add Menu Items To List
        [TestMethod]
        public void TestForAddingMenuItemsToList_Self()
        {
            //Arrange
            _menuItems = new Menu(1, "Single Burger", "Single patty burger with a drink and a side.", 5.95m, new List<string> { "patty", "mustard", "cheese", "onions" });
            _repo = new MenuRepository();

            //Act
            _repo.AddMenuItemsToList(_menuItems);

            //Assert

            List<Menu> menuDirectory = _repo.GetMenuItems();

            bool descriptionIsEqual = false;

            foreach (Menu menuItem in menuDirectory)
            {
                if (menuItem.MealDescription == _menuItems.MealDescription)
                {
                    descriptionIsEqual = true;
                    break;
                }
            }
            Assert.IsTrue(descriptionIsEqual);
        }

        //This method does the same thing as above
        [TestMethod]
        public void TestForAddingMenuItemsToList_Class()
        {
            //Arrange
            MenuRepository menuRepo = new MenuRepository();
            Menu menuItemsToAdd = new Menu(1, "Single Burger", "Single patty burger with a drink and a side.", 5.95m, new List<string> { "patty", "mustard", "cheese", "onions" });

            //Act
            menuRepo.AddMenuItemsToList(menuItemsToAdd);

            //Assert

            List<Menu> menuDirectory = menuRepo.GetMenuItems();

            bool IdIsEqual = false;

            foreach (Menu menu in menuDirectory)
            {
                if (menu.MealNumber == menuItemsToAdd.MealNumber)
                {
                    IdIsEqual = true;
                    break;
                }
            }
            Assert.IsTrue(IdIsEqual);
        }

        //Add Ingredient To Menu
        [TestMethod]
        public void AddIngredientToMenu_ShouldGetNotNull()
        {
            //Arrange
            _menuItems = new Menu();
            _menuItems.MealNumber = 1;
            _repo = new MenuRepository();
            List<string> ingredients = new List<string>();
            ingredients = new List<string> { "ketchup", "pickles" };

            //Act
            _repo.AddIngredientToMenu(_menuItems.MealNumber, ingredients);

            //Assert
            Assert.IsNotNull(_repo);

            

        }
        //Get Menu Item By Number
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange --> Setting up the playing field
            Menu menuItems = new Menu();
            menuItems.MealNumber = 1;
            MenuRepository repository = new MenuRepository();
            repository.AddMenuItemsToList(menuItems);

            //Act --> Get/run the code we want to test
            Menu menuItemsFromDirectory = repository.GetMenuItemByNumber(1);

            //Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(menuItemsFromDirectory);
        }

        
    }
}
