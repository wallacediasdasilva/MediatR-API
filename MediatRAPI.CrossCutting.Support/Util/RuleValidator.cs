using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDAPI.CrossCutting.Support.Util
{
    public class RuleValidator
    {
        private string _errorMessages;

        public static RuleValidator New()
        {
            return new RuleValidator();
        }

        public RuleValidator When(bool hasError, string errorMessage)
        {
            if(hasError)
                _errorMessages += errorMessage + "; " ;

            return this;
        }

        public void ExceptionIfExist()
        {
            if (_errorMessages != null)
                throw new ExceptionDomain(_errorMessages);
        }
    }

    public class ExceptionDomain : ArgumentException
    {
        public List<string> ErrorMessage { get; set; }

        public ExceptionDomain(string message) : base(message)
        {
        }
    }
}
