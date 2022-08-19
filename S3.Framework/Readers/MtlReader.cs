using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using S3.Framework.Abstract;
using S3.Framework.Common;
using S3.Framework.Entities;

namespace S3.Framework.Readers
{
    public class MtlReader : Reader
    {
        public List<Material> Materials { get; }

        public MtlReader()
        {
            Materials = new List<Material>();
        }

        protected internal override void Parse(string line)
        {
            var lineItems = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!lineItems.Any()) return;

            switch (lineItems[0].ToEnum<DataType>())
            {
                case DataType.newmtl:
                    var material = new Material(lineItems[1]);
                    Materials.Add(material);
                    break;

                case DataType.map_Kd:
                    var filename = lineItems[1];
                    Materials[Materials.Count - 1].File = filename;
                    Materials[Materials.Count - 1].FilePath = Path.Combine(Directory, filename);
                    break;
            }
        }
    }
}
