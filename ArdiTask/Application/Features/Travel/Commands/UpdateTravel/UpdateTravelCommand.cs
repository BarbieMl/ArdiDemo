using Application.Features.Medical.Commands.CreateMedical;
using Domain.Enumeration;
using MediatR;

namespace Application.Features.Travel.Commands.UpdateTravel
{
    public record UpdateTravelCommand(
        Guid Id,
        string PolicyNumber,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount,
        string Provider,
        string Insurer,
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        bool IsActive,
        TypeOfTrip TypeOfTrip,
        string Countries
    ) : IRequest<UpdateTravelCommandResponse>;
}