using HW13.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Dto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public EnumRole Role { get; set; }
        public int NumberBorrowed { get; set; }
    }
}
