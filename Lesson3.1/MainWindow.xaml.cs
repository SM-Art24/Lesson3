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

namespace Lesson3._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RandArray(int[] array_1)// Заполнение массива случайными числами
        {
            Random rand = new Random();
            for (int i = 0; i < array_1.Length; i++)
            {
                array_1[i] = rand.Next(100);// от 0 до 100
                textBoxArray1.Text += array_1[i] + " ";
            }
        }
        static int MaxNumverIndex(int[] array)// Поиск индекса максимального элемента
        {
            int MaxNumber = 0;
            int MaxIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > MaxNumber) //Проверяем текущее число
                {
                    MaxNumber = array[i];
                    MaxIndex = i;
                }
            }
            return MaxIndex;//Возвращаем индекс наибольшего числа
        }
        private void Button_Click_Accept(object sender, RoutedEventArgs e)
        {
            textBoxResult.Text = null;
            int[] array_1 = textBoxArray1.Text.Split(' ').Select(x => int.Parse(x)).ToArray();// Разбиваем и записываем строку в массив
            textBoxResult.Text += MaxNumverIndex(array_1);// Выводим результат
        }
       
        //Выход из приложения
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            //Выводим диалоговое окно
            MessageBoxButton Button = MessageBoxButton.YesNoCancel;
            MessageBoxResult Result = MessageBox.Show("Выйти из приложения?", "Выход", Button);
            if (Result == MessageBoxResult.Yes)
                Environment.Exit(0);
        }
    }
}
