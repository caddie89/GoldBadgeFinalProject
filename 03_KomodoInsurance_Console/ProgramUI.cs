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
                        ListAllBadgesTable();
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
            Console.WriteLine("Enter a unique 5-digit Badge # (i.e. 12345):");
            string badgeNumber = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeNumber);

            var values5 = _badgeRepo.ShowBadgesAndAccess();
            if (values5.TryGetValue(newBadge.BadgeID, out List<string> doors5))
            {
                Console.WriteLine($"\nBadge # {newBadge.BadgeID} already exists. Return to Menu and try again.");
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
                Console.Clear();
                Menu();
            }

            bool keepAdding = true;
            while (keepAdding)
            {
                Console.Clear();
                keepAdding = false;

                Console.WriteLine($"Enter a Door you would like Badge # {newBadge.BadgeID} to have access to (i.e. A1, B5, etc.):");
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

            var values = _badgeRepo.ShowBadgesAndAccess();
            if (values.TryGetValue(newBadge.BadgeID, out List<string> doors))
            {
                Console.WriteLine($"\nBadge # {newBadge.BadgeID} has access to door(s) {string.Join(",", doors.ToArray())}.");
            }
        }

        //Update Badge
        private void UpdateBadge()
        {
            Console.Clear();

            ListAllBadges();

            Console.WriteLine("Enter the Badge ID # you would like to update (i.e. 12345):");
            string badgeNumber = Console.ReadLine();
            int badgeId = int.Parse(badgeNumber);

            List<string> newDoors = _badgeRepo.ShowBadgeByID(badgeId);

            var values = _badgeRepo.ShowBadgesAndAccess();
            if (values.TryGetValue(badgeId, out List<string> doors))
            {
                Console.WriteLine($"\nBadge # {badgeId} has access to door(s) {string.Join(",", doors.ToArray())}.\n");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"\nBadge # {badgeId} does not exist.\n");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                UpdateBadge();
            }

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("Select an option from the list below (i.e. 1):\n\n" +
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
                            if (values2.TryGetValue(badgeId, out List<string> doors1))
                            {
                                Console.WriteLine($"Badge # {badgeId} has access to door(s) {string.Join(",", doors1.ToArray())}.\n");
                            }

                            Console.WriteLine($"Enter a Door that Badge # {badgeId} should have access to (i.e. A1, B5, etc.):");
                            string doorToAdd = Console.ReadLine();
                            newDoors.Add(doorToAdd);

                            Console.WriteLine($"\nWould you like Badge # {badgeId} to have access to more Doors (yes/no)?");
                            string yesOrNoInput = Console.ReadLine().ToLower();

                            if (yesOrNoInput == "yes" || yesOrNoInput == "y")
                            {
                                keepAdding = true;
                            }

                            _badgeRepo.UpdateBadgeAccess(badgeId, newDoors);
                        }
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
                            if (values3.TryGetValue(badgeId, out List<string> doors2))
                            {
                                Console.WriteLine($"Badge # {badgeId} has access to door(s) {string.Join(",", doors2.ToArray())}.\n");
                            }

                            Console.WriteLine($"Enter a Door to remove from Badge # {badgeId} (i.e. A1, B5, etc.):");
                            string doorToRemove = Console.ReadLine();
                            newDoors.Remove(doorToRemove);

                            var values4 = _badgeRepo.ShowBadgesAndAccess();
                            if (values4.TryGetValue(badgeId, out List<string> doors3))
                            {
                                Console.WriteLine($"\nDoor {doorToRemove} has been deleted.\n\n" +
                                    $"Badge # {badgeId} now has access to door(s) {string.Join(",", doors3.ToArray())}.\n");
                            }

                            Console.WriteLine($"\nWould you like to remove another Door from Badge # {badgeId} (yes/no)?");
                            string yesOrNoInput = Console.ReadLine().ToLower();

                            if (yesOrNoInput == "yes" || yesOrNoInput == "y")
                            {
                                keepRemoving = true;
                            }

                            _badgeRepo.UpdateBadgeAccess(badgeId, newDoors);
                        }
                        break;
                    case "3":
                        //Return to Main Menu
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease select a valid number option from the menu above.\n\n" +
                            "Press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

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

        //List All Badges Table
        private void ListAllBadgesTable()
        {
            Console.Clear();

            Console.WriteLine("List of all Badges:");

            PrintSeperatorLine();
            PrintRow("Badge", "Door Access");
            PrintSeperatorLine();
            Dictionary<int, List<string>> listOfBadges = _badgeRepo.ShowBadgesAndAccess();
            foreach (KeyValuePair<int, List<string>> badgeInfo in listOfBadges)
            {
                PrintRow(badgeInfo.Key.ToString(), string.Join(",", badgeInfo.Value.ToArray()));
            }
            PrintSeperatorLine();
        }

        //Seed Badges
        private void SeedBadges()
        {
            Badge badge1 = new Badge(12345, new List<string> { "A7" });
            Badge badge2 = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge badge3 = new Badge(32345, new List<string> { "A4", "A5" });

            _badgeRepo.AddBadgeToDictionary(badge1.BadgeID, badge1.Doors);
            _badgeRepo.AddBadgeToDictionary(badge2.BadgeID, badge2.Doors);
            _badgeRepo.AddBadgeToDictionary(badge3.BadgeID, badge3.Doors);
        }

        //Table Code (I do not understand this!)
        private const int TableWidth = 40;
        private static void PrintSeperatorLine()
        {
            Console.WriteLine(new string(' ', TableWidth));
        }
        private static void PrintRow(params string[] columns)
        {
            int columnWidth = (TableWidth - columns.Length) / columns.Length;

            const string seed = " ";

            string row = columns.Aggregate(seed, (seperator, columnText) => seperator + GetRightAlignedText(columnText, columnWidth) + seed);

            Console.WriteLine(row);
        }
        private static string GetRightAlignedText(string columnText, int columnWidth)
        {
            columnText = columnText.Length > columnWidth ? columnText.Substring(0, columnWidth - 3) + "..." : columnText;

            return string.IsNullOrEmpty(columnText)
                ? new string(' ', columnWidth)
                : columnText.PadRight(columnWidth - ((columnWidth - columnText.Length) / 2)).PadRight(columnWidth);
        }
    }
}
