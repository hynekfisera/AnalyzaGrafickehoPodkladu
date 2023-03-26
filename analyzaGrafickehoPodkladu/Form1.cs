namespace analyzaGrafickehoPodkladu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = of.FileName;
                    btnLoad.Enabled = false;
                    btnNew.Enabled = true;
                }
            }
        }
    }
}