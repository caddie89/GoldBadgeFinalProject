using System;
using System.Collections.Generic;
using System.Text;

namespace _01_KomodoCafe_Repository
{
    public class MenuRepository
    {
        //Field
        private List<Menu> _menuItems = new List<Menu>();

        //Create Method(s)
        public void AddMenuItemsToList(Menu menuItems)
        {
            _menuItems.Add(menuItems);
        }

        public void AddIngredientToMenu(int mealNumber, List<string> ingredients)
        {
            var menuItems = GetMenuItemByNumber(mealNumber);
            if (menuItems != null)
            {
                if (menuItems.ListOfIngredients == null)
                    menuItems.ListOfIngredients = new List<string>();

                menuItems.ListOfIngredients.AddRange(ingredients);
            }
        }

        //Read Method
        public List<Menu> GetMenuItems()
        {
            return _menuItems;
        }

        //Update Method (optional)

        //Delete Method
        public bool RemoveMenuItem(int itemNumber)
        {
            Menu menuItem = GetMenuItemByNumber(itemNumber);

            if (_menuItems.Remove(menuItem))
            {
                return true;
            }
            return false;
        }

        //Get Menu Item By Number
        public Menu GetMenuItemByNumber(int itemNumber)
        {
            foreach (Menu mealNumber in _menuItems)
            {
                if (mealNumber.MealNumber == itemNumber)
                {
                    return mealNumber;
                }
            }

            return null;
        }
    }
}
