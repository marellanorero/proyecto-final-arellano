using proyecto_final_arellano.clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_arellano.handlers
{
    internal class UsuarioHandler
    {
        public static string cadenaConexion = "Data Source=Lauri;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Usuario ObtenerUsuario(long id)
        {
            Usuario usuario = new Usuario();
            //Función que me permita obtener todos los productos de la base
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE Id={id}", conn);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Usuario usuario2 = new Usuario();
                    {
                        usuario2.Id = reader.GetInt64(0);
                        usuario2.Nombre = reader.GetString(1);
                        usuario2.Apellido = reader.GetString(2);
                        usuario2.Mail = reader.GetString(5);
                        usuario2.NombreUsuario = reader.GetString(3);
                        usuario2.Contraseña = reader.GetString(4);
                    };

                    usuario.Add(usuario2);
                }
                return usuario;
            }
        }

        public Usuario Login(string user, string password)
        {
            Usuario UsuarioTemporal = new Usuario();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @user AND Contraseña = @password", conn);

                try
                {
                    comando.Parameters.AddWithValue("@user", user);
                    comando.Parameters.AddWithValue("@password", password);

                    conn.Open();

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        UsuarioTemporal.Id = reader.GetInt64(0);
                        UsuarioTemporal.Nombre = reader.GetString(1);
                        UsuarioTemporal.Apellido = reader.GetString(2);
                        UsuarioTemporal.Mail = reader.GetString(5);
                        UsuarioTemporal.NombreUsuario = reader.GetString(3);
                        UsuarioTemporal.Contraseña = reader.GetString(4);
                       
                    }
                    return UsuarioTemporal;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
    }

