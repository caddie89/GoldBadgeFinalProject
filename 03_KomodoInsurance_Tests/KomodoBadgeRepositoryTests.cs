using System;
using System.Collections.Generic;
using _03_KomodoInsurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_KomodoInsurance_Tests
{
    [TestClass]
    public class KomodoBadgeRepositoryTests
    {
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
        public void TestForShowBadgesAndAccessIsNotNull()
        {
            //Arrange
            Badge badgeItems = new Badge();
            BadgeRepository badgeRepo = new BadgeRepository();
            badgeItems.BadgeID = 12345;
            string doorInput = "A6";
            badgeItems.Doors.Add(doorInput);
            
            badgeRepo.AddBadgeToDictionary(badgeItems.BadgeID, badgeItems.Doors);

            //Act
            Dictionary<int, List<string>> dictionary = badgeRepo.ShowBadgesAndAccess();

            //Assert
            Assert.IsNotNull(dictionary);
        }

        //Update Doors
        [TestMethod]
        public void TestToUpdateBadgeAccess()
        {
            //Arrange
            BadgeRepository badgeRepo = new BadgeRepository();
            int badgeId = 12345;
            List<string> newDoors = badgeRepo.ShowBadgeByID(badgeId);

            //Act
            badgeRepo.UpdateBadgeAccess(badgeId, newDoors);

            //Assert
            Dictionary<int, List<string>> dictionary = badgeRepo.ShowBadgesAndAccess();

            bool IsEqual = false;

            foreach (KeyValuePair<int, List<string>> pair in dictionary)
            {
                if (pair.Key == badgeId && pair.Value == newDoors)
                {
                    IsEqual = true;
                }
            }
            Assert.IsTrue(IsEqual);
        }

        //Show Badge By ID
        [TestMethod]
        public void TestForShowBadgeByID()
        {
            //Arrange
            Badge badgeItems = new Badge();
            BadgeRepository badgeRepo = new BadgeRepository();
            badgeItems.BadgeID = 12345;
            string doorInput = "A6";
            badgeItems.Doors.Add(doorInput);
            int badgeId = 12345;

            badgeRepo.AddBadgeToDictionary(badgeItems.BadgeID, badgeItems.Doors);

            //Act
            List<string> newDoors = new List<string>();
            newDoors = badgeRepo.ShowBadgeByID(badgeId);

            //Assert
            Assert.AreEqual(badgeItems.Doors, newDoors);
        }
    }
}
