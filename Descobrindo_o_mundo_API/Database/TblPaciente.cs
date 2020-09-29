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

        /*
         * TODO
         * Construtor com argumentos para adicionar um paciente no BD.
         * Preciso descobrir o que é 'HashSet' e como ele influencia no construtor acima.
         */
        public TblPaciente(string nick, int idUsuarioPaciente)
        {
            this.DscNicknamePaciente = nick;
            this.IdUsuarioPaciente = idUsuarioPaciente;
        }
        #endregion
    }
}
