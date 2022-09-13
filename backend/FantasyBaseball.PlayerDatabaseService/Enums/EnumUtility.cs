using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FantasyBaseball.PlayerDatabaseService.Enums
{
    /// <summary>Utility methods for the enums.</summary>
    public static class EnumUtility
    {
        /// <summary>Gets the description for the enum (based on the DescriptionAttribute).</summary>
        /// <param name="value">The enum to get the description for.</param>
        /// <returns>The description for the enum (empty string if the attribute isn't set).</returns>
        public static string GetDescription(Enum value)
        {
            var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes != null && attributes.Length > 0 ? (attributes[0] as DescriptionAttribute).Description : string.Empty;
        }

        /// <summary>Gets the enum from the description (based on the DescriptionAttribute).</summary>
        /// <param name="value">The description for the enum.</param>
        /// <returns>The enum for the description (Value = 0 if the description cannot be found).</returns>
        public static T GetFromDescription<T>(string value) where T : Enum => GetValues<T>().FirstOrDefault(v => EqualsIgnoreCase(GetDescription(v), value));

        /// <summary>Gets the enum from the key (based on the name of the enum).</summary>
        /// <param name="value">The key for the enum.</param>
        /// <returns>The enum for the key (Value = 0 if the key cannot be found).</returns>
        public static T GetFromKey<T>(string value) where T : Enum => GetValues<T>().FirstOrDefault(v => EqualsIgnoreCase(v.ToString(), value));

        /// <summary>Gets the enum as a dictionary.</summary>
        /// <returns>The enum as a dictionary.</returns>
        public static Dictionary<int, string> GetValuesAsDictionary<T>() where T : Enum  => GetValues<T>().ToDictionary(e => (int)(object)e, e => GetDescription(e));

        private static bool EqualsIgnoreCase(string v1, string v2) => string.Equals(v1, v2, StringComparison.InvariantCultureIgnoreCase);

        private static IEnumerable<T> GetValues<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>();
    }
}