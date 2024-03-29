﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Service
{
    public class EmailService
    {
        //Vars:
        private MailMessage email; // datos del mail, cuerpo, asunto, a quien...
        private SmtpClient server; // servidor por el cual mandamos el mail, depende del tipo (investigar)

        //Constructor:
        public EmailService()
        {
            //Funcionando con sandbox de MailTrap
            this.server = new SmtpClient();
            this.server.Credentials = new NetworkCredential("4616c3dc994360", "dfb982da4cd841");
            this.server.EnableSsl = true;
            this.server.Port = 2525;
            this.server.Host = "smtp.mailtrap.io";
        }

        //Metodos
        //Configurar Servicio:
        public void constructMail(string destino, string asunto, string cuerpo)
        {
            
            email = new MailMessage();
            email.From = new MailAddress("noresponderCatalogoCarrito@mail.com");
            email.To.Add(destino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = $"<h2> Mail de CarritoCatalogo!s </h1> <br>{cuerpo}</br>";
           
        }
        //Enviar Mail:
        public void sendMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
