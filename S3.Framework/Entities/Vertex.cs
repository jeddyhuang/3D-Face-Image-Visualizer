using System.Collections.Generic;
using S3.Framework.Common;

namespace S3.Framework.Entities
{
    public class Vertex : StructureType
    {
        public int Index { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Vertex(IEnumerable<string> data = null) : base(data) { }

        public override void Load(List<string> data)
        {
            data.MustBeLength(Constants.MinimumDataLength_Vertex)
                .MustBePrefix(Constants.Prefix_Vertex);

            X = CommonUtil.StringToFloat(data[1], "X");
            Y = CommonUtil.StringToFloat(data[2], "Y");
            Z = CommonUtil.StringToFloat(data[3], "Z");
        }

        public override string ToString()
        {
            return $"{Constants.Prefix_Vertex} {X} {Y} {Z}";
        }
    }
}
