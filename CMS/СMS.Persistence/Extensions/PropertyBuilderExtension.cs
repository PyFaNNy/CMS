using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace СMS.Persistence.Extensions
{
    internal static class PropertyBuilderExtension
    {
        private const int LowLength = 64;
        private const int MediumLength = 128;
        private const int HighLength = 256;
        private const int LongLength = 4000;

        public static PropertyBuilder<string> HasLowMaxLength(this PropertyBuilder<string> propertyBuilder)
        {
            return propertyBuilder.HasMaxLength(LowLength);
        }

        public static PropertyBuilder<string> HasMediumMaxLength(this PropertyBuilder<string> propertyBuilder)
        {
            return propertyBuilder.HasMaxLength(MediumLength);
        }

        public static PropertyBuilder<string> HasHighMaxLength(this PropertyBuilder<string> propertyBuilder)
        {
            return propertyBuilder.HasMaxLength(HighLength);
        }

        public static PropertyBuilder<string> HasLongMaxLength(this PropertyBuilder<string> propertyBuilder)
        {
            return propertyBuilder.HasMaxLength(LongLength);
        }

    }
}
