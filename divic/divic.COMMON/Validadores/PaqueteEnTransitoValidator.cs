using COMMON.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.Validadores
{
    public class PaqueteEnTransitoValidator : AbstractValidator<PaqueteEnTransito>
    {
        public PaqueteEnTransitoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.IdPaquete).GreaterThan(0);
            RuleFor(x => x.IdDelivery).GreaterThan(0);
        }
    }
}
