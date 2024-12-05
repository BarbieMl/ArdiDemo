using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Commands.CreateTravel
{
    public class CreateTravelCommands : IRequest<CreateTravelCommandResponse>
    {
        public List<CreateTravelCommand> Commands { get; set; }

        public CreateTravelCommands(List<CreateTravelCommand> commands)
        {
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }
    }
}
