using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence.Medical
{
    public interface IMedicalRepository
    {
        Task Add(Customer customer);
    }
}
