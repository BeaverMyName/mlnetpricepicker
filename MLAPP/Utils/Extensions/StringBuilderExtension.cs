using System.Text;

namespace MLAPP.Utils.Extensions
{
    public static class StringBuilderExtension
    {
        public static StringBuilder ValidateAndAppendRequest(this StringBuilder builder, string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? builder.Append($" {value}") : builder;
        }
    }
}
