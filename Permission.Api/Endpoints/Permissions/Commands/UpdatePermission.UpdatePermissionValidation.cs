using FluentValidation;

namespace Permissions.Api.Endpoints.Permissions.Commands
{
    public class UpdatePermissionValidator : AbstractValidator<UpdatePermissionCommand>
    {
        public UpdatePermissionValidator()
        {
            RuleFor(permission => permission.PermissionId).NotEmpty().NotNull();
            RuleFor(permission => permission.UpdateRequest.EmployeeName).NotEmpty();
            RuleFor(permission => permission.UpdateRequest.EmployeeLastName).NotEmpty();
            RuleFor(permission => permission.UpdateRequest.PermissionTypeId).NotEmpty().NotNull();
        }
    }
}
