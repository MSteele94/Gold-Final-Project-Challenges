using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuClass
{
    public class MenuPOCOs
    {
        public string MealName { get; set; }
        public int MealNumber { get; set; }
        public string MealDescription { get; set; }
        public List<string> _ingredientsList { get; set; } = new List<string>();
        public double ItemPrice { get; set; }
        public MenuPOCOs(){}
        public MenuPOCOs(string mealName, int mealNumber, string mealDescription, List<string> ingredientsList , double itemPrice)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            MealDescription = mealDescription;
            _ingredientsList = ingredientsList;
            
            ItemPrice = itemPrice;

        }
    }
}
