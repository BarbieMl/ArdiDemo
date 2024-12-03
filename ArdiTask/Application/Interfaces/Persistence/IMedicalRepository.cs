using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence
{
    public interface IMedicalRepository
    { 
        Task AddAsync(MedicalPolicy entity, CancellationToken cancellationToken);
        Task UpdateAsync(MedicalPolicy entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
