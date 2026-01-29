using System.Reflection;

namespace ResumeProfile.UI.Helpers
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            if (value == null) return string.Empty;

            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var displayName = field.GetCustomAttribute<DisplayNameAttribute>();
            return displayName?.DisplayName ?? value.ToString();
        }
    }
}
