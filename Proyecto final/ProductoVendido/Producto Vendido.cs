using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.ProductoVendido
{
    public class ProductoVendido
    {
        //Encapsulated fields
        private int _id;
        private int _stock;
        private int _idProducto;
        private int _idVenta;

        //Properties
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        //Default Constructor
        public ProductoVendido()
        {
            _id = 0;
            _stock = 0;
            _idProducto = 0;
            _idVenta = 0;
        }

        //Parametrized Constructor
        public ProductoVendido(int id, int stock, int idProducto, int idVenta)
        {
            this._id = id;
            this._stock = stock;
            this._idProducto = idProducto;
            this._idVenta = idVenta;
        }
    }
}
}
