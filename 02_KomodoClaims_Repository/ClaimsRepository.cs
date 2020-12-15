using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02_KomodoClaims_Repository
{
    public class ClaimsRepository
    {
        private Queue<Claims> _claimItems = new Queue<Claims>();

        //Create Method (Create New Claim)
        public void AddClaimToQueue(Claims claimItems)
        {
            _claimItems.Enqueue(claimItems);
        }

        //Read Method (View All Claims)
        public Queue<Claims> SeeClaimItems()
        {
            return _claimItems;            
        }
    }
}
