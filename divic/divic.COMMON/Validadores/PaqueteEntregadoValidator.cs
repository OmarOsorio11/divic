using COMMON.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
    public class PaqueteEntregadoValidator : AbstractValidator<PaqueteEntregado>
    {
        public PaqueteEntregadoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.IdPaquete).GreaterThan(0);
            RuleFor(x => x.NombreRecibe).NotEmpty().MaximumLength(50);
            RuleFor(x => x.TipoPersonaRecibe).NotEmpty().MaximumLength(50);
            RuleFor(x => x.UrlImagen).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CurpRecibe).MaximumLength(50);
        }
    }
}
