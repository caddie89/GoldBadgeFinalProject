using System;

namespace _02_KomodoClaims_Repository
{
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; } = new DateTime();
        public DateTime DateOfClaim { get; set; } = new DateTime();
        public bool IsValid { get; set; }

        public Claims() { }

        //Seed Data Constructor
        public Claims(int claimId, ClaimType claimType, string claimDescription, decimal claimAmount, DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }

    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft,
    }
}
