using System.Collections.Generic;
using S3.Framework.Entities;

namespace S3.ViewModels
{
    public class ObjDataViewModel
    {
        public ObjDataModel ObjDataModel { get; set; }  

        public IEnumerable<PositionVertexFaceViewModel> PositionVertexFaces { get; set; }
    }
}
