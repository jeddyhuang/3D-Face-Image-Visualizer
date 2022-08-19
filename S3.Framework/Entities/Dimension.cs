namespace S3.Framework.Entities
{
    public class Dimension_3D
    {
        public float XMax { get; set; }
        public float XMin { get; set; }

        public float YMax { get; set; }
        public float YMin { get; set; }

        public float ZMax { get; set; }
        public float ZMin { get; set; }

        public float XSize => XMax - XMin;
        public float YSize => YMax - YMin;
        public float ZSize => ZMax - ZMin;

        public override string ToString()
        {
            return $"{nameof(XMin)}: {XMin} " +
                   $"{nameof(YMin)}: {YMin} " +
                   $"{nameof(ZMin)}: {ZMin} " +
                   $"{nameof(XMax)}: {XMax} " +
                   $"{nameof(YMax)}: {YMax} " +
                   $"{nameof(ZMax)}: {ZMax} ";
        }
    }

    public class Dimension_2D
    {
        public float XMin { get; set; }
        public float XMax { get; set; }

        public float YMin { get; set; }
        public float YMax { get; set; }

        public float XSize => XMax - XMin;
        public float YSize => YMax - YMin;

        public override string ToString()
        {
            return $"{nameof(XMin)}: {XMin} " +
                   $"{nameof(YMin)}: {YMax} " +
                   $"{nameof(XMax)}: {XMax} " +
                   $"{nameof(YMax)}: {YMax} ";
        }
    }
}
