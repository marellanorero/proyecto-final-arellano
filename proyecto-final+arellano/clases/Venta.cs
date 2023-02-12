using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_arellano.clases
{
    internal class Venta
    {
        private long id;
        private string comentarios;

        public long Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }

        public Venta(long id, string comentarios)
        {
            this.id = id;
            this.comentarios = comentarios;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        internal void Add(Venta ventas)
        {
            throw new NotImplementedException();
        }
    }
}
