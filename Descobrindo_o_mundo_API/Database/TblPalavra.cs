using System;
using System.Collections.Generic;

namespace Descobrindo_o_mundo_API
{
    public partial class TblPalavra
    {
        public TblPalavra()
        {
            TblPartida = new HashSet<TblPartida>();
        }

        public int IdPalavra { get; set; }
        public string NmPalavra { get; set; }

        public virtual TblSilaba TblSilaba { get; set; }
        public virtual ICollection<TblPartida> TblPartida { get; set; }
    }
}
