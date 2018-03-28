using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL_APP
{
    public class Book
    {
        string bookName = null;
        string publishing = null;
        string publishingDate = null;
        int pagesCount = 0;

        public Book() { }

        public string BookName
        {
            get
            {
                if (bookName != null)
                    return bookName;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    bookName = value;
            }
        }

        public string BookPublishing
        {
            get
            {
                if (publishing != null)
                    return publishing;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    publishing = value;
            }
        }

        public string PublishingDate
        {
            get
            {
                if (publishingDate != null)
                    return publishingDate;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    publishingDate = value;
            }
        }

        public int PagesCount
        {
            get
            {
                if (pagesCount != 0)
                    return pagesCount;
                else return 0;
            }
            set
            {
                if (value > 0 || value < 5000)
                    pagesCount = value;
            }
        }

        public Book GetObj
        {
            get
            {
                return this;
            }
        }

        public string GetProcName
        {
            get
            {
                return "public.insert_book(@n,@ph,@pd,@pc)";
            }
        }
        public string GetEditProcName
        {
            get
            {
                return "public.upd_book(@i,@n,@ph,@pd,@pc)";
            }
        }
    }
}
