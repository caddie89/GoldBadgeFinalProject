using _02_KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Console
{
    class ProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();

        public void Run()
        {
            SeedClaimsToQueue();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Please select an option from the menu below (i.e. 1, 2, 3, etc.):\n\n" +
                    "1. View All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //View All Claims
                        ViewAllClaims();
                        break;
                    case "2":
                        //Next Claim
                        NextClaim();
                        break;
                    case "3":
                        //Enter a New Claim

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

        //View All Claims
        private void ViewAllClaims()
        {
            Console.Clear();

            Console.WriteLine("View All Claims:\n");

            PrintSeperatorLine();
            PrintRow("Claim ID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            PrintSeperatorLine();
            Queue<Claims> viewAllClaims = _claimsRepo.SeeClaimThings();
            foreach (Claims claimInfo in viewAllClaims)
            {
                PrintRow(claimInfo.ClaimID.ToString(), claimInfo.ClaimType.ToString(), claimInfo.ClaimDescription, claimInfo.ClaimAmount.ToString(), claimInfo.DateOfIncident.ToString(), claimInfo.DateOfClaim.ToString(), claimInfo.IsValid.ToString());
            }
            PrintSeperatorLine();
        }

        //Next Claim
        private void NextClaim()
        {
            Console.Clear();

            Queue<Claims> nextClaimInQueue = _claimsRepo.SeeClaimThings();
            Console.WriteLine(nextClaimInQueue.Peek().ClaimID);

            //Console.WriteLine($"\nClaim ID: {claimInfo.ClaimID}\n" +
            //$"Type: {claimInfo.ClaimType}\n" +
            //$"Description: {claimInfo.ClaimDescription}\n" +
            //$"Amount: {claimInfo.ClaimAmount}\n" +
            //$"DateOfAccident: {claimInfo.DateOfIncident}\n" +
            //$"DateOfClaim: {claimInfo.DateOfClaim}\n" +
            //$"IsValid: {claimInfo.IsValid}")

            //Console.WriteLine($"This is the next Claim in Queue:\n\n" +
            //    $"{nextClaimInQueue.Peek()}");



            //List<Claims> nextClaimInQueue = _claimsRepo.SeeClaimItems();
            //foreach (Claims claimInfo in nextClaimInQueue)

        }

        //Seed Method
        private void SeedClaimsToQueue()
        {
            var claim1 = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            var claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            var claim3 = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _claimsRepo.AddClaimToQueue(claim1);
            _claimsRepo.AddClaimToQueue(claim2);
            _claimsRepo.AddClaimToQueue(claim3);
        }

        //Build Table
        private const int TableWidth = 110;
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
