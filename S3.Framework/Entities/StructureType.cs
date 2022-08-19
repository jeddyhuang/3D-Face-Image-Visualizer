using System.Collections.Generic;
using System.Linq;

namespace S3.Framework.Entities
{
    public abstract class StructureType
    {
        protected StructureType(IEnumerable<string> data = null)
        {
            if (data != null && data.Any())
            {
                Load(data.ToList());
            }
        }

        public abstract void Load(List<string> data);
    }
}
