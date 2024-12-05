using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Medical.Commands.DeleteMedical
{
    public record DeleteMedicalCommand(Guid Id):IRequest<bool>;
}
