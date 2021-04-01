using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoInsurance_BadgesPocos;
namespace Dictionary_Discovery
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BadgesPOCOs> _badgesDict = new Dictionary<int, BadgesPOCOs>();

            _badgesDict.Add(1, new BadgesPOCOs
            {
                BadgeID = 1,
                BadgeDoors=new List<string>() 
                {
                    "A1",
                    "B2",
                    "C2"
                }
            });

            _badgesDict.Add(2, new BadgesPOCOs
            {
                BadgeID = 2,
                BadgeDoors = new List<string>()
                {
                    "A1",
                    "C2"
                }
            });

            _badgesDict.Add(3, new BadgesPOCOs
            {
                BadgeID = 3,
                BadgeDoors = new List<string>()
                {
                    "A1",
                    "B2",
                    "C2",
                    "D1",
                    "SS250"
                }
            });

            foreach (KeyValuePair<int, BadgesPOCOs> pair in _badgesDict)
            {
                Console.WriteLine(pair.Key);
                Console.WriteLine(pair.Value.BadgeID);
                
                foreach (string door in pair.Value.BadgeDoors)
                {
                    if (door=="SS250")
                    {
                        Console.WriteLine(pair.Key);
                        Console.WriteLine(door);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
