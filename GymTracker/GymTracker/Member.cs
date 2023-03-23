using Microsoft.Extensions.Configuration.UserSecrets;
using System;
namespace GymTracker
{
    public class Member
    {
        public Member() 
        { 
        }

        public int UserID { get; set; }
        public int MembershipID { get; set; }
        public string MembershipName { get; set; }
        public string MembershipIDNumber { get; set; }
        public int MemberID { get; set; }
        public DateOnly JoiningDate { get; set; }
        public int Gender { get; set; }
        public DateOnly EndOfMembership { get; set; }

    }
}
