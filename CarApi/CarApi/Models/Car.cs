using System;
using System.Collections.Generic;

namespace CarApi.Models
{
    public partial class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }
    }
}
