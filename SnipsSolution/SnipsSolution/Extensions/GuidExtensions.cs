using System;

namespace SnipsSolution.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Indicates wheter the specified <see cref="Nullable{Guid}"/> is null or empty.
        /// </summary>
        /// <param name="value">Guid to test</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter is <see langword="null"/> or an empty Guid.</returns>
        public static bool IsNullOrEmpty(this Guid? value)
        {
            return value == null || value.Value == Guid.Empty;
        }

        /// <summary>
        /// Indicates whether the specified <see cref="Guid"/> is empty.
        /// </summary>
        /// <param name="value">Guid to test</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter is an empty Guid.</returns>
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }
    }
}