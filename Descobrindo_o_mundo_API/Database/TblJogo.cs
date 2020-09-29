using System;
using System.Collections.Generic;

namespace Descobrindo_o_mundo_API
{
    public partial class TblJogo
    {
        public TblJogo()
        {
            TblPartida = new HashSet<TblPartida>();
        }

        public int IdJogo { get; set; }
        public string NmJogo { get; set; }

        public virtual ICollection<TblPartida> TblPartida { get; set; }
    }
}
