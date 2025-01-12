// See https://aka.ms/new-console-template for more information


using Azure;
using IMDBOpgave;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

using (SqlConnection connection = new SqlConnection("Server =MSI; Database =CustomerProductOrderDB;Integrated Security=True;TrustServerCertificate=True"))
{
    List<string> criterion= new List<string>{"gini","entropy","log_loss"};
    connection.Open();
    for(int i=1;i<100;i++)
    {
        for(int j=1;j<10000;j++)
        {
            foreach(string functionName in criterion) 
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Decision_Tree_Classifier (Criterion,max_depth,min_depth) Values('{functionName}','{i}','{j}')",connection);
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





