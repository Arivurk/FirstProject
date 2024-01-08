using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FirstProject.Models
{
    public class UserModel
    {
        [Display(Name = "User name")]
        public string Username { get; set; }
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Display(Name = "Last name")]
        public string Lastname { get; set; }
        [Display(Name = "Branch id")]
        public int Branch_Id { get; set; }
        [Display(Name = "Branch name")]
        public string Branchname { get; set;}
        [Display(Name = "Gender")]
        public string Gender { get;set; }

        public string Mobile { get; set; }
        public string Email { get; set; }

        public string City { get; set; }
        public string State { get; set; }
    }
    public class BranchModel
    {
        public int Branch_Id { get; set; }
        public string Branchname { get; set;}
        public string Address { get; set; }
    }
    public enum Gender
    {
         Male,

        Female
    }
    public class selectGender
    {
        public Gender selecGender { get; set; }
    }
    public class listTables
    {
        [Display(Name = "data")]
        public string data { get; set;}
    }
}