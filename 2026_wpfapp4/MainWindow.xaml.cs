using System.Security.Cryptography.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
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
        string actionType = "Draw";
        Point start = new Point { X = 0, Y = 0 };
        Point end = new Point { X=0, Y= 0 };

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
            if (StatusLabel != null)
            {
                if(actionType == "Draw")
                {
                    StatusLabel.Content = $"圖形:{shapeType}  座標: ({start.X:F0}, {start.Y:F0}) 到 ({end.X:F0}, {end.Y:F0})";
                }
                else
                {
                    StatusLabel.Content = "選擇模式";
                }
            }
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

        private void MyCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MyCanvas.Cursor = Cursors.Pen;//設定滑鼠游標為鉛筆
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyCanvas.Cursor = Cursors.Cross;//設定滑鼠游標為十字
            start = e.GetPosition(MyCanvas);//取得滑鼠按下時的座標位置

            if  (actionType == "Draw")
            {
                    switch (shapeType)//判斷要畫的形狀
                {
                        case "Line":
                        Line line = new Line
                        {
                            X1 = start.X,
                            Y1 = start.Y,
                            X2 = end.X,
                            Y2 = end.Y,
                            Stroke = Brushes.Gray,
                            StrokeThickness=1
                        };
                        MyCanvas.Children.Add(line);
                        break;
                        case "Rectangle":
                        Rectangle rect = new Rectangle
                        {
                            Stroke = Brushes.Gray,
                            Fill = Brushes.LightGreen
                        };
                        MyCanvas.Children.Add(rect);
                        
                        break;
                        case "Ellipse":
                            break;
                        case "polyline":
                            break; 
                    }
            }
            DisplayStatus();
        }

      private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            end = e.GetPosition(MyCanvas);//取得滑鼠放開時的座標位置
            DisplayStatus();

            switch (actionType)
                {
                case "Draw":
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {)

            }
        }
    }

        private void StatusBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Brush strokeBrush = new SolidColorBrush(StrokeColor);
            Brush fillBrush = new SolidColorBrush(fillColor);

            switch (shapeType)
            {
                case "Line":
            }
        }
    }