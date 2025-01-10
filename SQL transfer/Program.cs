// See https://aka.ms/new-console-template for more information


using Azure;
using IMDBOpgave;
using Microsoft.Data.SqlClient;
using SQL_transfer;
using System.Text.RegularExpressions;

using (SqlConnection connection = new SqlConnection("Server =MSI; Database =CustomerProductOrderDB;Integrated Security=True;TrustServerCertificate=True"))
{
    List<string> init= new List<string>{ "kmeans++", "random" };
    List<string> n_init= new List<string> { "auto", "int" };
    List<string> algorithm = new List<string> { "lloyd", "elkan" };
    connection.Open();
    for(int i=1;i<100;i++)
    {
        for(int j=1;j<10000;j++)
        {
            foreach(string functionName in functions) 
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO MLP_new (hidden,max_iter,codes) Values('{i}','{j}','{functionName}')",connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(cmd.CommandText);
                }
            }
        }
    }

}


bool ConvertToBool(string input)
{
    if (input == "0")
    {
        return false;
    }
    else if (input == "1")
    {
        return true;
    }
    throw new ArgumentException("Ukendt værdi: " + input);
}

int? ConvertToInt(string input)
{
    if (input.ToLower() == @"\n")
    {
        return 0;
    }
    return int.Parse(input);
}





