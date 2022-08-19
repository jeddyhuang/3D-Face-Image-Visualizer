using System.Collections.Generic;
using S3.Framework.Entities;

namespace S3.UI.OpenTK.Primitives
{
    public abstract class PolygonMesh
    {
        public IEnumerable<Face> Faces { get; set; }
            
        public abstract void Draw();
    }
}
