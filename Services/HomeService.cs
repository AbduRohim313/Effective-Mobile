using Effective_Mobile.Dto;
using Effective_Mobile.Interfaces;

namespace Effective_Mobile.Services;

public class HomeService : IService
{
    private IRepository _repository;

    public HomeService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseDto> LoadFile(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
                return new ResponseDto
                {
                    Message = "Файл не найден или пустой",
                    Status = false
                };

            var allowedExtensions = new[] { "", ".txt" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
                return new ResponseDto
                {
                    Message = "Разрешены только текстовые файлы или файлы без расширения.",
                    Status = false
                };


            using var reader = new StreamReader(file.OpenReadStream());

            var db = (await _repository.Db());
            db.Clear();

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();

                if (string.IsNullOrWhiteSpace(line) || !line.Contains(':'))
                    continue;

                var parts = line.Split(':', 2);
                var platform = parts[0].Trim();

                var locations = parts[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Where(loc => !string.IsNullOrWhiteSpace(loc) && loc.StartsWith("/"))
                    .ToList();
                
                if (locations.Count == 0)
                    continue;
                db[platform] = locations.ToList();
            }

            return new ResponseDto()
            {
                Message = "Данные загружены",
                Status = true
            };
        }
        catch (Exception ex)
        {
            return new ResponseDto
            {
                Message = $"Ошибка при обработке файла: {ex.Message}",
                Status = false
            };
        }
    }
    public async Task<IList<string>> Reklama(string location)
    {
        try
        {
            location = location.Trim();
            if (string.IsNullOrWhiteSpace(location))
                return null;

            var result = new List<string>();

            foreach (var platform in await _repository.Db())
            {
                foreach (var loc in platform.Value)
                {
                    if (string.Equals(location, loc, StringComparison.OrdinalIgnoreCase) ||
                        location.StartsWith(loc + "/", StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(platform.Key);
                        break;
                    }
                }
            }

            return result;
        }
        catch
        {
            return new List<string>();
        }
    }
}