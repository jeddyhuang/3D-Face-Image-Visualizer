using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace S3.UI.OpenTK.Models
{
    public class MousePicker
    {
        private Vector3 _currentRay;


        private Matrix4 _projectionMatrix;
        private Matrix4 _viewMatrix4;

        private Camera _camera;


        public MousePicker(Camera cam, Matrix4 projectionMatrix)
        {
            this._camera = cam;
            this._projectionMatrix = projectionMatrix;

        }

    }
}
