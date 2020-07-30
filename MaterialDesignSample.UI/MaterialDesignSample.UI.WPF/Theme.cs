using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using MaterialDesignSample.UI.WPF.Brushes;

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

        public static void LoadThemeType(ThemeType type)
        {
            ThemeType = type;

            switch (type)
            {
                case ThemeType.Light:
                    LoadLightTheme();
                    break;
                case ThemeType.Dark:
                    LoadDarkTheme();
                    break;
            }
        }

        private static void LoadLightTheme()
        {
            var lightThemeBrushes = new LightThemeBrushes();
            lightThemeBrushes.InitializeComponent();

            foreach (DictionaryEntry lightThemeBrush in lightThemeBrushes)
            {
                SetResource(lightThemeBrush.Key.ToString(), lightThemeBrush.Value);
            }
        }

        private static void LoadDarkTheme()
        {
            var darkThemeBrushes = new DarkThemeBrushes();
            darkThemeBrushes.InitializeComponent();

            foreach (DictionaryEntry darkThemeBrush in darkThemeBrushes)
            {
                SetResource(darkThemeBrush.Key.ToString(), darkThemeBrush.Value);
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
    }
}
