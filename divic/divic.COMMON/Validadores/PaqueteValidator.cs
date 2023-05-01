using COMMON.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
    public class PaqueteValidator : AbstractValidator<Paquete>
    {
        public PaqueteValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Descripcion).NotEmpty().MaximumLength(100);
            RuleFor(x => x.DireccionEntrega).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Estatus).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Contacto).NotEmpty().MaximumLength(50);
        }
    }
}
