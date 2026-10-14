using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2026_wpfapp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color StrokeColor = Colors.Black;
        Color fillColor =Colors.Transparent;
        int strokeThickness = 1;
        string shapeType= "Line";
        public MainWindow()
        {
            InitializeComponent();
            StrokeColorPicker.SelectedColor = StrokeColor;
            FillColorPicker.SelectedColor = fillColor;
        }

        private void ShapeButton_Checked(object sender, RoutedEventArgs e)
        {
            var targetButton = sender as RadioButton;
            shapeType = targetButton.Tag.ToString();
            DisplayStatus();
        }

        private void StrokeColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (StrokeColorPicker.SelectedColor.HasValue)
            {
                StrokeColor = StrokeColorPicker.SelectedColor.Value;
                DisplayStatus();
            }
        }

        private void DisplayStatus()
        {
            if (ColorLabel != null) ColorLabel.Content = $"筆刷色彩:{StrokeColor}        填充色彩:{fillColor}        筆刷粗細：{strokeThickness}";
            if (ShapeLabel != null) ShapeLabel.Content = $"形狀:{shapeType}";
        }

        private void FillColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (FillColorPicker.SelectedColor.HasValue)
            {
                fillColor = FillColorPicker.SelectedColor.Value;
                DisplayStatus();
            }
        }

        private void ThickenessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strokeThickness = (int)ThickenessSlider.Value;
            DisplayStatus();
        }
    }
}