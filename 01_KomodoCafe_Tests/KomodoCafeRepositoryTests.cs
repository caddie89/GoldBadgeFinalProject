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

        //Test Initialize
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _menuItems = new Menu(1, "Single Burger", "Single patty burger with a drink and a side.", 5.95m, new List<string> { "patty", "mustard", "cheese", "onions" });

            _repo.AddMenuItemsToList(_menuItems);
        }

        //Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange --> Setting up the playing field
            Menu menuItems = new Menu();
            menuItems.MealNumber = 1;
            MenuRepository repository = new MenuRepository();

            //Act --> Get/run the code we want to test
            repository.AddMenuItemsToList(menuItems);
            Menu menuItemsFromDirectory = repository.GetMenuItemByNumber(1);

            //Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(menuItemsFromDirectory);
        }

        
    }
}
