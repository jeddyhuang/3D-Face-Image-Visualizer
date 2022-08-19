using System;
using System.Collections.Generic;
using S3.Framework.Common;

namespace S3.Framework.Entities
{
    public class VertexNormal : StructureType
    {
        public int Index { get; set; }

        public float I { get; set; }

        public float J { get; set; }

        public float K { get; set; }

        public VertexNormal(IEnumerable<string> data = null) : base(data) { }

        public override void Load(List<string> data)
        {
            data.MustBeLength(Constants.MinimumDataLength_VertexNormal)
                .MustBePrefix(Constants.Prefix_VertexNormal);

            I = CommonUtil.StringToFloat(data[1], "I");
            J = CommonUtil.StringToFloat(data[2], "J");
            K = CommonUtil.StringToFloat(data[3], "K");
        }

        public override string ToString()
        {
            return $"{Constants.Prefix_VertexTexture} {I} {J} {K}";
        }
    }
}
