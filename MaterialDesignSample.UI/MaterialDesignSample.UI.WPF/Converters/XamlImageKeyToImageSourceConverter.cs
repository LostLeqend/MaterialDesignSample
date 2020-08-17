using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MaterialDesignSample.UI.WPF.Controls;

namespace MaterialDesignSample.UI.WPF.Converters
{
    public class XamlImageKeyToImageSourceConverter : MarkupExtension, IValueConverter
    {
        private static XamlImageKeyToImageSourceConverter _converter;

        public double Height { get; set; } = 16;
        public double Width { get; set; } = 16;
        public string ForegroundResourceKey { get; set; } = "GlyphForeground";

        public XamlImageKeyToImageSourceConverter()
        {

        }

        public XamlImageKeyToImageSourceConverter(double height, double width, string foregroundResourceKey)
        {
            Height = height;
            Width = width;
            ForegroundResourceKey = foregroundResourceKey;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new XamlImageKeyToImageSourceConverter(Height, Width, ForegroundResourceKey));
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var keyParsed = Enum.TryParse(ForegroundResourceKey, out ThemeResourceKey foreground);

            if (!(value is ControlTemplate resource) || !keyParsed)
                return null;

            var element = new XamlImage
            {
                Template = resource,
                Foreground = (Brush)Theme.GetResource(foreground),
                Height = Height,
                Width = Width
            };

            element.Measure(new Size((int)element.Width, (int)element.Height));
            element.Arrange(new Rect(new Size((int)element.Width, (int)element.Height)));

            var dpiScale = VisualTreeHelper.GetDpi(element);

            var renderTargetBitmap = new RenderTargetBitmap(
                (int)element.ActualWidth,
                (int)element.ActualHeight,
                dpiScale.PixelsPerInchX,
                dpiScale.PixelsPerInchY,
                PixelFormats.Pbgra32);

            renderTargetBitmap.Render(element);

            return renderTargetBitmap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
