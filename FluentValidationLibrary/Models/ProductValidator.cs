using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationLibrary.Models
{
    public class ProductValidator : AbstractValidator<Product>
    {
		public ProductValidator()
		{
			RuleFor(x => x.Name).Length(0, 20);
			RuleFor(x => x.Cost).InclusiveBetween(100,200).WithMessage("El Costo debe estar entre 100 y 500");
            RuleFor(y => y.Brand).NotEmpty().WithMessage("Es necesario ingresar una Marca");

            RuleFor(y => y.Description).MaximumLength(60).WithMessage("Máximo 60 caracteres para la Descripción");
            RuleFor(z => z.Price).GreaterThan(0).WithMessage("El Precio debe ser un número mayor a 0");


            //RuleSet("ConjuntoValidaciones", () => {
            //    RuleFor(y => y.Description).MaximumLength(60).WithMessage("Máximo 60 caracteres para la Descripción");
            //    RuleFor(z => z.Price).GreaterThan(0).WithMessage("El Precio debe ser un número mayor a 0");
            //});

        }
	}
}
