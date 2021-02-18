
using _04a_KomodoOutings_Repo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04c_KomodoOutings_Console.UI
{
    public class ProgramUI
    {
        private KomodoOutingsContent _event1;
        private KomodoOutingsContent _event2;
        private KomodoOutingsContent _event3;
        private KomodoOutingsContent _event4;
        private KomodoOutingsContent _event5;
        private KomodoOutingsContent _event6;
        private KomodoOutingsContent _event7;
        private KomodoOutingsContent _event8;
        private KomodoOutingsContent _event9;
        private KomodoOutingsContent _event10;
        private KomodoOutingsContent _event11;
        private KomodoOutingsContent _event12;
        private KomodoOutingsContent _event13;
        private KomodoOutingsContent _event14;
        private KomodoOutingsContent _event15;
        private KomodoOutingsContent _event16;
        private KomodoOutingsContent _event17;
        private KomodoOutingsContent _event18;
        private KomodoOutingsContent _event19;
        private KomodoOutingsContent _event20;
        private readonly KomodoOutingsContent_Repo _repo =
            new KomodoOutingsContent_Repo();

        public void Run()
        {
            SetUpList();
            RunTheMenu();
        }

        public void RunTheMenu()
        {
            bool continueToRun = true;
            do
            { 
                string userInput = GetChoiceFromMenu();
                Console.Clear();

                if (userInput == "7")
                {
                    continueToRun = false;
                }
                else
                {
                    switch (userInput)
                    {
                        case "1":
                            //Console.Clear();
                            DisplayListOfOutings();
                            //  Pause();
                            break;
                        case "2":
                            //Console.Clear();
                            DisplayOuting(EventType.Golf);
                            break;
                        case "3":
                            DisplayOuting(EventType.Bowling);
                            break;
                        case "4":
                            //Console.Clear();
                            DisplayOuting(EventType.AmusementPark);
                            break;
                        case "5":
                            DisplayOuting(EventType.Concert);
                            break;
                        case "6":
                            AddAnEvent();
                            DisplayListOfOutings();
                            break;
                        default:
                            Console.WriteLine("Something went terribly wrong!");
                            break;
                    }
                    Pause();
                }
                if (continueToRun) DisplayListOfOutings();

            } while (continueToRun);
        }

        public string GetChoiceFromMenu()
        {
            string userInput = "";
            bool badChoice = true;

            do
            {
                Console.Clear();
                Console.Write("\n\n Enter the number of the option you'd like to select:\n\n" +
                   " 1. Show all Events\n" +
                   " 2. Show Golf Outing Totals\n" +
                   " 3. Show Bowling Outing Totals\n" +
                   " 4. Show Amusement Park Totals\n" +
                   " 5. Show Concert Totals\n" +
                   " 6. Add an Event\n" +
                   " 7. To Exit Program: ");
                userInput = Console.ReadLine();
                badChoice = userInput != "1" && userInput != "2" && 
                            userInput != "3" && userInput != "4" &&
                            userInput != "5" && userInput != "6" && 
                            userInput != "7";
                if(badChoice)
                {
                    Console.WriteLine($"\n {userInput} is not valid. Please try again.");
                    Pause();
                }
            } while (badChoice);

            // Console.Clear();


            return userInput;
        }
        public void AddAnEvent()
        {
            Console.WriteLine("\n\n Here are your events:\n\n" +
                   " 1. Golf\n" +
                   " 2. Bowling\n" +
                   " 3. Amusement Park\n" +
                   " 4. Concert\n");
            Console.Write($"Enter the event number: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            EventType eventType = new EventType();

            switch (userInput)
            {
                case 1: eventType = EventType.Golf; break;
                case 2: eventType = EventType.Bowling; break;
                case 3: eventType = EventType.AmusementPark; break;
                case 4: eventType = EventType.Concert; break;
                default: Console.WriteLine("Something went wrong!"); break;
            }

            Console.Write($"How many attended? ");
            int numberOfPeople = Convert.ToInt32(Console.ReadLine());

            DateTime dateOfEvent = GetDateTime();

            Console.Write($"What was the cost per individual? ");
            decimal costOfEvent = Convert.ToDecimal(Console.ReadLine());

            KomodoOutingsContent content = new KomodoOutingsContent(
                eventType,
                numberOfPeople,
                dateOfEvent,
                costOfEvent);
            _repo.AddContentToDirectory(content);
        }

        public DateTime GetDateTime()
        {
            string dateInput;
            DateTime dateNeeded;
            CultureInfo enUS = new CultureInfo("en-US");
            bool badEntry = true;

            do
            {
                Console.Write($"\nEnter the event date (format: mm/dd/yyyy): ");
                dateInput = Console.ReadLine();

                if (DateTime.TryParseExact(
                    dateInput,
                    "MM/dd/yyyy",
                    enUS,
                    DateTimeStyles.AllowLeadingWhite,
                    out dateNeeded))
                {
                    badEntry = false;
                }
                else
                {
                    Console.WriteLine("\n Bad date format. Please try again.");
                    Pause();
                    Console.WriteLine();
                }
            } while (badEntry);
            return dateNeeded;
        }

        private void Pause()
        {
            Console.Write($"\nPress any key to continue . . . ");
            Console.ReadKey();
        }

        public void DisplayOuting(EventType choice)
        {
            List<KomodoOutingsContent> myList = _repo.GetContents();

            HeadingLines();

            int numberOfPeople = 0;
            decimal totalForAllEvents = 0m;
            foreach (KomodoOutingsContent content in myList)
            {
                if (content.OutingEvent == choice)
                {
                    DisplayContent(content);
                    numberOfPeople += content.NumberAttending;
                    totalForAllEvents += content.TotalCostForEvent;
                }
            }
            if (numberOfPeople > 0)
                DisplayTotals(numberOfPeople, totalForAllEvents);
            else
                Console.WriteLine("\n\n   No one atteneded.\n\n");
        }
        public void DisplayListOfOutings()
        {
            List<KomodoOutingsContent> myList = _repo.GetContents();

            HeadingLines();

            int numberOfPeople = 0;
            decimal totalForAllEvents = 0m;
            foreach (KomodoOutingsContent content in myList)
            {
                DisplayContent(content);
                numberOfPeople += content.NumberAttending;
                totalForAllEvents += content.TotalCostForEvent;
            }
            DisplayTotals(numberOfPeople, totalForAllEvents);
        }
        public void DisplayContent(KomodoOutingsContent content)
        {
            if (content.TotalCostForEvent < 1000m)
            {
                Console.WriteLine(
                    String.Format(
                        " {0, -15} | {1, 6}    |{2, 11} | ${3, 6} | ${4, 11}",
                        content.OutingEvent,
                        content.NumberAttending,
                        content.DateOfEvent.ToShortDateString(),
                        content.CostPerPerson,
                        content.TotalCostForEvent));
            }
            else
            {
                Console.Write(
                   String.Format(
                       " {0, -15} | {1, 6}    |{2, 11} | ${3, 6} | $",
                       content.OutingEvent,
                       content.NumberAttending,
                       content.DateOfEvent.ToShortDateString(),
                       content.CostPerPerson));
                CommaTotal(content.TotalCostForEvent);
            }
        }

        public void HeadingLines()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine($"{" Outing",-17}" +
                $"{" # Attended",-17}" +
                $"{" Date",-8}" +
                $"{" Cost per",-10}" +
                $"{" Total Cost",14}");
            Console.WriteLine($"{"person",50}");
            Console.WriteLine(new String('-', 66));
            Console.WriteLine(new String('-', 66));
        }

        public void DisplayTotals(int people, decimal total)
        {
            if (total < 1000.00m)
            {
                Console.WriteLine(String.Format("\n\n  {0, -12} {1, 7} {2,  8} {3, 7}",
                "Total Attended: ", people, "Total: $", total));
            }
            else
            {
                Console.Write(String.Format("\n\n  {0, -12} {1, 7} {2,  8} ",
                "Total Attended: ", people, "Total: $"));
                CommaTotal(total);
            }

        }

        public void CommaTotal(decimal total) // 1067.03 - 1267 
        {
            decimal centsValue = (total - Math.Floor(total)) * 100; // 3.00
            //Console.WriteLine($"This is the cents portion: {centsValue}");
            int thousandsValue = Convert.ToInt32(total) / 1000; // 1
            int hundredsValue = Convert.ToInt32(total) % 1000; // 67
            int newCentsValue = Convert.ToInt32(centsValue);  // 3
            string cents = newCentsValue.ToString(); // "3"

            if (newCentsValue < 10)
            {
                cents = "0" + newCentsValue; // "03"
            }

            if (hundredsValue >= 100)
            {
                Console.WriteLine(String.Format(" {0, 3},{1,3}.{2,2}",
                    thousandsValue, hundredsValue, cents));
            }
            else
            {
                Console.WriteLine(String.Format(" {0, 3},0{1,2}.{2,2}",
                    thousandsValue, hundredsValue, cents));
            }

        }
        public void SetUpList()
        {
            //  _repo = new KomodoOutingsContent_Repo();

            _event1 = new KomodoOutingsContent(
                EventType.AmusementPark,
                75,
                new DateTime(2020, 06, 26),
                5.95m);

            _event2 = new KomodoOutingsContent(
                EventType.Bowling,
                33,
                new DateTime(2020, 08, 08),
                7.50m);

            _event3 = new KomodoOutingsContent(
                EventType.Concert,
                250,
                new DateTime(2020, 09, 16),
                11.95m);

            _event4 = new KomodoOutingsContent(
                EventType.Golf,
                111,
                new DateTime(2020, 05, 09),
                21.75m);

            _event5 = new KomodoOutingsContent(
               EventType.AmusementPark,
               81,
               new DateTime(2020, 09, 22),
               6.95m);

            _event6 = new KomodoOutingsContent(
                EventType.Bowling,
                17,
                new DateTime(2020, 08, 15),
                7.50m);

            _event7 = new KomodoOutingsContent(
                EventType.Concert,
                175,
                new DateTime(2020, 10, 08),
                10.95m);

            _event8 = new KomodoOutingsContent(
                EventType.Golf,
                127,
                new DateTime(2020, 11, 21),
                19.75m);

            _event9 = new KomodoOutingsContent(
                EventType.Bowling,
                17,
                new DateTime(2020, 08, 22),
                7.50m);

            _event10 = new KomodoOutingsContent(
                EventType.Concert,
                151,
                new DateTime(2020, 11, 29),
                14.95m);

            _event11 = new KomodoOutingsContent(
                EventType.Golf,
                87,
                new DateTime(2020, 12, 15),
                15.75m);

            _event12 = new KomodoOutingsContent(
               EventType.AmusementPark,
               67,
               new DateTime(2020, 10, 31),
               5.95m);

            _event13 = new KomodoOutingsContent(
                EventType.Bowling,
                21,
                new DateTime(2020, 08, 29),
                7.50m);

            _event14 = new KomodoOutingsContent(
                EventType.Concert,
                70,
                new DateTime(2020, 12, 25),
                19.95m);

            _event15 = new KomodoOutingsContent(
                EventType.Golf,
                90,
                new DateTime(2020, 12, 22),
                15.75m);

            _event16 = new KomodoOutingsContent(
               EventType.AmusementPark,
               88,
               new DateTime(2020, 11, 07),
               8.95m);

            _event17 = new KomodoOutingsContent(
                EventType.Bowling,
                27,
                new DateTime(2020, 09, 05),
                7.50m);

            _event18 = new KomodoOutingsContent(
                EventType.Concert,
                75,
                new DateTime(2021, 01, 11),
                21.95m);

            _event19 = new KomodoOutingsContent(
                EventType.Golf,
                12,
                new DateTime(2021, 01, 15),
                9.75m);

            _event20 = new KomodoOutingsContent(
               EventType.AmusementPark,
               100,
               new DateTime(2021, 01, 23),
               8.95m);

            _repo.AddContentToDirectory(_event1);
            _repo.AddContentToDirectory(_event2);
            _repo.AddContentToDirectory(_event3);
            _repo.AddContentToDirectory(_event4);
            _repo.AddContentToDirectory(_event5);
            _repo.AddContentToDirectory(_event6);
            _repo.AddContentToDirectory(_event7);
            _repo.AddContentToDirectory(_event8);
            _repo.AddContentToDirectory(_event9);
            _repo.AddContentToDirectory(_event10);
            _repo.AddContentToDirectory(_event11);
            _repo.AddContentToDirectory(_event12);
            _repo.AddContentToDirectory(_event13);
            _repo.AddContentToDirectory(_event14);
            _repo.AddContentToDirectory(_event15);
            _repo.AddContentToDirectory(_event16);
            _repo.AddContentToDirectory(_event17);
            _repo.AddContentToDirectory(_event18);
            _repo.AddContentToDirectory(_event19);
            _repo.AddContentToDirectory(_event20);
        }

    }

}
