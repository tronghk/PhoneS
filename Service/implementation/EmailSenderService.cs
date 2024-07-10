using DataAccess;
using System.Net;
using System.Net.Mail;


namespace Service.implementation
{
    public class EmailSenderService : IEmailSender
    {
        private ApplicationDbContext _context;
        public EmailSenderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            var mail = "thantrite1@gmail.com";
            var pw = "cqbnonklbzsbknxz";

            MailMessage mailMessage = new MailMessage(
                  from: mail,
                  to: email,
                  subject: subject,
                  body: message
              );
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.ReplyToList.Add(new MailAddress(mail));
            mailMessage.Sender = new MailAddress(mail);

            // Tạo SmtpClient kết nối đến smtp.gmail.com
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential(mail, pw);
                client.EnableSsl = true;
                return await SendMail(mail, email, subject, message, client);
            }


        }
        public static async Task<bool> SendMail(string _from, string _to, string _subject, string _body, SmtpClient client)
        {
            // Tạo nội dung Email
            MailMessage message = new MailMessage(
                from: _from,
                to: _to,
                subject: _subject,
                body: _body
            );
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);


            try
            {
                await client.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }


}
