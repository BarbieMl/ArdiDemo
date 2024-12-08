using Application.Features.Medical.Commands.CreateMedical;
using Application.Features.Medical.Commands.DeleteMedical;
using Application.Features.Medical.Commands.UpdateMedical;
using Application.Features.Medical.Queries.GetAllMedical;
using Application.Features.Medical.Queries.GetByIdMedical;
using FluentValidation;

namespace API.Validators
{
    public class GetMedicalPolicyCommandValidator : AbstractValidator<GetMedicalQuery>
    {
        public GetMedicalPolicyCommandValidator()
        {
            
        }
    }

    public class GetAllMedicalPolicyCommandValidator : AbstractValidator<GetAllMedicalQuery>
    {
        public GetAllMedicalPolicyCommandValidator()
        {
            
        }
    }

    public class CreateMedicalPolicyCommandValidator : AbstractValidator<CreateMedicalCommands>
    {
        public CreateMedicalPolicyCommandValidator()
        {
         
        }
    }

    public class UpdateMedicalPolicyCommandValidator : AbstractValidator<UpdateMedicalCommand>
    {
        public UpdateMedicalPolicyCommandValidator()
        {
            
        }
    }

    public class DeleteMedicalPolicyCommandValidator : AbstractValidator<DeleteMedicalCommand>
    {
        public DeleteMedicalPolicyCommandValidator()
        {
            
        }
    }
}
