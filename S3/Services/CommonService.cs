using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using S3.Framework.Entities;
using S3.Framework.Readers;
using S3.ViewModels;

namespace S3.Services
{
    public class CommonService
    {
        public static ObjDataViewModel GetData(string directory, string dataset)
        {
            var objReader = new ObjReader();
            var objModel = objReader.LoadObjFile(Path.Combine(directory, dataset + ".obj"));

            var positionVertexFaces = new List<PositionVertexFaceViewModel>();
            for (var i = 1; i <= 3; i++)
            {
                var jpgFile = dataset + i + ".jpg";
                var image = new Image<Bgr, float>(Path.Combine(directory, jpgFile));

                var material = objModel.Materials.First(m => m.File == jpgFile);
                var faces = objModel.Faces.Where(f => f.UseMtl == material.Name);

                var posFile = dataset + i + ".pos";
                var posReader = new PosReader();
                posReader.Load(Path.Combine(directory, posFile));

                foreach (var position in posReader.Positions)
                {
                    var p = position.ToPercentage(image.Width, image.Height);

                    var matchedFaces = faces.Where(f => f.ContainsTexturePoint(p));
                    if (matchedFaces.Any())
                    {
                        var pvf = matchedFaces.GetClosestVertexWithFace(p);
                        positionVertexFaces.Add(pvf);
                    }

                }//End foreach loop

            }//End for loop

            return new ObjDataViewModel
            {
                ObjDataModel = objModel,
                PositionVertexFaces = positionVertexFaces
            };
        }
    }
    public static class Extensions
    {
        public static PositionVertexFaceViewModel GetClosestVertexWithFace(this IEnumerable<Face> faces, Position p)
        {
            var minDistance = double.MaxValue;

            var v = new Vertex();
            var f = new Face();

            foreach (var face in faces)
            {
                foreach (var vt in face.VertexTextures)
                {
                    var d = Math.Pow(vt.X - p.X, 2) + Math.Pow(vt.Y - p.Y, 2);

                    if (d < minDistance)
                    {
                        minDistance = d;

                        v = face.VertexDetails.Single(vd => vd.VertexTexture == vt).Vertex;
                        f = face;
                    }
                }
            }//End foreach

            return new PositionVertexFaceViewModel(p, v, f);
        }

        public static Position ToPercentage(this Position p, int width, int height)
        {
            return new Position
            {
                Name = p.Name,
                X = p.X / width,
                Y = 1.0f - p.Y / height
            };
        }

    }

}
