namespace analyzaGrafickehoPodkladu
{
    public partial class Form1 : Form
    {
        public List<Area> SavedAreas { get; set; }
        public bool IsCreatingNew { get; set; }
        public Form1()
        {
            SavedAreas = new List<Area>();
            IsCreatingNew = false;
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
                    //btnLoad.Enabled = false;
                    //btnNew.Enabled = true;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnImport.Enabled = false;
            IsCreatingNew = true;
            SavedAreas.Add(new Area(SavedAreas.Count));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsCreatingNew)
            {
                SavedAreas[SavedAreas.Count - 1].Points.Add(e.Location);
                if (SavedAreas[SavedAreas.Count - 1].Points.Count >= 3)
                {
                    btnSave.Enabled = true;
                }
            }
            UpdateLabels();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = true;
            btnExport.Enabled = true;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            IsCreatingNew = false;
            lbSaved.Items.Add(SavedAreas[SavedAreas.Count - 1]);
            UpdateLabels();
        }
        public double GetRealDistance(double distance)
        {
            return distance * ((double)numScale.Value / 400);
        }

        public double GetRealArea(double distance)
        {
            return distance * (((double)numScale.Value * (double)numScale.Value) / (400 * 400));
        }

        public void UpdateLabels()
        {
            if (IsCreatingNew)
            {
                Area currentArea = SavedAreas[SavedAreas.Count - 1];
                if (currentArea.Points.Count >= 2)
                {
                    Point a = currentArea.Points[currentArea.Points.Count - 1];
                    Point b = currentArea.Points[currentArea.Points.Count - 2];
                    double x = Math.Abs(a.X - b.X);
                    double y = Math.Abs(a.Y - b.Y);
                    double distance = Math.Sqrt(x * x + y * y);
                    int realDistance = (int)GetRealDistance(distance);
                    labelDistance.Text = $"{realDistance} m";
                }
                if (currentArea.Points.Count >= 1)
                {
                    Point a = currentArea.Points[currentArea.Points.Count - 1];
                    int realX = (int)GetRealDistance(a.X);
                    int realY = (int)GetRealDistance(a.Y);
                    labelLast.Text = $"{realX} m; {realY} m";
                }
                if (currentArea.Points.Count >= 3)
                {
                    labelLastArea.Text = $"{(int)GetRealArea(currentArea.GetArea())} m2";
                }
            }
            else
            {
                labelDistance.Text = "";
                labelLast.Text = "";
                labelLastArea.Text = "";
            }
            if (lbSaved.SelectedIndex != -1 && SavedAreas.Count >= lbSaved.SelectedIndex)
            {
                Area selectedArea = SavedAreas[lbSaved.SelectedIndex];
                labelPerimeter.Text = $"{(int)GetRealDistance(selectedArea.GetPerimeter())} m";
                labelArea.Text = $"{(int)GetRealArea(selectedArea.GetArea())} m2";
            }
        }

        private void lbSaved_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSaved.SelectedIndex != -1 && SavedAreas.Count >= lbSaved.SelectedIndex)
            {
                lbPoints.Items.Clear();
                Area selectedArea = SavedAreas[lbSaved.SelectedIndex];
                foreach (Point point in selectedArea.Points)
                {
                    lbPoints.Items.Add(point);
                }
            }
            UpdateLabels();
        }
    }
}