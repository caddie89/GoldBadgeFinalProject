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

        //This checks same method as above
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

            bool idIsEqual = false;

            foreach (Menu menu in menuDirectory)
            {
                if (menu.MealNumber == menuItemsToAdd.MealNumber)
                {
                    idIsEqual = true;
                    break;
                }
            }
            Assert.IsTrue(idIsEqual);
        }

        //Add Ingredient To Menu
        [TestMethod]
        public void TestForAddingIngredientsToList()
        {
            //Arrange
            Menu menuItems = new Menu(1, new List<string> { "onions" });
            MenuRepository menuRepo = new MenuRepository();
            menuItems.MealNumber = 1;
            menuItems.ListOfIngredients = new List<string> { "onions" };

            menuRepo.AddMenuItemsToList(menuItems);

            //Act
            menuRepo.AddIngredientToMenu(menuItems.MealNumber, menuItems.ListOfIngredients);

            //Assert
            Menu copyOfMenuFromList = new Menu();
            List<Menu> menuDirectory = menuRepo.GetMenuItems();

            foreach (Menu menu in menuDirectory)
            {
                if (menu.MealNumber == menuItems.MealNumber)
                {
                    copyOfMenuFromList = menu;
                    break;
                }
            }
            Assert.AreEqual(menuItems.MealNumber, copyOfMenuFromList.MealNumber);

            foreach (Menu menu in menuDirectory)
            {
                if (menu.ListOfIngredients == menuItems.ListOfIngredients)
                {
                    copyOfMenuFromList = menu;
                    break;
                }
            }
            Assert.AreEqual(menuItems.ListOfIngredients, copyOfMenuFromList.ListOfIngredients);
        }

        //Get Menu Items
        [TestMethod]
        public void TestForGetMenuItems()
        {
            //Arrange
            MenuRepository menuRepo = new MenuRepository();
            Menu menuItemsToAdd = new Menu(1, "Single Burger", "Single patty burger with a drink and a side.", 5.95m, new List<string> { "patty", "mustard", "cheese", "onions" });

            menuRepo.AddMenuItemsToList(menuItemsToAdd);

            //Act
            List<Menu> menuList = menuRepo.GetMenuItems();

            //Assert
            Assert.IsNotNull(menuList);
        }

        //Delete
        [TestMethod]
        public void TestForRemoveMenuItem()
        {
            //Arrange
            MenuRepository menuRepo = new MenuRepository();
            Menu menuItemsToAdd = new Menu(1, "Single Burger", "Single patty burger with a drink and a side.", 5.95m, new List<string> { "patty", "mustard", "cheese", "onions" });

            menuRepo.AddMenuItemsToList(menuItemsToAdd);

            //Act

            bool removeItem = menuRepo.RemoveMenuItem(menuItemsToAdd.MealNumber);

            Assert.IsTrue(removeItem);
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
