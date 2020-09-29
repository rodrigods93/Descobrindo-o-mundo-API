using System;
using System.Collections.Generic;

namespace Descobrindo_o_mundo_API
{
    public partial class TblSilaba
    {
        public int IdSilaba { get; set; }
        public int IdPalavraSilaba { get; set; }
        public string SlbsCorretasSilaba { get; set; }
        public string SlbsIncorretasSilaba { get; set; }

        public virtual TblPalavra IdPalavraSilabaNavigation { get; set; }
    }
}
