using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Talper.API.Models
{
    public class ArchivosBD
    {

        public bool archivosInsert(Archivos archivo)
        {
            bool res = false;

            string strConnection = ConfigurationManager.ConnectionStrings["BDTALPER"].ToString();

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "SP_ArchivosInsert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prospectoId", archivo.prospectoId);
                cmd.Parameters.AddWithValue("@nombre", archivo.nombre);
                cmd.Parameters.AddWithValue("@path", archivo.path);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }


        public List<Archivos> archivosRead(int idProspecto)
        {
            List<Archivos> lista = new List<Archivos>();

            string strConnection = ConfigurationManager.ConnectionStrings["BDTALPER"].ToString();

            using (SqlConnection sqlConn = new SqlConnection(strConnection))
            {
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "SP_ArchivosRead";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prospectoId", idProspecto);

                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    int archivoId = read.GetInt32(0);
                    int prospectoId = read.GetInt32(1);
                    string nombre = read.GetString(2).Trim();
                    string path = read.GetString(3).Trim();


                    Archivos archivos = new Archivos(archivoId, prospectoId, nombre, path);

                    lista.Add(archivos);
                }

                read.Close();
                sqlConn.Close();
            }

            return lista;

        }
    }
}