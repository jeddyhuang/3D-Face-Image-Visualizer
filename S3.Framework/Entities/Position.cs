using System.Collections.Generic;
using S3.Framework.Common;

namespace S3.Framework.Entities
{
    public class Position : StructureType
    {
        public string Name { get; set; }
        public float X { get; set; }

        public float Y { get; set; }

        public Position() { }

        public Position(IEnumerable<string> data) : base(data) { }

        public override void Load(List<string> data)
        {
            data.MustBeLength(Constants.MinimumDataLength_Position);

            Name = data[0];
            X = CommonUtil.StringToFloat(data[1], "X");
            Y = CommonUtil.StringToFloat(data[2], "Y");
        }

        public override string ToString()
        {
            return $"{Name} {X} {Y}";
        }
    }
}
