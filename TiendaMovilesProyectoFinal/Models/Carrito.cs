using System.Collections.Generic;
using System.Linq;

namespace TiendaMovilesProyectoFinal.Models
{
    public class Carrito
    {
        private List<CarritoItem> items = new List<CarritoItem>();

        public List<CarritoItem> Items
        {
            get { return items; }
        }

        public void AgregarAlCarrito(int id, string titulo, decimal precio, int cantidad)
        {
            var item = items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                item = new CarritoItem
                {
                    Id = id,
                    Titulo = titulo,
                    Precio = precio,
                    Cantidad = cantidad
                };
                items.Add(item);
            }
            else
            {
                item.Cantidad += cantidad;
            }
        }

        public void BorrarDelCarrito(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                items.Remove(item);
            }
        }

        public decimal CalcularTotal()
        {
            return items.Sum(item => item.Precio * item.Cantidad);
        }

        public void VaciarCarrito()
        {
            items.Clear();
        }
    }
}