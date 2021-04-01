using KomodoCafeReopositories;
using MenuClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe
{


    public class Program_UI
    {
        private MenuRepo _mealRepo = new MenuRepo();
        public void Run()
        {

            Seed();
            RunMenu();

        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("1. Create Menu Items\n" +
                                  "2. View Menu Items\n" +
                                  "3. Delete Menu Items");


                string userInput = Console.ReadLine();
                switch (userInput)
                {

                    case "1":
                        CreateMenuItems();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        DeleteExistingMenuItem();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        //creates menu items
        public void CreateMenuItems()
        {
            Console.Clear();
            //
            MenuPOCOs menuItem = new MenuPOCOs();


            Console.WriteLine("Creating New Menu items...");

            Console.WriteLine("Input the Meal Name..");
            string userInput = Console.ReadLine();

            menuItem.MealName = userInput;

            Console.WriteLine("Meal Number will auto assign the Meal Number in numerical order.");

            Console.WriteLine("Add a description for the meal.");
            string userInputMealDescription = Console.ReadLine();
            menuItem.MealDescription = userInputMealDescription;

            bool userInputMoreIngredients = false;
            List<string> ingredientsToAdd = new List<string>();
            while (!userInputMoreIngredients)
            {
                Console.WriteLine("Do you want to Add Ingredients to this Item? (y/n)");

                //user input more ingredients
                string userInputMI = Console.ReadLine().ToLower();
                if (userInputMI == "y")
                {
                    Console.WriteLine("Input ingredient: ");
                    string ingredient = Console.ReadLine();
                    

                    ingredientsToAdd.Add(ingredient);

             
                }
                else
                {
                    userInputMoreIngredients = true;
                }
            }
            menuItem._ingredientsList.AddRange(ingredientsToAdd);
            
            // AddIngredients();


            Console.WriteLine("Input the items price.");
            double userInputItemPrice = double.Parse(Console.ReadLine());
            menuItem.ItemPrice = userInputItemPrice;

            bool isSuccessful = _mealRepo.AddMealNumberToMeal(menuItem);
            if (isSuccessful)
            {
                Console.WriteLine("Menu Item Created");
            }
            else
            {
                Console.WriteLine("Menu Item Creation Failed!");
            }
            Console.ReadKey();
        }
        //private void AddIngredients()
        //{
        //    List<string> userInput = new List<string>();
        //    Console.WriteLine("Do you want to put in more ingredients?(y/n)");
        //    string userAddMoreIngredients = Console.ReadLine().ToLower();
        //    if (userAddMoreIngredients == "y")
        //    {
        //        //Console.ReadLine(userInput);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ingredients Added.");
        //    }

        //}
        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<MenuPOCOs> menuPOCOs = _mealRepo.GetMenuItems();
            if (menuPOCOs != null)
            {
                foreach (var menuItem in menuPOCOs)
                {

                    DisplayMenuItemDetails(menuItem);
                }
            }
            else
            {
                Console.WriteLine("No menu items available");
            }


            Console.ReadKey();

        }



        //possibly useful in the README part of this challenge


        //created method that will delete items. ConsoleClear will wipe the console then display the first WriteLine.
        //Calls on the GiveMeMenuItemData helper method, then takes user input of the item number and assigns the menuItemNumber int property to it.
        //bool remove menu item then is set equal to the FIELD "_mealRepo" which uses the . command to call on the "DeleteExistingMenuItems"
        // method from the Menu repository and i pass in the paramaters the menuItemNumber value from the line before 
        //if the user input is the same as an item that already is on the menu it will delete. else it will say failed to remove. 
        private void DeleteExistingMenuItem()
        {
            Console.Clear();
            Console.WriteLine("What Menu Item Would you like to delete?\n" +
                "Please input the items Menu Number\n" +
                "\n" +
                "\n" +
                "");
            GiveMeMenuItemData();
            string userInputMenuItemNumber = Console.ReadLine();
            int menuItemNumber = int.Parse(userInputMenuItemNumber);

            bool removeMenuItem = _mealRepo.DeleteExistingMenuItems(menuItemNumber);
            if (removeMenuItem)
            {
                Console.WriteLine("Menu Item Has Been Removed");
            }
            else
            {
                Console.WriteLine("Item failed to be removed.");
            }
            Console.WriteLine(removeMenuItem);
        }
        private void GiveMeMenuItemData()
        {
            List<MenuPOCOs> menuItemsData = _mealRepo.GetMenuItems();
            foreach (MenuPOCOs menuItem in menuItemsData)
            {
                DisplayMenuItemDetails(menuItem);
            }
        }
        private void DisplayMenuItemDetails(MenuPOCOs menuItem)
        {
            Console.WriteLine($"Meal Name: {menuItem.MealName}\n" +
                              $"Meal Number: {menuItem.MealNumber}\n" +
                              $"Meal Description: {menuItem.MealDescription}");
            ShowIngredients(menuItem._ingredientsList);
            Console.WriteLine($"Item price: {menuItem.ItemPrice}");

        }
        public void ShowIngredients(List<string> listOfIngredients)
        {

            foreach (string ingredient in listOfIngredients)
            {

                Console.WriteLine("Meal Ingredients:" + " " + ingredient);
            }

        }

        private void Seed()
        {
            MenuPOCOs A = new MenuPOCOs("Large Pizza", 1, "Amazing pizza cooked fresh everytime.", new List<string> { "Dough", "Sauce", "Cheese", "Pepperoni" }, 10.99);

            _mealRepo.AddMealNumberToMeal(A);
        }
    }
}
