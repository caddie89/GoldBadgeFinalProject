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

        public Dictionary<int, List<string>> ShowBadgesAndAccess()
        {
            return _badgeDictionary;
        }

        //Update Doors
        public void UpdateBadgeAccess(int badgeId, List<string> newBadgeAccess)
        {
            _badgeDictionary[badgeId] = newBadgeAccess;
        }

        //Delete Doors
        //public bool RemoveDoor(int badgeId, List<string> door)
        //{
        //    _badgeDictionary[badgeId] = door;

        //    if (_badgeDictionary.Remove(badgeId))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
