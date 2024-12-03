using Application.Interfaces.Persistence;
using Domain.Entities;

namespace Infrastructure.Repoistory
{
    public class MedicalRepository : IMedicalRepository
    {
        public Task<MedicalPolicy> Add(Customer customer)
        {
            throw new NotImplementedException();
        }
    }

}
