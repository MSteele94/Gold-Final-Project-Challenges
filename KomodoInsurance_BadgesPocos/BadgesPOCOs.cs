using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_BadgesPocos
{
       
    public enum DoorAccess {A1 = 1, A2 = 2 , A3 = 3, A4 = 4, A5= 5, B1 = 6, B2 = 7, B3 = 8, B4 = 9, B5 = 10}
    public class BadgesPOCOs
    {
       public int BadgeID { get; set; }
        public List<DoorAccess> DoorAccess { get; set; } = new List<DoorAccess>();
       
        
        public BadgesPOCOs(){}

        public BadgesPOCOs(int badgeID, List<DoorAccess> doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;
          
        }
    }
}
