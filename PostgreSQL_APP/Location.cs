using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL_APP
{
    public class Location
    {
        int bookId = -1;
        int authorId = -1;
        int shelfId = -1;
        int booksCount = 0;

        public Location() { }

        public int BookId
        {
            get
            {
                if (bookId != -1)
                    return bookId;
                else return -1;
            }
            set
            {
                if (value >= 0 )
                    bookId = value;
            }
        }

        public int AuthorId
        {
            get
            {
                if (authorId != -1)
                    return authorId;
                else return -1;
            }
            set
            {
                if (value >= 0)
                    authorId = value;
            }
        }

        public int ShelfId
        {
            get
            {
                if (shelfId != -1)
                    return shelfId;
                else return -1;
            }
            set
            {
                if (value >= 0)
                    shelfId = value;
            }
        }

        public int BooksCount
        {
            get
            {
                if (booksCount != -1)
                    return booksCount;
                else return -1;
            }
            set
            {
                if (value >= 0 || value < 100000)
                    booksCount = value;
            }
        }

        public string GetProcName
        {
            get
            {
                return "public.insert_loc(@ai,@bi,@si,@c)";
            }
        }

        public string GetEditProcName
        {
            get
            {
                return "public.upd_location(@i,@ai,@bi,@si,@c)";
            }
        }

        public Location GetObj
        {
            get
            {
                return this;
            }
        }
    }
}
