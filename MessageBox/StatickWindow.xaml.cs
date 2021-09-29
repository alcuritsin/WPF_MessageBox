using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MessageBox
{
    /// <summary>
    /// Interaction logic for StatickWindow.xaml
    /// </summary>
    public partial class StatickWindow : Window
    {
        private int startX;
        private int startY;
        private int counterStatick = 0;

        public StatickWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(null);

            startX = (int)point.X;
            startY = (int)point.Y;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(null);

            Title = $"Create statick x: {point.X} y: {point.Y}";

        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(null);

            Rectangle staticPectangle = new Rectangle();

            int rWidth = Math.Abs((int)point.X - startX);
            int rHeigth = Math.Abs((int)point.Y - startY);

            if (rWidth < 10 || rHeigth < 10)
            {
                System.Windows.MessageBox.Show($"Вы попытались создать пряпоугольник с размером w: {rWidth} h: {rHeigth}\n" +
                    $"Минимально возможный размер 10x10.\n" +
                    $"Прямоугольник не создан...", "Отмена создания", MessageBoxButton.OK, MessageBoxImage.Error);
                startX = 0;
                startY = 0;
                return;
            }

            int offsetX = (startX > point.X) ? (int)point.X : startX;
            int offsetY = (startY > point.Y) ? (int)point.Y : startY;

            staticPectangle.Width = rWidth;
            staticPectangle.Height = rHeigth;
            staticPectangle.Fill = new SolidColorBrush(Colors.LightCoral);
            staticPectangle.Stroke = new SolidColorBrush(Colors.DarkBlue);
            staticPectangle.Fill.Opacity = 0.25;
            staticPectangle.RenderTransform = new TranslateTransform (offsetX, offsetY);
             

            CanvasWindow.Children.Add(staticPectangle);
            
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Тут не могу пока придумать...

            Point point = e.GetPosition(null);

            //HitTestResult result = VisualTreeHelper.HitTest(CanvasWindow, point);

            //UIElementCollection chs = CanvasWindow.Children;

            //foreach (object ch in chs)
            //{

            //    Title += ch;
            //}



        }

    }
}
