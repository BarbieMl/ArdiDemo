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
         

        public UnitOfWork(InsuranceDBContext dBContext)
        {
            _context = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
        }
        private ICustomerRepository _customers;
        private IMedicalRepository _medicalPolicies;
        private ITravelRepository _travelRepository; 
         

        public ICustomerRepository CustomerRepository => _customers ??= new CustomerRepository(_context);

        public IMedicalRepository MedicalRepository => _medicalPolicies ??= new MedicalRepository(_context);

        public ITravelRepository TravelRepository => _travelRepository ??= new TravelRepository(_context);
 

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
