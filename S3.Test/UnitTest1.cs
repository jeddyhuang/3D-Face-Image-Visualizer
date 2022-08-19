using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S3.Framework.Entities;
using S3.Framework.Readers;
using S3.Services;
using S3.ViewModels;
using System.Diagnostics;

namespace S3.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RealTest()
        {
            try
            {
                const string directory = @"C:\Users\rxiao\Desktop\New folder";
                const string dataset = "309576";

                var objReader = new ObjReader();
                var objModel = objReader.LoadObjFile(Path.Combine(directory, dataset + ".obj"));


                var results = new List<PositionVertexFaceViewModel>();
                for (var i = 1; i <= 3; i++)
                {
                    var jpgFile = dataset + "_" + i + ".jpg";
                    var image = new Image<Bgr, float>(Path.Combine(directory, jpgFile));

                    var material = objModel.Materials.First(m => m.File == jpgFile);
                    var faces = objModel.Faces.Where(f => f.UseMtl == material.Name);

                    var posFile = dataset + "_" + i + ".pos";
                    var posReader = new PosReader();
                    posReader.Load(Path.Combine(directory, posFile));

                    foreach (var position in posReader.Positions)
                    {
                        var p = position.ToPercentage(image.Width, image.Height);

                        var matchedFaces = faces.Where(f => f.ContainsTexturePoint(p));
                        if (matchedFaces.Any())
                        {
                            var pvf = matchedFaces.GetClosestVertexWithFace(p);
                            results.Add(pvf);
                        }

                    }//End foreach loop

                }//End for loop

                foreach (var item in results)
                {
                    Debug.Write(item.Position.Name);
                    Debug.Write(" ");
                    Debug.Write(item.Vertex.Index);
                    Debug.Write(" ");
                    Debug.WriteLine(item.Face.Index);
                }
                //TODO: Write Results to File

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
