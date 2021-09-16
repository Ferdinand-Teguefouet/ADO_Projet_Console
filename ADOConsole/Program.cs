using Microsoft.Data.SqlClient;
using System;

namespace ADOConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = @"Data Source=PC-LEADERTF\SQLEXPRESS;Initial Catalog=ADO;Integrated Security=True";

                string firstname = "James";
                string lastname = "JeanJean";
                string birthDate = "1992-01-01";
                int YearResult = 18;
                int sectionID = 1010;

                // Exercice p.86
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = $"insert into Student (FirstName, LastName, BirthDate, YearResult, SectionID) output inserted.ID VALUES ('{firstname}', '{lastname}', '{birthDate}', {YearResult}, {sectionID});";

                    c.Open();
                    int id = (int)cmd.ExecuteScalar();
                    c.Close();

                    Console.WriteLine(id);
                }

                firstname = "James";
                lastname = "Bond";
                birthDate = "1992-01-01";
                YearResult = 18;
                sectionID = 1010;
                // Exercice p.96
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = $"insert into Student (FirstName, LastName, BirthDate, YearResult, SectionID)" +
                            "output inserted.ID VALUES (@firstname, @lastname, @birthDate, @yearResult, @sectionID);";

                    SqlParameter fName = new SqlParameter()
                    {
                        ParameterName = "firstName",
                        Value = firstname
                    };
                    SqlParameter lName = new SqlParameter()
                    {
                        ParameterName = "lastname",
                        Value = lastname
                    };
                    SqlParameter bDate = new SqlParameter()
                    {
                        ParameterName = "birthDate",
                        Value = birthDate
                    };
                    SqlParameter yRes = new SqlParameter()
                    {
                        ParameterName = "YearResult",
                        Value = YearResult
                    };
                    SqlParameter sId = new SqlParameter()
                    {
                        ParameterName = "sectionID",
                        Value = sectionID
                    };

                    cmd.Parameters.Add(fName);
                    cmd.Parameters.Add(lName);
                    cmd.Parameters.Add(bDate);
                    cmd.Parameters.Add(yRes);
                    cmd.Parameters.Add(sId);

                    c.Open();
                    int id = (int)cmd.ExecuteScalar();
                    c.Close();

                    Console.WriteLine(id);
                }

                // Exercice p.108
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UpdateStudent";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter inId = new SqlParameter()
                    {
                        ParameterName = "Id",
                        Value = 28
                    };
                    SqlParameter inSecId = new SqlParameter()
                    {
                        ParameterName = "SectionId",
                        Value = 1120
                    };
                    SqlParameter inYearRes = new SqlParameter()
                    {
                        ParameterName = "YearResult",
                        Value = YearResult
                    };

                    cmd.Parameters.Add(inId);
                    cmd.Parameters.Add(inSecId);
                    cmd.Parameters.Add(inYearRes);

                    c.Open();
                    cmd.ExecuteNonQuery();
                    c.Close();
                }
            }
        }
    }
}
