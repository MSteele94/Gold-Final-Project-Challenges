using KomodoInsurance_BadgesPocos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoInsurance_BadgesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddNewBadge()
        {
            BadgesPOCOs content = new BadgesPOCOs();
            BadgesRepo repository = new BadgesRepo();

            bool addResult = repository.AddNewBadge(content);
            Assert.IsTrue(addResult);
        }

        private BadgesPOCOs _content;
        private BadgesRepo _repo;


        [TestInitialize]

        public void Arrange()
        {
            _repo = new BadgesRepo();
            _content = new BadgesPOCOs(12345, new List<DoorAccess> { DoorAccess.A3, DoorAccess.A5 });

            _repo.AddNewBadge(_content);
        }
        [TestMethod]
        public void GetBadgesByKey()
        {
            BadgesPOCOs searchResult = _repo.GetBadgesByKey(1);
            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void UpdateBadge()
        {
            BadgesPOCOs newContent = new BadgesPOCOs(12345, new List<DoorAccess> { DoorAccess.A3, DoorAccess.A5 });
            bool updateResult = _repo.UpdateBadge(1, newContent);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        //passes but unsure if correct
        public void RemovingAllDoors()
        {
            List<DoorAccess> newContent = new List<DoorAccess>( new List<DoorAccess> { DoorAccess.A3, DoorAccess.A5 });
            bool removeResult = _repo.RemovingAllDoors(1, newContent);
            Assert.IsTrue(removeResult);
        }
        [TestMethod]
       
        public void AddingADoor()
        {
            //passes but unsure if correct
            List<DoorAccess> content = new List<DoorAccess>(new List<DoorAccess> { DoorAccess.A3, DoorAccess.A5 });
           

            bool addResult = _repo.AddingDoor(1, content);
            Assert.IsTrue(addResult);
        }
    }
}
