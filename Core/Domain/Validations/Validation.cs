using Core.Domain.Exceptions;
using Core.Domain.Interfaces.Validations;
using System;
using System.Collections.Generic;

namespace Core.Domain.Validations
{
    public abstract class Validation : ISpecificationObject, IDisposable
    {
        private bool disposedValue;

        public List<string> Errors { get; set; }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public bool IsValid()
        {
            return this.Errors.Count <= 0;
        }

        protected void AddError(string error)
        {
            this.Errors.Add(error);
        }

        protected void AddErrors(List<string> errors)
        {
            this.Errors.AddRange(errors);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Errors?.Clear();
                }

                disposedValue = true;
            }
        }

        protected void Validate()
        {
            var listValidation = new List<ValidationException>();
            if (this.IsValid())
                return;

            foreach (var erro in this.Errors)
                listValidation.Add(new ValidationException(erro));
            var message = string.Join(Environment.NewLine, this.Errors);

            throw new ValidationAggregateException(message, listValidation);
        }
    }
}