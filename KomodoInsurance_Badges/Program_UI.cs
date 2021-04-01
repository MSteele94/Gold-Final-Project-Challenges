using KomodoInsurance_BadgesPocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Badges
{
    public class Program_UI
    {
        // protected readonly Dictionary<int, BadgesPOCOs> _badgesDict = new Dictionary<int, BadgesPOCOs>();
        protected readonly BadgesRepo _badgeRepo = new BadgesRepo();

        public void Run()
        {
            Seed();
            RunMenu();
        }

        private void RunMenu()
        {

            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                                    "1. Add a Badge.\n" +
                                    "2. Edit a Badge." +
                                    "3. List all Badges");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditBadges();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    default:
                        break;
                }

            }
        }
        //while loop for bages in adding badges

        public void EditBadges()
        {
            Console.Clear();
            Console.WriteLine("Which badge would you like to update? Please enter the Key.");
            foreach (var badge in _badgeRepo.ViewAllBadges())
            {
                DisplayBadgeDetails(badge);
            }
            int userInputBadgeKey = int.Parse(Console.ReadLine());
            Console.ReadKey();

            List<DoorAccess> newBadgeData = new List<DoorAccess>();
            BadgesPOCOs newBadgeID = new BadgesPOCOs();

            BadgesPOCOs updatedBadge = _badgeRepo.GetBadgesByKey(userInputBadgeKey);
            newBadgeData = updatedBadge.DoorAccess;

            Console.WriteLine("Please enter a new Badge ID:");
            int userInputBadgeID = int.Parse(Console.ReadLine());
            newBadgeID.BadgeID = userInputBadgeID;

           
            //henry helped me with this as well
            bool loop = true;
            while (loop)
            {

                Console.WriteLine("Would you like to add a door? (y/n)");
                string userInputAddDoor = Console.ReadLine().ToLower();

                if (userInputAddDoor == "n")
                {

                    Console.WriteLine("All doors updated");
                    loop = false;
                }
                else if (userInputAddDoor == "y")
                {
                    Console.WriteLine("Input the door you would like to add\n" +
                         "1. A1\n" +
                         "2. A2\n" +
                         "3. A3\n" +
                         "4. A4\n" +
                         "5. A5\n" +
                         "6. B1\n" +
                         "7. B2\n" +
                         "8. B3\n" +
                         "9. B4\n" +
                         "10. B5");
                    string userInputUpdateDoor = Console.ReadLine();
                    // List<DoorAccess> newDoors = new List<DoorAccess>();
                    switch (userInputUpdateDoor)
                    {
                        case "1":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "2":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "3":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "4":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "5":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "6":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "7":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "8":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "9":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                        case "10":
                            newBadgeData.Add((DoorAccess)int.Parse(userInputUpdateDoor));
                            break;
                            
                        default:
                            break;

                    }
                }

                else
                {
                    Console.WriteLine("Invalid input");
                }
            }



            bool isSuccessful = _badgeRepo.UpdateBadge(userInputBadgeKey, userInputBadgeID, newBadgeData);

            if (isSuccessful)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Exiting to Menu");
            }
            Console.ReadKey();
        }
        public void ListAllBadges()
        {
            Console.Clear();

            foreach (var badge in _badgeRepo.ViewAllBadges())
            {
                DisplayBadgeDetails(badge);
            }
            Console.ReadKey();
        }
        public void DisplayBadgeDetails(KeyValuePair<int, BadgesPOCOs> badge)
        {
            //KeyValuePair<int, BadgesPOCOs> badgeContent = new KeyValuePair<int, BadgesPOCOs>();
            Console.WriteLine($"Key: {badge.Key}\n" +
                $"BadgeId: {badge.Value.BadgeID}\n");
            foreach (var door in badge.Value.DoorAccess)
            {
                Console.WriteLine(door);
            }
            Console.WriteLine("------------------------");
        }
        public void AddABadge()
        {
            BadgesPOCOs newBadge = new BadgesPOCOs();

           //List<DoorAccess> newBadgeDoor = new List<DoorAccess>();

            Console.WriteLine("What is the number on the badge?");
            int userInputBadgeNumber = int.Parse(Console.ReadLine());
            newBadge.BadgeID = userInputBadgeNumber;

            //this is for adding doors to a badge
            bool userInputDoorAccess = false;
            //List<DoorAccess> newDoorsForAccess = new List<DoorAccess>();
            while (!userInputDoorAccess)
            {

                Console.WriteLine("Do you want to add new doors to this badge? (y/n)");
                string userInputAddDoors = Console.ReadLine().ToLower();
                if (userInputAddDoors == "y")
                {

                    Console.WriteLine("Input the door you would like to add\n" +
                        "1. A1\n" +
                        "2. A2\n" +
                        "3. A3\n" +
                        "4. A4\n" +
                        "5. A5\n" +
                        "6. B1\n" +
                        "7. B2\n" +
                        "8. B3\n" +
                        "9. B4\n" +
                        "10. B5");
                    string userInputNewDoors = Console.ReadLine();
                    // List<DoorAccess> newDoors = new List<DoorAccess>();
                    switch (userInputNewDoors)
                    {
                        case "1":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "2":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "3":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "4":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "5":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "6":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "7":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "8":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "9":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                        case "10":
                            newBadge.DoorAccess.Add((DoorAccess)int.Parse(userInputNewDoors));
                            break;
                           
                        default:
                            break;

                    }

                    //Console.WriteLine("Input Door from this list:\n" +
                    //"---------------------------------------------\n" +
                    //"Entering nothing at this point will remove all doors\n" +
                    //"(A1, A2, A3, A4, A5) - (B1, B2, B3, B4, B5");
                    //string doorNumber = Console.ReadLine().ToUpper();



                }
                else if (userInputAddDoors == "n")
                {
                    
                    userInputDoorAccess = true;
                    bool isSuccessful = _badgeRepo.AddNewBadge( newBadge);
                    if (isSuccessful)
                    {
                        Console.WriteLine("Successful");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
                else
                {
                    userInputDoorAccess = true;
                    RunMenu();
                }
            }
         

          


           
            Console.ReadKey();
        }
        private void Seed()
        {

            BadgesPOCOs A = new BadgesPOCOs(12345, new List<DoorAccess> { DoorAccess.A3 , DoorAccess.A5}  );
            BadgesPOCOs B = new BadgesPOCOs(22345, new List<DoorAccess> { DoorAccess.A1 , DoorAccess.A4, DoorAccess.B1, DoorAccess.B2}  );
            BadgesPOCOs C = new BadgesPOCOs(32345, new List<DoorAccess> { DoorAccess.A4 , DoorAccess.A5}  );

            _badgeRepo.AddNewBadge(A);
            _badgeRepo.AddNewBadge(B);
            _badgeRepo.AddNewBadge(C);



            //_badgeRepo.AddNewBadge(
            //{
            //    BadgeID = 12345,
            //    = new DoorAccess();

            //});

            //_badgeRepo.AddNewBadge(new BadgesPOCOs
            //{
            //    BadgeID = 22345,
            //    BadgeDoors = new List<string>()
            //    {
            //        "A1",
            //        "A4",
            //        "B1",
            //        "B2"
            //    }
            //});

            //_badgeRepo.AddNewBadge(new BadgesPOCOs
            //{
            //    BadgeID = 32345,
            //    BadgeDoors = new List<string>()
            //    {
            //        "A4",
            //        "A5"
            //    }
            //});


        }
        
    }
}
