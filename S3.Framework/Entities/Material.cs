namespace S3.Framework.Entities
{
    public class Material
    {
        public string Name { get; set; }
        public string File { get; set; }
        public string FilePath { get; set; }


        public Material(string name = null)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {File}";
        }
    }
}
