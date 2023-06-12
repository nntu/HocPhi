
using SQLite;
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
