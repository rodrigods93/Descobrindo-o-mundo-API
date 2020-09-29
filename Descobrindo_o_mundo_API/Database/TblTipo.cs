using System;
using System.Collections.Generic;

namespace Descobrindo_o_mundo_API
{
    public partial class TblTipo
    {
        public TblTipo()
        {
            TblUsuario = new HashSet<TblUsuario>();
        }

        public int IdTipo { get; set; }
        public string NmTipo { get; set; }

        public virtual ICollection<TblUsuario> TblUsuario { get; set; }
    }
}
