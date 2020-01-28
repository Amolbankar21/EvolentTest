using EvolentTest.Utility;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentTest.DAL.Model
{

	public class ContactValidator : AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50).WithMessage(Contants.FirstNameRequired);
			RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(Contants.EmailRequired);
			RuleFor(x => x.LastName).NotEmpty().MaximumLength(50).WithMessage(Contants.LastNameRequired);
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(Contants.PhoneNumberRequired);
		}
	}
}
