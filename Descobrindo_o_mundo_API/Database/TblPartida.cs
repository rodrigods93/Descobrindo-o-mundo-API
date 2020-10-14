using System;
using System.Collections.Generic;

namespace Descobrindo_o_mundo_API
{
    public partial class TblPartida
    {
        #region Propriedades
        public int IdPartida { get; set; }
        public int IdPalavraPartida { get; set; }
        public int IdJogoPartida { get; set; }
        public int IdPacientePartida { get; set; }
        public decimal QtdAcertosPartida { get; set; }
        public decimal QtdErrosPartida { get; set; }
        public TimeSpan DuracaoPartida { get; set; }
        public DateTime DtPartida { get; set; }
        public string StatusPartida { get; set; }

        public virtual TblJogo IdJogoPartidaNavigation { get; set; }
        public virtual TblPaciente IdPacientePartidaNavigation { get; set; }
        public virtual TblPalavra IdPalavraPartidaNavigation { get; set; }
        #endregion

        #region Construtores
        public TblPartida(){}
        public TblPartida(int idJogo,int idPalavra,int idPaciente,TimeSpan duracao,DateTime data,decimal qtdAcertos,decimal qtdErros,string status)
        {
            this.IdJogoPartida = idJogo;
            this.IdPalavraPartida = idPalavra;
            this.IdPacientePartida = idPaciente;
            this.DuracaoPartida = duracao;
            this.DtPartida = data;
            this.QtdAcertosPartida = qtdAcertos;
            this.QtdErrosPartida = qtdErros;
            this.StatusPartida = status;
        }
        #endregion
    }
}
