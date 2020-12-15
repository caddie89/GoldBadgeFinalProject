using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02_KomodoClaims_Repository
{
    public class ClaimsRepository
    {
        private Queue<Claims> _claimThings = new Queue<Claims>();

        //Create Method (Create New Claim)
        public void AddClaimToQueue(Claims claimThings)
        {
            _claimThings.Enqueue(claimThings);
        }

        //Read Method (View All Claims)
        public Queue<Claims> SeeClaimThings()
        {
            return _claimThings;            
        }

    //    //Delete Method
    //    public bool RemoveClaim(int claimNumber)
    //    {
    //        Claims claimItem = GetClaimByID(claimNumber);

    //        if (_claimItems.Remove(claimItem))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    //Helper (Get Claim by ID)
    //    public Claims GetClaimByID(int id)
    //    {
    //        foreach (Claims claim in _claimItems)
    //        {
    //            if (claim.ClaimID == id)
    //            {
    //                return claim;
    //            }
    //        }
    //        return null;
    //    }
    }
}
