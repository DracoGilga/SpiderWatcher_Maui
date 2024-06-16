using Azure.Storage.Blobs;

namespace SpiderWatcher.Conexion
{
    public class AzureVideoService
    {
        private readonly string _blobStorageConnectionString;
        private readonly string _containerName;

        public AzureVideoService(string blobStorageConnectionString, string containerName)
        {
            _blobStorageConnectionString = blobStorageConnectionString;
            _containerName = containerName;
        }

        public async Task<byte[]> GetVideoAsync(string videoName)
        {
            var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = blobContainerClient.GetBlobClient(videoName);

            using var memoryStream = new MemoryStream();
            await blobClient.DownloadToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
