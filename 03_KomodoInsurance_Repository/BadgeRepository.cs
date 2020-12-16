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

        //Show Badge By ID
        public List<string> ShowBadgeByID(int badgeId)
        {
            if (_badgeDictionary.ContainsKey(badgeId))
            {
                return _badgeDictionary[badgeId];
            }
            return null;
        }
    }
}
