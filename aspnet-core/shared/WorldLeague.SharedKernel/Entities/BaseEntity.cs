using System;

namespace WorldLeague.SharedKernel.Entities
{
    public abstract class BaseEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; protected set; }

        protected virtual string Check(
            string value,
            string property,
            int maxLength = int.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(property);

            if (value.Length > maxLength)
                throw new ArgumentOutOfRangeException(property);

            return value;
        }
    }
}
