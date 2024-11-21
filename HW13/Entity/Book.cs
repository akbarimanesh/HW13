using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrow { get; set; } = false;
        public DateTime? Barrowdate { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
