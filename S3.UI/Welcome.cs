using System;
using System.Windows.Forms;

namespace S3.UI
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFacialMorphology_Click(object sender, EventArgs e)
        {
            var form = new FacialMorphology();
            form.ShowDialog();
        }

        private void btnVTK_Click(object sender, EventArgs e)
        {
            var vtkForm = new VtkForm();
            vtkForm.ShowDialog();
        }
    }
}
