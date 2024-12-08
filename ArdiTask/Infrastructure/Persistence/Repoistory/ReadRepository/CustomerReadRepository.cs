using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.Query;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.DataContext; 
using Npgsql; 
using static Dapper.SqlMapper; 

namespace Infrastructure.Persistence.Repoistory.Queries
{
    
    public class CustomerReadRepository : GenericReadRepository<Customer>, ICustomerReadRepository
    {
        private readonly DapperInsuranceDBContext _context;

        public CustomerReadRepository(DapperInsuranceDBContext context
            )
            : base(context)
        { 
            _context = context ?? throw new ArgumentNullException(nameof(context));
        } 
         
        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        { 
            string sql = @"
            SELECT *
            FROM Customers c
            LEFT JOIN MedicalPolicies mp ON c.Id = mp.CustomerId AND mp.IsDeleted = 0
            LEFT JOIN TravelPolicies tp ON c.Id = tp.CustomerId AND tp.IsDeleted = 0
            ORDER BY c.IdNumber"
            ;

            using var connection =   _context.CreateConnection();
            connection.Open();
            Customer customerEntry = default;

            var customers = await connection.QueryAsync<Customer, MedicalPolicy?, TravelPolicy?, Customer>(
                sql, (customer, medicalPolicy, travelPolicy) =>
                { 
                    if (customer is not null)
                    { 
                        customer.MedicalPolicies = customer.MedicalPolicies ?? new List<MedicalPolicy>();
                        customer.TravelPolicies = customer.TravelPolicies ?? new List<TravelPolicy>();
                        if(customerEntry is null || customerEntry?.IdNumber != customer.IdNumber)
                            customerEntry = customer;
                    }
                     
                    if (medicalPolicy != null)
                    {
                        customerEntry.MedicalPolicies.Add(medicalPolicy);
                    }

                    if (travelPolicy != null)
                    {
                        customerEntry.TravelPolicies.Add(travelPolicy);
                    }

                    return customerEntry;
                }
            );

            return customers.Distinct().ToList(); 
        }
      
        
        public async Task<Customer> GetCustomerByIdAsync(Guid Id)
        {
            try
            {

                using var connection =  _context.CreateConnection();
                connection.Open();

                string sql = @"
                SELECT *
                FROM Customers c
                LEFT JOIN MedicalPolicies mp ON c.Id = mp.CustomerId AND mp.IsDeleted = 0
                LEFT JOIN TravelPolicies tp ON c.Id = tp.CustomerId AND tp.IsDeleted = 0
                WHERE c.Id = @Id";

                Customer customerEntry = default; 

                var result = await connection.QueryAsync<Customer, MedicalPolicy?, TravelPolicy?, Customer>(
                   sql, (customer, medicalPolicy, travelPolicy) =>
                   { 
                           if (customer is not null)
                           {
                               if(customerEntry is null)
                                {
                                    customer.MedicalPolicies = customer.MedicalPolicies ?? new List<MedicalPolicy>();
                                    customer.TravelPolicies = customer.TravelPolicies ?? new List<TravelPolicy>();
                                    customerEntry = customer;
                                }

                               if (medicalPolicy != null)
                               {
                                   customerEntry.MedicalPolicies.Add(medicalPolicy);
                               }

                               if (travelPolicy != null)
                               {
                                   customerEntry.TravelPolicies.Add(travelPolicy);
                               }
                           }

                       return customerEntry;
                   },
                   new { Id }
                 );
                return result.FirstOrDefault();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
