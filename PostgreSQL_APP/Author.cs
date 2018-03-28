using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL_APP
{
    public class Author
    {
        string firstname = null;
        string name = null;
        string patronymic = null;
        string city = null;

        public Author() { }

        public string AuthorFirstName
        {
            get
            {
                if (firstname != null)
                    return firstname;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    firstname = value;
            }
        }

        public string AuthorName
        {
            get
            {
                if (name != null)
                    return name;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    name = value;
            }
        }

        public string AuthorPatronymic
        {
            get
            {
                if (patronymic != null)
                    return patronymic;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    patronymic = value;
            }
        }

        public string AuthorCity
        {
            get
            {
                if (city != null)
                    return city;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    city = value;
            }
        }

        public string GetProcName
        {
            get
            {
                return "public.insert_author(@fn,@n,@p,@c)";
            }
        }

        public string GetEditProcName
        {
            get
            {
                return "public.upd_author(@i,@fn,@n,@p,@c)";
            }
        }

        public Author GetObj
        {
            get
            {
                return this;
            }
        }
    }
}
