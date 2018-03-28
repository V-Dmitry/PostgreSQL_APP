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
                this.Title = "Изменение книги";
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
                this.Title = "Изменение автора";
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
                this.Title = "Изменение полки";
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
                this.Title = "Изменение расположения";
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
                this.Title = "Изменение издательства";
            }
        }

        public Book Book()
        {
            Book book = new Book();
            book.BookName = textBox.Text;
            book.BookPublishing = comboBox1.Text;
            book.PublishingDate = textBox2.Text;
            book.PagesCount = Convert.ToInt32(textBox3.Text);
            return book.GetObj;
        }

        public Author Author()
        {
            Author author = new Author();
            author.AuthorFirstName = textBox.Text;
            author.AuthorName = textBox1.Text;
            author.AuthorPatronymic = textBox2.Text;
            author.AuthorCity = textBox3.Text;
            return author.GetObj;
        }

        public BookShelf BookShelf()
        {
            BookShelf shelf = new BookShelf();
            shelf.ShelfName = textBox.Text;
            shelf.ShelfPosition = textBox1.Text;
            return shelf.GetObj;
        }

        public Location Location()
        {
            Location location = new Location();
            location.AuthorId = Convert.ToInt32(comboBox.SelectedValue);
            location.BookId = Convert.ToInt32(comboBox1.SelectedValue);
            location.ShelfId = Convert.ToInt32(comboBox2.SelectedValue);
            location.BooksCount = Convert.ToInt32(textBox3.Text);
            return location.GetObj;
        }

        public Publishing Publishing()
        {
            Publishing publishing = new Publishing();
            publishing.PublishingName = textBox.Text;
            publishing.PublishingCity = textBox1.Text;
            return publishing.GetObj;
        }

        private void editBut_Click(object sender, RoutedEventArgs e)
        {
            ok = true;
            Close();
        }
    }
}
