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

                Console.WriteLine("\nEnter a Door you would like this Badge to have access to (i.e. A1, B5, etc.):");
                string doorInput = Console.ReadLine();
                newBadge.Doors.Add(doorInput);

                Console.WriteLine("\nWould you like this Badge to have access to more Doors (yes/no)?");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "yes" || userInput == "y")
                {
                    keepAdding = true;
                }
            }

            //_badgeRepo.AddDoorsToBadge(newBadge.BadgeID, newBadge.Doors);

            _badgeRepo.AddBadgeToDictionary(newBadge.BadgeID, newBadge); //Help!
        }

        //List All Badges
        private void ListAllBadges()
        {
            Console.Clear();

            Console.WriteLine("List of all Badges:\n");
            Dictionary<int, Badge> listOfBadges = _badgeRepo.ShowBadgesAndAccess();
            foreach (KeyValuePair<int, Badge> badgeInfo in listOfBadges)
            {
                Console.WriteLine($"Badge ID: {badgeInfo.Key}\n" +
                    $"Door Access: {badgeInfo.Value}");
            }
        }
    }
}
