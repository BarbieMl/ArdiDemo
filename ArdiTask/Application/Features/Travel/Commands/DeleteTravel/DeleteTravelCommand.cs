using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Commands.DeleteTravel
{
    public record DeleteTravelCommand(Guid Id):IRequest<bool>;
}
