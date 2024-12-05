using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.UnitOfWork;
using Application.Features.Medical.Commands.CreateMedical;
using Domain.Entities;
using Domain.Enumeration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Travel.Commands.UpdateTravel
{
    public class UpdateTravelCommandsHandler : IRequestHandler<UpdateTravelCommand, UpdateTravelCommandResponse>
    {
        private readonly ITravelRepository _Travel; 
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTravelCommandsHandler(
                ITravelRepository travel,
             IUnitOfWork unitOfWork)
        {
            _Travel = travel; 
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateTravelCommandResponse> Handle(UpdateTravelCommand command, CancellationToken cancellationToken)
        {
            var existingRecord = await _Travel.FindAsync(x => x.Id == command.Id);
            if (existingRecord is null || !existingRecord.IsActive)
            {
                throw new KeyNotFoundException("Medical record not found.");
            }

            existingRecord.PolicyNumber = command.PolicyNumber;
            existingRecord.StartDate = command.StartDate;
            existingRecord.EndDate = command.EndDate;
            existingRecord.PremiumAmount = command.PremiumAmount;
            existingRecord.Insurer = command.Insurer;
            existingRecord.TypeOfPaymentPeriod = command.TypeOfPaymentPeriod; 
            existingRecord.IsActive = command.IsActive;
            existingRecord.TypeOfTrip = command.TypeOfTrip;
            existingRecord.Countries = command.Countries; 

            await _Travel.Update(existingRecord);
            await _unitOfWork.SaveAsync(cancellationToken);

            return new UpdateTravelCommandResponse
                (
                existingRecord.Id,
                existingRecord.PolicyNumber,
                existingRecord.StartDate,
                existingRecord.EndDate,
                existingRecord.PremiumAmount, 
                existingRecord.Insurer,
                existingRecord.TypeOfPaymentPeriod,
                existingRecord.IsActive,
                existingRecord.TypeOfTrip,
                existingRecord.Countries
                );
        }
    }
}