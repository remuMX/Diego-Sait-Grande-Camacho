using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactosMAVI
{
    class Conexion
    {
        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        #region queryExecute


        // Metodo para select
        // IN: nombre del stored procedure
        // OUT: DataTable de la consulta (inner, tabla pura, etc).
        public DataTable Query(String query)
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();

                DataTable resultado = new DataTable();

                // El resultado se vacia en un DataTable.

                resultado.Load(cmd.ExecuteReader());
                // Se regresa el datatable
                return resultado;
            }
        }


        // Sobrecarga de select.
        // IN: nombre del stored_procedure, parametros del stored_procedure.
        // OUT: DataTable de la consulta (inner, tabla pura, etc).
        public DataTable Query(String query, SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();

                DataTable resultado = new DataTable();
                cmd.Parameters.AddRange(parameters);

                // El resultado se vacia a un DataTable
                resultado.Load(cmd.ExecuteReader());
                // Se regresa el datatable
                return resultado;
            }
        }


        // Metodo para DDL (Insert, Update, Delete).
        // IN: nombre del stored_procedure, parametros del stored_procedure.
        // OUT: Entero que indica el numero de lineas afectada.
        public int Execute(String query, SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();

                cmd.Parameters.AddRange(parameters); // Se agregan los parametros

                // Regresa el numero de lineas afectadas.
                return cmd.ExecuteNonQuery();

            }
        }
        #endregion



    }
}
