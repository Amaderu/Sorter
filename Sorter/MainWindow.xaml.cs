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

namespace Sorter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] ARR = null; //сортируемый массив
        string result = ""; //для вывода
        List<int[]> arrays = null; //сгруппированные массивы по группам 5 4 3
        int weighing = 0; //кол-во взвешиваний;
        int iterations = 0;//кол-во групп

        public MainWindow()
        {
            InitializeComponent();
        }

        void groubSplit(int[] array)
        {
            //групаа 1(6) - 3 3
            //групаа 2(7) - 3 4
            //групаа 3(3) - 3
            //групаа 4(3) - 4
            //групаа 5 - 5
            int a = ARR.GetLength(0) / 5;
            int b = ARR.GetLength(0) % 5;
            int[] temp;
            int counter = 0;
            if (b == 1)
            {
                arrays = new List<int[]>(a + 1);
                for (int i = 0; i < a + 1; i++)
                {
                    if (i < a - 1)
                        temp = new int[5];
                    else
                        temp = new int[3];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[j] = ARR[counter];
                        counter++;
                    }
                    arrays.Add(temp);
                }
            }
            else if (b == 2)
            {
                arrays = new List<int[]>(a + 1);
                for (int i = 0; i < a + 1; i++)
                {
                    if (i < a - 1)
                        temp = new int[5];
                    else if (i < a)
                        temp = new int[4];
                    else
                        temp = new int[3];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[j] = ARR[counter];
                        counter++;
                    }
                    arrays.Add(temp);
                }
            }
            else if (b > 2)
            {
                arrays = new List<int[]>(a + 1);
                for (int i = 0; i < a + 1; i++)
                {
                    if (i < a)
                        temp = new int[5];
                    else
                        temp = new int[b];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[j] = ARR[counter];
                        counter++;
                    }
                    arrays.Add(temp);
                }
            }
            else
            {
                arrays = new List<int[]>(a);
                for (int i = 0; i < a; i++)
                {
                    temp = new int[5];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[j] = ARR[(i * (temp.Length)) + j];
                    }
                    arrays.Add(temp);
                }
            }

            //int C = Factorial(20) / (Factorial(5) * Factorial(20 - 5));
            //MessageBox.Show(C.ToString(), "Отсортированный массив", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        void readTextBox()
        {
            //char[] separators = " .,/\\/r/n'\"".ToCharArray();
            char[] separators = ";".ToCharArray();
            string[] arrayS = Input.Text.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[arrayS.GetLength(0)];

            if (arrayS.Length > 2)
                try
                {
                    for (int i = 0; i < array.Length; i++)
                        array[i] = int.Parse(arrayS[i]);
                    //int.TryParse(arrayS[i], out array[i]);
                    array.CopyTo(ARR = new int[arrayS.Length], (int)0);

                }
                catch (Exception)
                {
                    MessageBox.Show("Введите массив целых чисел разделённых ';'\n Например: \" 1;2;3;\" ");
                    //throw;
                }

        }
        void addRowToDataBase()
        {
            
        }

        private void sort5(int[] a)
        {
            if (a.Length != 5) return;
            int t;
            if (a[4] < a[0])
            {
                t = a[4]; a[4] = a[0]; a[0] = t;
            }
            if (a[3] < a[1])
            {
                t = a[3]; a[3] = a[1]; a[1] = t;
            }
            if (a[4] < a[3])
            {
                t = a[4]; a[4] = a[3]; a[3] = t;
                t = a[1]; a[1] = a[0]; a[0] = t;
            }
            weighing += 3;

            //now: a[0]<=a[4], a[1]<=a[3]<=a[4]
            //insert a[2] into a[1]<=a[3]<=a[4]
            if (a[3] < a[2])
            {
                t = a[2]; a[2] = a[3];
                if (a[4] < t)
                {
                    a[3] = a[4]; a[4] = t;
                }
                else a[3] = t;

            }
            else if (a[2] < a[1])
            {
                t = a[2]; a[2] = a[1]; a[1] = t;
            }
            weighing += 2;

            //now: a[0]<=a[4], a[1]<=a[2]<=a[3]<=a[4]
            //insert a[0] into a[1]<=a[2]<=a[3]<=a[4]
            if (a[2] < a[0])
            {
                t = a[0]; a[0] = a[1]; a[1] = a[2];
                if (a[3] < t)
                {
                    a[2] = a[3]; a[3] = t;
                }
                else a[2] = t;
            }
            else if (a[1] < a[0])
            {
                t = a[0]; a[0] = a[1]; a[1] = t;
            }
            weighing += 2;
        }
        private void sort4(int[] a)
        {
            if (a.Length != 4) return;
            int t;
            if (a[2] < a[0])
            {
                t = a[2]; a[2] = a[0]; a[0] = t;
            }
            if (a[1] < a[0])
            {
                t = a[0]; a[0] = a[1]; a[1] = t;
            }
            if (a[2] < a[1])
            {
                t = a[2]; a[2] = a[1]; a[1] = t;
            }
            weighing += 3;
            //now сравниваем среднее усли да то двигаемся влево
            if (a[3] < a[1])
            {
                if (a[3] < a[0])
                {
                    //сместить группу из 3 влево
                    t = a[3]; a[3] = a[0]; a[0] = t;
                    t = a[3]; a[3] = a[1]; a[1] = t;
                    t = a[3]; a[3] = a[2]; a[2] = t;
                }
                else
                {
                    t = a[3]; a[3] = a[1]; a[1] = t;
                    t = a[3]; a[3] = a[2]; a[2] = t;
                }
               
            }
            else if (a[3] < a[2])
            {
                t = a[3]; a[3] = a[2]; a[2] = t;
            }
            weighing += 2;
        }

        private void sort3(int[] a)
        {
            if (a.Length != 3) return;
            int t;
            if (a[2] < a[0])
            {
                t = a[2]; a[2] = a[0]; a[0] = t;
            }
            if (a[1] < a[0])
            {
                t = a[0]; a[0] = a[1]; a[1] = t;
            }
            if (a[2] < a[1])
            {
                t = a[2]; a[2] = a[1]; a[1] = t;
            }
            weighing += 3;
        }
        void sortAll()
        {
            for (int i = iterations; i < arrays.Count; i++)
            {
                if (arrays[i].Length == 5) sort5(arrays[i]);
                else if (arrays[i].Length == 4) sort4(arrays[i]);
                else sort3(arrays[i]);
            }
        }
        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (ARR == null)
            {
                readTextBox();
                groubSplit(ARR);
            }
            if (iterations < arrays.Count)
            {
                int oldWeight = weighing;
                //for (int i = iterations; i < arrays.Count; i++)
                //{
                //    for (int j = 0; j < arrays[i].Length; j++)
                //        result += arrays[i][j] + ";";
                //}
                //history.Text += $"Группа: ({concatArray(arrays[iterations])})";
                if (arrays[iterations].Length == 5) sort5(arrays[iterations]);
                else if (arrays[iterations].Length == 4) sort4(arrays[iterations]);
                else sort3(arrays[iterations]);
                //history.Text += $" | Взвешиваний: {weighing - oldWeight}\n";
                DataTable1.Items.Add(new group { GroupNumber=iterations+1, SourceMass = concatArray(arrays[iterations]), SortedMass = (weighing - oldWeight).ToString() }); 

                sorted.Text += concatArray(arrays[iterations]);
                iterations++;
                weighingsCount.Content = weighing;
            }
        }
        string concatArray(int[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + ";";
            }
            return result;
        }

        private void Button_Click_Sort(object sender, RoutedEventArgs e)
        {
            readTextBox();
            groubSplit(ARR);
            sortAll();
            for (int i = 0; i < arrays.Count; i++)
            {
                sorted.Text += concatArray(arrays[i]);
            }
            weighingsCount.Content = weighing;
            //MessageBox.Show(result, "Отсортированный массив", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox TextBox)
            {
                string str = new string(TextBox.Text.Where(ch => (ch >= '0' && ch <= '9') || ch == ';').ToArray());
                if (str.Length > 2 && str[str.Length - 2] == ';' && str[str.Length - 1] == ';')
                    str = str.Remove(str.Length - 1);
                else if (str.Where((n) => n == ';').Count() == 1 && str.Length == 1)
                {
                    str = str.Remove(str.Length - 1);
                }
                //else if (str.Where((n) => n == ';').Count() > 1)
                //{
                //    str = str.Remove(str.Length - 1);
                //}
                TextBox.SelectionStart = str.Length;
                TextBox.Text = str;
            }
        }
        #region Для тестов
        public int[] sort_five(int[] a)
        {
            if (a.Length != 5) return null;
            int t;
            if (a[4] < a[0])
            {
                t = a[4]; a[4] = a[0]; a[0] = t;
            }
            if (a[3] < a[1])
            {
                t = a[3]; a[3] = a[1]; a[1] = t;
            }
            if (a[4] < a[3])
            {
                t = a[4]; a[4] = a[3]; a[3] = t;
                t = a[1]; a[1] = a[0]; a[0] = t;
            }
            weighing += 3;

            //now: a[0]<=a[4], a[1]<=a[3]<=a[4]
            //insert a[2] into a[1]<=a[3]<=a[4]
            if (a[3] < a[2])
            {
                t = a[2]; a[2] = a[3];
                if (a[4] < t)
                {
                    a[3] = a[4]; a[4] = t;
                }
                else a[3] = t;
                weighing += 2;

            }
            else if (a[2] < a[1])
            {
                t = a[2]; a[2] = a[1]; a[1] = t;
                weighing++;

            }
            return a;
        }
        #endregion

        private void Button_Click_del(object sender, RoutedEventArgs e)
        {
            DataTable1.Items.Clear();
            weighingsCount.Content = 0;
        }
        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Введите массив целых чисел разделённых ';'\nНапример: \"1;2;3;\" ");
        }
    }
    public class group
    {
        public int GroupNumber { get; set; }
        public string SourceMass { get; set; }
        public string SortedMass { get; set; }
    }
}
