using MenuClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeReopositories
{
    public class MenuRepo
    {
        int _count = 0;

        protected readonly List<MenuPOCOs> _mealDirectory = new List<MenuPOCOs>();
        public bool AddMealNumberToMeal(MenuPOCOs mealNumber)
        {
            _count++;
            mealNumber.MealNumber = _count;
            _mealDirectory.Add(mealNumber);

            return true;
        }
        public List<MenuPOCOs> GetMenuItems()
        {
            return _mealDirectory;
        }
        public MenuPOCOs GetMealByID(int mealNumber)
        {
            foreach (MenuPOCOs content in _mealDirectory)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }
            return null;
        }
        public bool DeleteExistingMenuItems(int mealNumber)
        {
            foreach (MenuPOCOs meal in _mealDirectory)
            {
                if (meal.MealNumber == mealNumber)
                {
                    _mealDirectory.Remove(meal);
                    return true;
                }
            }
            return false;
        }
    }
}
