using _04a_KomodoOutings_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _04b_KomodoOutings_Tests
{
    [TestClass]
    public class KomodoOutingsTests
    {
        private KomodoOutingsContent_Repo _repo;
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


        [TestMethod]
        public void TestingKomodoOutings()
        {
            SetUpList();
            DisplayListOfOutings();
        }

        public void DisplayListOfOutings()
        {
            List<KomodoOutingsContent> myList = _repo.GetContents();

            Console.WriteLine("\n\n");
            Console.WriteLine($"{" Outing", -15}" +
                $"{" # Attended", -11}" +
                $"{" Date", -8}" +
                $"{" Cost per Person", -16}" +
                $"{" Total Cost", -12}");
            Console.WriteLine(new String('-', 62));
            Console.WriteLine(new String('-', 62));

            foreach (KomodoOutingsContent content in myList)
            {
                DisplayContent(content);
            }
        }
        public void DisplayContent(KomodoOutingsContent content)
        {
            Console.WriteLine(
                String.Format(
                    " {0, -15} | {1, -11} | {2, -8} | {3, -16} | {4, -12}",
                    content.OutingEvent,
                    content.NumberAttending,
                    content.DateOfEvent,
                    content.CostPerPerson,
                    content.TotalCostForEvent));
        }
        public void SetUpList()
        {
            _repo = new KomodoOutingsContent_Repo();

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
