using FluentValidation;

namespace Jmcarrasc0.Portal.Models.Validations
{
    public class UsuarioPassValidator : AbstractValidator<UsuarioPass>
    {

        public UsuarioPassValidator()
        {
            RuleFor(p => p.Pass)
                .NotNull().NotEmpty().WithMessage("Ingrese su contraseña")
                .Length(8, 20).WithMessage("La contraseña debe contener un rango de 8 a 20 caracteres")
                .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos 1 letra en Mayúsculas")
                .Matches("[a-z]").WithMessage("La contraseña debe contener al menos 1 letra en Minúsculas")
                .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número")
                .Matches("[^a-zA-Z0-9]").WithMessage("La contraseña debe contener alguno de estos símbolos ~!@#$%^&*()_+=?><., /");

        }


    }
}
