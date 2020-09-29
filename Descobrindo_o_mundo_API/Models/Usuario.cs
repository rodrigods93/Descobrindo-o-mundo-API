﻿using System;
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
        protected descobrindo_mundoContext _db;
        #endregion

        #region Properties
        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Sobrenome { get => _sobrenome; set => _sobrenome = value; }
        public string DtNascimento { get => _dtNascimento.ToString(); set => _dtNascimento = DateTime.Parse(value.ToString()); }
        public string Email { get => _email; set => _email = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public int Tipo { get => _tipo; set => _tipo = value; }
        #endregion

        #region Construtores
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

        public Usuario()
        {
            _db = new descobrindo_mundoContext();
        }
        #endregion

        #region Métodos
        public Usuario Login(string email, string senha)
        {
            var _usuarioBusca = _db.TblUsuario.Single(x => (x.EmailUsuario == email) && (x.SenhaUsuario == senha));
            Usuario UsuarioRetorno = new Usuario(_usuarioBusca.IdUsuario, _usuarioBusca.NmUsuario, _usuarioBusca.SbrnmUsuario, _usuarioBusca.DtNascUsuario.ToString(), _usuarioBusca.EmailUsuario, _usuarioBusca.SenhaUsuario, _usuarioBusca.IdTipoUsuario);
            return UsuarioRetorno;
        }

        public void Cadastrar(Usuario usuario)
        {
            TblUsuario _usuarioCadastro = new TblUsuario(usuario.Nome, usuario.Sobrenome, usuario._dtNascimento, usuario.Email, usuario.Senha, usuario.Tipo);
            _db.TblUsuario.Add(_usuarioCadastro);
        }

        #endregion

        #region Métodos auxiliares

        #endregion
    }
}