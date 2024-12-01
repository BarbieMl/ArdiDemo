using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer: BaseEntity
    { 
        public string IdNumber { get; set; }    
        public string PassportNumberm { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //to do: GenderEnum
        public string Gender { get; set; }
        public string Adress { get; set; }
        public string Citizenship { get; set; }
    }
}
