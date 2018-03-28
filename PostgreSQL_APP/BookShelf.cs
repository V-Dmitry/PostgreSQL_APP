using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL_APP
{
    public class BookShelf
    {
        string shelfName = null;
        string shelfPosition = null;

        public BookShelf() { }

        public string ShelfName
        {
            get
            {
                if (shelfName != null)
                    return shelfName;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    shelfName = value;
            }
        }

        public string ShelfPosition
        {
            get
            {
                if (shelfPosition != null)
                    return shelfPosition;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    shelfPosition = value;
            }
        }

        public string GetProcName
        {
            get
            {
                return "public.insert_shelf(@n , @p)";
            }
        }

        public string GetEditProcName
        {
            get
            {
                return "public.upd_shelf(@i, @n , @p)";
            }
        }

        public BookShelf GetObj
        {
            get
            {
                return this;
            }
        }
    }
}
