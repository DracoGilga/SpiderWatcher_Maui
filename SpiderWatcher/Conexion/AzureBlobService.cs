using Azure.Storage.Blobs;

namespace SpiderWatcher.Conexion
{
    public class AzureBlobService
    {
        private readonly string _blobStorageConnectionString;
        private readonly string _containerName;

        public AzureBlobService(string blobStorageConnectionString, string containerName)
        {
            _blobStorageConnectionString = blobStorageConnectionString;
            _containerName = containerName;
        }

        public async Task<byte[]> GetImageAsync(string imageName)
        {
            var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = blobContainerClient.GetBlobClient(imageName);

            using var memoryStream = new MemoryStream();
            await blobClient.DownloadToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
