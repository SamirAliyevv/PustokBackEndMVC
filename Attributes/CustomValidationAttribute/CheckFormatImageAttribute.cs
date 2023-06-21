using Pustok.Entities;
using System.ComponentModel.DataAnnotations;

namespace Pustok.Attributes.CustomValidationAttribute
{
    public class CheckFormatImageAttribute:ValidationAttribute
    {
        private readonly string _checkformat;
        private readonly string _checkformat2;

        public CheckFormatImageAttribute(string checkformat,string checkformat2)
        {
            _checkformat = checkformat;
            _checkformat2 = checkformat2;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile)
            {
                var formFile = (IFormFile)value;
                if (formFile.ContentType !=_checkformat)
                {
                    return new ValidationResult($"ImageFile ImageFile must be .jpg,.jpeg or .png {_checkformat} ");

                }



            }

            return ValidationResult.Success;
        }
    }
}
