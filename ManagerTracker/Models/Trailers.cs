﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerTracker.Models
{
    public class Trailers
    {
        public int Id { get; set; }
        public string TrailerNumber { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; } 
    }
}