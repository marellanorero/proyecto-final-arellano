using proyecto_final_arellano.clases;
using System.Data.SqlClient;

internal static class UsuarioHandlerHelpers
{

    public static bool Login(string nombreUsuario, string contraseña)
    {
        using (SqlConnection conn = new SqlConnection(cadenaConexion))
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE nombreUsuario = @nombreUsuario AND contraseña = @contraseña", conn);

            conn.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.Mail = reader.GetString(5);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contraseña = reader.GetString(4);
                }
            }
            else
            {
                return false;
            }
        }
    }
}