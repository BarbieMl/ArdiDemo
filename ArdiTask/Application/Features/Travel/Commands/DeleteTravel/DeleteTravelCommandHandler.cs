using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.UnitOfWork;
using Application.Features.Medical.Commands.UpdateMedical;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Commands.DeleteTravel
{
    public class DeleteTravelCommandHandler : IRequestHandler<DeleteTravelCommand, bool>
    {
        private readonly ITravelRepository _travel;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTravelCommandHandler(
                ITravelRepository travel,
             IUnitOfWork unitOfWork)
        {
            _travel = travel;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTravelCommand command, CancellationToken cancellationToken)
        {
            var existingRecord = await _travel.FindAsync(x => x.Id == command.Id);
            if (existingRecord is null || !existingRecord.IsActive)
            {
                throw new KeyNotFoundException("Medical record not found.");
            }

            existingRecord.IsActive = false;

            await _travel.Update(existingRecord);
            await _unitOfWork.SaveAsync(cancellationToken);

            return true;
        }
    }
}
