using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Plateform_RH_Finlogik.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        //it 's used to return the client validations errors that i have thrown by  fluent Validation ( a package that i have installed )
        public List<string> ValdationErrors { get; set; }

        
        public ValidationException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
