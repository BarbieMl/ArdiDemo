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
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTravelCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTravelCommand command, CancellationToken cancellationToken)
        {
            var existingRecord = await _unitOfWork.TravelRepository.FindAsync(x => x.Id == command.Id, cancellationToken);
            if (existingRecord is null || !existingRecord.IsDeleted)
            {
                throw new KeyNotFoundException("Medical record not found.");
            }

            await _unitOfWork.TravelRepository.Delete(existingRecord, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return true;
        }
    }
}
