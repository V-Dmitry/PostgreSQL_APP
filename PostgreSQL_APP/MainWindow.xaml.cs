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

namespace PostgreSQL_APP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        PgSQL pgsql = null;

        DataTable bookDt = null;
        DataTable authorDt = null;
        DataTable shelfDt = null;
        DataTable locationDt = null;
        DataTable pubDt = null;

        string connParam = null;
        #endregion

        #region Initialaze
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Init(string connParam)
        {
            pgsql = new PgSQL(connParam);
            pgsql.Connect();
            bookDt = pgsql.OutTable("out_book()");
            authorDt = pgsql.OutTable("out_author()");
            shelfDt = pgsql.OutTable("out_shelf()");
            locationDt = pgsql.OutTable("out_loc()");
            pubDt = pgsql.OutTable("out_pub()");
            this.connParam = connParam;
        }

        #endregion

        #region Show_table
        private void tableOutBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bookDt = pgsql.OutTable("out_book()");
                BookTable.ItemsSource = bookDt.DefaultView;
                BookTable.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void authorOutBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                authorDt = pgsql.OutTable("out_author()");
                AuthorTable.ItemsSource = authorDt.DefaultView;
                AuthorTable.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void shelfOutBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                shelfDt = pgsql.OutTable("out_shelf()");
                ShelfTable.ItemsSource = shelfDt.DefaultView;
                ShelfTable.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        
        private void locOutBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                locationDt = pgsql.OutTable("out_loc()");
                LocationTable.ItemsSource = locationDt.DefaultView;
                LocationTable.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void outPubBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pubDt = pgsql.OutTable("out_pub()");
                PubTable.ItemsSource = pubDt.DefaultView;
                PubTable.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        #endregion

        #region Book
        private void addBookBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddBook();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void editBookBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditBook();
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void delBookBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DelBook();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Author
        private void addAuthorBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddAuthor();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void editAuthorBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditAuthor();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void delAuthorBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DelAuthor();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Bookshelf
        private void addShelfBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddShelf(); 
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void editShelfBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditShelf();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void delShelfBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DelShelf();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Location 
        private void addLocBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddLoc();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void editLocBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditLoc();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void delLocBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DelLoc();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Publishing
        private void addPubBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddPub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void editPubBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditPub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void delPubBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DelPub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region AddFunctions
        public void AddBook()
        {
            Add("book");
        }

        public void AddAuthor()
        {
            Add("author");
        }

        public void AddShelf()
        {
            Add("shelf");
        }

        public void AddLoc()
        {
            Add("location");
        }
        public void AddPub()
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
                authorDt = pgsql.OutTable("get_author()");
                win.comboBox1.ItemsSource = authorDt.DefaultView;
                win.comboBox1.DisplayMemberPath = "name";
                win.comboBox1.SelectedValuePath = "id";
                bookDt = pgsql.OutTable("get_book()");
                win.comboBox2.ItemsSource = bookDt.DefaultView;
                win.comboBox2.DisplayMemberPath = "name";
                win.comboBox2.SelectedValuePath = "id";
                shelfDt = pgsql.OutTable("get_shelf()");
                win.comboBox3.ItemsSource = shelfDt.DefaultView;
                win.comboBox3.DisplayMemberPath = "name";
                win.comboBox3.SelectedValuePath = "id";
                win.ShowDialog();

                if (win.ok)
                {
                    int id1 = (int)win.comboBox1.SelectedValue;
                    int id2 = (int)win.comboBox2.SelectedValue; 
                    int id3 = (int)win.comboBox3.SelectedValue; 
                    query = win.Query(id1, id2, id3);
                }
            }
            else if (table =="book")
            {
                win = new PostgreSQL_APP.Add(table);
                pubDt = pgsql.OutTable("get_pub()");
                win.comboBox2.ItemsSource = pubDt.DefaultView;
                win.comboBox2.DisplayMemberPath = "name";
                win.comboBox2.SelectedValuePath = "id";
                win.ShowDialog();
                query = win.Query();
            }
            if (win.ok)
            {
                pgsql.Query(query);
                MessageBox.Show("Успешно добавлено");
            }
        }
        #endregion

        #region EditFunctions
        public void EditBook()
        {
            Edit(bookDt, BookTable, "book");
        }

        public void EditAuthor()
        {
            Edit(authorDt, AuthorTable, "author");
        }

        public void EditShelf()
        {
            Edit(shelfDt, ShelfTable, "shelf");
        }

        public void EditLoc()
        {
            Edit(locationDt, LocationTable, "location");
        }

        public void EditPub()
        {
            Edit(pubDt, PubTable, "pub");
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
                authorDt = pgsql.OutTable("get_author()");
                win.comboBox.ItemsSource = authorDt.DefaultView;
                win.comboBox.DisplayMemberPath = "name";
                win.comboBox.SelectedValuePath = "id";
                bookDt = pgsql.OutTable("get_book()");
                win.comboBox1.ItemsSource = bookDt.DefaultView;
                win.comboBox1.DisplayMemberPath = "name";
                win.comboBox1.SelectedValuePath = "id";
                shelfDt = pgsql.OutTable("get_shelf()");
                win.comboBox2.ItemsSource = shelfDt.DefaultView;
                win.comboBox2.DisplayMemberPath = "name";
                win.comboBox2.SelectedValuePath = "id";
                win.comboBox.Text = dt.Rows[num][1].ToString();
                win.comboBox1.Text = dt.Rows[num][2].ToString();
                win.comboBox2.Text = dt.Rows[num][3].ToString();
                win.textBox3.Text = dt.Rows[num][4].ToString();
                win.ShowDialog();
                if (win.ok)
                {
                    int id1 = (int)win.comboBox.SelectedValue;
                    int id2 = (int)win.comboBox1.SelectedValue; ;
                    int id3 = (int)win.comboBox2.SelectedValue; ;
                    query = win.Query(id, id2, id1, id3);
                }
            }
            else if (table == "book")
            {
                pubDt = pgsql.OutTable("get_pub()");
                win.comboBox1.ItemsSource = pubDt.DefaultView;
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
                pgsql.Query(query);
                MessageBox.Show("Успешно изменено\nОбновите таблицу");
            }
        }
        #endregion

        #region DelFunctions
        public void DelBook()
        {
            Del(bookDt, BookTable, "book");
        }

        public void DelAuthor()
        {
            Del(authorDt, AuthorTable, "author");
        }

        public void DelShelf()
        {
            Del(shelfDt, ShelfTable, "shelf");
        }

        public void DelLoc()
        {
            Del(locationDt, LocationTable, "loc");
        }

        public void DelPub()
        {
            Del(pubDt, PubTable, "pub");
        }

        private void Del(DataTable dt, DataGrid dg, string table)
        {
            int num = dg.SelectedIndex;
            if (num == -1) throw new Exception("Не выбрана строка для удаления!");
            int id = (int)dt.Rows[num][0];
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                pgsql.Query("del_" + table + "(" + id + ")");
                MessageBox.Show("Успешно удалено\nОбновите таблицу");
            }
        }
        #endregion

        #region ContextMenyItem
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditBook();
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
                DelBook();
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
                EditAuthor();
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
                DelAuthor();
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
                EditShelf();
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
                DelShelf();
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
                EditLoc();
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
                DelLoc();
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
                EditPub();
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
                DelPub();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region Auto
        private void addBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddAuthors win = new AddAuthors();
                AutoGeneration gen = new AutoGeneration(connParam);
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