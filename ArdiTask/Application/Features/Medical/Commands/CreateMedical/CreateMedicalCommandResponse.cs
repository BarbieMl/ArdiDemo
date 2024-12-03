using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Commands.CreateMedical
{
    public record CreateMedicalCommandResponse
    (
        string FullName, 
        string Citizenship,
        string IdNumber,
        DateOnly DateOfBirth,
        string PhoneNumber,
        string Email 
    );
}
