
using SQLite;
using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HocPhi.DataModel;

namespace HocPhi
{
    public class DatabaseHandler
    {
        private SQLiteConnection _db;


        public DatabaseHandler(string database)
        {
            _db = new SQLiteConnection(database);
            _db.CreateTable<LoaiChi>();
            _db.CreateTable<TienNop>();
        }

    }
}
