using System;
using System.Collections.Generic;
using System.Text;

namespace _03_KomodoInsurance_Repository
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        //Add to Dictionary
        public void AddBadgeToDictionary(int badgeId, List<string> doors)
        {
            _badgeDictionary.Add(badgeId, doors);
        }

        public void AddDoorsToBadge(int badgeId, List<string> doors)
        {
            Badge badge = GetBadgeByID(badgeId);
            if (badge != null)
            {
                if (badge.Doors == null)
                    badge.Doors = new List<string>();

                badge.Doors.AddRange(doors);
            }
        }

        //Show List of Badges and Door Access
        public Dictionary<int, List<string>> ShowBadgesAndAccess()
        {
            return _badgeDictionary;
        }

        //Update Doors
        //public bool UpdateBadgeAccess(int badgeId, List<string> newBadgeAccess)
        //{
        //    Badge existingBadge = GetBadgeByID(badgeId);

        //    if (existingBadge != null)
        //    {
        //        existingBadge.Doors = newBadgeAccess.Doors;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Delete Doors
        //public bool RemoveDoorAccess(int badgeId, Badge door)
        //{
        //    Badge existingBadge = GetBadgeByID(badgeId);

        //    if (existingBadge != null)
        //    {
        //        foreach (var i in door)
        //        {
        //            existingBadge.Doors.RemoveAll(item => item == i);
        //        }
        //    }
        //}

        //Helper Method
        public Badge GetBadgeByID(int id)
        {
            foreach (int key in _badgeDictionary.Keys)
            {
                if (key == id)
                { 
                    return key;
                }
            }
            return null;
        }
    }
}
