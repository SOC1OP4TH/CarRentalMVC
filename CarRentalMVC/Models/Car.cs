using System.ComponentModel.DataAnnotations;

namespace CarRentalMVC.Models
{
    public class Car
    {
        [Key]
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string number { get; set; }
        public int price { get; set; }
        public bool isActive { get; set; }

    }
}
