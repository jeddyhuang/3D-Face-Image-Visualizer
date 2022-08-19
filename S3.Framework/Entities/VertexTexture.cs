using System.Collections.Generic;
using S3.Framework.Common;

namespace S3.Framework.Entities
{
    public class VertexTexture : StructureType
    {
        public int Index { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public VertexTexture(IEnumerable<string> data = null) : base(data) { }

        public override void Load(List<string> data)
        {
            data.MustBeLength(Constants.MinimumDataLength_VertexTexture)
                .MustBePrefix(Constants.Prefix_VertexTexture);

            X = CommonUtil.StringToFloat(data[1], "X");
            Y = CommonUtil.StringToFloat(data[2], "Y");
        }

        public override string ToString()
        {
            return $"{Constants.Prefix_VertexTexture} {X} {Y}";
        }
    }
}
