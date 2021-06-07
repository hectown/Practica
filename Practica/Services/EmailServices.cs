using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Practica.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;

namespace Practica.Services
{
    public class EmailServices
    {

        public async Task<OperationResult<bool>> SendAsync(string from, string from_name, string to, string to_name, string subject, string mensaje)
        {
            var result = new OperationResult<bool> { Success = false };
            try
            {
                var mailMessage = new MimeMessage();

                mailMessage.From.Add(new MailboxAddress(from_name, from));

                mailMessage.To.Add(new MailboxAddress(to_name, to));

                mailMessage.Subject = subject;

                mailMessage.Body = new TextPart("html")

                {
                    Text = @"<h1>SE RECIBIO UN COMENTARIO DESDE EL SISTEMA DE ANUNCIOS EMPRESARIALES CON LA SIGUIENTE INFORMACÓN DE CONTACTO</h1>
                                       <p>Nombre: " + from_name +@".</p> 
                                       <p>Correo contacto: " + from + @".</p> 
                                        <p>Mensaje: "+ mensaje +@"."
                                      
                    // Text = mensaje

                };

                using (var smtpClient = new SmtpClient())

                {

                    //   smtpClient.Connect("smtp.gmail.com", 587, true);
                    smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtpClient.Authenticate("productosdiversos2021@gmail.com", "utSYNORP");

                     smtpClient.Send(mailMessage);

                     smtpClient.Disconnect(true);

                }



                result.Success = true;
                result.Data = true;

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.ErrorType = ErrorType.Fatal;
            }


            return result;
        }

    }
}