using System;
using System.Collections.Generic;

namespace Descobrindo_o_mundo_API
{
    public partial class TblProfissional
    {
        public int IdProfissional { get; set; }
        public string CrmProfissional { get; set; }
        public int IdUsuarioProfissional { get; set; }

        public virtual TblUsuario IdUsuarioProfissionalNavigation { get; set; }
    }
}
