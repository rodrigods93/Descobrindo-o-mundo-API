using Microsoft.AspNetCore.Razor.Language.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descobrindo_o_mundo_API.Models
{
    public class Partida
    {
        #region Propriedades
        private int _id;
        private int _idJogo;
        private int _idPaciente;
        private int _idPalavra;
        private DateTime _data;
        private DateTime _duracao;
        private string _status;
        private int _qtdErros;
        private int _qtdAcertos;
        #endregion

        #region Properties
        public int IdPartida { get => _id; set => _id = value; }
        public int IdJogo { get => _idJogo; set => _idJogo = value; }
        public int IdPaciente { get => _idPaciente; set => _idPaciente = value; }
        public int IdPalavra { get => _idPalavra; set => _idPalavra = value; }
        public string Data { get => _data.ToString(); set => _data = DateTime.Parse(value); }
        public string Duracao { get => _duracao.ToString(); set => _duracao = DateTime.Parse(value); }
        public string Status { get => _status; set => _status = value; }
        public int QtdErros { get => _qtdErros; set => _qtdErros = value; }
        public int QtdAcertos { get => _qtdAcertos; set => _qtdAcertos = value; }
        #endregion

        #region Construtores
        public Partida(int idJogo,int idPaciente,int idPalavra,string data,string duracao,string status,int qtdErros,int qtdAcertos)
        {
            this.IdJogo = idJogo;
            this.IdPaciente = idPaciente;
            this.IdPalavra = idPalavra;
            this.Data = data;
            this.Duracao = duracao;
            this.Status = status;
            this.QtdErros = qtdErros;
            this.QtdAcertos = qtdAcertos;
        }
        #endregion

        #region Métodos
        public void Cadastrar(Partida partida)
        {

        }
        #endregion
    }
}
