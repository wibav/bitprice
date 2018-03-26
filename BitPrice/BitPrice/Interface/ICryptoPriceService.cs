using BitPrice.Models;
using BitPrice.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitPrice.Interface
{
    interface ICryptoPriceService
    {
        Task<List<CryptoPrices>> GetPrices();
    }
}
