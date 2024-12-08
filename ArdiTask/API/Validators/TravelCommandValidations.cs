using Application.Features.Travel.Commands.CreateTravel;
using Application.Features.Travel.Commands.DeleteTravel;
using Application.Features.Travel.Commands.UpdateTravel;
using Application.Features.Travel.Queries.GetByIdMedical;
using FluentValidation;

namespace API.Validators
{
    public class GetTravelPolicyCommandValidator : AbstractValidator<GetTravelQuery>
    {
        public GetTravelPolicyCommandValidator()
        {
            
        }
    }

    public class CreateTravelPolicyCommandValidator : AbstractValidator<CreateTravelCommands>
    {
        public CreateTravelPolicyCommandValidator()
        {
            
        }
    }

    public class UpdateTravelPolicyCommandValidator : AbstractValidator<UpdateTravelCommand>
    {
        public UpdateTravelPolicyCommandValidator()
        {

        }
    }

    public class DeleteTravelPolicyCommandValidator : AbstractValidator<DeleteTravelCommand>
    {
        public DeleteTravelPolicyCommandValidator()
        {
            
        }
    }
}
