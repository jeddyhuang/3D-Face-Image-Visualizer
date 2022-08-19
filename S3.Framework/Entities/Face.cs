using System.Collections.Generic;
using System.Linq;
using System.Text;
using S3.Framework.Common;

namespace S3.Framework.Entities
{
    public class VertexIndices
    {
        public int VertexIndex { get; set; }
        public int? VertexTextureIndex { get; set; }
        public int VertexNormalIndex { get; set; }
    }

    public class VertexDetail
    {
        public Vertex Vertex { get; set; }
        public VertexTexture VertexTexture { get; set; }
        public VertexNormal VertexNormal { get; set; }
    }

    public class Face : StructureType
    {
        public int Index { get; set; }

        public string UseMtl { get; set; }

        public IEnumerable<VertexTexture> VertexTextures
        {
            get
            {
                return VertexDetails.Select(vd => vd.VertexTexture);
            }
        }

        public IEnumerable<Vertex> Vertices
        {
            get
            {
                return VertexDetails.Select(vd => vd.Vertex);   
            }
        }

        public IEnumerable<VertexNormal> VertexNormals
        {
            get
            {
                return VertexDetails.Select(vd => vd.VertexNormal);
            }
        }

        public Dimension_2D TextureDimension
        {
            get
            {
                var vts = VertexTextures;

                return new Dimension_2D
                {
                    XMin = vts.Min(vt => vt.X),
                    XMax = vts.Max(vt => vt.X),

                    YMin = vts.Min(vt => vt.Y),
                    YMax = vts.Max(vt => vt.Y),
                };
            }
        }

        public List<VertexIndices> IndicesInformations = new List<VertexIndices>();

        public List<VertexDetail> VertexDetails = new List<VertexDetail>();

        public Face(IEnumerable<string> data = null) : base(data) { }

        public override void Load(List<string> data)
        {
            data.MustBeLength(Constants.MinimumDataLength_Face)
                .MustBePrefix(Constants.Prefix_Face);

            data.ForEach(LoadTriplet);
        }

        private void LoadTriplet(string triplet)
        {
            var elements = triplet.Split('/');

            if (elements.Length < 3) return;

            var vIndex = CommonUtil.StringToInt(elements[0], "Vertex Index");
            var vtIndex = CommonUtil.StringToNullableInt(elements[1], "Vertex Texture Index");
            var vnIndex = CommonUtil.StringToInt(elements[2], "Vertex Normal Index");

            var indexesInformation = new VertexIndices
            {
                VertexIndex = vIndex,
                VertexTextureIndex = vtIndex,
                VertexNormalIndex = vnIndex
            };

            IndicesInformations.Add(indexesInformation);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Constants.Prefix_Face);

            foreach (var indexesInfo in IndicesInformations)
            {
                sb.Append($" {indexesInfo.VertexIndex}/{indexesInfo.VertexTextureIndex}/{indexesInfo.VertexNormalIndex}");
            }

            return sb.ToString();
        }

        public void SetVertexDetails(
            List<Vertex> vertices,
            List<VertexTexture> vertexTextures,
            List<VertexNormal> vertexNormals)
        {
            foreach (var indices in IndicesInformations)
            {
                var vertexDetail = new VertexDetail
                {
                    Vertex = vertices[indices.VertexIndex],
                    VertexTexture = indices.VertexTextureIndex.HasValue ? vertexTextures[indices.VertexTextureIndex.Value] : null,
                    VertexNormal = vertexNormals[indices.VertexNormalIndex]
                };

                VertexDetails.Add(vertexDetail);
            }

        }

        public bool ContainsTexturePoint(Position p)
        {
            if (TextureDimension.XMin <= p.X && p.X <= TextureDimension.XMax)
            {
                if (TextureDimension.YMin <= p.Y && p.Y <= TextureDimension.YMax)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
