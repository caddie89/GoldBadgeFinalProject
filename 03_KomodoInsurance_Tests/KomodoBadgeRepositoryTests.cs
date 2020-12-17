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

        //Add Badge to Dictionary
        [TestMethod]
        public void TestAddBadgeToDictionary()
        {
            //Arrange
            Badge badgeItems = new Badge();
            BadgeRepository badgeRepo = new BadgeRepository();
            badgeItems.BadgeID = 12345;
            string doorInput = "A6";
            badgeItems.Doors.Add(doorInput);

            //Act
            badgeRepo.AddBadgeToDictionary(badgeItems.BadgeID, badgeItems.Doors);

            //Assert
            Dictionary<int, List<string>> dictionary = badgeRepo.ShowBadgesAndAccess();

            bool IsEqual = false;

            foreach (KeyValuePair<int, List<string>> pair in dictionary)
            {
                if (pair.Key == badgeItems.BadgeID && pair.Value == badgeItems.Doors)
                {
                    IsEqual = true;
                }
            }
            Assert.IsTrue(IsEqual);
        }

        //Show All Badges and Access
        [TestMethod]
        public void ShowAllBadgesAndAccess_IsNotNull()
        {
            //Arrange
            _badgeRepository = new BadgeRepository();
            List<string> newList = new List<string>();
            newList = new List<string> { "A7", "A8" };
            _badgeRepository.UpdateBadgeAccess(12346, newList);

            //Act
            Dictionary<int, List<string>> dictionary = _badgeRepository.ShowBadgesAndAccess();

            //Assert
            Assert.IsNotNull(dictionary);
        }

        //Update Doors
        //[TestMethod]
        //public void UpdateDoors_IsNotNull()
        //{
        //    //Arrange
        //    Badge badgeItems = new Badge();
        //    BadgeRepository badgeRepo = new BadgeRepository();
        //    int badgeId = 12345;
        //    List<string> newDoors = badgeRepo.ShowBadgeByID(badgeId);
        //    string doorToAdd = "A4";
        //    newDoors.Add(doorToAdd);

        //    //Act
        //    _badgeRepository.UpdateBadgeAccess(12346, newList);

        //    //Assert
        //    Assert.IsNotNull(_badgeRepository);
        //}

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
            badgeRepository.AddBadgeToDictionary(1, doors);

            //Act
            List<string> badgeItemsList = badgeRepository.ShowBadgeByID(1);

            //Assert
            Assert.IsNotNull(badgeItemsList);
        }
    }
}
