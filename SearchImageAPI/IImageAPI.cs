using System.Threading.Tasks;

namespace SearchImageAPI
{
    public interface IImageAPI
    {
        Task<string> GetImageURL(string discription);
    }
}