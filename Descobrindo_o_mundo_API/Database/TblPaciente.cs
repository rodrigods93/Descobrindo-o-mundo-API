using Descobrindo_o_mundo_API.Models;
using System;
using System.Collections.Generic;

namespace Descobrindo_o_mundo_API
{
    public partial class TblPaciente
    {
        public int IdPaciente { get; set; }
        public string DscNicknamePaciente { get; set; }
        public int IdUsuarioPaciente { get; set; }

        public virtual TblUsuario IdUsuarioPacienteNavigation { get; set; }
        public virtual ICollection<TblPartida> TblPartida { get; set; }

        #region Construtores
        public TblPaciente()
        {
            TblPartida = new HashSet<TblPartida>();
        }

        public TblPaciente(string nick, int idUsuarioPaciente)
        {
            this.DscNicknamePaciente = nick;
            this.IdUsuarioPaciente = idUsuarioPaciente;
        }

        public TblPaciente(string nick)
        {
            this.DscNicknamePaciente = nick;
        }
        #endregion
    }
}
