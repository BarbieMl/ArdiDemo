using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Contracts.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable  
    {
        ICustomerRepository CustomerRepository { get; }
        IMedicalRepository MedicalRepository { get; }
        ITravelRepository TravelRepository { get; }
        Task SaveAsync(); 
    }
}
