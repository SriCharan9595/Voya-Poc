using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using poc_voya_entity.Models;

namespace poc_voya_entity.Services
{
    public class CryptoService: ICrypto
    {
        private readonly cryptoContext _context;

        public CryptoService(cryptoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<crypto>> getAllCrypto()
        {
            return await _context.crypto.ToListAsync();
        }

        public async Task<crypto> getCryptoByID(int id)
        {
            var crypto = await _context.crypto.FindAsync(id);

            if (crypto == null)
            {
                throw new KeyNotFoundException("crypto not found");
            }

            return crypto;
        }

        public async Task updateCrypto(int id, crypto crypto)
        {
            if (id != crypto.cryptoID)
            {
                throw new ArgumentException("id not exists");
            }

            _context.Entry(crypto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task createCrypto(crypto crypto)
        {
            _context.crypto.Add(crypto);
            await _context.SaveChangesAsync();
        }

        public async Task deleteCrypto(int id)
        {
            var crypto = await _context.crypto.FindAsync(id);
            if (crypto == null)
            {
                throw new KeyNotFoundException("crypto not found");
            }
            _context.crypto.Remove(crypto);
            await _context.SaveChangesAsync();
        }
    }
}

