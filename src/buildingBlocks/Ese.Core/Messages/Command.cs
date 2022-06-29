using FluentValidation.Results;

namespace Ese.Core.Messages
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        { 
            throw new NotImplementedException();
        }
    }
}
