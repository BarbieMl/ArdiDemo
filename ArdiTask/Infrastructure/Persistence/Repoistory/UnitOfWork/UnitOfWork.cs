using Application.Common.Contracts.Persistence.Command; 
using Application.Common.Contracts.Persistence.UnitOfWork;
using Infrastructure.Persistence.DataContext; 
using System.Data; 

namespace Infrastructure.Persistence.Repoistory.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly IDbTransaction _transaction;
        private readonly DapperInsuranceDBContext _context;

        public bool _disposed;

        public ICustomerRepository CustomerRepository { get; }
        public IMedicalRepository MedicalRepository { get; }
        public ITravelRepository TravelRepository { get; }

        public UnitOfWork(
            DapperInsuranceDBContext dBContext,
            ICustomerRepository customerRepository,
            IMedicalRepository medicalRepository,
            ITravelRepository travelRepository)
        {
            _context = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
            _transaction = _context.OpenConnection().BeginTransaction();
            CustomerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            MedicalRepository = medicalRepository ?? throw new ArgumentNullException(nameof(medicalRepository));
            TravelRepository = travelRepository ?? throw new ArgumentNullException(nameof(travelRepository));
        } 
        public async Task SaveAsync()
        {
            try
            {
                await Task.Run(() => _transaction.Commit());
            }
            catch
            {
                await Task.Run(() => _transaction.Rollback());
                throw;
            }
            finally
            {
                _transaction.Dispose();
            }
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _transaction.Dispose();
                _context.Dispose();
                _disposed = true;
            }
        }
         
    }
     

}
