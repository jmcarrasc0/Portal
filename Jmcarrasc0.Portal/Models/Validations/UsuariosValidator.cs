﻿using FluentValidation;
using Jmcarrasc0.Portal.Data;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models.Validations
{
    public class UsuariosValidator : AbstractValidator<Usuarios>
    {

        private readonly PortalContext db;

            public UsuariosValidator(PortalContext _db)
        {
            db = _db;
            RuleFor(u => u.Nombre)
                .NotNull().NotEmpty().WithMessage("Ingrese su Nombre")
                .Length(2, 50).WithMessage("Ingrese un Nombre Valido");
            RuleFor(u => u.Apellido)
              .NotEmpty().WithMessage("Ingrese su Apellido")
              .Length(2, 50).WithMessage("Ingrese un Apellido Valido");

            RuleFor(u => u.Correo)
                .NotNull().NotEmpty().WithMessage("Ingrese su Correo")
                .EmailAddress().WithMessage("Ingrese un correo valido");


            RuleFor(u => u.Username)
                .NotNull().NotEmpty().WithMessage("Ingrese su usuario")
                .Length(2, 50).WithMessage("Ingrese un usuario Valido");


            RuleForEach(u => u.UsuarioPass).SetValidator(new UsuarioPassValidator());
        }

        private async Task<bool> CorreoUnico(string correo)
        {
            var dbUsuario = await db.Usuarios.AnyAsync(x => x.Correo.ToLower().Equals(correo.ToLower()));

            return dbUsuario;
        }

        private async Task<bool> UsuarioUnico(string Username)
        {
            var dbUsuario = await db.Usuarios.AnyAsync(a => a.Username.ToLower().Equals(Username.ToLower()));
            return dbUsuario;
        }


    }
}