using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepository
{
    public class KomodoClaimsRepo
    {
        //trouble with test methods. they all pass but not sure if executed correctly.
        
        protected readonly Queue<ClaimsPOCOs> _claimDirectory = new Queue<ClaimsPOCOs>();

        public bool AddClaimToQueue(ClaimsPOCOs claimData)
        {
            _claimDirectory.Enqueue(claimData);
            return true;
        
        }

        //creating a queue method to call in the ViewAllClaims Method in the UI
        public Queue<ClaimsPOCOs> GetClaimsInQueue()
        {
            return _claimDirectory;
        }
        //creating a method to call in the NextClaimInLine
        public ClaimsPOCOs SeeNextClaimInQueue()
        {
            return _claimDirectory.Peek();
        }
        public ClaimsPOCOs GetClaimByID(int claimID)
        {
            foreach (ClaimsPOCOs content in _claimDirectory)
            {
                if (content.ClaimID == claimID)
                {
                    return content;
                }
            }
            return null;
        }

        //creating "removal" method that uses the SeeNextClaim method, and returns the claim directory to call in the NextClaimInQueue method
        public bool GrabClaimFromQueue()
        {
            ClaimsPOCOs claimInQueue = SeeNextClaimInQueue();
            if (claimInQueue == null)
            {
                return false;
            }
            else
            {
                _claimDirectory.Dequeue();
                return true;
            }
        }
    }
}
