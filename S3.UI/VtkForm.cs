using System;
using System.Windows.Forms;
using Kitware.VTK;

namespace S3.UI
{
    public partial class VtkForm : Form
    {
        public VtkForm()
        {
            InitializeComponent();
        }

        private void oBJFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReadObj();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadObj()
        {
            //OBJ Reader
            var fileDialog = new OpenFileDialog
            {
                Filter = "OBJ|*.obj",
                Multiselect = false
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var reader = vtkOBJReader.New();
                reader.SetFileName(fileDialog.FileName);
                reader.Update();

                var mapper = vtkPolyDataMapper.New();
                mapper.SetInputConnection(reader.GetOutputPort());

                var actor = vtkActor.New();
                actor.SetMapper(mapper);

                var renderWindow = renderWindowControl.RenderWindow;
                var renderer = renderWindow.GetRenderers().GetFirstRenderer();

                renderer.SetBackground(0.2, 0.3, 0.4);

                renderer.AddActor(actor);
                renderWindow.Render();
            }

        }

    }
}
