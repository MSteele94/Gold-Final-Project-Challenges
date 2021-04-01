using KomodoCafeReopositories;
using MenuClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeUnitTest
{
    [TestClass]
    public class MenuTestClass
    {
        [TestMethod]
        public void AddMealNumberToMeal_ShouldGetCorrectBoolean()
        {
            MenuPOCOs menu = new MenuPOCOs();
            MenuRepo repository = new MenuRepo();

            bool addResult = repository.AddMealNumberToMeal(menu);
            Assert.IsTrue(addResult);
            Console.WriteLine(addResult);


        }
        private MenuPOCOs _items;
        private MenuRepo _repoItems;

        [TestInitialize]
        public void Arrange()
        {
            _repoItems = new MenuRepo();
            _items = new MenuPOCOs("CheeseBurger", 1, "Juicy Cheeseburger", new List<string> { "Bun", "Beef patty", "Cheese", "Tomato","Pickle","Onion"}, 7.98);

            _repoItems.AddMealNumberToMeal(_items);
        }
        //need help

        //[TestMethod]
        //public void GetMenuItems_ShouldReturnCorrectResult()
        //{
        //    MenuPOCOs searchResult = 
        //}
        [TestMethod]

        //created this method to help with the delete method so had to test it. Get By ID is unused in the code besides the testM. Other ways to do this??

        public void GetMealByID()
        {
            MenuPOCOs searchResult = _repoItems.GetMealByID(1);

            Assert.AreEqual(_items, searchResult);
        }

        [TestMethod]
        public void DeleteExistingMenuItems_ShouldReturnCorrectBoolean()
        {
            MenuPOCOs meal = _repoItems.GetMealByID(1);

            bool removeResult = _repoItems.DeleteExistingMenuItems(1);

            Assert.IsTrue(removeResult);


        }
    }
}
