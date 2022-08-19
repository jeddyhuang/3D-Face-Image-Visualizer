namespace S3.UI.OpenTK.Models
{
    public struct TextureMaterial2D
    {
        public int Id { get; }
        public string MaterialName { get; }
        public int Width { get; }
        public int Height { get; }

        public TextureMaterial2D(int id, string materialName, int width, int height)
        {
            this.Id = id;
            this.MaterialName = materialName;
            this.Width = width;
            this.Height = height;
        }

                
        public bool IsValid => !string.IsNullOrEmpty(MaterialName);
    }
}
