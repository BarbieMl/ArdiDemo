using System.Collections.ObjectModel;

namespace API.Exceptions
{
    public class ValidationAppEcxeption : Exception
    {
        public ValidationAppEcxeption(IReadOnlyDictionary<string, string[]> errors)
            : base("One or more validation errors occured")
            => Errors = errors;

        public IReadOnlyDictionary<string, string[]> Errors { get; }
    }
}
