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
          
            _badgesDict.Add(Count, newBadge);
            Count++;
            return true;
        }

        public BadgesPOCOs GetBadgesByKey(int badgeKey)
        {
            foreach (var content in _badgesDict)
            {
                if (content.Key == badgeKey)
                {
                    return content.Value;
                }
            }
            return null;
        }

        public bool UpdateBadge(int key, int oldBadge, List<DoorAccess> newBadgeData)
        {
            BadgesPOCOs oldBadgeData = new BadgesPOCOs();
            oldBadgeData = GetBadgesByKey(key);
            if (oldBadgeData == null)
            {
                return false;
            }
            else
            {
                oldBadgeData.DoorAccess = newBadgeData;
                oldBadgeData.BadgeID = oldBadge;

                return true;
            }
        }
        public Dictionary<int, BadgesPOCOs> ViewAllBadges()
        {
            return _badgesDict;

        }
    }
}
