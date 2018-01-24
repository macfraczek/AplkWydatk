using System;
using System.Net.Mail;
using System.Net;

namespace SmtpClientAccess
{
    class Program
    {
        public static void SendEmail(string receiver, string content)
        {
            using (SmtpClient client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "loginaplikacyjny@gmail.com",
                    Password = "Hasloaplikacyjne1"
                };
                client.Credentials = credential;

                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;

                var message = new MailMessage();
                message.To.Add(new MailAddress(receiver));
                message.From = new MailAddress("loginaplikacyjny@gmail.com");
                //Tytuł wiadomości
                message.Subject = "Raport z Aplikacji Wydatkowej";
                message.Body = content;
                message.IsBodyHtml = false;

                client.Send(message);
                Console.WriteLine("Wiadomość została wysłana.");
            }
            Console.ReadKey();
        }
    }
}