using System.Threading.Tasks;

namespace Infrastructure.Services.Scenes
{
    public interface ISceneLoaderService
    {
        Task LoadAsync(Scene scene);
        Task UnLoadAsync(Scene scene);
    }
}