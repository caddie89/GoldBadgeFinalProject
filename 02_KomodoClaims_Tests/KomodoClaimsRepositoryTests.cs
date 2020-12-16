using System;
using _02_KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_KomodoClaims_Tests
{
    [TestClass]
    public class KomodoClaimsRepositoryTests
    {
        private Claims _claimsItems;
        private ClaimsRepository _claimsRepo;

        //Test Initialize
        [TestInitialize]
        public void Arrange()
        {
            _claimsRepo = new ClaimsRepository();
            _claimsItems = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);

            _claimsRepo.AddClaimToQueue(_claimsItems);
        }

        //Add Method
        [TestMethod]
        public void AddClaimToQueue_ShouldNotGetNull()
        {
            //Arrange --> Seetting up the playing field
            Arrange();

            //Act --> Get/run the code we want to test
            _claimsRepo.AddClaimToQueue(_claimsItems);

            //Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(_claimsItems);
        }

        //Read Method
        [TestMethod]
        public void SeeClaimsItems_ShouldNotGetNull()
        {
            //Arrange
            Arrange();

            //Act
            _claimsRepo.SeeClaimItems();

            //Assert

        }
    }
}
