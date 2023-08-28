using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Application.DTOs.UserDTOs
{
    public class CreateUserDto
    {
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
