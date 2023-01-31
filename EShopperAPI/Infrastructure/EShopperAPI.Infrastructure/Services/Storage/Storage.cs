using EShopperAPI.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Infrastructure.Services.Storage
{
    public class Storage
    {
        /// <summary>
        /// Rename files with filename_datetime for databases unique name system
        /// </summary>
        protected async Task<string> FileRenameAsync(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string oldFileName = Path.GetFileNameWithoutExtension(fileName);
            return $"{NameOperations.CharacterRegulatory(oldFileName)}_{DateTime.Now.ToString("ddMMyyyyHHmmsss", System.Globalization.CultureInfo.InvariantCulture)}{extension}";

        }
    }
}
