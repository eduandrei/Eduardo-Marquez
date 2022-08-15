using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.Venta
{
    public class Venta
    {
        //Encapsulated fields
        private int _id;
        private string _comentarios;

        //Properties
        public int Id { get; set; }
        public string Comentarios { get; set; }

        //Default constructor
        public Venta()
        {
            _id = 0;
            _comentarios = String.Empty;
        }

        //Parametrized Constructor
        public Venta(int id, string comentarios)
        {
            this._id = id;
            this._comentarios = comentarios;
        }
    }


}


