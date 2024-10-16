using Sistema_OT.Services;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Sistema_OT.Models
{
    public class Usuarios
    {
        public string UserID { get; set; }
        public string Contrasenia { get; set; }

        public string Administrador { get; set; }
        public Usuarios encontrarUsuario(string id, string contra)
        {
            Usuarios usuario = new Usuarios();

            string query = "Select UserID, Contrasenia, Administrador WHERE UserID = @pid and Contrasenia = @pcontra";
            ConexionDB conexionDB = new ConexionDB();
            conexionDB.AbrirConexion();
            using (SqlCommand command = new SqlCommand(query, conexionDB.con))
            {
                command.Parameters.AddWithValue("@pid", id);
                command.Parameters.AddWithValue("@pcontra", contra);
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new Usuarios()
                            {
                                UserID = reader["UserID"].ToString(),
                                Contrasenia = reader["Contrasenia"].ToString(),
                                Administrador = reader["Administrador"].ToString(),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            return usuario;
        }
    } 

}
