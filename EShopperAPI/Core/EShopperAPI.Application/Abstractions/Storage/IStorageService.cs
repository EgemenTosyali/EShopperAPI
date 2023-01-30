using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Abstractions.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
