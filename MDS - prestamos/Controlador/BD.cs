using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS___prestamos.Controlador
{
    class BD
    {
        public string CadenaConexion { get; set; }

        //Hacemos referencia a la cade de conexion
        public BD()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        }

        //Se establece la conexion a la base de datos
        private SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(CadenaConexion);

            return connection;
        }
        //Obtencion de cualquier tabla
        public DataSet GetData(string StoreProcedure, SqlParameter[] sqlParameters)
        {
            DataSet ds = new DataSet();

            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter adapter = null;

            try
            {
                connection = ObtenerConexion();
                using (connection)
                {
                    command = new SqlCommand(StoreProcedure, connection);

                    using (command)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (sqlParameters != null)
                        {
                            command.Parameters.AddRange(sqlParameters);
                        }
                        adapter = new SqlDataAdapter(command);
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return ds;
        }

        //Metodo para el CUD de la base de datos
        public bool UpdateData(string StoreProcedure, SqlParameter[] sqlParameters)
        {
            bool realizado = false;

            SqlConnection connection = null;
            SqlCommand command = null;
            int registroAfectado = 0;

            try
            {
                connection = ObtenerConexion();
                using (connection)
                {
                    command = new SqlCommand(StoreProcedure, connection);

                    using (command)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (sqlParameters != null)
                        {
                            command.Parameters.AddRange(sqlParameters);
                        }

                        registroAfectado = command.ExecuteNonQuery();
                        if (registroAfectado > 0)
                        {
                            realizado = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return realizado;
        }


    }
}
