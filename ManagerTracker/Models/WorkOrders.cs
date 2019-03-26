using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerTracker.Models
{
    public class WorkOrders
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PartNumberOrDescription { get; set; }
        public string PartQuantity { get; set; }
        public string PartPrice { get; set; }
        public string RepairDescription { get; set; }
        [ForeignKey("People")]
        public int PeopleId { get; set; }
        public People People { get; set; }
        [ForeignKey("Trucks")]
        public int TruckId { get; set; }
        public Trucks Trucks { get; set; }
        [ForeignKey("Trailers")]
        public int TrailerId { get; set; }
        public Trailers Trailers { get; set; }


    }
}