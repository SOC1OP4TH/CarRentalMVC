using Microsoft.AspNetCore.Identity;

namespace CarRentalMVC.Models

{
    public class Customer : IdentityUser

    {
        
        public string name { get; set; }
        public string surname { get; set; }
        
        public string city { get; set; }
        public string address { get; set; }
        public  string drivingLicense  { get; set; }



    }
}
