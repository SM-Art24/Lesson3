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

namespace Lesson3
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
        private static int CompareArray(int[] array_1, int[] array_2) // Метод сравнивает два массива и возвращает количество общих элементов 
        {
            int GeneralElement = 0;//Количество общих элементов

            for (int i = 0; i < array_1.Length; i++)
            {
                for (int j = 0; j < array_2.Length; j++)
                {
                    if (array_1[i] == array_2[j])//Сравнение каждого элемента массива
                    {
                        GeneralElement++;
                    }
                }
            }
            return GeneralElement;//Возвращаем общее количество
        }
        private  void RandArray (int[] array_1, int[] array_2) // Заполняем массивы случайными числами
        {
            Random rand = new Random();
            for (int i = 0; i < array_1.Length; i++)
            {
                array_1[i] = rand.Next(100);
                textBoxArray1.Text += array_1[i] + " ";
            }

            for (int i = 0; i < array_2.Length; i++)
            {
                array_2[i] = rand.Next(100);

                textBoxArray2.Text += array_2[i] + " ";
            }
            
        }
       //Выход из приложения
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        { //Выводим диалоговое окно
            MessageBoxButton Button = MessageBoxButton.YesNo;
            MessageBoxResult Result =MessageBox.Show("Вы уверены что хотите выйти из приложения?", "Выход", Button);
            if(Result == MessageBoxResult.Yes)
            Environment.Exit(0);
            
        }

        private void Button_Click_Accept(object sender, RoutedEventArgs e)
        {
            
                if ((bool)EnterKeyboard.IsChecked)
                {
                    textBoxResult.Text = null;//Ощищаем строку результатов 

                    int[] array_1 = textBoxArray1.Text.Split(' ').Select(x => int.Parse(x)).ToArray();//Задаём первый массив 
                    int[] array_2 = textBoxArray2.Text.Split(' ').Select(x => int.Parse(x)).ToArray();//Задаём второй массив 
                    textBoxResult.Text += CompareArray(array_1, array_2);//Сравнивам массивы и выводим результат
                }
                else if ((bool)EnterRandom.IsChecked)
                {
                    textBoxArray1.Text = null;
                    textBoxArray2.Text = null;
                    textBoxResult.Text = null;
                    Random rand = new Random();
                //Создаём массивы случайной велечины от 1 до 25
                    int[] array_1 = new int[rand.Next(1, 25)];
                    int[] array_2 = new int[rand.Next(1, 25)];
                    RandArray(array_1, array_2);
                    textBoxResult.Text += CompareArray(array_1, array_2);//Сравнивам массивы и выводим результат
            }
        }
  
    }
}
