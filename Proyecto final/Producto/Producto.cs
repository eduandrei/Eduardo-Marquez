using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.Producto
{
    public class Producto
    {
        //Encapsulated fields
        private int _id;
        private string _descripciones;
        private double _costo;
        private double _precioVenta;
        private int _stock;
        private int _idUsusario;

        //Properties to be get and set
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        //Default Constructor
        public Producto()
        {
            _id = 0;
            _descripciones = String.Empty;
            _costo = 0;
            _precioVenta = 0;
            _stock = 0;
            _idUsusario = 0;
        }

        //Parametrized Constructor
        public Producto (int id, string descripciones, double costo, double precioVenta, int stock, int idUsuario)
        {
            this._id = id;
            this._descripciones = descripciones;
            this._costo = costo;
            this._precioVenta = precioVenta;
            this._stock = stock;
            this._idUsusario = idUsuario;
        }

        public Producto(int Id, string descripciones, double costo, double precioVenta, int stock, int idUsusario, int id, string descripciones, double Costo, double PrecioVenta, int Stock, int idUsuario) : this( id, descripciones, costo, precioVenta, stock, idUsusario)
        {
            Id = id;
            Descripciones = descripciones;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }
    }
}  
}
