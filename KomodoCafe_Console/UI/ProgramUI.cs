
using KomodoCafe_Repo;
using KomodoCafe_Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoCafe_Repo.KomodoCafeContent;

namespace KomodoCafe_Console.UI
{
    public class ProgramUI
    {

        private KomodoCafeMenu _meal1;
        private KomodoCafeMenu _meal2;
        private KomodoCafeMenu _meal3;
        private KomodoCafeMenu _meal4;
        private readonly KomodoCafeContent_Repo _repo = new KomodoCafeContent_Repo();

        public void Run()
        {
            SeedContentList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            do
            {
                string userInput = GetMenuChoice();

                switch (userInput)
                {
                    case "1": 
                        ShowAllContent();
                        Pause();
                        break;
                    case "2": 
                        ShowContentByMealName();
                        Pause();
                        break;
                    case "3": 
                        ShowContentByMealNumber();
                        Pause();
                        break;
                    case "4": 
                        AddNewMeal();
                        Pause();
                        break;
                    case "5":
                        RemoveMealFromList();
                        Pause();
                        break;
                    case "6":
                        UpdateMeal();
                        Pause();
                        break;
                    case "0":
                        // Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-5.\n");
                        Console.ReadKey();
                        break;
                }
            } while (continueToRun);
        }

        private string GetMenuChoice()
        {
            string userInput = "";
            bool badInput = true;

            do
            {
                Console.Clear();
                Console.Write("\n\n Enter the number of the option you'd like to select:\n\n" +
                    " 1. Show the Menu\n" +
                    " 2. Find a menu item by name of meal\n" +
                    " 3. Find a menu item by number of meal\n" +
                    " 4. Add a new menu item\n" +
                    " 5. Remove a meal\n" +
                    " 6. Update a meal\n" +
                    " 0. Exit\n\n" +
                    " Enter your choice: ");

                userInput = Console.ReadLine();
                badInput = userInput != "0" && userInput != "1" && userInput != "2" &&
                           userInput != "3" && userInput != "4" && userInput != "5";
                if (badInput)
                {
                    Console.WriteLine($"\n {userInput} is not valid. Please try again.");
                    Pause();
                }
            } while (badInput);
            return userInput;
        }

        private void Pause()
        {
            Console.Write($"Press any key to continue . . . ");
            Console.ReadKey();
        }

        private void ShowAllContent()// case 1 from the menu.
        {
            Console.Clear();

            List<KomodoCafeMenu> listOfContent = _repo.GetContents();

            foreach (KomodoCafeMenu content in listOfContent)
            {
                DisplayContent(content);
            }

        }

        private void ShowContentByMealName() // case 2 from the menu
        {
            string mealName = GetMealNameFromUser();

            KomodoCafeMenu content = _repo.GetContentsByMealName(mealName);

            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("Invalid title. Could not find any results.");
            }
            //Console.ReadKey();
        }

