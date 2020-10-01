using Descobrindo_o_mundo_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Descobrindo_o_mundo_API
{
    public partial class TblUsuario
    {
        #region Propriedades
        public int IdUsuario { get; set; }
        public string NmUsuario { get; set; }
        public string SbrnmUsuario { get; set; }
        public DateTime DtNascUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public int IdTipoUsuario { get; set; }

        public virtual TblTipo IdTipoUsuarioNavigation { get; set; }
        public virtual TblPaciente TblPaciente { get; set; }
        public virtual TblProfissional TblProfissional { get; set; }
        #endregion

        #region Construtores
        public TblUsuario()
        {

        }
        public TblUsuario(string nome,string sbNome,DateTime dtNascimento,string email,string senha,int tipo)
        {
            this.NmUsuario = nome;
            this.SbrnmUsuario = sbNome;
            this.DtNascUsuario = dtNascimento;
            this.EmailUsuario = email;
            this.SenhaUsuario = senha;
            this.IdTipoUsuario = tipo;
        }

        public TblUsuario(string nome, string sbNome, DateTime dtNascimento, string email, string senha, int tipo, TblPaciente paciente)
        {
            this.NmUsuario = nome;
            this.SbrnmUsuario = sbNome;
            this.DtNascUsuario = dtNascimento;
            this.EmailUsuario = email;
            this.SenhaUsuario = senha;
            this.IdTipoUsuario = tipo;
            this.TblPaciente = paciente;
        }

        public TblUsuario(string nome, string sbNome, DateTime dtNascimento, string email, string senha, int tipo, TblProfissional profissional)
        {
            this.NmUsuario = nome;
            this.SbrnmUsuario = sbNome;
            this.DtNascUsuario = dtNascimento;
            this.EmailUsuario = email;
            this.SenhaUsuario = senha;
            this.IdTipoUsuario = tipo;
            this.TblProfissional = profissional;
        }
        #endregion
    }
}
