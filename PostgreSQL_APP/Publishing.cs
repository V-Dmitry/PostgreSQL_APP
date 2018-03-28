using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL_APP
{
    public class Publishing
    {
        string publishingName = null;
        string publishingCity = null;

        public Publishing() { }

        public string PublishingName
        {
            get
            {
                if (publishingName != null)
                    return publishingName;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    publishingName = value;
            }
        }

        public string PublishingCity
        {
            get
            {
                if (publishingCity != null)
                    return publishingCity;
                else return null;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    publishingCity = value;
            }
        }

        public string GetProcName
        {
            get
            {
                return "public.insert_pub(@n, @c)";
            }
        }

        public string GetEditProcName
        {
            get
            {
                return "public.upd_pub(@i,@n, @c)";
            }
        }

        public Publishing GetObj
        {
            get
            {
                return this;
            }
        }
    }
}
