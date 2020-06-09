using System;
using System.Collections.Generic;

namespace CarApplication.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
