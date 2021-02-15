using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repo
{
    public class KomodoCafeContent
    {
        public class KomodoCafeMenu
        {
            public int MealNumber { get; set; }
            public string MealName { get; set; }
            public string Description { get; set; }

            public List<string> Ingredients { get; set; }
            public decimal Price { get; set; }

            // Constructor
            public KomodoCafeMenu(
                int mealNumber,
                string mealName,
                string description,
                decimal price)
            {
                MealNumber = mealNumber;
                MealName = mealName;
                Description = description;
                Ingredients = new List<string>();
                Price = price;
            }

            public KomodoCafeMenu() 
            {
                MealNumber = 0;
                MealName = "";
                Description = "";
                Ingredients = new List<string>();
                Price = 0m;
            }
        }
    }
}
