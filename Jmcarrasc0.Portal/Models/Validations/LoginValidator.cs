using FluentValidation;
using Jmcarrasc0.Portal.Models.Customizeds;

namespace Jmcarrasc0.Portal.Models.Validations
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Usuario)
                .NotEmpty().WithMessage("Ingrese correo o usuario")
                .NotNull().WithMessage("Campo de identificación en blanco");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Ingrese su contraseña")
                .NotNull().WithMessage("Campo de Contraseña en blanco");
        }
    }
}
