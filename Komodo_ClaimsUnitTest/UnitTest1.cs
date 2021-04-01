using KomodoClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_ClaimsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddClaimToQueue()
        {
            ClaimsPOCOs content = new ClaimsPOCOs();
            KomodoClaimsRepo repository = new KomodoClaimsRepo();

            bool addResult = repository.AddClaimToQueue(content);

            Assert.IsTrue(addResult);
        }


        private ClaimsPOCOs _content;
        private KomodoClaimsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoClaimsRepo();

            _content = new ClaimsPOCOs (1, "Car Accident on 465", 400, ClaimType.Car, DateTime.Parse("4/25/18"), DateTime.Parse("4/27/18"));

            _repo.AddClaimToQueue(_content);
        }
        [TestMethod]
        public void GetClaimById()
        {
            ClaimsPOCOs searchResult = _repo.GetClaimByID(1);

            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void GrabClaimFromQueue()
        {
            ClaimsPOCOs content = _repo.GetClaimByID(1);

            bool removeResult = _repo.GrabClaimFromQueue();
            Assert.IsTrue(removeResult);
        }
    }

}
