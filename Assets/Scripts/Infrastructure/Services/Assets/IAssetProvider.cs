namespace Infrastructure.Services.Assets
{
    public interface IAssetProvider : IService
    {
        Customer GetCustomerPrefab();
        Item GetPrefabItem(string id);
    }
}
