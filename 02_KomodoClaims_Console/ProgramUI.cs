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
                        //Enter New Claim
                        EnterNewClaim();
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
            PrintRow("ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            PrintSeperatorLine();
            Queue<Claims> viewAllClaims = _claimsRepo.SeeClaimItems();
            foreach (Claims claimInfo in viewAllClaims)
            {
                PrintRow(claimInfo.ClaimID.ToString(), claimInfo.ClaimType.ToString(), claimInfo.ClaimDescription, claimInfo.ClaimAmount.ToString(), claimInfo.DateOfAccident.ToShortDateString(), claimInfo.DateOfClaim.ToShortDateString(), claimInfo.IsValid.ToString());
            }
            PrintSeperatorLine();
        }

        //Next Claim
        private void NextClaim()
        {
            bool keepWorkingOnClaims = true;
            while (keepWorkingOnClaims)
            {
                Console.Clear();

                keepWorkingOnClaims = false;

                Queue<Claims> nextClaimInQueue = _claimsRepo.SeeClaimItems();
                if (nextClaimInQueue.Count == 0)
                {
                    Console.WriteLine("ATTENTION: there are no more Claims left in the Queue.");
                }

                while (nextClaimInQueue.Count > 0)
                {
                    Console.WriteLine($"ClaimID: {nextClaimInQueue.Peek().ClaimID}\n" +
                    $"Type: {nextClaimInQueue.Peek().ClaimType}\n" +
                    $"Description: {nextClaimInQueue.Peek().ClaimDescription}\n" +
                    $"Amount: {nextClaimInQueue.Peek().ClaimAmount}\n" +
                    $"DateOfAccident: {nextClaimInQueue.Peek().DateOfAccident}\n" +
                    $"DateOfClaim: {nextClaimInQueue.Peek().DateOfClaim}\n" +
                    $"IsValid: {nextClaimInQueue.Peek().IsValid}\n");

                    Console.WriteLine("Would you like to deal with this claim now (yes/no)?");
                    string userInput = Console.ReadLine().ToLower();

                    if (userInput == "yes" || userInput == "y")
                    {
                        nextClaimInQueue.Dequeue();
                        keepWorkingOnClaims = true;
                    }
                    else
                    {
                        keepWorkingOnClaims = false;
                        break;
                    }

                    Console.Clear();
                }
            }
        }

        //Enter New Claim
        public void EnterNewClaim()
        {
            Console.Clear();

            Claims newClaim = new Claims();

            //Enter ClaimID
            Console.WriteLine("Enter the Claim ID:");
            var claimId = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimId);

            //Enter Claim Type
            Console.WriteLine("\nEnter the Claim Type (1, 2, or 3):\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            var claimTypeInput = Console.ReadLine();
            var claimTypeInt = int.Parse(claimTypeInput);
            newClaim.ClaimType = (ClaimType)claimTypeInt;

            //Enter Description
            Console.WriteLine("\nEnter Description of Claim:");
            newClaim.ClaimDescription = Console.ReadLine();

            //Enter Claim Amount
            Console.WriteLine("\nEnter Claim Amount:");
            var claimAmount = Console.ReadLine();
            var claimAmountDecimal = decimal.Parse(claimAmount);
            newClaim.ClaimAmount = claimAmountDecimal;

            //Date of Accident
            Console.WriteLine("\nDate of Accident (yyyy, mm, dd):");
            var dateOfAccident = Console.ReadLine();
            var dateOfAccidentDate = DateTime.Parse(dateOfAccident);
            newClaim.DateOfAccident = dateOfAccidentDate;

            //Date of Claim
            Console.WriteLine("\nDate of Claim (yyyy, mm, dd):");
            var dateOfClaim = Console.ReadLine();
            var dateOfClaimDate = DateTime.Parse(dateOfClaim);
            newClaim.DateOfClaim = dateOfClaimDate;

            //IsValid Claim
            Console.WriteLine("\nIs this Claim Valid (yes/no)?");
            var isValidString = Console.ReadLine().ToLower();

            if (isValidString == "yes" || isValidString == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimsRepo.AddClaimToQueue(newClaim);
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

        //Build Table (I do not understand this at all, the video I watched was NOT in English!!!)
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
