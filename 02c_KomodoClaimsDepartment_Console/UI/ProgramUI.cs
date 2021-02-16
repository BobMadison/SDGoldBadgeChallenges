using _02a_KomodoClaimsDepartment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02c_KomodoClaimsDepartment_Console.UI
{
    public class ProgramUI
    {
        private KomodoClaimsContent _claim1;
        private KomodoClaimsContent _claim2;
        private KomodoClaimsContent _claim3;
        private readonly KomodoClaimsDepartment_Repo _repo = 
            new KomodoClaimsDepartment_Repo();

        public void Run()
        {
            SeedContentList();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            do 
            {
                Console.Clear();
                Console.Write("\n\n Enter the number of the option you'd like to select:\n\n" +
                   " 1. Show all Claims\n" +
                   " 2. Take care of the next claim\n" +
                   " 3. Add a new claim\n\n" +
                   " Enter your choice (anything else to Exit): ");

                string userInput = Console.ReadLine();
                Console.Clear();
                if (userInput != "1" && userInput != "2" && userInput != "3")
                {
                    continueToRun = false;
                }
                else
                {
                    switch (userInput)
                    {
                        case "1":
                            //Console.Clear();
                            DisplayListOfClaims();
                            Pause();
                            break;
                        case "2":
                            //Console.Clear();
                            DisplayListOfClaims();
                            Console.Write($"\nDo you want to deal with the next claim? (y/n) ");
                            userInput = Console.ReadLine();
                            if (userInput == "y") 
                            { 
                                List<KomodoClaimsContent> myList = _repo.GetContents();
                                _repo.DeleteContentByClaimID(myList[0].ClaimID);
                                Console.Clear();
                                DisplayListOfClaims(); 
                            }
                            break;
                        case "3":
                            //Console.Clear();
                            AddAClaim();
                            DisplayListOfClaims();
                            break;
                        default:
                            Console.WriteLine("Something went terribly wrong!");
                            break;
                    }
                   // Pause();
                }
                if (continueToRun) DisplayListOfClaims();

            } while (continueToRun);
        }
        private void Pause()
        {
            Console.Write($"\nPress any key to continue . . . ");
            Console.ReadKey();
        }
        public void AddAClaim()
        {
            Console.Write($"Enter the Claim ID: ");
            int claimID = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n\n Here are your claim types:\n\n" +
                   " 1. Car\n" +
                   " 2. Home\n" +
                   " 3. Theft\n");
            Console.Write($"Enter the type of claim: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            ClaimTypes claimType = new ClaimTypes();
            switch (userInput)
            {
                case 1: claimType = ClaimTypes.Car; break;
                case 2: claimType = ClaimTypes.Home; break;
                case 3: claimType = ClaimTypes.Theft; break;
                default: Console.WriteLine("Something went wrong!"); break;
            }

            Console.Write($"Enter the amount of claim (no dollar sign): ");
            decimal claimAmount = Convert.ToDecimal(Console.ReadLine());

            DateTime dateOfClaim, dateOfAccident;
            string dateInput;
            CultureInfo enUS = new CultureInfo("en-US");

            Console.Write($"Enter the date of the ACCIDENT (format: mm/dd/yyyy): ");
            dateInput = Console.ReadLine();

            DateTime.TryParseExact(
                dateInput,
                "MM/dd/yyyy",
                enUS,
                DateTimeStyles.AllowLeadingWhite,
                out dateOfAccident);

            Console.Write($"Enter the date of the CLAIM (format: mm/dd/yyyy): ");
            dateInput = Console.ReadLine();

            DateTime.TryParseExact(
                dateInput,
                "MM/dd/yyyy",
                enUS,
                DateTimeStyles.AllowLeadingWhite,
                out dateOfClaim);

            Console.Write("Enter a brief description of the incident: ");
            string description = Console.ReadLine();

            KomodoClaimsContent content = new KomodoClaimsContent(
                claimID, 
                claimType, 
                description, 
                claimAmount, 
                dateOfAccident, 
                dateOfClaim);
            _repo.AddContentToDirectory(content);
        }

        public void DisplayListOfClaims()
        {
            List<KomodoClaimsContent> myList = _repo.GetContents();

            Console.WriteLine("\n\n");
            Console.WriteLine($" {"ClaimID",-10}" +
                $"{"Type",-9}" +
                $"{"Description",-28}" +
                $"{"Amount",-12}" +
                $"{"Date of Accident",-21}" +
                $"{"Date Of Claim",-18}" +
                $"{"Is Valid",-8}");
            Console.WriteLine(new String('-', 107));
            Console.WriteLine(new String('-', 107));

            foreach (KomodoClaimsContent content in myList)
            {
                DisplayContent(content);
            }
        }

        public static void DisplayContent(KomodoClaimsContent content)
        {
            Console.WriteLine(
                String.Format(
                    " {0,-7} | {1,-6} | {2, -25} | ${3, 8} | {4, -18} | {5, -15} | {6, -8}",
                content.ClaimID,
                content.ClaimType,
                content.Description,
                content.ClaimAmount,
                content.DateOfIncident.ToShortDateString(),
                content.DateOfClaim.ToShortDateString(),
                content.IsValid));
        }
        public void SeedContentList()
        {
            _claim1 = new KomodoClaimsContent(
                1,
                ClaimTypes.Car,
                "Car accident on 465",
                400.00m,
                new DateTime(2018, 04, 25),
                new DateTime(2018, 04, 27));

            _claim2 = new KomodoClaimsContent(
                2,
                ClaimTypes.Home,
                "House fire in kitchen",
                4000.00m,
                new DateTime(2018, 04, 11),
                new DateTime(2018, 04, 12));

            _claim3 = new KomodoClaimsContent(
                3,
                ClaimTypes.Theft,
                "Stolen pancakes",
                4.00m,
                new DateTime(2018, 04, 27),
                new DateTime(2018, 06, 01));

            _repo.AddContentToDirectory(_claim1);
            _repo.AddContentToDirectory(_claim2);
            _repo.AddContentToDirectory(_claim3);
        }
    }
}
