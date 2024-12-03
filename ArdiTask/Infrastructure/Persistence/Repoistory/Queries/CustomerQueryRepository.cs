using Application.Common.Interfaces.Persistence.Commands;
using Application.Common.Interfaces.Persistence.Queries;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infrastructure.Persistence.Repoistory.Queries
{
    public class CustomerQueryRepository : GenericQueryRepository<Customer>, ICustomerQueryRepository
    {
        private readonly InsuranceDBContext _context;
        public CustomerQueryRepository(InsuranceDBContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Customer>> GetAllWithRelationsAsync()
        {
            using var connection = _context.Database.GetDbConnection();
             
            string sql = @"
            SELECT *
            FROM Customers c
            LEFT JOIN MedicalPolicies mp ON c.Id = mp.CustomerId AND mp.IsActive = 1
            LEFT JOIN TravelPolicies tp ON c.Id = tp.CustomerId AND tp.IsActive = 1";

            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }
             
            var customersDictionary = new Dictionary<Guid, Customer>();

            var customers = await connection.QueryAsync<Customer, MedicalPolicy, TravelPolicy, Customer>(
                sql, (customer, medicalPolicy, travelPolicy) =>
                { 
                    if (!customersDictionary.TryGetValue(customer.Id, out var customerEntry))
                    {
                        customerEntry = customer;
                        customerEntry.MedicalPolicies = new List<MedicalPolicy>();
                        customerEntry.TravelPolicies = new List<TravelPolicy>();
                        customersDictionary.Add(customerEntry.Id, customerEntry);
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
                },
                splitOn: "MedicalPolicyId, TravelPolicyId"  
            );

            return customers.Distinct().ToList(); 
        }

        public async Task<Customer?> GetByIdNumber(string IdNumber)
        {
            using var connection = _context.Database.GetDbConnection();
            string sql = $"SELECT * FROM Customers Where IdNumber = @IdNumber";

            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            return await connection.QueryFirstOrDefaultAsync<Customer>(sql, new { IdNumber = IdNumber });
        }

        public async Task<Customer> GetWithRelationsAsync(Guid Id)
        {
            using var connection = _context.Database.GetDbConnection();

            string sql = @"
                SELECT *
                FROM Customers c
                LEFT JOIN MedicalPolicies mp ON c.Id = mp.CustomerId AND mp.IsActive = 1
                LEFT JOIN TravelPolicies tp ON c.Id = tp.CustomerId AND tp.IsActive = 1
                WHERE c.Id = @Id";

            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            Customer customerEntry = default;

            var customer = await connection.QueryAsync<Customer, MedicalPolicy, TravelPolicy, Customer>(
                sql, (customer, medicalPolicy, travelPolicy) =>
                {
                    if (customerEntry == null)
                    {
                        customerEntry = customer;
                        customerEntry.MedicalPolicies = new List<MedicalPolicy>();
                        customerEntry.TravelPolicies = new List<TravelPolicy>();
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
                },
                new { CustomerId = Id },
                splitOn: "MedicalPolicyId,TravelPolicyId"
            );

            return customerEntry;
        }

    }
}
