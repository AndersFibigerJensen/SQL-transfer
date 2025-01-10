using Microsoft.Data.SqlClient;
using SQL_transfer;
using System.Data.SqlClient;

namespace IMDBOpgave
{
    public interface IInserter
    {
        void InsertTitles(SqlConnection sqlConn, List<Movies> titles);
    }
}