using System;
using System.Collections.Generic;
using _02_KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_KomodoClaims_Tests
{
    [TestClass]
    public class KomodoClaimsRepositoryTests
    {
        private Claims _claimsItems;
        private ClaimsRepository _claimsRepo;

        //Didn't Use
        [TestInitialize]
        public void Arrange()
        {
            
        }

        //Add Method
        [TestMethod]
        public void AddClaimToQueue_ShouldNotGetNull()
        {
            //Arrange
            _claimsItems = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            _claimsRepo = new ClaimsRepository();

            //Act
            _claimsRepo.AddClaimToQueue(_claimsItems);

            //Assert
            Assert.IsNotNull(_claimsRepo);
        }

        //Read Method
        [TestMethod]
        public void SeeClaimsItems_ShouldNotGetNull()
        {
            //Arrange
            _claimsRepo = new ClaimsRepository();
            _claimsItems = new Claims();
            _claimsRepo.AddClaimToQueue(_claimsItems);

            //Act
            Queue<Claims> queue = _claimsRepo.SeeClaimItems();

            //Assert
            Assert.IsNotNull(queue);
        }
    }
}
