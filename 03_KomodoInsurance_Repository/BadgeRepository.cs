using System;
using System.Collections.Generic;
using System.Text;

namespace _03_KomodoInsurance_Repository
{
    public class BadgeRepository
    {
        private Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        //Add to Dictionary
        public void AddBadgeToDictionary(int badgeId, Badge doors)
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

        public Dictionary<int, Badge> ShowBadgesAndAccess()
        {
            return _badgeDictionary;
        }

        //Update Doors
        public bool UpdateBadgeAccess(int badgeId, Badge newBadgeAccess)
        {
            Badge existingBadge = GetBadgeByID(badgeId);

            if (existingBadge != null)
            {
                existingBadge.Doors = newBadgeAccess.Doors;

                return true;
            }
            else
            {
                return false;
            }
        }

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
        private Badge GetBadgeByID(int id)
        {
            if (_badgeDictionary.TryGetValue(id, out Badge value))
            {
                return value;
            }
            return null;
        }

        //foreach (KeyValuePair<int, List<string>> key in _badgeDictionary) /*(int key in _badgeDictionary.Keys)*/
        //{

        //    Badge badge = null;

        //    if (key.Key == id )
        //    {
        //       ;
        //        return key.Value;
        //    }
        //}
        //return null;

        //public void AddDoorsToBadge(int badgeId, List<string> doors)
        //{
        //    Badge badge = GetBadgeByID(badgeId);

        //    if (badge != null)
        //    {
        //        if (badge.Doors == null)
        //            badge.Doors = new List<string>();

        //        badge.Doors.AddRange(doors);
        //    }
        //}

        //Show List of Badges and Door Access
    }
}
