using FluentValidation;

namespace Permissions.Api.Endpoints.Permissions.Commands
{
    public class CreatePermissionValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionValidator()
        {
            RuleFor(permission => permission.EmployeeName).NotEmpty();
            RuleFor(permission => permission.EmployeeLastName).NotEmpty();
            RuleFor(permission => permission.PermissionTypeId).NotEmpty().NotNull();
        }
    }
}
