namespace Expert.WebShop.Vjezbe.models
{
    public class UploadedFiles
    {
        public int ProductId { get; set; }

        public string FileName { get; set; }

        public byte[] FileContent { get; set; }
    }
}
