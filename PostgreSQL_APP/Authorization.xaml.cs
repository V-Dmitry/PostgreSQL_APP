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
using Unity;

namespace PostgreSQL_APP
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public string name = null;
        public string password = null;
        public string connParam = null;
        public Authorization()
        {
            InitializeComponent();
        }

        private void InitMainForm()
        {
            try
            {
                UnityContainer container = new UnityContainer();
                container.RegisterType<IController, Controller>();
                MainWindow win = container.Resolve<MainWindow>();
                win.Init(connParam);
                win.Show();
                this.Close();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message, "Error");
            }
        }

        public bool CheckUser()
        {
                name = name_box.Text;
                password = pass_box.Password;
                ActiveDirectory ad = new ActiveDirectory();
                if (ad.CheckUser(name, password)) return true;
                else return false;

            }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckUser())
                {
                    connParam = "Server=localhost;Port=5433;Database=Library;User Id=postgres;Password=12345;";
                    InitMainForm();
                }
                else
                {
                    MessageBox.Show("Неверный пользователь!");
                }
            }
            catch (Exception q)
            {
                MessageBox.Show("Ошибка подключения к серверу\n" + q.Message);
            }
        }
    }
}
