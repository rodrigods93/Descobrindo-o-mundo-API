using Descobrindo_o_mundo_API.Models;
using Descobrindo_o_mundo_API.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Descobrindo_o_mundo_API
{
    public partial class Usuario
    {
        #region Propriedades
        private int _id;
        private string _nome;
        private string _sobrenome;
        private DateTime _dtNascimento;
        private string _email;
        private string _senha;
        private int _tipo;
        private Paciente _paciente;
        private Profissional _profissional;
        #endregion

        #region Properties
        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Sobrenome { get => _sobrenome; set => _sobrenome = value; }
        public string DtNascimento { get => _dtNascimento.ToString(); set => _dtNascimento = DateTime.Parse(value.ToString()); }
        public string Email { get => _email; set => _email = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public int Tipo { get => _tipo; set => _tipo = value; }
        public Paciente Paciente { get => _paciente; set => _paciente = value; }
        public Profissional Profissional { get => _profissional; set => _profissional = value; }
        #endregion

        #region Construtores
        public Usuario()
        {
        }
        public Usuario(int id, string nome, string sobrenome, string dtNascimento, string email, string senha, int tipo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.DtNascimento = dtNascimento;
            this.Email = email;
            this.Senha = senha;
            this.Tipo = tipo;
        }
        public Usuario(int id, string nome, string sobrenome, string dtNascimento, string email, string senha, int tipo, Paciente paciente)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.DtNascimento = dtNascimento;
            this.Email = email;
            this.Senha = senha;
            this.Tipo = tipo;
            this.Paciente = paciente;
        }
        public Usuario(int id, string nome, string sobrenome, string dtNascimento, string email, string senha, int tipo, Profissional profissional)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.DtNascimento = dtNascimento;
            this.Email = email;
            this.Senha = senha;
            this.Tipo = tipo;
            this.Profissional = profissional;
        }
        #endregion

        #region Métodos
        public Usuario Login(string email, string senha)
        {
            descobrindo_mundoContext _db = new descobrindo_mundoContext();
            var _usuarioBusca = _db.TblUsuario.Single(x => (x.EmailUsuario == email) && (x.SenhaUsuario == senha));
            Usuario UsuarioRetorno = new Usuario(_usuarioBusca.IdUsuario, _usuarioBusca.NmUsuario, _usuarioBusca.SbrnmUsuario, _usuarioBusca.DtNascUsuario.ToString(), _usuarioBusca.EmailUsuario, _usuarioBusca.SenhaUsuario, _usuarioBusca.IdTipoUsuario);
            return UsuarioRetorno;
        }

        public void Cadastrar(Usuario usuario)
        {
            descobrindo_mundoContext _db = new descobrindo_mundoContext();
            switch (usuario.Tipo)
            {
                case 1:
                    TblPaciente tblPaciente = new TblPaciente(usuario.Paciente.Nickname);
                    TblUsuario _usuarioCadastroPaciente = new TblUsuario(usuario.Nome, usuario.Sobrenome, usuario._dtNascimento, usuario.Email, usuario.Senha, usuario.Tipo, tblPaciente);
                    _db.TblUsuario.Add(_usuarioCadastroPaciente);
                    _db.SaveChanges();
                    break;
                case 2:
                    TblProfissional tblProfissional = new TblProfissional(usuario._profissional.Crm);
                    TblUsuario _usuarioCadastroProfissional = new TblUsuario(usuario.Nome, usuario.Sobrenome, usuario._dtNascimento, usuario.Email, usuario.Senha, usuario.Tipo, tblProfissional);
                    _db.TblUsuario.Add(_usuarioCadastroProfissional);
                    _db.SaveChanges();
                    break;
            } 
        }

        public void Atualizar(Usuario usuario)
        {
            descobrindo_mundoContext _db = new descobrindo_mundoContext();
            switch (usuario.Tipo)
            {
                case 1:
                    TblUsuario tblUsuarioPaciente = _db.TblUsuario.Include(x => x.TblPaciente).First(x => x.IdUsuario == usuario.Id);
                    if (tblUsuarioPaciente.NmUsuario != usuario.Nome)
                    {
                        tblUsuarioPaciente.NmUsuario = usuario.Nome;
                    }
                    else if(tblUsuarioPaciente.SbrnmUsuario != usuario.Sobrenome)
                    {
                        tblUsuarioPaciente.SbrnmUsuario = usuario.Sobrenome;
                    }
                    else if (tblUsuarioPaciente.DtNascUsuario != DateTime.Parse(usuario.DtNascimento))
                    {
                        tblUsuarioPaciente.DtNascUsuario = DateTime.Parse(usuario.Sobrenome);
                    }
                    else if (tblUsuarioPaciente.EmailUsuario != usuario.Email)
                    {
                        tblUsuarioPaciente.EmailUsuario = usuario.Email;
                    }
                    else if (tblUsuarioPaciente.SenhaUsuario != usuario.Senha)
                    {
                        tblUsuarioPaciente.SenhaUsuario = usuario.Senha;
                    }
                    else if (tblUsuarioPaciente.TblPaciente.DscNicknamePaciente != usuario.Paciente.Nickname)
                    {
                        tblUsuarioPaciente.TblPaciente.DscNicknamePaciente = usuario.Paciente.Nickname;
                    }
                    _db.SaveChanges();
                    break;
                case 2:
                    TblUsuario tblUsuarioProfissional = _db.TblUsuario.Include(x => x.TblProfissional).First(x => x.IdUsuario == usuario.Id);
                    if (tblUsuarioProfissional.NmUsuario != usuario.Nome)
                    {
                        tblUsuarioProfissional.NmUsuario = usuario.Nome;
                    }
                    else if (tblUsuarioProfissional.SbrnmUsuario != usuario.Sobrenome)
                    {
                        tblUsuarioProfissional.SbrnmUsuario = usuario.Sobrenome;
                    }
                    else if (tblUsuarioProfissional.DtNascUsuario != DateTime.Parse(usuario.DtNascimento))
                    {
                        tblUsuarioProfissional.DtNascUsuario = DateTime.Parse(usuario.Sobrenome);
                    }
                    else if (tblUsuarioProfissional.EmailUsuario != usuario.Email)
                    {
                        tblUsuarioProfissional.EmailUsuario = usuario.Email;
                    }
                    else if (tblUsuarioProfissional.SenhaUsuario != usuario.Senha)
                    {
                        tblUsuarioProfissional.SenhaUsuario = usuario.Senha;
                    }
                    else if (tblUsuarioProfissional.TblProfissional.CrmProfissional != usuario.Profissional.Crm)
                    {
                        tblUsuarioProfissional.TblProfissional.CrmProfissional = usuario.Profissional.Crm;
                    }
                    _db.SaveChanges();
                    break;
            }
        }

        public void RecuperarSenha(string email)
        {
            descobrindo_mundoContext _db = new descobrindo_mundoContext();
            TblUsuario _usuario = _db.TblUsuario.Single(x => x.EmailUsuario == email);
            _usuario.SenhaUsuario = NovaSenha(10);
            _db.SaveChanges();
            MailService.Send(new Usuario(_usuario.IdUsuario, _usuario.NmUsuario, _usuario.SbrnmUsuario, _usuario.DtNascUsuario.ToString(), _usuario.EmailUsuario, _usuario.SenhaUsuario, _usuario.IdTipoUsuario));
        }
        #endregion

        #region Métodos auxiliares
        public static string NovaSenha(int tamanho)
        {
            var caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%/&*()_-=+?{}[]";
            var random = new Random();
            var resultado = new string(
                Enumerable.Repeat(caracteres, tamanho)
                          .Select(x => x[random.Next(x.Length)])
                          .ToArray());
            return resultado;
        }
        #endregion
    }
}
