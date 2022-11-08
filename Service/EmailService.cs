using System;
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
            this.server = new SmtpClient();
            this.server.Credentials = new NetworkCredential("cuanta@mail.com", "password");
            this.server.EnableSsl = true;
            this.server.Port = 587;
            this.server.Host = "smpt.gmail.com";
        }

        public void constructEmail(string destino, string asunto, string cuerpo)
        {
            
            email = new MailMessage();
            email.From = new MailAddress(destino);


           
        }
    }
}
