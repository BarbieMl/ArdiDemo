using Application.Common.Contracts.Persistence.Command; 
using Application.Common.Contracts.Persistence.UnitOfWork;
using Infrastructure.Persistence.DataContext;
using Infrastructure.Persistence.Repoistory.Commands;
using Infrastructure.Persistence.Repoistory.EFCore; 

namespace Infrastructure.Persistence.Repoistory.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {  
        private readonly InsuranceDBContext _context;
        private bool _disposed;

        public ICustomerRepository Customers { get; }

        public IMedicalRepository MedicalRepository { get; }

        public ITravelRepository TravelRepository { get; }

        public UnitOfWork(InsuranceDBContext dBContext,
            ICustomerRepository customerRepository,
            IMedicalRepository medicalRepository,
             ITravelRepository travelRepository)
        {
            _context = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
            Customers = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            MedicalRepository = medicalRepository ?? throw new ArgumentNullException(nameof(medicalRepository));
            TravelRepository = travelRepository ?? throw new ArgumentNullException(nameof(travelRepository));
        }
       
        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
         
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                { 
                    _context?.Dispose();
                } 
                _disposed = true;
            }
        }
    }


}
