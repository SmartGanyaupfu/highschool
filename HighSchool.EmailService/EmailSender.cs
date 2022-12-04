using System;
using HighSchool.Contracts;
using HighSchool.Shared.Configs;
using HighSchool.Shared.DTOs;
using MailKit.Net.Smtp;
using MimeKit;

namespace HighSchool.EmailService
{
    public class EmailSender:IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        // private readonly ILoggerManager _logger;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;

        }
        public void SendEmail(EmailMessageDto message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        public async Task SendEmailAsync(EmailMessageDto message)
        {
            var emailMessage = CreateEmailMessage(message);
            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessageDto message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("",_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<p style='color:black;'>{0}</p> <p></p>", message.Content) };

            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);// SecureSocketOptions.Auto);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    //client.Connect(hostName, port, SecureSocketOptions.Auto);

                    await client.SendAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.
                    // _logger.LogError($"Something went went wrong see ex: {ex.Message}");
                    throw;

                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);// SecureSocketOptions.Auto);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    //client.Connect(hostName, port, SecureSocketOptions.Auto);

                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.
                    //  _logger.LogError($"Something went went wrong see ex: {ex.Message}");
                    throw;

                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}

