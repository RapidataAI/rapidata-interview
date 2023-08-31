namespace Rapidata.Application.Services;

public interface IMailSender
{
    Task SendMailAsync(string to, string subject, string body, CancellationToken cancellationToken = default);
}
