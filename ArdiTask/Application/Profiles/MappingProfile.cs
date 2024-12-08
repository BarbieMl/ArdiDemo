using Application.DTOs;
using Application.Features.Customers.Queries.GetAllCustomer;
using Application.Features.Customers.Queries.GetCustomer;
using Application.Features.Medical.Queries.GetAllMedical;
using Application.Features.Medical.Queries.GetByIdMedical;
using Application.Features.Travel.Queries.GetAllMedical;
using Application.Features.Travel.Queries.GetByIdMedical;
using AutoMapper;
using Domain.Entities;
using Domain.Enumeration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Customer, GetAllCustomerQueryResponse>()
            .ForMember(dest => dest.MedicalPolicies, opt =>
                opt.MapFrom(src => MapMedicalPolicies(src.MedicalPolicies)))
            .ForMember(dest => dest.TravelPolicies, opt =>
                opt.MapFrom(src => MapTravelPolicies(src.TravelPolicies)));

            CreateMap<Customer, GetCustomerQueryResponse>()
                .ForMember(dest => dest.MedicalPolicies, opt =>
                    opt.MapFrom(src => MapMedicalPolicies(src.MedicalPolicies)))
                .ForMember(dest => dest.TravelPolicies, opt =>
                    opt.MapFrom(src => MapTravelPolicies(src.TravelPolicies)));
        
        

            CreateMap<MedicalPolicy, GetMedicalQueryResponse>();
 
            CreateMap<TravelPolicy, GetTravelQueryResponse>();

            CreateMap<MedicalPolicy, GetAllMedicalQueryResponse>();

            CreateMap<TravelPolicy, GetAllTravelQueryResponse>();
        }

        private static List<MedicalPolicyDto>? MapMedicalPolicies(IEnumerable<MedicalPolicy> medicalPolicies)
        {
            return medicalPolicies?.Select(mp => new MedicalPolicyDto
            {
                Id = mp.Id,
                CreateDate = mp.CreateDate,
                IsDeleted = mp.IsDeleted,
                PolicyNumber =mp.PolicyNumber,
                StartDate = mp.StartDate,
                EndDate = mp.EndDate,
                PremiumAmount = mp.PremiumAmount,
                Insurer = mp.Insurer,
                TypeOfPaymentPeriod = mp.TypeOfPaymentPeriod,
                Provider= mp.Provider
            }).ToList();
        }  
        private static List<TravelPolicyDto>? MapTravelPolicies(IEnumerable<TravelPolicy> travelPolicies)
        {
            return travelPolicies?.Select(tp => new TravelPolicyDto
            {
                Id = tp.Id,
                CreateDate = tp.CreateDate,
                IsDeleted = tp.IsDeleted,
                PolicyNumber = tp.PolicyNumber,
                StartDate = tp.StartDate,
                EndDate = tp.EndDate,
                PremiumAmount = tp.PremiumAmount,
                Insurer = tp.Insurer,
                TypeOfTrip = tp.TypeOfTrip,
                TypeOfPaymentPeriod = tp.TypeOfPaymentPeriod,
                Countries = tp.Countries
            }).ToList();
        }
    }
}
