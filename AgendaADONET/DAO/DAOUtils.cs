using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaADONET.DAO
{
    public class DAOUtils
    {
        public static DbConnection GetConexao()
        {
            DbConnection conexao = new SqlConnection(@"Server=David-pc;Database=TreinaWebCSharpIntermediario;User Id=sa;Password = ludmira0; ");
            conexao.Open();
            return conexao;
        }

        public static DbCommand GetComando(DbConnection conexao)
        {
            DbCommand comando = conexao.CreateCommand();
            return comando;
        }

        public static DbDataReader GetDbDataReader(DbCommand comando)
        {
            return comando.ExecuteReader();
        }
    }
}
