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
    /// Логика взаимодействия для Add_authors.xaml
    /// </summary>
    public partial class AddAuthors : Window
    {
        int count = 0;
        bool ok = false;
        public AddAuthors()
        {
            InitializeComponent();
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value > 0) count = value;
                else throw new Exception("Некорректное число!");
            }
        }

        public bool Ok
        {
            get { return ok; }
        }

        private void addBut_Click(object sender, RoutedEventArgs e)
        {
            ok = true;
            Count = Convert.ToInt32(textBox.Text);
            Close();
        }
    }
}
