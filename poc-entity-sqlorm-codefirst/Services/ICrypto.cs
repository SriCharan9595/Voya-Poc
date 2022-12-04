using poc_voya_entity.Models;

namespace poc_voya_entity.Services
{
    public interface ICrypto
    {
        Task<IEnumerable<crypto>> getAllCrypto();
        Task<crypto> getCryptoByID(int id);
        Task updateCrypto(int id, crypto crypto);
        Task createCrypto(crypto crypto);
        Task deleteCrypto(int id);
    }
}
