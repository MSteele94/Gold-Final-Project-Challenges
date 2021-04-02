using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_BadgesPocos
{
    public class BadgesRepo
    {
        protected readonly Dictionary<int, BadgesPOCOs> _badgesDict = new Dictionary<int, BadgesPOCOs>();
        int Count = 0;
        public bool AddNewBadge(BadgesPOCOs newBadge)
        {

            Count++;
            _badgesDict.Add(Count, newBadge);
            return true;
        }

        public BadgesPOCOs GetBadgesByKey(int badgeKey)
        {
            foreach (KeyValuePair<int, BadgesPOCOs> content in _badgesDict)
            {
                if (content.Key == badgeKey)
                {
                    return content.Value;
                }
            }
            return null;
        }


        public bool RemoveADoor(int key, List<DoorAccess> door)
        {
            foreach (KeyValuePair<int, BadgesPOCOs> item in _badgesDict)
            {
                if (key == item.Key)
                {
                    
                    //didn't work, trying to find a way to compare the entered door in the UI and then take that door off of a badge but leave the remaining doors
                    //if desired

                    //item.Value.DoorAccess.Count.CompareTo(door);
                    return true;
                }
            }
            return false;
        }



        public bool RemovingAllDoors(int key, List<DoorAccess> doors)
        {
            foreach (KeyValuePair<int, BadgesPOCOs> item in _badgesDict)
            {
                if (key == item.Key)
                {

                    item.Value.DoorAccess.Clear();
                  //  item.Value.DoorAccess.Count().CompareTo(doors);
                    return true;
                }
            }
            return false;
           
        }
        public bool AddingDoor(int key, List<DoorAccess> doors)
        {

            foreach (KeyValuePair<int, BadgesPOCOs> item in _badgesDict)
            {
                if (key == item.Key)
                {
                    item.Value.DoorAccess.AddRange(doors);
                    return true;
                }

            }
            return false;
          
        }
        public bool UpdateBadge( int oldBadge, BadgesPOCOs newBadgeData)
        {

            BadgesPOCOs oldBadgeData = GetBadgesByKey(oldBadge);
            if (oldBadgeData == null)
            {
                return false;
            }
            else
            {
                oldBadgeData.DoorAccess = newBadgeData.DoorAccess;
                oldBadgeData.BadgeID = newBadgeData.BadgeID;

                return true;
            }
        }
        public Dictionary<int, BadgesPOCOs> ViewAllBadges()
        {
            return _badgesDict;

        }
    }
}
