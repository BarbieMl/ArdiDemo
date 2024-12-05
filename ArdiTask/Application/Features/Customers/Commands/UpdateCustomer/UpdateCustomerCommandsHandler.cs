using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.UnitOfWork;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Medical.Commands.CreateMedical;
using Domain.Entities;
using Domain.Enumeration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.UpdateCustomerf
{
    public class UpdateCustomerCommandsHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customer;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandsHandler(
                ICustomerRepository customer,
             IUnitOfWork unitOfWork)
        {
            _customer = customer;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var existingRecord = await _customer.FindAsync(x => x.Id == command.Id);
            if (existingRecord is null || !existingRecord.IsActive)
            {
                throw new KeyNotFoundException("Customer record not found.");
            } 
            existingRecord.IdNumber = command.IdNumber;
            existingRecord.PassportNumber = command.PassportNumber;
            existingRecord.DateOfBirth = command.DateOfBirth;
            existingRecord.FirstName = command.FirstName;
            existingRecord.LastName = command.LastName;
            existingRecord.PhoneNumber = command.PhoneNumber;
            existingRecord.Gender = command.Gender;
            existingRecord.Citizenship = command.Citizenship;
            existingRecord.Address = command.Address;
            existingRecord.IsActive = command.IsActive; 

            await _customer.Update(existingRecord);
            await _unitOfWork.SaveAsync(cancellationToken);

            return new UpdateCustomerCommandResponse
                (
                existingRecord.Id,
                existingRecord.IdNumber,
                existingRecord.PassportNumber,
                existingRecord.DateOfBirth,
                existingRecord.FirstName,
                existingRecord.LastName,
                existingRecord.PhoneNumber,
                existingRecord.Email,
                existingRecord.Gender,
                existingRecord.Citizenship,
                existingRecord.Address,
                existingRecord.IsActive
                );
        }
    }
}