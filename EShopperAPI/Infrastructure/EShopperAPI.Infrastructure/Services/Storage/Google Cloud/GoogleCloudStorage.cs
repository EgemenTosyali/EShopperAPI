using Azure.Storage.Blobs;
using EShopperAPI.Application.Abstractions.Storage.Google_Cloud;
using Google.Api.Gax.ResourceNames;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Infrastructure.Services.Storage.Google_Cloud
{
    public class GoogleCloudStorage : Storage, IGoogleCloudStorage
    {
        private readonly string _bucketName;
        private readonly StorageClient _storageClient;
        private readonly GoogleCredential _googleCredential;

        public GoogleCloudStorage(IConfiguration configuration)
        {
            _googleCredential = GoogleCredential.FromFile(configuration.GetValue<string>("Storage:Google:GoogleCredentialFile"));
            _storageClient = StorageClient.Create(_googleCredential);
            _bucketName = configuration.GetValue<string>("Storage:Google:GoogleCloudStorageBucket");
        }
        public async Task DeleteAsync(string path, string fileName)
        {
            await _storageClient.DeleteObjectAsync(_bucketName, path+fileName);
        }

        public List<string> GetFiles(string path)
        {
            var storageObjects = _storageClient.ListObjects(path);
            List<string> files = new List<string>();
            foreach (var file in storageObjects)
            {
                files.Add(file.Name);
            }
            return files;
        }

        public bool HasFile(string path, string fileName)
        {
            if(_storageClient.GetObject(_bucketName, path + fileName) != null)
                return true;
            return false;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            List<(string fileName, string pathOrContainerName)> datas = new();
            if (!path.EndsWith('/'))
                path += "/";

            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(file.Name);
                using var fileStream = file.OpenReadStream();
                await _storageClient.UploadObjectAsync(_bucketName, path+fileNewName, null, fileStream);
                datas.Add((file.Name, path));
            }
            return datas;
        }
    }
}
