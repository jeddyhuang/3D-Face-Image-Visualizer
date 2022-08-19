using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using S3.Framework.Abstract;
using S3.Framework.Common;
using S3.Framework.Entities;

namespace S3.Framework.Readers
{
    public sealed class ObjReader : Reader
    {
        public ObjDataModel Model { get; }

        public ObjReader()
        {
            Model = new ObjDataModel();
        }

        private void LoadMaterials(string mtllib)
        {
            var mtlReader = new MtlReader();
            mtlReader.Load(Path.Combine(Directory, mtllib));
            Model.AddMaterials(mtlReader.Materials);
        }

        public ObjDataModel LoadObjFile(string filePath)
        {
            this.Load(filePath);
            return this.Model;
        }

        protected internal override void Parse(string line)
        {
            var lineItems = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!lineItems.Any()) return;

            switch (lineItems[0].ToEnum<DataType>())
            {
                case DataType.usemtl:
                    var useMtl = lineItems[1];
                    Model.SetUseMtl(useMtl);
                    break;

                case DataType.mtllib:
                    var mtlLib = lineItems[1];
                    LoadMaterials(mtlLib);
                    break;

                case DataType.v:
                    var v = new Vertex(lineItems);
                    Model.AddVertex(v);
                    break;

                case DataType.vn:
                    var vn = new VertexNormal(lineItems);
                    Model.AddVertexNormal(vn);
                    break;

                case DataType.vt:
                    var vt = new VertexTexture(lineItems);
                    Model.AddVertexTextures(vt);
                    break;

                case DataType.f:
                    var f = new Face(lineItems);
                    f.SetVertexDetails(Model.Vertices, Model.VertexTextures, Model.VertexNormals);
                    Model.AddFace(f);
                    break;
            }
        }

        protected internal override void UpdateSize()
        {
            this.Model.UpdateSize();
        }
    }
}
