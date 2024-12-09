﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enumeration;

namespace Domain.Entities
{
    public class Customer : BaseEntity 
    { 
        public string IdNumber { get; set; }    
        public string PassportNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } 
        public Gender Gender { get; set; }
        public string Citizenship { get; set; }
        public string Address { get; set; }

        public ICollection<MedicalPolicy>? MedicalPolicies { get; set; } = new List<MedicalPolicy>();
        public ICollection<TravelPolicy>? TravelPolicies { get; set; } = new List<TravelPolicy>();
    }
}
