using _02a_KomodoClaimsDepartment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02b_KomodoClaimsDepartment_Tests
{
    [TestClass]
    public class KomodoClaimsDepartmentTest
    {
        private KomodoClaimsDepartment_Repo _repo;
        private KomodoClaimsContent _claim1;
        private KomodoClaimsContent _claim2;
        private KomodoClaimsContent _claim3;

        [TestInitialize]
        public void Seed()
        {
            _repo = new KomodoClaimsDepartment_Repo();

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
                2,
                ClaimTypes.Theft,
                "Stolen pancakes",
                4.00m,
                new DateTime(2018, 04, 27),
                new DateTime(2018, 06, 01));

            _repo.AddContentToDirectory(_claim1);
            _repo.AddContentToDirectory(_claim2);
            _repo.AddContentToDirectory(_claim3);
        }

        [TestMethod]
        public void DisplayList()
        {
            Seed();
            List<KomodoClaimsContent> myList = _repo.GetContents();

            Console.WriteLine($" {"ClaimID", -9}" +
                $"{"Type", -7}" +
                $"{"Description",-25}" +
                $"{"Amount",-11}" +
                $"{"Date of Accident", -18}" +
                $"{"Date Of Claim", -15}" +
                $"{"Is Valid", -8}");

            foreach(KomodoClaimsContent content in myList)
            {
                DisplayContent(content);
            }

        }

        public static void DisplayContent(KomodoClaimsContent content)
        {
            Console.WriteLine(String.Format(" {0,-12} | {1,-6} | {2, -25} | ${3, -11} | {4, -18} | {5, -15} | {6, -8}",
                content.ClaimID, 
                content.ClaimType, 
                content.Description, 
                content.ClaimAmount, 
                content.DateOfIncident.ToShortDateString(),
                content.DateOfClaim.ToShortDateString(),
                content.IsValid));
        }
    }
}
