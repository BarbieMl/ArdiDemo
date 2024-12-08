using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PolicyNumberGenerator
    {
        public string GenerateRandomPolicyNumber()
        {
            var random = new Random();
            var randomString = new string(Enumerable.Range(0, 10) 
                .Select(_ => "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[random.Next(0, 36)])  
                .ToArray());

            return $"P{randomString}";
        }
    }
}
