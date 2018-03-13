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
using Npgsql;

namespace PostgreSQL_APP
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public string server = null;
        public string port = null;
        public string name = null;
        public string password = null;
        public string conn_param = null;
        public Authorization()
        {
            InitializeComponent();
        }

        private void ConnectToDb()
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(conn_param);
                conn.Open(); 
                conn.Close(); 
                MainWindow win = new MainWindow();
                win.server = this.server;
                win.port = this.port;
                win.name = this.name;
                win.password = this.password;
                win.conn_param = this.conn_param;
                win.def();
                win.Show();
                this.Close();
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message, "Error");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            server = server_box.Text;
            port = port_box.Text;
            name = name_box.Text;
            password = pass_box.Password;
            conn_param = "Server=" + server + ";Port=" + port + ";Database=Library;User Id=" + name + ";Password=" + password + ";";
            ConnectToDb();
        }
    }
}
