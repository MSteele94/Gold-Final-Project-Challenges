using KomodoClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    public class Program_UI
    {

       
       
    
        private KomodoClaimsRepo _claimRepo = new KomodoClaimsRepo();
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
                Console.WriteLine("  1.  See All Claims\n" +
                                    "2.  Take Care Of Next Claim\n" +
                                    "3.  Enter a New Claim\n" +
                                    "25. Exit Menu. ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        NextClaimInLine();
                        break;
                    case "3":
                        AddClaimToQueue();
                        break;
                    case "25":
                        continueToRun = false;
                        Console.WriteLine("Press Any Key to continue");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
            Console.ReadKey();
        }

        //displays next claim and asks the manager if they would like to deal with the claim or not 
        public void NextClaimInLine()
        {
            Console.Clear();
            ClaimsPOCOs claimContent = _claimRepo.SeeNextClaimInQueue();
            Console.WriteLine($"Claim ID: {claimContent.ClaimID}\n" +
                                $"Claim Description: {claimContent.Description}\n" +
                                $"Claim Amount: {claimContent.ClaimAmount}\n" +
                                $"Claim Type: {claimContent.ClaimType}\n" +
                                $"Date Of Incident: {claimContent.DateOfIncident}\n" +
                                $"Date Of Claim: {claimContent.DateOfClaim}\n" +
                                $"Claim is Valid: {claimContent.IsValid}");


            Console.WriteLine("Do you want to to deal with this claim? (y/n)");
            string userInputDealWithNextClaim = Console.ReadLine().ToLower();
            if (userInputDealWithNextClaim == "y")
            {
                bool isSuccessful = _claimRepo.GrabClaimFromQueue();
                if (isSuccessful)
                {
                    Console.WriteLine("Claim Pulled");
                }
            }
            else if (userInputDealWithNextClaim == "n")
            {
                Console.WriteLine("Returning to Main Menu");
            }
            Console.ReadKey();
        }
        private void AddClaimToQueue()
        {
            Console.Clear();

            ClaimsPOCOs claim = new ClaimsPOCOs();

            Console.WriteLine("What is the claim ID");
            int userInputClaimID = int.Parse(Console.ReadLine());
            claim.ClaimID = userInputClaimID;

            Console.WriteLine("What is the Description of the Claim?");
            string userInputClaimDescription = Console.ReadLine();
            claim.Description = userInputClaimDescription;

            Console.WriteLine("Enter the Claim Amount");
            int userInputClaimAmount = int.Parse(Console.ReadLine());
            claim.ClaimAmount = userInputClaimAmount;

            Console.WriteLine("Enter the Claim Type.\n" +
                                    "1. Car \n" +
                                    "2. Home\n" +
                                    "3. Theft");
            string userInputClaimType = Console.ReadLine();
            switch (userInputClaimType)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    break;
            }



            Console.WriteLine("Enter the Date of the Incident\n" +
                            "Format is YYYY/MM/DD");
            DateTime userInputDateOfIncident = DateTime.Parse(Console.ReadLine());
            claim.DateOfIncident = userInputDateOfIncident;

            Console.WriteLine("Date of Claim\n" +
                                "Format is YYYY/MM/DD");
            DateTime userInputDateOfClaim = DateTime.Parse(Console.ReadLine());
            claim.DateOfClaim = userInputDateOfClaim;


            _claimRepo.AddClaimToQueue(claim);

            Console.ReadKey();



        }
        public void ViewAllClaims()
        {
            Console.Clear();
            Queue<ClaimsPOCOs> claims = _claimRepo.GetClaimsInQueue();
            foreach (var claim in claims)
            {
                DisplayClaimDetails(claim);
            }
            Console.WriteLine("Press any Key to continue");
            Console.ReadKey();
        }
        //public void DisplayClaims(ClaimsPOCOs claim)
        //{
        //    Console.WriteLine($"Claim: {claim.}");
        //    foreach (var claim in _claimDirectory)
        //    {
        //        if (true)
        //        {

        //        }
        //    }
        //}
        private void DisplayClaimDetails(ClaimsPOCOs claim)
        {
            ClaimsPOCOs claimContent = new ClaimsPOCOs();


            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                                $"Claim Description: {claim.Description}\n" +
                                $"Claim Amount: {claim.ClaimAmount}\n" +
                                $"Claim Type: {claim.ClaimType}\n" +
                                $"Date Of Incident: {claim.DateOfIncident}\n" +
                                $"Date Of Claim: {claim.DateOfClaim}\n" +
                                $"Claim is Valid: {claim.IsValid}");
            //Console.WriteLine("Select a claim Type:\n" +
            //                    "1: Car\n" +
            //                    "2: Home\n" +
            //                    "3. Theft");
            //string claimType = Console.ReadLine();
            //switch (claimType)
            //{
            //    case "1":
            //        claimContent.ClaimType = ClaimType.Car;
            //        break;
            //    case "2":
            //        claimContent.ClaimType = ClaimType.Home;
            //        break;
            //    case "3":
            //        claimContent.ClaimType = ClaimType.Theft;
            //        break;
            //    default:
            //        break;
            //}
        }
        public void Seed()
        {
            ClaimsPOCOs A = new ClaimsPOCOs(1, "Car Accident on 465", 400, ClaimType.Car, DateTime.Parse("4/25/18"), DateTime.Parse("4/27/18"));
            ClaimsPOCOs B = new ClaimsPOCOs(2, "House fire in kitchen", 4000, ClaimType.Home, DateTime.Parse("4/11/18"), DateTime.Parse("4/12/18"));
            ClaimsPOCOs C = new ClaimsPOCOs(3, "Stolen pancakes.", 4.00, ClaimType.Car, DateTime.Parse("4/27/18"), DateTime.Parse("6/01/18"));

            _claimRepo.AddClaimToQueue(A);
            _claimRepo.AddClaimToQueue(B);
            _claimRepo.AddClaimToQueue(C);


        }
    }
}
