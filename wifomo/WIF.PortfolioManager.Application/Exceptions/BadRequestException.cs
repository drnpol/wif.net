using FluentValidation.Results;

namespace WIF.PortfolioManager.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {

            Dictionary<string, string[]> validationErrors = new(); // custom dict for now.

            foreach (var error in validationResult.Errors)
            {
                validationErrors.Add(error.PropertyName, new string[] { error.ErrorMessage }); 
            }
        }

        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }

}
