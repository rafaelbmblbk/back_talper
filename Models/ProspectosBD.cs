using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Talper.API.Models
{
    public class ProspectosBD
    {
        public List<Prospecto> prostectoQuery()
        {
            List<Prospecto> lista = new List<Prospecto>();

            string strConnection = ConfigurationManager.ConnectionStrings["BDTALPER"].ToString();

            using (SqlConnection sqlConn = new SqlConnection(strConnection))
            {
                sqlConn.Open();

                SqlCommand cdm = sqlConn.CreateCommand();
                cdm.CommandText = "SP_ProspectosQuery";
                cdm.CommandType = CommandType.StoredProcedure;

                SqlDataReader read = cdm.ExecuteReader();

                while (read.Read())
                {
                    int prospectoId = read.GetInt32(0);
                    string nombre = read.GetString(1).Trim();
                    string apMaterno = read.GetString(2).Trim();
                    string apPaterno = read.GetString(3).Trim();
                    string calle = read.GetString(4).Trim();
                    string numero = read.GetString(5).Trim();
                    string colonia = read.GetString(6).Trim();
                    string cp = read.GetString(7).Trim();
                    string telefono = read.GetString(8).Trim();
                    string rfc = read.GetString(9).Trim();
                    string authorization = read.GetString(10).Trim();
                    int stAutorization = read.GetInt32(11);
                    string motivo = read.GetString(12).Trim();

                    Prospecto prospecto = new Prospecto(prospectoId, nombre, apMaterno, apPaterno, calle, numero, colonia, cp, telefono, rfc, authorization, stAutorization, motivo);

                    lista.Add(prospecto);
                }

                read.Close();
                sqlConn.Close();
            }

            return lista;

        }

        public List<Prospecto> prostectoRead(int idProspecto)
        {
            List<Prospecto> lista = new List<Prospecto>();

            string strConnection = ConfigurationManager.ConnectionStrings["BDTALPER"].ToString();

            using (SqlConnection sqlConn = new SqlConnection(strConnection))
            {
                sqlConn.Open();

                SqlCommand cmd = sqlConn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "SP_ProspectosRead";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prospectoId", idProspecto);

                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    int prospectoId = read.GetInt32(0);
                    string nombre = read.GetString(1).Trim();
                    string apMaterno = read.GetString(2).Trim();
                    string apPaterno = read.GetString(3).Trim();
                    string calle = read.GetString(4).Trim();
                    string numero = read.GetString(5).Trim();
                    string colonia = read.GetString(6).Trim();
                    string cp = read.GetString(7).Trim();
                    string telefono = read.GetString(8).Trim();
                    string rfc = read.GetString(9).Trim();
                    string authorization = read.GetString(10).Trim();
                    int stAutorization = read.GetInt32(11);
                    string motivo = read.GetString(12).Trim();

                    Prospecto prospecto = new Prospecto(prospectoId, nombre, apMaterno, apPaterno, calle, numero, colonia, cp, telefono, rfc, authorization, stAutorization, motivo);

                    lista.Add(prospecto);
                }

                read.Close();
                sqlConn.Close();
            }

            return lista;

        }

        public int prospectoInsert(Prospecto prospecto)
        {
            bool res = false;
            string prospectoId = "";

            string strConnection = ConfigurationManager.ConnectionStrings["BDTALPER"].ToString();

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "SP_ProspectosInsert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", prospecto.nombre);
                cmd.Parameters.AddWithValue("@apMaterno", prospecto.apMaterno);
                cmd.Parameters.AddWithValue("@apPaterno", prospecto.apPaterno);
                cmd.Parameters.AddWithValue("@calle", prospecto.calle);
                cmd.Parameters.AddWithValue("@numero", prospecto.numero);
                cmd.Parameters.AddWithValue("@colonia", prospecto.colonia);
                cmd.Parameters.AddWithValue("@cp", prospecto.cp);
                cmd.Parameters.AddWithValue("@telefono", prospecto.telefono);
                cmd.Parameters.AddWithValue("@rfc", prospecto.rfc);

                try
                {
                    conn.Open();                    
                    SqlDataReader read = cmd.ExecuteReader();           
                    while (read.Read())
                    {
                        prospectoId = read.GetValue(0).ToString();
                    }
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

                return Int32.Parse(prospectoId);
            }
        }


        public bool prospectoUpdate(int prospectoId, Prospecto prospecto)
        {
            bool res = false;

            string strConnection = ConfigurationManager.ConnectionStrings["BDTALPER"].ToString();

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "SP_ProspectosUpdate";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prospectoId", prospectoId);
                cmd.Parameters.AddWithValue("@nombre", prospecto.nombre);
                cmd.Parameters.AddWithValue("@apMaterno", prospecto.apMaterno);
                cmd.Parameters.AddWithValue("@apPaterno", prospecto.apPaterno);
                cmd.Parameters.AddWithValue("@calle", prospecto.calle);
                cmd.Parameters.AddWithValue("@numero", prospecto.numero);
                cmd.Parameters.AddWithValue("@colonia", prospecto.colonia);
                cmd.Parameters.AddWithValue("@cp", prospecto.cp);
                cmd.Parameters.AddWithValue("@telefono", prospecto.telefono);
                cmd.Parameters.AddWithValue("@rfc", prospecto.rfc);
                cmd.Parameters.AddWithValue("@status", prospecto.stAutorization);

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


        public bool prospectoDelete(int prospectoId)
        {
            bool res = false;

            string strConnection = ConfigurationManager.ConnectionStrings["BDTALPER"].ToString();

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "SP_ProspectosDelete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prospectoId", prospectoId);

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


        public bool prospectoEstatus(Prospecto prospecto)
        {
            bool res = false;

            string strConnection = ConfigurationManager.ConnectionStrings["BDTALPER"].ToString();

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "SP_ProspectosStatus";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prospectoId", prospecto.prospectoId);
                cmd.Parameters.AddWithValue("@status", prospecto.stAutorization);
                cmd.Parameters.AddWithValue("@motivo", prospecto.motivo);

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
    }
}