using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace My_Agenda
{
    class Conexion
        
    {
        public static SQLiteConnection Conectar()
        {
            string database = Application.StartupPath + "\\myagenda.db;";
            SQLiteConnection cn = new SQLiteConnection("Data Source = " + database);
            return cn;
        }
    }
}
