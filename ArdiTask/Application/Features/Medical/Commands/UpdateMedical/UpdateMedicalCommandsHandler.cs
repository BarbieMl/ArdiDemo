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

namespace Application.Features.Medical.Commands.UpdateMedical
{
    public class UpdateMedicalCommandsHandler : IRequestHandler<UpdateMedicalCommand, UpdateMedicalCommandResponse>
    {
        private readonly IMedicalRepository _medical; 
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMedicalCommandsHandler(
                IMedicalRepository medical,
             IUnitOfWork unitOfWork)
        {
            _medical = medical; 
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateMedicalCommandResponse> Handle(UpdateMedicalCommand command, CancellationToken cancellationToken)
        {
            var existingRecord = await _unitOfWork.MedicalRepository.FindAsync(x => x.Id == command.Id, cancellationToken);
            if (existingRecord is null || !existingRecord.IsDeleted)
            {
                throw new KeyNotFoundException("Medical record not found.");
            }

            existingRecord.PolicyNumber = command.PolicyNumber;
            existingRecord.StartDate = command.StartDate;
            existingRecord.EndDate = command.EndDate;
            existingRecord.PremiumAmount = command.PremiumAmount;
            existingRecord.Insurer = command.Insurer;
            existingRecord.TypeOfPaymentPeriod = command.TypeOfPaymentPeriod;
            existingRecord.Provider = command.Provider; 

            await _unitOfWork.MedicalRepository.Update(existingRecord, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return new UpdateMedicalCommandResponse
                (
                existingRecord.Id,
                existingRecord.PolicyNumber,
                existingRecord.StartDate,
                existingRecord.EndDate,
                existingRecord.PremiumAmount,
                existingRecord.Provider,
                existingRecord.Insurer,
                existingRecord.TypeOfPaymentPeriod,
                existingRecord.IsDeleted
                );
        }
    }
}