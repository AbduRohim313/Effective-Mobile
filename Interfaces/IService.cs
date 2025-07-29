using Effective_Mobile.Dto;

namespace Effective_Mobile.Interfaces;

public interface IService
{
    public Task<ResponseDto> LoadFile(IFormFile file);
    public Task<IList<string>> Reklama(string location);
}