using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Dto
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrow { get; set; }
        public string UserName { get; set; }
        public DateTime? Barrowdate { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
