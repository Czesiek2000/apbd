using cwiczenia4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia4.Services.Animals
{
    public class AnimalDbService : IAnimalDbService
    {
        private readonly string _sqlConn = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True";

        public List<Animal> GetAnimals ( string orderBy )
        {
            string sql = "SELECT * FROM ANIMAL";

            var output = new List<Animal>();

            if ( string.IsNullOrEmpty( orderBy ) )
            {
                orderBy = "name";
            }

            using ( var conn = new SqlConnection( _sqlConn ) )
            {
                using ( var comm = new SqlCommand() )
                {
                    comm.Connection = conn;


                    if ( orderBy == "name" || orderBy == "description" || orderBy == "area" || orderBy == "category" )
                    {

                        comm.CommandText = $"{sql} ORDER BY {orderBy} ASC";

                        conn.Open();

                        var dr = comm.ExecuteReader();

                        if ( !dr.HasRows )
                        {
                            Console.WriteLine( "Empty rows" );
                        }


                        while ( dr.Read() )
                        {
                            output.Add( new Animal
                            {
                                IdAnimal = int.Parse( dr["IdAnimal"].ToString() ),
                                Name = dr["Name"].ToString(),
                                Description = dr["Description"].ToString(),
                                Category = dr["Category"].ToString(),
                                Area = dr["Area"].ToString()

                            } );
                        }
                    }


                    conn.Close();
                }
            }

            return output;
        }

        public int AddAnimal ( Animal animal )
        {
            if ( animal.IdAnimal != 0 || !string.IsNullOrEmpty( animal.Name ) || !string.IsNullOrEmpty( animal.Description ) || !string.IsNullOrEmpty( animal.Category ) || !string.IsNullOrEmpty( animal.Area ) )
            {
                using ( var conn = new SqlConnection( _sqlConn ) )
                {
                    using ( var comm = new SqlCommand() )
                    {
                        comm.Connection = conn;

                        conn.Open();

                        comm.CommandText = "INSERT INTO ANIMAL VALUES(@NAME, @DESCRIPTION, @CATEGORY, @AREA)";

                        comm.Parameters.AddWithValue( "NAME", animal.Name );

                        comm.Parameters.AddWithValue( "DESCRIPTION", animal.Description );

                        comm.Parameters.AddWithValue( "CATEGORY", animal.Category );

                        comm.Parameters.AddWithValue( "AREA", animal.Area );

                        comm.ExecuteNonQuery();

                        conn.Close();

                        return 1;
                    }

                }

            }
            return 0;

        }

        public int UpdateAnimal (Animal animal, int idAnimal)
        {
            using ( var conn = new SqlConnection( _sqlConn ) )
            {
                using ( var comm = new SqlCommand() )
                {
                    comm.Connection = conn;

                    conn.Open();

                    comm.CommandText = "UPDATE ANIMAL SET NAME = @NAME, DESCRIPTION = @DESCRIPTION, CATEGORY = @CATEGORY, AREA = @AREA WHERE IDANIMAL = @IDANIMAL";


                    comm.Parameters.AddWithValue( "NAME", animal.Name );

                    comm.Parameters.AddWithValue( "DESCRIPTION", animal.Description );

                    comm.Parameters.AddWithValue( "CATEGORY", animal.Category );

                    comm.Parameters.AddWithValue( "AREA", animal.Area );
                    
                    comm.Parameters.AddWithValue( "IDANIMAL", idAnimal );
                    int res = comm.ExecuteNonQuery();

                    conn.Close();

                    return res;
                }

            }
        }

        public int DeleteAnimal(int idAnimal )
        {
            using ( var conn = new SqlConnection( _sqlConn ) )
            {
                using ( var comm = new SqlCommand() )
                {
                    comm.Connection = conn;
                    
                    conn.Open();

                    comm.CommandText = "DELETE FROM ANIMAL WHERE IDANIMAL = @IDANIMAL";

                    comm.Parameters.AddWithValue( "IDANIMAL", idAnimal );

                    int res = comm.ExecuteNonQuery();

                    conn.Close();

                    return res;
                }
            }
        }
    }
}
