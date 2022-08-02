using System;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.ImageService.Services.Interfaces;

public interface IImageService
{
    Task<string?> GetCardPathAsync(string code);
}
