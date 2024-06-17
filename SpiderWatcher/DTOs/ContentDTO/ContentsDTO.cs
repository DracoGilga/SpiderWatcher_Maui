using Newtonsoft.Json;

namespace SpiderWatcher.DTOs.ContentDTO
{
    public class ContentsDTO
    {
        public int idContent { get; set; }
        public string title { get; set; }
        public string imageReference { get; set; }

        [JsonIgnore]
        public byte[] ImageData { get; set; }  // Nueva propiedad para almacenar los datos de la imagen
    }
}
