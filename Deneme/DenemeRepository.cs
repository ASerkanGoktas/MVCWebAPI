using Deneme.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Deneme
{
    public class DenemeRepository : IRepository<DenemeModel>
    {

        private MySqlConnection sqlconnection;

        //In order not to confuse what col numbers refer to what
        private int col_id = 0;
        private int col_name = 1;
        private int col_desc = 2;

        public DenemeRepository(MySqlConnection connection)
        {
            sqlconnection = connection;
        }

        public IEnumerable<DenemeModel> get_entities()
        {
            List<DenemeModel> result = new List<DenemeModel>();

            using (sqlconnection)
            {

                //Will be disposed out of scope
                using (var cmd = sqlconnection.CreateCommand())
                {


                    cmd.CommandText = "SELECT * FROM deneme_table";
                    sqlconnection.Open();


                    using (MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {

                        DenemeModel temp_entity;
                        while (dataReader.Read())
                        {
                            temp_entity = new DenemeModel(dataReader.GetInt32(col_id), dataReader.GetString(col_name), dataReader.GetString(col_desc));
                            result.Add(temp_entity);
                        }
                    }

                }


            }

            return result;
        }

        public void insert_entity(DenemeModel entity)
        {

            using (sqlconnection)
            {

                //Will be disposed out of scope
                using (MySqlCommand cmd = sqlconnection.CreateCommand())
                {


                    cmd.CommandText = "INSERT INTO deneme_table VALUES(0, @Name, @Desc)";
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Desc", entity.Detail);
                    sqlconnection.Open();


                    using (var dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {


                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }
                    }

                }

            }

        }

        public void update_entity(DenemeModel entity)
        {

            using (sqlconnection)
            {

                //Will be disposed out of scope
                using (var cmd = sqlconnection.CreateCommand())
                {


                    cmd.CommandText = "UPDATE deneme_table SET Name= @Name, Detail= @Desc WHERE ID= @ID";
                    cmd.Parameters.AddWithValue("@ID", entity.getID());
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Desc", entity.Detail);
                    sqlconnection.Open();


                    using (MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {


                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }
                    }

                }



            }


        }

        public DenemeModel retrieve_entity(int id)
        {
            DenemeModel result;
            //Opening sql command. Will be disposed when out of scope
            using (sqlconnection)
            {

                //Will be disposed out of scope
                using (MySqlCommand cmd = sqlconnection.CreateCommand())
                {


                    cmd.CommandText = "SELECT * FROM deneme_table WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    sqlconnection.Open();


                    using (MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {

                        dataReader.Read();
                        result = new DenemeModel(dataReader.GetInt32(col_id), dataReader.GetString(col_name), dataReader.GetString(col_desc));


                    }

                }



            }

            return result;
        }

        public void delete_entity(int id)
        {

            using (sqlconnection)
            {

                //Will be disposed out of scope
                using (var cmd = sqlconnection.CreateCommand())
                {


                    cmd.CommandText = "DELETE FROM deneme_table WHERE ID= @ID";
                    cmd.Parameters.AddWithValue("@ID", id);

                    sqlconnection.Open();


                    using (var dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {


                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }
                    }

                }


             }
        }




    }
}