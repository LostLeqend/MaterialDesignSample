using System;
using System.Windows;
using System.Windows.Media;

namespace MaterialDesignSample.UI.WPF
{
    public sealed class Theme
    {
        [ThreadStatic] private static ResourceDictionary _resourceDictionary;

        internal static ResourceDictionary ResourceDictionary
        {
            get
            {
                if (_resourceDictionary != null)
                    return _resourceDictionary;

                _resourceDictionary = new ResourceDictionary();
                LoadThemeType(ThemeType.Light);
                return _resourceDictionary;
            }
        }

        public static ThemeType ThemeType { get; set; } = ThemeType.Light;

        private static void LoadThemeType(ThemeType type)
        {
            ThemeType = type;

            switch (type)
            {
                case ThemeType.Light:
                    break;
                case ThemeType.Dark:
                    break;
            }
        }

        public static object GetResource(ThemeResourceKey resourceKey)
        {
            return ResourceDictionary.Contains(resourceKey.ToString())
                ? ResourceDictionary[resourceKey.ToString()]
                : null;
        }

        internal static void SetResource(object key, object resource)
        {
            ResourceDictionary[key] = resource;
        }

        internal static Color ColorFromHex(string colorHex)
        {
            return (Color?) ColorConverter.ConvertFromString(colorHex) ?? Colors.Transparent;
        }
    }
}
