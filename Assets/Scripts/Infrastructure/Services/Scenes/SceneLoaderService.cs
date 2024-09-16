using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Extensions;

namespace Infrastructure.Services.Scenes
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public async Task LoadAsync(Scene scene) =>
            await SceneManager.LoadSceneAsync(scene.SceneName);

        public async Task UnLoadAsync(Scene scene) =>
            await SceneManager.UnloadSceneAsync(scene.SceneName);
    }
}
