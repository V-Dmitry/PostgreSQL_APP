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
using System.Data;

namespace PostgreSQL_APP
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public string name = null;
        public string phouse = null;
        public string pdate = null;
        public string pcount = null;
        public string surname = null;
        public string patronymic = null;
        public string city = null;
        public string position = null;

        public string flag = null;

        public bool ok = false;
        
        public Add() { }
        public Add(string flag)
        {
            InitializeComponent();
            this.flag = flag;
            if(flag == "book")
            {
                label.Content = "Название:";
                label1.Content = "Издательство:";
                label2.Content = "Дата издательства:";
                label3.Content = "Кол-во страниц:";
                comboBox1.Visibility = Visibility.Collapsed;
                textBox2.Visibility = Visibility.Collapsed;
                comboBox3.Visibility = Visibility.Collapsed;
                this.Title = "Добавление книги";
            }
            else if(flag == "author")
            {
                label.Content = "Фамилия:";
                label1.Content = "Имя:";
                label2.Content = "Отчество:";
                label3.Content = "Город проживания:";
                comboBox1.Visibility = Visibility.Collapsed;
                comboBox2.Visibility = Visibility.Collapsed;
                comboBox3.Visibility = Visibility.Collapsed;
                this.Title = "Добавление автора";
            }
            else if (flag == "shelf")
            {
                label.Content = "Название полки:";
                label1.Content = "Расположение:";
                label2.Visibility = Visibility.Collapsed;
                label3.Visibility = Visibility.Collapsed;
                textBox3.Visibility = Visibility.Collapsed;
                textBox4.Visibility = Visibility.Collapsed;
                comboBox1.Visibility = Visibility.Collapsed;
                comboBox2.Visibility = Visibility.Collapsed;
                comboBox3.Visibility = Visibility.Collapsed;
                this.Title = "Добавление полки";
            }
            else if (flag == "location")
            {
                label.Content = "Автор:";
                label1.Content = "Название книги:";
                label2.Content = "Полка:";
                label3.Content = "Кол-во книг:";
                this.Title = "Добавление расположения";
            }
            else if (flag == "pub")
            {
                label.Content = "Название издательства:";
                label1.Content = "Город:";
                label2.Visibility = Visibility.Collapsed;
                label3.Visibility = Visibility.Collapsed;
                textBox3.Visibility = Visibility.Collapsed;
                textBox4.Visibility = Visibility.Collapsed;
                comboBox1.Visibility = Visibility.Collapsed;
                comboBox2.Visibility = Visibility.Collapsed;
                comboBox3.Visibility = Visibility.Collapsed;
                this.Title = "Добавление издательства";
            }
        }

        public Book Book()
        {
            Book book = new Book();
            book.BookName = textBox1.Text;
            book.BookPublishing = comboBox2.Text;
            book.PublishingDate = textBox3.Text;
            book.PagesCount = Convert.ToInt32(textBox4.Text);
            return book.GetObj;
        }

        public Author Author()
        {
            Author author = new Author();
            author.AuthorFirstName = textBox1.Text;
            author.AuthorName = textBox2.Text;
            author.AuthorPatronymic = textBox3.Text;
            author.AuthorCity = textBox4.Text;
            return author.GetObj;
        }

        public BookShelf BookShelf()
        {
            BookShelf shelf = new BookShelf();
            shelf.ShelfName = textBox1.Text;
            shelf.ShelfPosition = textBox2.Text;
            return shelf.GetObj;
        }

        public Location Location()
        {
            Location location = new Location();
            location.AuthorId = Convert.ToInt32(comboBox1.SelectedValue);
            location.BookId = Convert.ToInt32(comboBox2.SelectedValue);
            location.ShelfId = Convert.ToInt32(comboBox3.SelectedValue);
            location.BooksCount = Convert.ToInt32(textBox4.Text);
            return location.GetObj;
        }

        public Publishing Publishing()
        {
            Publishing publishing = new Publishing();
            publishing.PublishingName = textBox1.Text;
            publishing.PublishingCity = textBox2.Text;
            return publishing.GetObj;
        }

        private void addBut_Click(object sender, RoutedEventArgs e)
        {
            ok = true;
            Close();
        }
    }
}
