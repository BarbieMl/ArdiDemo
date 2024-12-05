using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Commands.CreateTravel
{
    public record CreateTravelCommandResponse
    (
        string FullName, 
        string Citizenship,
        string IdNumber,
        DateOnly DateOfBirth,
        string PhoneNumber,
        string Email 
    );
}
