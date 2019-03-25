using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerTracker.Models
{
    public class Trucks
    {
        public int Id { get; set; }
        public string TruckNumber { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public int? EngineSerialNumber { get; set; }
    }
}