using System;
using System.Collections.Generic;
using _03_KomodoInsurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_KomodoInsurance_Tests
{
    [TestClass]
    public class KomodoBadgeRepositoryTests
    {
        private BadgeRepository _badgeRepository;

        [TestInitialize]
        public void Arrange()
        {
           
        }

        //Add Badge to Dictionary
        [TestMethod]
        public void AddBadgeToDictionary_IsNotNull()
        {
            //Arrange
            Badge badgeItems = new Badge();
            badgeItems.BadgeID = 1;
            _badgeRepository = new BadgeRepository();
            List<string> doors = new List<string>();
            doors = new List<string> { "A1" };

            //Act
            _badgeRepository.AddBadgeToDictionary(1, doors);

            //Assert
            Assert.IsNotNull(_badgeRepository);

        }

        //Show All Badges and Access
        [TestMethod]
        public void ShowAllBadgesAndAccess_()
        {

        }

        //Update Doors
        [TestMethod]
        public void UpdateDoors_ShouldReturnTrue()
        {


        }

        //Show Badge By ID
        [TestMethod]
        public void ShowBadgeByID_IsNotNull()
        {
            //Arrange
            Badge badgeItems = new Badge();
            badgeItems.BadgeID = 1;
            BadgeRepository badgeRepository = new BadgeRepository();
            List<string> doors = new List<string>();
            doors = new List<string> { "A1" };

            //Act
            badgeRepository.AddBadgeToDictionary(1, doors);
            List<string> badgeItemsList = badgeRepository.ShowBadgeByID(1);

            //Assert
            Assert.IsNotNull(badgeItemsList);
        }
    }
}
