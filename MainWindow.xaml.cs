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

namespace ListaZakupow
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (progresBar.Value < 100)
            {
                if (textBox.Text.Length > 0)
                {
                    if (listBox.Items.Contains(textBox.Text))
                    {
                        //inaczej niz w win forms
                        MessageBoxResult result = MessageBox.Show("Element juz istnieje. Czy chcesz dodac?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    listBox.Items.Add(textBox.Text);
                    textBox2.Text = listBox.Items.Count.ToString();// zliczanie po dodaniu
                    AktualizujPostep();

                    //if (checkBox.Checked)
                    // {
                    textBox.Text = "";
                    //}
                    //else { 
                    //}
                }
                else
                {
                    MessageBox.Show("Wartosc nie moze byc pusta", "Blad", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Lista jest pelna", "Blad", MessageBoxButton.OK);
            }
         }

        private void AktualizujPostep()
        {
            int i = listBox.Items.Count;
            progresBar.Value = i * 10; // bo mamy do 100 kazde 10 to 10%

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "CheckBox zaznaczony"; 
        }
       
        private void checkBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {//usun

            int i = listBox.SelectedIndex;// jesli niec nie zaznaczone zwraca -1
            if ( i != -1)
            {
                listBox.Items.RemoveAt(i);//usowa
                textBox2.Text = listBox.Items.Count.ToString();
                AktualizujPostep(); //wywolanie metody zmniejsza liste
            }
            else
            {
                MessageBox.Show("Zaden element nie zostal zaznaczony", "Blad", MessageBoxButton.OK);
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            textBox2.Text= " ";
            AktualizujPostep();
        }
    }
}
