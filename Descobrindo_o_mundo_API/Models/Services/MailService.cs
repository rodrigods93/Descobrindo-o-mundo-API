using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Descobrindo_o_mundo_API.Models.Services
{
    public static class MailService
    {
        #region Propriedades
        private static string _emailOrigem = "suporte.descobrindo.o.mundo@gmail.com";
        private static string _tituloEmail = "Recuperação de senha - Descobrindo o mundo";
        private static string _servidorProvedorEmail = "smtp.gmail.com";
        private static int _portaServidorProvedorEmail = 587;
        private static string _credenciaisEmail = "LightTech@1234";
        #endregion

        #region Métodos
        public static string Send(Usuario usuario)
        {
            MailMessage mailMessage = new MailMessage(_emailOrigem, usuario.Email);

            mailMessage.Subject = _tituloEmail;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"<h1>Pedido de redefinição de senha</h1> <p>Olá {usuario.Nome} {usuario.Sobrenome}, segue as informações para recuperar seu acesso ao aplicativo.</p> <p>Senha: {usuario.Senha}</p>";
            mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
            mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

            SmtpClient smtpClient = new SmtpClient(_servidorProvedorEmail, _portaServidorProvedorEmail);

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_emailOrigem, _credenciaisEmail);

            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
            return "Email enviado com sucesso";
        }
        #endregion
    }
}
