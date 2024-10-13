using MLAPP.DTOs.Requests;
using PuppeteerSharp;

namespace MLAPP.Services.Interfaces
{
    public interface IBrowserService
    {

        Task MadeAndSaveScreenshotAsync(string url, string path, IPage page);
        IEnumerable<string> SearchRequestAndGetUrlList(FormRequestRequestDto dto);
    }
}
