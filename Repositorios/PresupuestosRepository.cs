using Microsoft.Data.Sqlite;
using Tienda;

public class PresupuestosRepository
{
    private const string cadenaConexion = @"DataSource=db/Tienda.db";

    public void CrearNuevoPesupuesto(Presupuestos nuevo)
    {
        using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@nombreD, @FechaCreacion);";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@nombreD", nuevo.NombreDestinatario));
            command.Parameters.Add(new SqliteParameter("@FechaCreacion", nuevo.FechaCreacion));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

        public List<Presupuestos> ListarPresupuestos()
        {
            List<Presupuestos> listaPresup = new List<Presupuestos>();
            using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                string query = "SELECT * FROM Presupuestos;";
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open();
                using(SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var presup = new Presupuestos();
                        presup.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                        presup.NombreDestinatario = reader["NombreDestinatario"].ToString();
                        presup.FechaCreacion = reader["FechaCreacion"].ToString();
                        //presup.CargarDetallesPresupuesto(ListarDetallePresupuesto(Convert.ToInt32(reader["idPresupuesto"])));
                        //cargar esta en el models de presupuesto de gonza
                        listaPresup.Add(presup);
                    }
                }
                connection.Close();

            }
            return listaPresup;
        }
}