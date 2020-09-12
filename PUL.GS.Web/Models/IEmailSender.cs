using System.Threading.Tasks;

namespace PUL.GS.Web.Models
{
    public interface IEmailSender
    {
        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendEmailAsync(string email, string subject, string message);
    }
}
