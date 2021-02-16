using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static KomodoCafe_Repo.KomodoCafeContent;

namespace KomodoCafe_Repo
{
    public class KomodoCafeContent_Repo
    {
        private readonly List<KomodoCafeMenu> _directory = new List<KomodoCafeMenu>();

        public int Count
        {
            get
            {
                return _directory.Count;
            }
        }
        // Next methods Adds to the Menu
        public bool AddContentToDirectory(KomodoCafeMenu content)
        {
            int startingCount = _directory.Count;
            _directory.Add(content);
            return _directory.Count > startingCount;
        }

        // Read from CRUD is next
        public List<KomodoCafeMenu> GetContents()
        {
            return _directory;
        }

        // Get a menu item by either the Menu Number or
        // the Meal Name

        public KomodoCafeMenu GetContentsByMealNumber(int MealNumber)
        {
            foreach (KomodoCafeMenu content in _directory)
            {
                if (MealNumber == content.MealNumber)
                {
                    return content;
                }
            }

            throw new Exception($"{MealNumber} is not a valid Menu Number.");
        }

        public KomodoCafeMenu GetContentsByMealName(string mealName)
        {
            foreach (KomodoCafeMenu content in _directory)
            {
                if (mealName.ToLower() == content.MealName.ToLower())
                {
                    return content;
                }
            }

            throw new Exception($"{mealName} is not a valid Menu Name.");
        }

        // Delete by either meal number or the meal name
        public bool DeleteContentByMealNumber(int mealNumber)
        {
            KomodoCafeMenu contentToDelete = GetContentsByMealNumber(mealNumber);
            return _directory.Remove(contentToDelete);
        }

        public bool DeleteContentByMealName(string mealName)
        {
            KomodoCafeMenu contentToDelete = GetContentsByMealName(mealName);
            return _directory.Remove(contentToDelete);
        }

    }
}
