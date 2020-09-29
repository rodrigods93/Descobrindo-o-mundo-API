using System;
using System.Collections.Generic;

namespace Descobrindo_o_mundo_API
{
    public partial class TblPartida
    {
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
    }
}
