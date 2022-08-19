using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using S3.Framework.Readers;

namespace S3.UI
{
    public partial class FacialMorphology : Form
    {
        public FacialMorphology()
        {
            InitializeComponent();
        }

        private const int DefaultWidth = 400;

        public Image<Bgr, byte> LeftImage { get; private set; }
        public Image<Bgr, byte> FrontImage { get; private set; }
        public Image<Bgr, byte> RightImage { get; private set; }

        private int GetWidth()
        {
            return DefaultWidth;
        }

        private int GetHeight(int height, int width)
        {
            return Convert.ToInt32(DefaultWidth * (1.0 * height / width));
        }

        private void btnLeftImage_Click(object sender, EventArgs e)
        {
            LeftImage = DialogSelect();
            DisplayImage(ibLeft, LeftImage);
        }

        private void btnFrontImage_Click(object sender, EventArgs e)
        {
            FrontImage = DialogSelect();
            DisplayImage(ibFront, FrontImage);
        }

        private void btnRightImage_Click(object sender, EventArgs e)
        {
            RightImage = DialogSelect();
            DisplayImage(ibRight, RightImage);
        }

        private Image<Bgr, byte> DialogSelect()
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "JPG|*.jpg",
                Multiselect = false
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = fileDialog.FileName;

                var image = new Image<Bgr, byte>(filePath);

                var posFile = Path.ChangeExtension(filePath, ".pos");

                if (File.Exists(posFile))
                {
                    var posReader = new PosReader();
                    posReader.Load(posFile);
                    var positions = posReader.Positions;


                    foreach (var position in positions)
                    {
                        var name = position.Name;
                        var point = new Point(Convert.ToInt16(position.X), Convert.ToInt16(position.Y));
                        var pointF = new PointF(position.X, position.Y);
                        var circle = new CircleF(pointF, 10);


                        image.Draw(circle, new Bgr(0, 255, 0), 5);
                        image.Draw(name, point, FontFace.HersheyTriplex, 2, new Bgr(Color.Red));
                    }

                }

                return image;
            }
            else
            {
                return null;
            }
        }

        private void DisplayImage(ImageBox imageBox, Image<Bgr, byte> image)
        {
            if (image != null)
            {
                imageBox.Width = GetWidth();
                imageBox.Height = GetHeight(image.Height, image.Width);
                imageBox.Image = image;
            }
        }

    }
}
