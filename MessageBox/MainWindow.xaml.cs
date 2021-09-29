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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_resume_OnClick(object sender, RoutedEventArgs e)
        {
            int counter_text = 0;
            int counter_mb = 0;

            string msg = "Message boxe 1";
            counter_text += msg.Length;
            counter_mb++;
            System.Windows.MessageBox.Show(msg, "Resume");
            msg = "Message boxe 2";
            counter_text += msg.Length;
            counter_mb++;
            System.Windows.MessageBox.Show(msg, "Resume");
            msg = "Message boxe 3";
            counter_text += msg.Length;
            counter_mb++;
            System.Windows.MessageBox.Show(msg, $"Resume avr: = {counter_text / counter_mb} count_mb: = {counter_mb}");
        }

        private void Button_find_number_OnClick(object sender, RoutedEventArgs e)
        {
            string caption = "Угадай число.";
            bool exit = false;
            int counter_game = 0;

            do
            {
                counter_game++;

                System.Windows.MessageBox.Show(
                    "Загадайте число от 1 до 2000",
                    caption, MessageBoxButton.OK, MessageBoxImage.Information);

                int count_attempt = 0; // Счетчик попыток.
                bool number_find = false;

                int left_number = 0;
                int right_number = 2000;

                MessageBoxResult answer;
                int result;

                do
                {
                    count_attempt++;
                    // Предпологаем, число пользователя
                    if ((right_number - left_number) != 1)
                    {
                        result = (right_number - left_number) / 2 + left_number;
                    }
                    else
                    {
                        result = left_number + 1;
                    }


                    answer = System.Windows.MessageBox.Show(
                        $"Ваше число {result}?",
                        caption,
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (answer == MessageBoxResult.Yes)
                    {
                        number_find = true;
                    }
                    else
                    {
                        answer = System.Windows.MessageBox.Show(
                            $"Ваше число больше {result}?",
                            caption,
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question);

                        if (answer == MessageBoxResult.Yes)
                        {
                            left_number = result;
                        }
                        else
                        {
                            right_number = result;
                        }
                    }
                } while (!number_find);

                answer = System.Windows.MessageBox.Show(
                    $"Число угадано за {count_attempt} попыток.\nЖелаете сыграть ещё раз?",
                    caption,
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (answer == MessageBoxResult.No)
                {
                    exit = true;
                }
            } while (!exit);

            System.Windows.MessageBox.Show(
                $"Сыграно {counter_game} игр.",
                caption,
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void Button_New_Windows(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();

            taskWindow.Show();
        }

        private void Button_StatickPaint_Click(object sender, RoutedEventArgs e)
        {
            StatickWindow statickWindow = new StatickWindow();

            statickWindow.Show();
        }
    }
}