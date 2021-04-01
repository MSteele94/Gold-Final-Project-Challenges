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
        public string MealDescription { get; set; }
        public List<MenuPOCOs> _ingredientsList = new List<MenuPOCOs>() { };
        public double ItemPrice { get; set; }
        public MenuPOCOs(){}
        public MenuPOCOs(string mealName, string mealDescriotion, List<MenuPOCOs> _ingredientsList , double itemPrice)
        {
            MealName = mealName;
            MealDescription = mealDescriotion;
            
            ItemPrice = itemPrice;

        }
    }
}
