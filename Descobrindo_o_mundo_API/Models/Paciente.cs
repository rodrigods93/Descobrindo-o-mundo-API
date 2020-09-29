using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Descobrindo_o_mundo_API.Models
{
    public class Paciente : Usuario
    {
        #region Propriedades
        private int _idUsuario;
        private string _nickname;
        #endregion

        #region Properties
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Nickname { get => _nickname; set => _nickname = value; }
        #endregion

        #region Construtores
        public Paciente() : base ()
        {
        
        }

        public Paciente(int id, string nome, string sobrenome, string dtNascimento, string email, string senha, int tipo,int idUsuario,string nickname) : base(id,nome,sobrenome,dtNascimento,email,senha,tipo)
        {
            this.IdUsuario = idUsuario;
            this.Nickname = nickname;
        }

        public Paciente(string nick,int idUsuario)
        {
            this.Nickname = nick;
            this.IdUsuario = idUsuario;
        }
        #endregion

        /*
         * TODO
         * Método para cadastrar usuário dentro do BD.*/
        public void Cadastrar(Paciente paciente,int idUsuario)
        {
            TblPaciente tblPaciente = new TblPaciente(paciente.Nickname,idUsuario);
            _db.TblPaciente.Add(tblPaciente);
        }
    }
}
