namespace Service.implementation
{
    public interface IEmailSender
    {
        public Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}
