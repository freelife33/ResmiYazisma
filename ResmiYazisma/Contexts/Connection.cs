using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResmiYazisma.Contexts
{
    public class Connection
    {
        public void connection1()
        {
            DbConnection context = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\\dbResmiYazismalar.accdb");
        }
        
        public DbConnection connection()
        {

            return  new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\\dbResmiYazismalar.accdb");
        }
    }
}
