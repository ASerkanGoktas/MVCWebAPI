
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI3.Models;

namespace WebAPI3
{
    public class DenemeRepository : IRepository<DenemeModel>
    {

        private MySqlConnection sqlconnection;

        //In order not to confuse what col numbers refer to what
        private int col_id = 0;
        private int col_name = 1;
        private int col_detail = 2;
        private int col_number = 3;

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


                    cmd.CommandText = "SELECT * FROM product_table";
                    sqlconnection.Open();


                    using (MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {

                        DenemeModel temp_entity;
                        while (dataReader.Read())
                        {
                            temp_entity = new DenemeModel(dataReader.GetInt32(col_id), dataReader.GetString(col_name), dataReader.GetString(col_detail), dataReader.GetInt32(col_number));
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


                    cmd.CommandText = "INSERT INTO product_table (Name,Detail,NumberStock) VALUES(@Name, @Desc, @Number)";
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Desc", entity.Detail);
                    cmd.Parameters.AddWithValue("@Number", entity.NumberStock);
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


                    cmd.CommandText = "UPDATE product_table SET Name= @Name, Detail= @Detail, NumberStock=@NumberStock WHERE ID= @ID";
                    cmd.Parameters.AddWithValue("@ID", entity.getID());
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Detail", entity.Detail);
                    cmd.Parameters.AddWithValue("@NumberStock", entity.NumberStock);
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
            DenemeModel result=null;
            //Opening sql command. Will be disposed when out of scope
            using (sqlconnection)
            {

                //Will be disposed out of scope
                using (MySqlCommand cmd = sqlconnection.CreateCommand())
                {


                    cmd.CommandText = "SELECT * FROM product_table WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    sqlconnection.Open();


                    using (MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        try
                        {
                            dataReader.Read();
                            result = new DenemeModel(dataReader.GetInt32(col_id), dataReader.GetString(col_name), dataReader.GetString(col_detail), dataReader.GetInt32(col_number));
                        }
                        catch (Exception e) { }
                        


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


                    cmd.CommandText = "DELETE FROM product_table WHERE ID= @ID";
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