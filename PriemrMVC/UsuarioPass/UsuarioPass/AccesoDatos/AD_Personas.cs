using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsuarioPass.Models;
using System.Data.SqlClient;

namespace UsuarioPass.AccesoDatos
{
    public class AD_Personas
    {
        //Insertar 
        public static bool InsertarNuevaPersona(Persona per)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO personas VALUES(@nombre,@apellido,@edad,@telefono)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", per.Nombre);
                cmd.Parameters.AddWithValue("@apellido", per.Apellido);
                cmd.Parameters.AddWithValue("@edad", per.Edad);
                cmd.Parameters.AddWithValue("@telefono", per.Telefono);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;

                


                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        } 

        //Seleccionar listado
        public static List<Persona> ObtenerPersonas()
        {
            List<Persona> listado = new List<Persona>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM personas";
                cmd.Parameters.Clear();
                
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr!=null)
                {
                    while(dr.Read())
                    {
                        Persona p = new Persona();
                        p.Id = int.Parse(dr["id"].ToString());
                        p.Nombre = dr["Nombre"].ToString();
                        p.Apellido = dr["Apellido"].ToString();
                        p.Telefono = dr["Telefono"].ToString();
                        p.Edad = int.Parse(dr["Edad"].ToString());

                        listado.Add(p);
                    }
                }




                return listado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        //Seleccionar 1 sola Persona con id especificio
        public static Persona ObtenerPersona(int idPersona)
        {
            Persona pers = new Persona();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELEC * FROM personas WHERE Id= @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", idPersona);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        
                        pers.Id = int.Parse(dr["id"].ToString());
                        pers.Nombre = dr["Nombre"].ToString();
                        pers.Apellido = dr["Apellido"].ToString();
                        pers.Telefono = dr["Telefono"].ToString();
                        pers.Edad = int.Parse(dr["Edad"].ToString());

                        
                    }
                }




                return pers;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }


    }


     
}