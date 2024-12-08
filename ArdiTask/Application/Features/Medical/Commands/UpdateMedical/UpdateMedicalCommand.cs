using Application.Features.Medical.Commands.CreateMedical;
using Domain.Enumeration;
using MediatR;

namespace Application.Features.Medical.Commands.UpdateMedical
{
    public record UpdateMedicalCommand(
        Guid Id,
        string PolicyNumber,
        DateTime StartDate,
        DateTime EndDate,
        decimal PremiumAmount,
        string Provider,
        string Insurer,
        TypeOfPaymentPeriod TypeOfPaymentPeriod,
        bool IsDeleted
    ) : IRequest<UpdateMedicalCommandResponse>;
}