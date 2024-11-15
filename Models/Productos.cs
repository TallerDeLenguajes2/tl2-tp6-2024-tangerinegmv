namespace Tienda
{
    public class Productos
    {
        private int idProducto;
        private string? descripcion;
        private int precio;

        public Productos()
        {
        }

      
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public int Precio { get => precio; set => precio = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
    }
}