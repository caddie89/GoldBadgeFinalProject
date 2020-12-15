using System;
using System.Collections.Generic;

namespace _03_KomodoInsurance_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; } = new List<string>();

        public Badge() { }

        public Badge(int badgeId) 
        {
            BadgeID = badgeId;
        }

        //Seed Data Constructor (may not need)
        public Badge(int badgeId, List<string> doors)
        {
            BadgeID = badgeId;
            Doors = doors;
        }
    }
}
