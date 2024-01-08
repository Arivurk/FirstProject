using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.bl
{
    public class Branchs
    {
        public int Branch_Id { get; set; }
        public string Branchname { get; set; }
        public string Address { get; set; }
    }
    public class UserModel
    {
        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Branch_Id { get; set; }

        public string Branchname { get; set; }

        public string Gender { get; set; }
    }
    public enum Gender
    {
        Male,

        Female
    }
}
