using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Commands.CreateMedical
{
    public class CreateMedicalCommands : IRequest<CreateMedicalCommandResponse>
    {
        public List<CreateMedicalCommand> Commands { get; set; }

        public CreateMedicalCommands(List<CreateMedicalCommand> commands)
        {
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }
    }
}
