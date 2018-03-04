using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace BCPAO.PhotoManager.Services
{
   // This class is used by the application to send Email and SMS
   // when you turn on two-factor authentication in ASP.NET Identity.
   // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
   // http://www.mimekit.net/
   public class AuthMessageSender : IEmailSender, ISmsSender
   {
      public async Task SendEmailAsync(string email, string subject, string message)
      {
         var emailMessage = new MimeMessage();

         emailMessage.From.Add(new MailboxAddress("BCPAO", "account@bcpao.us"));
         emailMessage.To.Add(new MailboxAddress("", email));
         emailMessage.Subject = subject;
         emailMessage.Body = new TextPart("html") { Text = message };

         using (var client = new SmtpClient())
         {
            client.LocalDomain = "bcpao-us.mail.protection.outlook.com";
            await client.ConnectAsync("bcpao-us.mail.protection.outlook.com", 25, SecureSocketOptions.None).ConfigureAwait(false);
            await client.SendAsync(emailMessage).ConfigureAwait(false);
            await client.DisconnectAsync(true).ConfigureAwait(false);
         }
      }

      public Task SendSmsAsync(string number, string message)
      {
         // Plug in your SMS service here to send a text message.
         return Task.FromResult(0);
      }
   }
}
