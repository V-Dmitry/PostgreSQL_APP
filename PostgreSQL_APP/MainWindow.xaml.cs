using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
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
using Npgsql;

namespace PostgreSQL_APP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        public string server = null;
        public string port = null;
        public string name = null;
        public string password = null;
        public string conn_param = null;

        DataTable book_dt = null;
        DataTable author_dt = null;
        DataTable shelf_dt = null;
        DataTable location_dt = null;
        DataTable pub_dt = null;
        #endregion

        #region Initialaze
        public MainWindow()
        {
            InitializeComponent();
        }
        public void def()
        {
            Out_table(ref book_dt, "select * from out_book()");
            Out_table(ref author_dt, "select * from out_author()");
            Out_table(ref shelf_dt, "select * from out_shelf()");
            Out_table(ref location_dt, "select * from out_loc()");
            Out_table(ref pub_dt, "select * from out_pub()");
        }
        #endregion

        #region Query
        private void Out_table(ref DataTable dt, string query)
        {
            NpgsqlConnection dbConnection = new NpgsqlConnection(conn_param);
            dbConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, dbConnection);
            NpgsqlDataAdapter dbDataAdapter = new NpgsqlDataAdapter(command);
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds);
            dt = ds.Tables[0];
            dbConnection.Close();
    }

    public void Query(string query)
        { 
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            com.ExecuteReader();
            con.Close();
        }
        #endregion

        #region Show_table
        private void table_out_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Out_table(ref book_dt, "select * from out_book()");
                Book_table.ItemsSource = book_dt.DefaultView;
                Book_table.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void author_out_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Out_table(ref author_dt, "select * from out_author()");
                Author_table.ItemsSource = author_dt.DefaultView;
                Author_table.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void shelf_out_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Out_table( ref shelf_dt, "select * from out_shelf()");
                Shelf_table.ItemsSource = shelf_dt.DefaultView;
                Shelf_table.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        
        private void loc_out_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Out_table(ref location_dt, "select * from out_loc()");
                Location_table.ItemsSource = location_dt.DefaultView;
                Location_table.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void out_pub_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Out_table(ref pub_dt, "select * from out_pub()");
                Pub_table.ItemsSource = pub_dt.DefaultView;
                Pub_table.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        #endregion

        #region Book
        private void add_book_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add("book");
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void edit_book_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_book();
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void del_book_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Del_book();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Author
        private void add_author_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add_author();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void edit_author_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_author();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void del_author_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Del_author();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Bookshelf
        private void add_shelf_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add_shelf(); 
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void edit_shelf_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_shelf();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void del_shelf_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Del_shelf();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Location 
        private void add_loc_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add_loc();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void edit_loc_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_loc();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void del_loc_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Del_loc();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Publishing
        private void add_pub_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add_pub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void edit_pub_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_pub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void del_pub_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Del_pub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Add_functions
        public void Add_book()
        {
            Add("book");
        }

        public void Add_author()
        {
            Add("author");
        }

        public void Add_shelf()
        {
            Add("shelf");
        }

        public void Add_loc()
        {
            Add("location");
        }
        public void Add_pub()
        {
            Add("pub");
        }

        public void Add(string table)
        {
            Add win = null;
            string query = null;
            if (table != "location" && table != "book")
            {
                win = new PostgreSQL_APP.Add(table);
                win.ShowDialog();
                query = win.Query();
            }
            else if (table == "location")
            {
                win = new PostgreSQL_APP.Add(table);
                Out_table(ref author_dt, "select * from get_author()");
                win.comboBox1.ItemsSource = author_dt.DefaultView;
                win.comboBox1.DisplayMemberPath = "name";
                win.comboBox1.SelectedValuePath = "id";
                Out_table(ref book_dt, "select * from get_book()");
                win.comboBox2.ItemsSource = book_dt.DefaultView;
                win.comboBox2.DisplayMemberPath = "name";
                win.comboBox2.SelectedValuePath = "id";
                Out_table(ref shelf_dt, "select * from get_shelf()");
                win.comboBox3.ItemsSource = shelf_dt.DefaultView;
                win.comboBox3.DisplayMemberPath = "name";
                win.comboBox3.SelectedValuePath = "id";
                win.ShowDialog();

                if (win.ok)
                {
                    //string author = win.comboBox1.Text.ToString();
                    int id1 = (int)win.comboBox1.SelectedValue;
                    //string book = win.comboBox2.Text.ToString();
                    int id2 = (int)win.comboBox2.SelectedValue; 
                    //string shelf = win.comboBox3.Text.ToString();
                    int id3 = (int)win.comboBox3.SelectedValue; 
                    query = win.Query(id1, id2, id3);
                }
            }
            else if (table =="book")
            {
                win = new PostgreSQL_APP.Add(table);
                Out_table(ref pub_dt, "select * from get_pub()");
                win.comboBox2.ItemsSource = pub_dt.DefaultView;
                win.comboBox2.DisplayMemberPath = "name";
                win.comboBox2.SelectedValuePath = "id";
                win.ShowDialog();
                query = win.Query();
            }
            if (win.ok)
            {
                Query(query);
                MessageBox.Show("Успешно добавлено");
            }
        }
        #endregion

        #region Edit_functions
        public void Edit_book()
        {
            Edit(book_dt, Book_table, "book");
        }

        public void Edit_author()
        {
            Edit(author_dt, Author_table, "author");
        }

        public void Edit_shelf()
        {
            Edit(shelf_dt, Shelf_table, "shelf");
        }

        public void Edit_loc()
        {
            Edit(location_dt, Location_table, "location");
        }

        public void Edit_pub()
        {
            Edit(pub_dt, Pub_table, "pub");
        }

        private void Edit(DataTable dt, DataGrid dg, string table)
        {
            Edit win = new PostgreSQL_APP.Edit(table);
            string query = null;
            int num = dg.SelectedIndex;
            if (num == -1) throw new Exception("Не выбрана строка для изменения!");
            int id = (int)dt.Rows[num][0];

            if (table != "location" && table != "book")
            {
                win.textBox.Text = (string)dt.Rows[num][1];
                win.textBox1.Text = (string)dt.Rows[num][2];

                if (table == "author")
                {
                    win.textBox2.Text = (string)dt.Rows[num][3];
                    win.textBox3.Text = dt.Rows[num][4].ToString();
                }
                win.ShowDialog();
                query = win.Query(id);
            }
            else if(table == "location")
            {
                Out_table(ref author_dt, "select * from get_author()");
                win.comboBox.ItemsSource = author_dt.DefaultView;
                win.comboBox.DisplayMemberPath = "name";
                win.comboBox.SelectedValuePath = "id";
                Out_table(ref book_dt, "select * from get_book()");
                win.comboBox1.ItemsSource = book_dt.DefaultView;
                win.comboBox1.DisplayMemberPath = "name";
                win.comboBox1.SelectedValuePath = "id";
                Out_table(ref shelf_dt, "select * from get_shelf()");
                win.comboBox2.ItemsSource = shelf_dt.DefaultView;
                win.comboBox2.DisplayMemberPath = "name";
                win.comboBox2.SelectedValuePath = "id";
                win.comboBox.Text = dt.Rows[num][1].ToString();
                win.comboBox1.Text = dt.Rows[num][2].ToString();
                win.comboBox2.Text = dt.Rows[num][3].ToString();
                win.textBox3.Text = dt.Rows[num][4].ToString();
                win.ShowDialog();
                if (win.ok)
                {
                    //string author = win.comboBox.Text.ToString();
                    int id1 = (int)win.comboBox.SelectedValue;
                    //string book = win.comboBox1.Text.ToString();
                    int id2 = (int)win.comboBox1.SelectedValue; ;
                    //string shelf = win.comboBox2.Text.ToString();
                    int id3 = (int)win.comboBox2.SelectedValue; ;
                    query = win.Query(id, id2, id1, id3);
                }
            }
            else if (table == "book")
            {
                Out_table(ref pub_dt, "select * from get_pub()");
                win.comboBox1.ItemsSource = pub_dt.DefaultView;
                win.comboBox1.DisplayMemberPath = "name";
                win.comboBox1.SelectedValuePath = "id";
                win.textBox.Text = (string)dt.Rows[num][1];
                win.comboBox1.Text = (string)dt.Rows[num][2];
                win.textBox2.Text = (string)dt.Rows[num][3];
                win.textBox3.Text = dt.Rows[num][4].ToString();
                win.ShowDialog();
                query = win.Query(id);
            }
            
            if (win.ok)
            {
                Query(query);
                MessageBox.Show("Успешно изменено\nОбновите таблицу");
            }
        }
        #endregion

        #region Del_functions
        public void Del_book()
        {
            Del(book_dt, Book_table, "book");
        }

        public void Del_author()
        {
            Del(author_dt, Author_table, "author");
        }

        public void Del_shelf()
        {
            Del(shelf_dt, Shelf_table, "shelf");
        }

        public void Del_loc()
        {
            Del(location_dt, Location_table, "loc");
        }

        public void Del_pub()
        {
            Del(pub_dt, Pub_table, "pub");
        }

        private void Del(DataTable dt, DataGrid dg, string table)
        {
            int num = dg.SelectedIndex;
            if (num == -1) throw new Exception("Не выбрана строка для удаления!");
            int id = (int)dt.Rows[num][0];
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Query("select del_" + table + "(" + id + ")");
                MessageBox.Show("Успешно удалено\nОбновите таблицу");
            }
        }
        #endregion

        #region Context_meny_item
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_book();
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Del_book();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
{
            try
            { 
                Edit_author();
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Del_author();
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
{
            try
            {
                Edit_shelf();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
{
            try
            {
                Del_shelf();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
{
            try
            {
                Edit_loc();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
{
            try
            {
                Del_loc();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_pub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            try
            {
                Del_pub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Auto
        private void add_but_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add_authors win = new Add_authors();
                Auto_generation gen = new Auto_generation(conn_param);
                win.ShowDialog();
                if (win.Ok)
                {
                    int count = win.Count;
                    gen.Generation(count);
                    MessageBox.Show("Записи добавлены");
                }
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion
    }
}