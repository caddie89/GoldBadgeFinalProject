﻿using _03_KomodoInsurance_Repository;
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

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Add New Badge
        private void AddNewBadge()
        {
            Console.Clear();

            Badge newBadge = new Badge();

            Console.WriteLine("Enter the Badge Number:");
            string badgeNumber = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeNumber);

            bool keepAdding = true;
            while (keepAdding)
            {
                keepAdding = false;

                Console.WriteLine($"\nEnter a Door you would like Badge # {newBadge.BadgeID} to have access to (i.e. A1, B5, etc.):");
                string doorInput = Console.ReadLine();
                newBadge.Doors.Add(doorInput);

                Console.WriteLine("\nWould you like this Badge to have access to more Doors (yes/no)?");
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

                        List<string> doors = new List<string>();
                        Console.WriteLine($"Enter the Door(s) that Badge # {newBadge.BadgeID} should have access to (i.e. A1, B5, etc.):\n" +
                            $"(remember to seperate multiple Doors with commas like in example)");
                        string doorToAdd = Console.ReadLine();
                        doors.Add(doorToAdd);

                        _badgeRepo.UpdateBadgeAccess(newBadge.BadgeID, doors);

                        break;
                    case "2":
                        //Remove Door Access
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






            //public void AddDoorsToBadge(int badgeId, List<string> doors)
            //{
            //    Console.WriteLine("Enter a door to add to Badge:");
            //    var userInput = Console.ReadLine();
            //    doors.Add(userInput);

            //    _badgeRepo.UpdateBadgeAccess(badgeId, doors);
            //}


            //if (values.TryGetValue(oldBadgeId, out List<string> result))
            //{
            //    Console.WriteLine($"{oldBadgeId} has access to doors {result}");
            //}



            //AddDoorsToBadge(oldBadgeId, );


            //Dictionary<int, List<string>> listOfBadges = _badgeRepo.UpdateBadgeAccess(oldBadgeId, oldBadge);

            //public int GetBadgeByID(int id)
            //{
            //    foreach (KeyValuePair<int, List<string>> key in _badgeDictionary)
            //    {
            //        if (key.Key == id)
            //        {
            //            return key.Key;
            //        }
            //    }
            //    return 0;
            //}





            //public void UpdateBadgeAccess(int badgeId, List<string> newBadgeAccess)
            //    {
            //        _badgeDictionary[badgeId] = newBadgeAccess;
            //    }

            //foreach (KeyValuePair<int, List<string>> entry in listOfBadges)
            //{
            //}
            //view dictionary item

            //foreach (int badgeId in listOfBadges.Keys)
            //{
            //    Console.WriteLine($"\nBadge ID # {oldBadgeId} has access to doors");
            //}

            //Dictionary<int, List<string>> listOfBadges = _badgeRepo.ShowBadgesAndAccess();
            //Dictionary<int, List<string>> listOfBadges = _badgeRepo.GetBadgeByID(oldBadgeId);

            //oldBadge = _badgeRepo.GetBadgeByID(oldBadgeId);

            //string value;
            //if (myDict.ContainsKey(key))
            //{
            //    value = myDict[key];
            //}
            //else
            //{
            //    Console.WriteLine("Key Not Present");
            //    return;
            //}
        }

        //Add Door to Badge
        public void AddDoorsToBadge(int badgeId, List<string> doors)
        {
            Console.WriteLine("Enter a door to add to Badge:");
            var userInput = Console.ReadLine();
            doors.Add(userInput);

            _badgeRepo.UpdateBadgeAccess(badgeId, doors);
        }

        //Delete Door from Badge

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

            _badgeRepo.AddBadgeToDictionary(badge1.BadgeID, badge1.Doors);
        }
    }
}
