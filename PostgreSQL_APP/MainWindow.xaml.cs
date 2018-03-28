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
using System.Diagnostics;

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
        DataTable indTab = null;

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
        private void AddBook()
        {
            Add win = new PostgreSQL_APP.Add("book");
            pubDt = pgsql.OutTable("get_pub()");
            win.comboBox2.ItemsSource = pubDt.DefaultView;
            win.comboBox2.DisplayMemberPath = "name";
            win.comboBox2.SelectedValuePath = "id";
            win.ShowDialog();
            Book b = win.Book();
            pgsql.SetParamsBook(b.GetProcName, b.BookName, b.BookPublishing, b.PublishingDate, b.PagesCount);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно добавлено");
            }
        }

        private void AddAuthor()
        {
            Add win = new PostgreSQL_APP.Add("author");
            win.ShowDialog();
            Author a = win.Author();
            pgsql.SetParamsAuthor(a.GetProcName, a.AuthorFirstName, a.AuthorName, a.AuthorPatronymic, a.AuthorCity);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно добавлено");
            }
        }

        private void AddShelf()
        {
            Add win = new PostgreSQL_APP.Add("shelf");
            win.ShowDialog();
            BookShelf bs = win.BookShelf();
            pgsql.SetParamsBookShelf(bs.GetProcName, bs.ShelfName, bs.ShelfPosition);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно добавлено");
            }
        }

        private void AddLoc()
        {
            Add win = new PostgreSQL_APP.Add("location");
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
            Location l = win.Location();
            pgsql.SetParamsLocation(l.GetProcName, l.AuthorId, l.BookId, l.ShelfId, l.BooksCount);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно добавлено");
            }
        }
        private void AddPub()
        {
            Add win = new PostgreSQL_APP.Add("pub");
            win.ShowDialog();
            Publishing p = win.Publishing();
            pgsql.SetParamsPublishing(p.GetProcName, p.PublishingName, p.PublishingCity);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно добавлено");
            }
        }
        #endregion

        #region EditFunctions
        private void EditBook()
        {
            Edit win = new PostgreSQL_APP.Edit("book");
            int num = BookTable.SelectedIndex;
            if (num == -1) throw new Exception("Не выбрана строка для изменения!");
            int id = (int)bookDt.Rows[num][0];
            pubDt = pgsql.OutTable("get_pub()");
            win.comboBox1.ItemsSource = pubDt.DefaultView;
            win.comboBox1.DisplayMemberPath = "name";
            win.comboBox1.SelectedValuePath = "id";
            win.textBox.Text = (string)bookDt.Rows[num][1];
            win.comboBox1.Text = (string)bookDt.Rows[num][2];
            win.textBox2.Text = (string)bookDt.Rows[num][3];
            win.textBox3.Text = bookDt.Rows[num][4].ToString();
            win.ShowDialog();
            Book b = win.Book();
            pgsql.SetParamsBook(b.GetEditProcName, b.BookName, b.BookPublishing, b.PublishingDate, b.PagesCount, id);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно изменено\nОбновите таблицу");
            }
        }

        private void EditAuthor()
        {
            Edit win = new PostgreSQL_APP.Edit("author");
            int num = AuthorTable.SelectedIndex;
            if (num == -1) throw new Exception("Не выбрана строка для изменения!");
            int id = (int)authorDt.Rows[num][0];
            win.textBox.Text = (string)authorDt.Rows[num][1];
            win.textBox1.Text = (string)authorDt.Rows[num][2];
            win.textBox2.Text = (string)authorDt.Rows[num][3];
            win.textBox3.Text = authorDt.Rows[num][4].ToString();
            win.ShowDialog();
            Author a = win.Author();
            pgsql.SetParamsAuthor(a.GetEditProcName, a.AuthorFirstName, a.AuthorName, a.AuthorPatronymic, a.AuthorCity, id);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно изменено\nОбновите таблицу");
            }
        }

        private void EditShelf()
        {
            Edit win = new PostgreSQL_APP.Edit("shelf");
            int num = ShelfTable.SelectedIndex;
            if (num == -1) throw new Exception("Не выбрана строка для изменения!");
            int id = (int)shelfDt.Rows[num][0];
            win.textBox.Text = (string)shelfDt.Rows[num][1];
            win.textBox1.Text = (string)shelfDt.Rows[num][2];
            win.ShowDialog();
            BookShelf bs = win.BookShelf();
            pgsql.SetParamsBookShelf(bs.GetEditProcName, bs.ShelfName, bs.ShelfName, id);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно изменено\nОбновите таблицу");
            }
        }

        private void EditLoc()
        {
            Edit win = new PostgreSQL_APP.Edit("location");
            int num = LocationTable.SelectedIndex;
            if (num == -1) throw new Exception("Не выбрана строка для изменения!");
            int id = (int)locationDt.Rows[num][0];
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
            win.comboBox.Text = locationDt.Rows[num][1].ToString();
            win.comboBox1.Text = locationDt.Rows[num][2].ToString();
            win.comboBox2.Text = locationDt.Rows[num][3].ToString();
            win.textBox3.Text = locationDt.Rows[num][4].ToString();
            win.ShowDialog();
            Location l = win.Location();
            pgsql.SetParamsLocation(l.GetEditProcName, l.AuthorId, l.BookId, l.ShelfId, l.BooksCount, id);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно изменено\nОбновите таблицу");
            }
        }

        private void EditPub()
        {
            Edit win = new PostgreSQL_APP.Edit("pub");
            int num = PubTable.SelectedIndex;
            if (num == -1) throw new Exception("Не выбрана строка для изменения!");
            int id = (int)pubDt.Rows[num][0];
            win.textBox.Text = (string)pubDt.Rows[num][1];
            win.textBox1.Text = (string)pubDt.Rows[num][2];
            win.ShowDialog();
            Publishing p = win.Publishing();
            pgsql.SetParamsPublishing(p.GetEditProcName, p.PublishingName, p.PublishingCity, id);
            if (win.ok)
            {
                pgsql.Query();
                MessageBox.Show("Успешно изменено\nОбновите таблицу");
            }
        }
        #endregion

        #region DelFunctions
        private void DelBook()
        {
            Del(bookDt, BookTable, "book");
        }

        private void DelAuthor()
        {
            Del(authorDt, AuthorTable, "author");
        }

        private void DelShelf()
        {
            Del(shelfDt, ShelfTable, "shelf");
        }

        private void DelLoc()
        {
            Del(locationDt, LocationTable, "loc");
        }

        private void DelPub()
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

        #region Index

        int ind = 0;
        int lim = 20;
        int offs = 0;
        bool ok = false;

        private void predBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ind = Convert.ToInt32(indBox.Text);
                if (ind > 1 && offs >= 20)
                {
                    ind -= 1;
                    indBox.Text = Convert.ToString(ind);
                    offs = offs - 20;
                    indTab = pgsql.OutTable("show_auth(" + lim + "," + offs + ")");
                    indexGrid.ItemsSource = indTab.DefaultView;
                    indexGrid.Columns[0].Visibility = Visibility.Collapsed;
                }
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void nextBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ind = Convert.ToInt32(indBox.Text);
                //if (ind  1)
                    ind += 1;
                indBox.Text = Convert.ToString(ind);
                offs = offs + lim;
                indTab = pgsql.OutTable("show_auth("+lim + "," + offs + ")");
                indexGrid.ItemsSource = indTab.DefaultView;
                indexGrid.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void addIndBut_Click(object sender, RoutedEventArgs e)
        {
            if (!ok)
            {
                ok = true;
                pgsql.Query("add_ind()");
            }
        }

        private void delIndBut_Click(object sender, RoutedEventArgs e)
        {
            if (ok)
            {
                ok = false;
                pgsql.Query("del_ind()");
            }
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            indTab = pgsql.OutTable("show_auth(" + lim + "," + offs + ")");
            indexGrid.ItemsSource = indTab.DefaultView;
            indexGrid.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void queryBut_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch s = new Stopwatch();
            try
            {
                string query = queryBox.Text;
                s.Start();
                indTab = pgsql.OutTable2(query);
                s.Stop();
                indexGrid.ItemsSource = indTab.DefaultView;
                indexGrid.Columns[0].Visibility = Visibility.Collapsed;
                label1.Content = Convert.ToString(s.ElapsedMilliseconds);
            }
            catch(Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        #endregion

        #region GotFocus
        private void TabItem_GotFocus_1(object sender, RoutedEventArgs e)
        {
            BookTable.ItemsSource = bookDt.DefaultView;
            BookTable.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void TabItem_GotFocus_2(object sender, RoutedEventArgs e)
        {
            AuthorTable.ItemsSource = authorDt.DefaultView;
            AuthorTable.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void TabItem_GotFocus_3(object sender, RoutedEventArgs e)
        {
            ShelfTable.ItemsSource = shelfDt.DefaultView;
            ShelfTable.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void TabItem_GotFocus_4(object sender, RoutedEventArgs e)
        {
            LocationTable.ItemsSource = locationDt.DefaultView;
            LocationTable.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void TabItem_GotFocus_5(object sender, RoutedEventArgs e)
        {
            PubTable.ItemsSource = pubDt.DefaultView;
            PubTable.Columns[0].Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}