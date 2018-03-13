using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PostgreSQL_APP
{
    class Auto_generation
    {
        string conn_param = null;

        string[] surnames = {"Петров", "Иванов", "Астахов", "Булгаков", "Булдаков", "Достоевский", "Александров", "Тургенев", "Павлов", "Арсеньев", "Хованский", "Загитов", "Боярский", "Минтагиров", "Тютчев", "Толстой", "Маяковский", "Остапов", "Девятченко", "Петренко", "Турутов", "Степанов"};
        string[] names = { "Иван", "Александр", "Олег", "Дмитрий", "Афанасий", "Эдуард", "Михаил", "Алексей", "Максим", "Пётр", "Ярослав", "Евгений", "Павел", "Иннокентий", "Николай", "Василий", "Рустам", "Артур", "Фёдор", "Лев", "Виктор", "Степан", "Сергей", "Владимир", "Евгений", "Юрий" };
        string[] secondnames = {"Александрович", "Дмитриевич", "Сергеевич", "Андреевич", "Иванович", "Рустамович", "Владимирович", "Афанасьевич", "Олегович", "Павлович", "Юрьевич", "Алексеевич", "Эдуардович", "Петрович", "Михайлович", "Евгеньевич", "Степанович", "Иоанович" };
        string[] cities = {"Ижевск", "Москва", "Пермь", "Екатеринбург", "Саратов", "Глазов", "Санкт-Петербург", "Иваново", "Березники", "Нижний Новгород", "Петропавловск", "Владимир", "Киев", "Киров", "Астрахань", "Норильск", "Когалым", "Братск", "Волгоград", "Калуга", "Коломна", "Красноярск", "Нижний тагил" };

        private Auto_generation() { }
        public Auto_generation(string conn_param)
        {
            this.conn_param = conn_param;
        }

        public void Generation(int count)
        {
            Random rnd = new Random();
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            for (int i = 0; i != count; i++)
            {
                string query = Query(rnd);
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand(query, con);
                com.ExecuteReader();
                con.Close();
            }
        }

        string Query(Random rnd)
        {
            string str = "select public.insert_author(\'" + surnames[rnd.Next(0, surnames.Length - 1)] + "\',\'" + names[rnd.Next(0, names.Length - 1)] + "\',\'" + secondnames[rnd.Next(0, secondnames.Length - 1)] + "\',\'" + cities[rnd.Next(0, cities.Length - 1)] + "\')";
            return str;
        }
    }
}
