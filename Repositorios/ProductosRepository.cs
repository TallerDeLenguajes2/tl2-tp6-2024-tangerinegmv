using Microsoft.Data.Sqlite;
using Tienda;
public class ProductosRepository
{

    private const string cadenaConexion = @"DataSource=db/Tienda.db";
    public void CrearNuevo(Productos prod)
    {
        using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio);";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@Descripcion", prod.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", prod.Precio));
            command.ExecuteNonQuery();
            connection.Close();
        }
    } 
public List<Productos> ListarProductos()
        {
            List<Productos> listaProd = new List<Productos>();
            using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                string query = "SELECT * FROM Productos;";
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open();
                using(SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var prod = new Productos();
                        prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                        prod.Descripcion = reader["Descripcion"].ToString();
                        prod.Precio = Convert.ToInt32(reader["Precio"]);
                        listaProd.Add(prod);
                    }
                }
                connection.Close();

            }
            return listaProd;
        }

        public void ModificarProducto(int id, Productos prod)
        {
            using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                var query = "UPDATE Productos SET Descripcion = @Descripcion, Precio = @Precio WHERE idProducto = @id;";
                connection.Open();
                var command = new SqliteCommand(query, connection);
                command.Parameters.Add(new SqliteParameter("@id", id));
                command.Parameters.Add(new SqliteParameter("@Descripcion", prod.Descripcion));
                command.Parameters.Add(new SqliteParameter("@Precio", prod.Precio));
                command.ExecuteNonQuery();
                connection.Close();
            }
        } 

        public Productos DetallesProducto(int id)
        {
            var prod = new Productos();
            using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                string query = "SELECT * FROM Productos WHERE idProducto = @id;";
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.Add(new SqliteParameter("@id", id));
                connection.Open();
                using(SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                        prod.Descripcion = reader["Descripcion"].ToString();
                        prod.Precio = Convert.ToInt32(reader["Precio"]);
                        
                    }
                }
                connection.Close();

            }
            return prod;
        }
        

        public void BorrarProducto(int id)
        {
            using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                var query = "DELETE FROM Productos WHERE idProducto = @id;";
                connection.Open();
                var command = new SqliteCommand(query, connection);
                command.Parameters.Add(new SqliteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
}