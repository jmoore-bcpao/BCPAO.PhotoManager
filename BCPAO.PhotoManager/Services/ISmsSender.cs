using System.Threading.Tasks;

namespace BCPAO.PhotoManager.Services
{
   public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
