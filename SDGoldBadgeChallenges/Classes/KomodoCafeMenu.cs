using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDGoldBadgeChallenges.Classes
{
    public class KomodoCafeMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }

        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        // Constructor
        public KomodoCafeMenu (
            int mealNumber,
            string mealName,
            string description,
            decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
        }
    }
}
