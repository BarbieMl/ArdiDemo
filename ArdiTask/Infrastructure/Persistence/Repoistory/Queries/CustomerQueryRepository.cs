using Application.Common.Contracts.Persistence.Command;
using Application.Common.Contracts.Persistence.Query;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper; 

namespace Infrastructure.Persistence.Repoistory.Queries
{
    
    public class CustomerQueryRepository : GenericQueryRepository<Customer>, ICustomerQueryRepository
    {
        private readonly DapperInsuranceDBContext _context;

        public CustomerQueryRepository(DapperInsuranceDBContext context
            )
            : base(context)
        { 
            _context = context ?? throw new ArgumentNullException(nameof(context));
        } 

        public async Task<IEnumerable<Customer>> GetAllWithRelationsAsync()
        { 
            string sql = @"
            SELECT *
            FROM Customers c
            LEFT JOIN MedicalPolicies mp ON c.Id = mp.CustomerId AND mp.IsActive = 1
            LEFT JOIN TravelPolicies tp ON c.Id = tp.CustomerId AND tp.IsActive = 1";

            using var connection =   _context.CreateConnection();
 
             
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
            try
            {
                string sql = "SELECT * FROM Customers WHERE IdNumber = @IdNumber";
                using var connection = _context.CreateConnection();
                
                connection.Open();
                var result = await connection.QueryAsync<Customer>(sql, new { IdNumber });
                return result.FirstOrDefault();
            }
            catch (NpgsqlException ex) when (ex.SqlState == "42P01")
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Customer> GetByIdAsync(Guid Id)
        {
            try
            {

                using var connection =  _context.CreateConnection();

                string sql = @"
                SELECT *
                FROM Customers c
                LEFT JOIN MedicalPolicies mp ON c.Id = mp.CustomerId AND mp.IsActive = 1
                LEFT JOIN TravelPolicies tp ON c.Id = tp.CustomerId AND tp.IsActive = 1
                WHERE c.Id = @Id";

                //if (connection.State == ConnectionState.Closed)
                //{
                //    await connection.OpenAsync();
                //}

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
                    new { Id },
                    splitOn: "MedicalPolicyId,TravelPolicyId"
                );

                return customerEntry;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