        private void ShowContentByMealNumber() // case 3 from the menu
        {
            int mealNumber = GetMealNumberFromUser();

            KomodoCafeMenu content = _repo.GetContentsByMealNumber(mealNumber);

            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("Invalid meal number. Could not find any results.");
            }
            // Console.ReadKey();
        }

        private string GetMealNameFromUser()
        {
            // Console.Clear();
            ShowAllContent();
            Console.Write("\n Enter a meal name: ");

            return Console.ReadLine().ToLower();
        }

        private int GetMealNumberFromUser()
        {
            // Console.Clear();
            ShowAllContent();
            Console.Write("Enter a meal number: ");

            return Convert.ToInt32(Console.ReadLine());
        }

        private void DisplayContent(KomodoCafeMenu content)
        {
            Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                $"Meal Name: {content.MealName}\n" +
                $"Description: {content.Description}\n" +
                $"Price : ${content.Price}\n" +
                $"\nIngredients for {content.MealName}: ");

            for (int i = 0; i < content.Ingredients.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {content.Ingredients[i]}");
            }
            Console.WriteLine();
        }

        public void AddNewMeal() // case 4 from the menu
        {
            KomodoCafeMenu content = new KomodoCafeMenu();

            content.MealNumber = _repo.Count + 1;

            Console.Write("Please enter a meal name: ");
            content.MealName = Console.ReadLine();

            Console.Write("Please enter a meal description: ");
            content.Description = Console.ReadLine();

            Console.Write("Please enter price of the meal (no dollar sign): ");
            content.Price = Convert.ToDecimal(Console.ReadLine());

            bool keepAdding = true;
            int num = 1;
            string ingred = "";
            string response = "";

            do
            {
                Console.Write($"Enter ingredient number {num}: ");
                ingred = Console.ReadLine();

                content.Ingredients.Add(ingred);
                Console.Write("Add another? (y/n) ");
                response = Console.ReadLine().ToLower();

                if (response != "y")
                {
                    keepAdding = false;
                }
                else
                {
                    num++;
                }
            } while (keepAdding);
            bool wasAdded = _repo.AddContentToDirectory(content);

            if (!wasAdded) Console.WriteLine("Failed to add.");
        }

        private void RemoveMealFromList() // case 5 from menu
        {
            List<KomodoCafeMenu> listOfContent = _repo.GetContents();
            Console.WriteLine("Which meal do you want to delete?");

            int count = 0;

            Console.Write("Do you want to delete by meal number or meal name?\n" +
                "Enter 1 for number or 2 for meal name: ");

            string choice = Console.ReadLine();

            foreach (KomodoCafeMenu content in listOfContent)
            {
                count++;
                Console.WriteLine($"Meal number: {count}. {content.MealName}");
            }

            switch (Convert.ToInt32(choice))
            {
                case 1:
                    Console.Write("Enter the number to delete: ");
                    int targetContentId = int.Parse(Console.ReadLine());

                    int targetIndex = targetContentId - 1;

                    if (targetIndex >= 0 && targetIndex < listOfContent.Count)
                    {
                        KomodoCafeMenu desiredContent = listOfContent[targetIndex];

                        if (_repo.DeleteContentByMealNumber(desiredContent.MealNumber))
                        {
                            Console.WriteLine($"{targetContentId}. {desiredContent.MealName} successfully removed.");
                        }
                        else
                        {
                            Console.WriteLine("I'm sorry.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No content has that ID.");
                    }
                    break;
                case 2:
                    string mealName = Console.ReadLine();
                    bool foundName = false;

                    targetIndex = 0;

                    do
                    {
                        KomodoCafeMenu desiredContent = listOfContent[targetIndex];
                        if (mealName == desiredContent.MealName)
                        {
                            foundName = true;
                            if (_repo.DeleteContentByMealName(desiredContent.MealName))
                            {
                                Console.WriteLine($"{desiredContent.MealName} successfully removed.");
                            }
                            else
                            {
                                Console.WriteLine("I'm sorry.");
                            }
                        }
                        targetIndex++;
                    } while (!foundName);
                   
                    break;
                default: break;
            }
            // need to renumber the list.
            for (int i = 0; i < listOfContent.Count; i++)
            {
                listOfContent[i].MealNumber = i + 1;
            }
        }
        private void UpdateMeal()  // case 6 from menu
        {
            Console.Clear();
            List<KomodoCafeMenu> listOfContent = _repo.GetContents();
            int count = 0;
            foreach (KomodoCafeMenu content in listOfContent)
            {
                count++;
                Console.WriteLine($"Meal number: {count}. {content.MealName}");
            }

            Console.Write("Which meal do you want to change?\n" +
                "Enter the meal number: ");

            int targetContentId = int.Parse(Console.ReadLine());

            Console.Write("Do you want to change the meal's name? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            string newName = "";

            if (choice == "y")
            {
                Console.Write("Enter the new name: ");
                newName = Console.ReadLine();
                listOfContent[targetContentId - 1].MealName = newName;
            }

            Console.Write("Do you want to change the meal's price? (y/n): ");
            choice = Console.ReadLine().ToLower();

            if (choice == "y")
            {
                decimal newPrice = 0m;
                Console.Write("Enter the new price: ");
                newPrice = Convert.ToDecimal(Console.ReadLine());
                listOfContent[targetContentId - 1].Price = newPrice;
            }

        }
        private void SeedContentList()
        {
            //  _repo = new KomodoCafeContent_Repo();
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

            _repo.AddContentToDirectory(_meal1);
            _repo.AddContentToDirectory(_meal2);
            _repo.AddContentToDirectory(_meal3);
            _repo.AddContentToDirectory(_meal4);
        }
    }
}
