using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerTracker.Models
{
    public class Trailers
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; } 
        public string Vin { get; set; }
    }
}