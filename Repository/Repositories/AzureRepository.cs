using DataAccess.Database.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Repositories
{
    public class AzureRepository : IAzureRepository
    {
        private readonly IConfiguration _config;
        private readonly CloudStorageAccount _storageAccount;

        private readonly string _blobImagesContainerName;

        private CloudBlobContainer _imageBlobContainer;

        public AzureRepository(IConfiguration config)
        {
            _config = config;
            _storageAccount = CloudStorageAccount.Parse(_config["Azure:Storage:Tables:Configuration"]);
            _blobImagesContainerName = _config["Azure:Storage:Blobs:Image"];
        }

        private async Task Initialize()
        {
            //initialize Image container
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer imageContainer = blobClient.GetContainerReference(_blobImagesContainerName);
            if (!(await imageContainer.ExistsAsync()))
            {
                await imageContainer.CreateAsync();
                BlobContainerPermissions permissions = await imageContainer.GetPermissionsAsync();
                permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                await imageContainer.SetPermissionsAsync(permissions);
            }
            _imageBlobContainer = imageContainer;
        }

        private static string CreateUniqueBlobPrefix(string fileIdentifier)
        {
            return $"{fileIdentifier}.";
        }

        private static string CreateCompleteBlobName(string shortName, string fileIdentifier)
        {
            return $"{fileIdentifier}.{shortName}";
        }

        private static string GetShortNameFromBlobName(string blobName, string fileIdentifier)
        {
            return blobName.StartsWith($"{fileIdentifier}.") ? blobName.Substring(blobName.IndexOf('}') + 2) : blobName;
        }

        private async Task<bool> FileExists(string fileName)
        {
            return (await _imageBlobContainer.ListBlobsSegmentedAsync(fileName, null)).Results.Any();
        }

        public async Task<string> StoreFile(string name, Guid id, byte[] fileContent)
        {
            var fileId = id.ToString();
            await Initialize();

            var fileName = CreateCompleteBlobName(name, fileId);

            if (string.IsNullOrEmpty(name) || fileContent == null || fileContent.Length == 0 || id == null)
            {
                return string.Empty;
            }

            if (await FileExists(fileName))
            {
                return string.Empty;
            }

            CloudBlockBlob blockBlob = _imageBlobContainer.GetBlockBlobReference(fileName);

            if (blockBlob == null)
                return string.Empty;

            if (fileName.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || fileName.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase))
            {
                blockBlob.Properties.ContentType = "image/jpeg";
            }

            if (fileName.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase)) { blockBlob.Properties.ContentType = "image/png"; }

            await blockBlob.UploadFromByteArrayAsync(fileContent, 0, fileContent.Length);

            blockBlob.Properties.CacheControl = "max-age=31536000, must-revalidate";
            await blockBlob.SetPropertiesAsync();

            var imageUrl = blockBlob.StorageUri.PrimaryUri.AbsoluteUri;

            return imageUrl;
        }

        public async Task<bool> RemoveImage(string fileName)
        {
            var blobContainer = _imageBlobContainer.GetBlockBlobReference(fileName);
            await blobContainer.DeleteIfExistsAsync();

            return true;
        }
    }
}
