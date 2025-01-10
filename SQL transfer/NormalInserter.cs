using Microsoft.Data.SqlClient;
using SQL_transfer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBOpgave
{
    public class NormalInserter : IInserter
    {
       

        public int CheckIntForNull(string? value)
        {
            if (value.ToLower() == @"\n")
            {
                return 0;
            }
            return int.Parse(value);
        }

        public string CheckStringForNull(string value)
        {
            if (value.ToLower() == @"\n")
            {
                return "NULL";
            }
            return value;
        }
    }
}
