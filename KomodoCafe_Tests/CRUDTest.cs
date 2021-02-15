using KomodoCafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static KomodoCafe_Repo.KomodoCafeContent;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class CRUDTests
    {
        //Fields (private variables for use with a class only
        private KomodoCafeContent_Repo _repo;
        private KomodoCafeMenu _meal1;
        private KomodoCafeMenu _meal2;
        private KomodoCafeMenu _meal3;
        private KomodoCafeMenu _meal4;

        [TestMethod]
        public void Seed()
        {
            _repo = new KomodoCafeContent_Repo();

            _meal1 = new KomodoCafeMenu(
                1,
                "Denver Omelet",
                "Delicious traditional omelet",
                6.95m);
            _meal1.Ingredients.Add("3 eggs");
            _meal1.Ingredients.Add("Ham");
            _meal1.Ingredients.Add("Onion");
            _meal1.Ingredients.Add("Green Pepper");
            _meal1.Ingredients.Add("American Cheese");

            _meal2 = new KomodoCafeMenu(
                2,
                "Banana Pancakes",
                "Scrumptious delightful buttermilk cakes with bananas",
                5.95m);
            _meal2.Ingredients.Add("Buttermilk");
            _meal2.Ingredients.Add("Eggs");
            _meal2.Ingredients.Add("Whole Wheat Flour");
            _meal2.Ingredients.Add("Bananas");
            _meal2.Ingredients.Add("Pure Maple Syrup or Whipped Cream");

            _meal3 = new KomodoCafeMenu(
                3,
                "Blueberry and Walnut Oatmeal",
                "The sweetest tasty oatmeal in the galaxy",
                3.95m);
            _meal3.Ingredients.Add("Organic Whole Oats");
            _meal3.Ingredients.Add("Blueberries");
            _meal3.Ingredients.Add("Walnuts");
            _meal3.Ingredients.Add("Optional Brown Sugar");
            _meal3.Ingredients.Add("Milk or Cream");

            _meal4 = new KomodoCafeMenu(
                4,
                "Strawberry Belgium Waffle",
                "The best ever, you'll never go back to the Waffle House",
                4.95m);

            _meal4.Ingredients.Add("Strawberries");
            _meal4.Ingredients.Add("Milk");
            _meal4.Ingredients.Add("Whole Wheat Flour");
            _meal4.Ingredients.Add("Milk");
            _meal4.Ingredients.Add("Eggs");
            _meal4.Ingredients.Add("Pure Maple Syrup");
            _meal4.Ingredients.Add("Whipped Cream");

            if (_repo.AddContentToDirectory(_meal1)) Console.WriteLine("Meal 1 added");
            if (_repo.AddContentToDirectory(_meal2)) Console.WriteLine("Meal 2 added");
            if (_repo.AddContentToDirectory(_meal3)) Console.WriteLine("Meal 3 added");
            if (_repo.AddContentToDirectory(_meal4)) Console.WriteLine("Meal 4 added");
        }

        [TestMethod]
        public void AddNewMeal()
        {
            // AAA Testing Pattern
            // Arrange
            // Action with the data
            // Assert a condition is true after it

            // Arrange data
            Seed();
            KomodoCafeMenu content = new KomodoCafeMenu(
                5,
                "Eggs Benedict",
                "Voted best in town 6 straight years!",
                7.95m
                );

            // Act (ad to directory)

            content.Ingredients.Add("Two poached Eggs");
            content.Ingredients.Add("Canadian Bacon");
            content.Ingredients.Add("English Muffin");
            content.Ingredients.Add("Hollandaise Sauce");
            content.Ingredients.Add("Hash Browns or Grits");

            bool wasAdded = _repo.AddContentToDirectory(content);

            Console.WriteLine(_repo.Count);
            Console.WriteLine(wasAdded);
            Console.WriteLine(content.MealName);


            // Assert the condition
            Assert.IsTrue(wasAdded);

        }
    }
}
