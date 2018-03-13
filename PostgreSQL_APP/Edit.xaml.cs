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

namespace PostgreSQL_APP
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {

        public string flag = null;

        public bool ok = false;


        public Edit(string flag)
        {
            InitializeComponent();
             this.flag = flag;
            if(flag == "book")
            {
                label.Content = "Название:";
                label1.Content = "Издательство:";
                label2.Content = "Дата издательства:";
                label3.Content = "Кол-во страниц:";
                comboBox.Visibility = Visibility.Collapsed;
                textBox1.Visibility = Visibility.Collapsed;
                comboBox2.Visibility = Visibility.Collapsed;
            }
            else if(flag == "author")
            {
                label.Content = "Фамилия:";
                label1.Content = "Имя:";
                label2.Content = "Отчество:";
                label3.Content = "Город проживания:";
                comboBox.Visibility = Visibility.Collapsed;
                comboBox1.Visibility = Visibility.Collapsed;
                comboBox2.Visibility = Visibility.Collapsed;
            }
            else if (flag == "shelf")
            {
                label.Content = "Название полки:";
                label1.Content = "Расположение:";
                label2.Visibility = Visibility.Collapsed;
                label3.Visibility = Visibility.Collapsed;
                textBox2.Visibility = Visibility.Collapsed;
                textBox3.Visibility = Visibility.Collapsed;
                comboBox.Visibility = Visibility.Collapsed;
                comboBox1.Visibility = Visibility.Collapsed;
                comboBox2.Visibility = Visibility.Collapsed;
            }
            else if (flag == "location")
            {
                label.Content = "Автор:";
                label1.Content = "Название книги:";
                label2.Content = "Полка:";
                label3.Content = "Кол-во книг:";
                textBox.Visibility = Visibility.Collapsed;
                textBox1.Visibility = Visibility.Collapsed;
                textBox2.Visibility = Visibility.Collapsed;
            }
            else if(flag == "pub")
            {
                label.Content = "Название издательства:";
                label1.Content = "Город:";
                label2.Visibility = Visibility.Collapsed;
                label3.Visibility = Visibility.Collapsed;
                textBox2.Visibility = Visibility.Collapsed;
                textBox3.Visibility = Visibility.Collapsed;
                comboBox.Visibility = Visibility.Collapsed;
                comboBox1.Visibility = Visibility.Collapsed;
                comboBox2.Visibility = Visibility.Collapsed;
            }
        }

        public string Query(int id = 0, int id1 = 0, int id2 = 0, int id3 = 0)
        {
            string str = null;
            if (flag == "book")
            {
                str = "select public.upd_book(\'" + id + "\', \'" + textBox.Text + "\', \'" + comboBox1.Text + "\', \'" + textBox2.Text + "\', \'" + textBox3.Text + "\')";
            }
            if (flag == "author")
            {
                str = "select public.upd_author(\'" + id + "\', \'"+ textBox.Text + "\', \'" + textBox1.Text + "\', \'" + textBox2.Text + "\', \'" + textBox3.Text + "\')";
            }
            if (flag == "shelf")
            {
                str = "select public.upd_shelf(\'" + id + "\', \'" + textBox.Text + "\', \'" + textBox1.Text + "\')";
            }
            if (flag == "location")
            {
                str = "select public.upd_location(" + id + ", " + id1 + ", " + id2 + ", " + id3 + ", " + textBox3.Text + ")";
            }
            if (flag == "pub")
            {
                str = "select public.upd_pub(\'" + id + "\', \'" + textBox.Text + "\', \'" + textBox1.Text + "\')";
            }
            return str;
        }

        private void edit_but_Click(object sender, RoutedEventArgs e)
        {
            ok = true;
            Close();
        }
    }
}
