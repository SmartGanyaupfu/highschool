using System;
using HighSchool.Shared.DTOs;

namespace HighSchool.Contracts
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessageDto message);
        Task SendEmailAsync(EmailMessageDto message);
    }
}

