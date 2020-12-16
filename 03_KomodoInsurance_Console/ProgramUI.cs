using _03_KomodoInsurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsurance_Console
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            SeedBadges();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("Hello Security Admin. Please select an option from the list below (i.e. 1, 2, 3, etc.\n\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Add New Badge
                        AddNewBadge();
                        break;
                    case "2":
                        //Update Badge
                        UpdateBadge();
                        break;
                    case "3":
                        //List All Badges
                        ListAllBadges();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("\nNow exiting application. Keep up the great work!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease select a valid number option from the menu above.");
                        break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Add New Badge
        private void AddNewBadge()
        {
            Console.Clear();

            ListAllBadges();

            Badge newBadge = new Badge();

            Console.WriteLine("Enter a new Badge Number:");
            string badgeNumber = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeNumber);

            bool keepAdding = true;
            while (keepAdding)
            {
                keepAdding = false;

                Console.WriteLine($"\nEnter a Door you would like Badge # {newBadge.BadgeID} to have access to (i.e. A1, B5, etc.):");
                string doorInput = Console.ReadLine();
                newBadge.Doors.Add(doorInput);

                Console.WriteLine($"\nWould you like Badge # {newBadge.BadgeID} to have access to more Doors (yes/no)?");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "yes" || userInput == "y")
                {
                    keepAdding = true;
                }
            }

            _badgeRepo.AddBadgeToDictionary(newBadge.BadgeID, newBadge.Doors);
        }

        //Update Badge
        private void UpdateBadge()
        {
            Console.Clear();

            ListAllBadges();

            Badge newBadge = new Badge();

            Console.WriteLine("Enter the Badge ID # you would like to update (i.e. 12345):");
            string badgeNumber = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeNumber);

            //var values = _badgeRepo.ShowBadgesAndAccess();
            //if (values.TryGetValue(newBadge.BadgeID, out List<string> result))
            //{
            //    Console.WriteLine($"\nBadge # {newBadge.BadgeID} has access to door(s) {string.Join(",", result.ToArray())}.\n\n" +
            //        $"Press ENTER to continue...");
            //}
            //Console.ReadLine();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("Please select an option from the list below (i.e. 1):\n\n" +
                "1. Add Door Access\n" +
                "2. Remove Door Access\n" +
                "3. Return to Main Menu\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Add Door Access
                        Console.Clear();

                        bool keepAdding = true;
                        while (keepAdding)
                        {
                            Console.Clear();
                            keepAdding = false;

                            var values2 = _badgeRepo.ShowBadgesAndAccess();
                            if (values2.TryGetValue(newBadge.BadgeID, out List<string> result2))
                            {
                                Console.WriteLine($"Badge # {newBadge.BadgeID} has access to door(s) {string.Join(",", result2.ToArray())}.\n");
                            }

                            Console.WriteLine($"Enter a Door that Badge # {newBadge.BadgeID} should have access to (i.e. A1, B5, etc.):\n");
                            string doorToAdd = Console.ReadLine();
                            newBadge.Doors.Add(doorToAdd);

                            Console.WriteLine($"\nWould you like Badge # {newBadge.BadgeID} to have access to more Doors (yes/no)?");
                            string yesOrNoInput = Console.ReadLine().ToLower();

                            if (yesOrNoInput == "yes" || yesOrNoInput == "y")
                            {
                                keepAdding = true;
                            }

                            _badgeRepo.UpdateBadgeAccess(newBadge.BadgeID, newBadge.Doors);
                        }

                        _badgeRepo.UpdateBadgeAccess(newBadge.BadgeID, newBadge.Doors);

                        break;
                    case "2":
                        //Remove Door Access
                        Console.Clear();

                        bool keepRemoving = true;
                        while (keepRemoving)
                        {
                            Console.Clear();
                            keepRemoving = false;

                            var values3 = _badgeRepo.ShowBadgesAndAccess();
                            if (values3.TryGetValue(newBadge.BadgeID, out List<string> result3))
                            {
                                Console.WriteLine($"Badge # {newBadge.BadgeID} has access to door(s) {string.Join(",", result3.ToArray())}.\n");
                            }

                            Console.WriteLine($"Enter a Door to remove from Badge # {newBadge.BadgeID} (i.e. A1, B5, etc.):");
                            string doorToRemove = Console.ReadLine();
                            newBadge.Doors.Remove(doorToRemove);
                                
                            //newBadge.Doors.Remove(doorToRemove);
                            

                            //bool wasDeleted = _badgeRepo.UpdateBadgeAccess(newBadge.BadgeID, newBadge.Doors);
                            //if (wasDeleted)
                            //{
                            //    Console.WriteLine("\nThe Door was successfully removed from Badge.");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("\nThe Door could not be removed from Badge.");
                            //}

                            Console.WriteLine($"\nWould you like to remove another Door from Badge # {newBadge.BadgeID} (yes/no)?");
                            string yesOrNoInput = Console.ReadLine().ToLower();

                            if (yesOrNoInput == "yes" || yesOrNoInput == "y")
                            {
                                keepRemoving = true;
                            }

                            _badgeRepo.UpdateBadgeAccess(newBadge.BadgeID, newBadge.Doors);
                        }

                        _badgeRepo.UpdateBadgeAccess(newBadge.BadgeID, newBadge.Doors);

                        break;
                    case "3":
                        //Return to Main Menu
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease select a valid number option from the menu above. Press any key to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        //Add Door to Badge
        //public void AddDoorsToBadge(int badgeId, List<string> doors)
        //{
        //    Console.WriteLine("Enter a door to add to Badge:");
        //    var userInput = Console.ReadLine();
        //    doors.Add(userInput);

        //    _badgeRepo.UpdateBadgeAccess(badgeId, doors);
        //}

        //List All Badges
        private void ListAllBadges()
        {
            Console.Clear();

            Console.WriteLine("List of all Badges:\n");
            Dictionary<int, List<string>> listOfBadges = _badgeRepo.ShowBadgesAndAccess();
            foreach (KeyValuePair<int, List<string>> badgeInfo in listOfBadges)
            {
                Console.WriteLine($"Badge ID: {badgeInfo.Key}\n" +
                    $"Door Access: {string.Join(",", badgeInfo.Value.ToArray())}\n");
            }
        }

        //Seed Badges
        private void SeedBadges()
        {
            Badge badge1 = new Badge(12345, new List<string> { "A7" });
            Badge badge2 = new Badge(22345, new List<string> { "A1," + "A4," + "B1," + "B2" });

            _badgeRepo.AddBadgeToDictionary(badge1.BadgeID, badge1.Doors);
            _badgeRepo.AddBadgeToDictionary(badge2.BadgeID, badge2.Doors);
        }
    }
}
