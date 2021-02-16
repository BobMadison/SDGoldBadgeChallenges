using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02a_KomodoClaimsDepartment
{
    public class KomodoClaimsContent
    {
        public int ClaimID { get; set; }
        public ClaimTypes ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public KomodoClaimsContent () {} // Empty constructor

        public KomodoClaimsContent (
            int claimID, 
            ClaimTypes claimType,
            string description,
            decimal claimAmount,
            DateTime dateOfIncident,
            DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = Convert.ToInt32(Math.Floor((dateOfClaim - dateOfIncident).TotalDays)) <= 30;
        }
    }

    public enum ClaimTypes { Car = 1, Home, Theft}
}
