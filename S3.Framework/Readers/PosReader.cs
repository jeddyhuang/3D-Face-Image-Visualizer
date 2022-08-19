using System;
using System.Collections.Generic;
using System.Linq;
using S3.Framework.Abstract;
using S3.Framework.Entities;

namespace S3.Framework.Readers
{
    public class PosReader : Reader
    {
        public List<Position> Positions { get; set; }

        public PosReader()
        {
            Positions = new List<Position>();
        }

        protected internal override void Parse(string line)
        {
            var lineItems = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (!lineItems.Any()) return;

            var position = new Position(lineItems);
            Positions.Add(position);
        }

    }
}
