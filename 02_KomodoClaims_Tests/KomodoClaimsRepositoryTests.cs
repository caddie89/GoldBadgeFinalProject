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

        //Add Claim To Queue
        [TestMethod]
        public void TestForAddingClaimsToQueue_Self()
        {
            //Arrange
            _claimsItems = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            _claimsRepo = new ClaimsRepository();

            //Act
            _claimsRepo.AddClaimToQueue(_claimsItems);

            //Assert
            Queue<Claims> claimsDirectory = _claimsRepo.SeeClaimItems();

            bool amountIsEqual = false;

            foreach (Claims claimsItem in claimsDirectory)
            {
                if (claimsItem.ClaimAmount == _claimsItems.ClaimAmount)
                {
                    amountIsEqual = true;
                    break;
                }
            }
            Assert.IsTrue(amountIsEqual);
        }

        //This checks same method as above
        [TestMethod]
        public void TestForAddingClaimsToQueue_Class()
        {
            //Arrange
            _claimsItems = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            _claimsRepo = new ClaimsRepository();

            //Act
            _claimsRepo.AddClaimToQueue(_claimsItems);

            //Assert
            Claims copyOfClaimFromList = new Claims();
            Queue<Claims> claimsDirectory = _claimsRepo.SeeClaimItems();

            foreach (Claims claim in claimsDirectory)
            {
                if (claim.ClaimType == _claimsItems.ClaimType)
                {
                    copyOfClaimFromList = claim;
                    break;
                }
            }
            Assert.AreEqual(_claimsItems.ClaimType, copyOfClaimFromList.ClaimType);
        }

        //See All Claims
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
