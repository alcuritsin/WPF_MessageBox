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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public TaskWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            //Point point = Mouse.GetPosition(CanvasWindows);
            //labelX.Content = $"x: {e.GetPosition(null).X}";
            //labelY.Content = $"y: {e.GetPosition(null).Y}";

            Title = $"x: {e.GetPosition(null).X} y: {e.GetPosition(null).Y}";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                this.Close();
                return;
            }

            Point point = e.GetPosition(null);

            // Полезная площадь окна менше заявленной
            // по ширине вычитается 17 пикселей.
            // по высоте вычитается 40 пикселей.

            if (point.X > 10 && point.X < this.Width - 10 - 17 &&
                point.Y > 10 && point.Y < this.Height - 10 - 40)
            {
                //label.Content = "внутри";
                System.Windows.MessageBox.Show("Указанная точка расположена: внутри");
            }
            else if ((point.X == 10 && (point.Y >= 10 && point.Y <= this.Height - 10 - 40)) ||   // на левой границе
                    (point.X == this.Width - 10 - 17 && (point.Y >= 10 && point.Y <= this.Height - 10 - 40)) || // на правой границе
                    (point.Y == 10 && (point.X >= 10 && point.X <= this.Width - 10 - 17)) || // на верхней границе
                    (point.Y == this.Height - 10 - 40 && (point.X >= 10 && point.X <= this.Width - 10 - 17))) // на нижней границе
            {
                //label.Content = "на границе";
                System.Windows.MessageBox.Show("Указанная точка расположена: на границе");
            }
            else
            {
                //label.Content = "снаружи";
                System.Windows.MessageBox.Show("Указанная точка расположена: снаружи");
            }


        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show($"Ширина = {this.Width}, Высота = {this.Height}");
        }
    }
}
