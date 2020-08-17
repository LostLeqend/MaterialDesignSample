using System.Windows;

namespace MaterialDesignSample.UI.WPF.AttachedProperties
{
    public static class ButtonProperties
    {
        #region CornerRadius (Attached Property)

        /// <summary>
        /// The corner radius property
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
            "CornerRadius", typeof(double), typeof(ButtonProperties), new FrameworkPropertyMetadata(0d));

        public static double GetCornerRadius(DependencyObject sender)
        {
            return (double)sender.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject sender, double value)
        {
            sender.SetValue(CornerRadiusProperty, value);
        }

        #endregion
    }
}
