namespace CachedRepository.Infrastructure.Exceptions
{
    using System;

    public class UninitializedPropertyException : InvalidOperationException
    {
        private const string UninitializedPropertyExceptionMessage = "Uninitialized property: {0} in type: {1}";

        public UninitializedPropertyException(string typeName, string propertyName)
            : base(string.Format(UninitializedPropertyExceptionMessage, typeName, propertyName))
        {
        }
    }
}
