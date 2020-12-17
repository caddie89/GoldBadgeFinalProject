using System;
using System.Collections.Generic;

namespace _01_KomodoCafe_Repository
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public decimal MealPrice { get; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>();

        //Empty Constructor
        public Menu() { }

        public Menu(int mealNumber, List<string> listOfIngredients)
        {
            MealNumber = mealNumber;
            ListOfIngredients = listOfIngredients;

        }

        //Constructor for Seed Method
        public Menu(int mealNumber, string mealName, string mealDescription, decimal mealPrice, List<string> listOfIngredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            ListOfIngredients = listOfIngredients;
        }
    }
}
