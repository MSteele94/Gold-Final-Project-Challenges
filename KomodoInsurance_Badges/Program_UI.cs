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
            Console.Clear();
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                                    "1. Add a Badge.\n" +
                                    "2. Edit a Badge.\n" +
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
        

        public void EditBadges()
        {
            Console.WriteLine("1. Update Badge\n" +
                              "2. Add a Door\n" +
                              "3. Remove a door\n" +
                              "4. Remove ALL doors\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    UpdateBadge();
                    break;
                case "2":
                    AddADoor();
                    break;
                case "3":
                    RemoveADoor();
                    break;
                case "4":
                    RemoveAllDoors();
                    break;
                case "4:":

                default:
                    break;
            }
        }


        public void RemoveADoor()
        {
            Console.WriteLine("Enter the badge key to select a badge to remove a door from.");
           
            
            //this is the inside of ListAllBadges
            //foreach (KeyValuePair<int, BadgesPOCOs> badge in _badgeRepo.ViewAllBadges())
            //{
            //    DisplayBadgeDetails(badge);
            //}
            ListAllBadges();

            int userKeyInput = int.Parse(Console.ReadLine());

            BadgesPOCOs newBadge = new BadgesPOCOs();
            

            //Doesn't work but retyped this from the Setup method in order to display the doors but have a different WriteLine ontop of the door list to choose from
            //
            bool userInputDoorAccess = false;
            while (!userInputDoorAccess)
            {

                Console.WriteLine("Are you sure you want to remove a door? (y/n)");
                string userInputAddDoors = Console.ReadLine().ToLower();
                if (userInputAddDoors == "y")
                {

                    Console.WriteLine("Input the door you would like to REMOVE\n" +
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
                }

                else
                {
                    userInputDoorAccess = true;

                }
            }
            BadgesPOCOs removingADoor = new BadgesPOCOs();
            bool isSuccessful = _badgeRepo.RemoveADoor(userKeyInput, removingADoor.DoorAccess);

            if (isSuccessful)
            {
                Console.WriteLine("Door removed");
            }
            else
            {
                Console.WriteLine("Removal Failed");
            }

        }


        public void RemoveAllDoors()
        {

            //found this by accident kind of.. REMOVES ALL DOORS Could be useful so will keep it in the UI and do another method for deleting a specific door
            //i believe it will require a mixture of the update method and the adding method with a tweak

            Console.WriteLine("Enter the badge key to remove all doors off that badge.");
            
            
            //this is the inside of ListAllBadges
            //foreach (KeyValuePair<int, BadgesPOCOs> badge in _badgeRepo.ViewAllBadges())
            //{
            //    DisplayBadgeDetails(badge);
            //}
            ListAllBadges();

            int userBadgeKey = int.Parse(Console.ReadLine());
            BadgesPOCOs removingAllDoors = new BadgesPOCOs();



            bool isSuccessful = _badgeRepo.RemovingAllDoors(userBadgeKey, removingAllDoors.DoorAccess);

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
        public void AddADoor()
        {
            Console.WriteLine("Enter the badge key to select a badge you would like to add a door to.");

           
            
            //this is the inside of ListAllBadges
            //foreach (KeyValuePair<int, BadgesPOCOs> badge in _badgeRepo.ViewAllBadges())
            //{
            //    DisplayBadgeDetails(badge);
            //}
            ListAllBadges();


            int userBadgeKey = int.Parse(Console.ReadLine());
            BadgesPOCOs addingADoor = new BadgesPOCOs();



            Setup(addingADoor);




            bool isSuccessful = _badgeRepo.AddingDoor(userBadgeKey, addingADoor.DoorAccess);

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


        private void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("Which badge would you like to update? Please enter the Key.");

            //this is the inside of ListAllBadges
            //foreach (KeyValuePair<int, BadgesPOCOs> badge in _badgeRepo.ViewAllBadges())
            //{
            //    DisplayBadgeDetails(badge);
            //}
            ListAllBadges();

            int userInputBadgeKey = int.Parse(Console.ReadLine());
            Console.ReadKey();

            BadgesPOCOs newBadgeData = new BadgesPOCOs();


            Console.WriteLine("Please enter a new Badge ID:");
            int userInputBadgeID = int.Parse(Console.ReadLine());
            newBadgeData.BadgeID = userInputBadgeID;


            Setup(newBadgeData);


            bool isSuccessful = _badgeRepo.UpdateBadge(userInputBadgeKey, newBadgeData);

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

            foreach (KeyValuePair<int, BadgesPOCOs> badge in _badgeRepo.ViewAllBadges())
            {
                DisplayBadgeDetails(badge);
            }
            Console.ReadKey();
            Console.Clear();
        }
        public void DisplayBadgeDetails(KeyValuePair<int, BadgesPOCOs> badge)
        {
            //KeyValuePair<int, BadgesPOCOs> badgeContent = new KeyValuePair<int, BadgesPOCOs>();
            Console.WriteLine($"Key: {badge.Key}\n" +
                $"BadgeId: {badge.Value.BadgeID}\n");
            foreach (DoorAccess door in badge.Value.DoorAccess)
            {
                Console.WriteLine(door);
            }
            Console.WriteLine("------------------------");
        }
        public void AddABadge()
        {
            BadgesPOCOs newBadge = new BadgesPOCOs();

            Console.WriteLine("What is the number on the badge?");
            int userInputBadgeNumber = int.Parse(Console.ReadLine());
            newBadge.BadgeID = userInputBadgeNumber;

            //this is for adding doors to a badge
            Setup(newBadge);




            bool isSuccessful = _badgeRepo.AddNewBadge(newBadge);
            if (isSuccessful)
            {
                Console.WriteLine("Successful");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            Console.ReadKey();
        }

        private void Setup(BadgesPOCOs newBadge)
        {


            bool userInputDoorAccess = false;

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
                }

                else
                {
                    userInputDoorAccess = true;

                }
            }
        }
        private void Seed()
        {

            BadgesPOCOs A = new BadgesPOCOs(12345, new List<DoorAccess> { DoorAccess.A3, DoorAccess.A5 });
            BadgesPOCOs B = new BadgesPOCOs(22345, new List<DoorAccess> { DoorAccess.A1, DoorAccess.A4, DoorAccess.B1, DoorAccess.B2 });
            BadgesPOCOs C = new BadgesPOCOs(32345, new List<DoorAccess> { DoorAccess.A4, DoorAccess.A5 });

            _badgeRepo.AddNewBadge(A);
            _badgeRepo.AddNewBadge(B);
            _badgeRepo.AddNewBadge(C);
        }

    }
}
