using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepository
{
    public enum ClaimType {Car, Home, Theft}
    public class ClaimsPOCOs
    {
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public ClaimType ClaimType { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if ((DateOfClaim - DateOfIncident).TotalDays <= 30)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }
        public ClaimsPOCOs(){}

        public ClaimsPOCOs(int claimID, string description, double claimAmount, ClaimType claimType, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            Description = description;
            ClaimAmount = claimAmount;
            ClaimType = claimType;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            
        }
    }
}
