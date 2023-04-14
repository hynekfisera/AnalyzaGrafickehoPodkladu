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
            lbSaved.SelectedIndex = -1;
            UpdateAll();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = cbImprove.Checked ? GetCornerPoint(e.Location) : e.Location;
            if (IsCreatingNew)
            {
                SavedAreas[SavedAreas.Count - 1].Points.Add(point);
                if (SavedAreas[SavedAreas.Count - 1].Points.Count >= 3)
                {
                    btnSave.Enabled = true;
                }
            }
            else if (cbOverwrite.Checked && lbPoints.SelectedIndex >= 0)
            {
                SavedAreas[lbSaved.SelectedIndex].Points[lbPoints.SelectedIndex] = point;
                lbPoints.Items[lbPoints.SelectedIndex] = point;
            }
            UpdateAll();
        }

        private Point GetCornerPoint(Point clickedPoint)
        {
            if (!IsBlank(clickedPoint))
            {
                return clickedPoint;
            }
            else
            {
                var initialIntersections = GetClosestIntersections(clickedPoint);
                Point centerA = GetCenterPoint(clickedPoint, GetIntersectionPoint(clickedPoint, initialIntersections[0]));
                Point centerB = GetCenterPoint(clickedPoint, GetIntersectionPoint(clickedPoint, initialIntersections[1]));
                Point center;
                if (DistanceIsUpDown(initialIntersections[0]))
                {
                    center = new Point(centerB.X, centerA.Y);
                } else
                {
                    center = new Point(centerA.X, centerB.Y);
                }
                var centerIntersections = GetClosestIntersections(center);
                if (initialIntersections[0].Item2 == centerIntersections[0].Item2)
                {
                    return GetSymmetricalPoint(GetIntersectionPoint(center, centerIntersections[0]), GetIntersectionPoint(clickedPoint, initialIntersections[0]));
                } else if (initialIntersections[0].Item2 == centerIntersections[1].Item2)
                {
                    return GetSymmetricalPoint(GetIntersectionPoint(center, centerIntersections[1]), GetIntersectionPoint(clickedPoint, initialIntersections[0]));
                }
                else if (initialIntersections[1].Item2 == centerIntersections[0].Item2)
                {
                    return GetSymmetricalPoint(GetIntersectionPoint(center, centerIntersections[0]), GetIntersectionPoint(clickedPoint, initialIntersections[1]));
                }
                else if (initialIntersections[1].Item2 == centerIntersections[1].Item2)
                {
                    return GetSymmetricalPoint(GetIntersectionPoint(center, centerIntersections[1]), GetIntersectionPoint(clickedPoint, initialIntersections[1]));
                }
                else
                {
                    MessageBox.Show("Došlo k problému se kterým se silnì nepoèítalo");
                    return clickedPoint;
                }
                //string min = intersections.Min().Item2;
                //switch (min)
                //{
                //    case "up":
                //        return new Point(clickedPoint.X, clickedPoint.Y - intersections.First(x => x.Item2 == min).Item1);
                //    case "down":
                //        return new Point(clickedPoint.X, clickedPoint.Y + intersections.First(x => x.Item2 == min).Item1);
                //    case "right":
                //        return new Point(clickedPoint.X + intersections.First(x => x.Item2 == min).Item1, clickedPoint.Y);
                //    case "left":
                //        return new Point(clickedPoint.X - intersections.First(x => x.Item2 == min).Item1, clickedPoint.Y);
                //    default:
                //        return clickedPoint;
                //}
            }
        }

        private Point GetIntersectionPoint(Point clickedPoint, (int, string) intersection)
        {
            switch (intersection.Item2)
            {
                case "up":
                    return new Point(clickedPoint.X, clickedPoint.Y - intersection.Item1);
                case "down":
                    return new Point(clickedPoint.X, clickedPoint.Y + intersection.Item1);
                case "right":
                    return new Point(clickedPoint.X + intersection.Item1, clickedPoint.Y);
                case "left":
                    return new Point(clickedPoint.X - intersection.Item1, clickedPoint.Y);
                default:
                    return clickedPoint;
            }
        }

        private (int, string)[] GetClosestIntersections(Point point)
        {
            var intersections = GetIntersections(point).ToList();
            intersections.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            bool IsUpDown = DistanceIsUpDown(intersections, 0);
            var firstIntersection = intersections[0];
            for (int i = 1; i < 4; i++)
            {
                if (IsUpDown ? DistanceIsLeftRight(intersections, i) : DistanceIsUpDown(intersections, i))
                {
                    return new[] { firstIntersection, intersections[i] };
                }
            }
            return intersections.ToArray();
        }

        private bool DistanceIsUpDown(List<(int, string)> intersections, int index)
        {
            return new[] { "up", "down" }.FirstOrDefault(x => x == intersections[index].Item2) != null;
        }

        private bool DistanceIsUpDown((int, string) intersection)
        {
            return new[] { "up", "down" }.FirstOrDefault(x => x == intersection.Item2) != null;
        }

        private bool DistanceIsLeftRight(List<(int, string)> intersections, int index)
        {
            return new[] { "left", "right" }.FirstOrDefault(x => x == intersections[index].Item2) != null;
        }

        private bool DistanceIsLeftRight((int, string) intersection)
        {
            return new[] { "left", "right" }.FirstOrDefault(x => x == intersection.Item2) != null;
        }

        private (int, string)[] GetIntersections(Point point)
        {
            int initial = Math.Max(pictureBox1.Image.Width, pictureBox1.Image.Height);
            int up = initial;
            int down = initial;
            int left = initial;
            int right = initial;

            for (int i = point.Y - 1; i > 0; i--)
            {
                if (!IsBlank(point.X, i))
                {
                    up = point.Y - i;
                    break;
                }
            }
            for (int i = point.Y + 1; i < pictureBox1.Image.Height; i++)
            {
                if (!IsBlank(point.X, i))
                {
                    down = i - point.Y;
                    break;
                }
            }
            for (int i = point.X + 1; i < pictureBox1.Image.Width; i++)
            {
                if (!IsBlank(i, point.Y))
                {
                    right = i - point.X;
                    break;
                }
            }
            for (int i = point.X - 1; i > 0; i--)
            {
                if (!IsBlank(i, point.Y))
                {
                    left = point.X - i;
                    break;
                }
            }
            return new[] {
                    (up, "up"),
                    (down, "down"),
                    (left, "left"),
                    (right, "right")
            };
        }

        private Point GetSymmetricalPoint(Point center, Point a)
        {
            int x = center.X - a.X;
            int y = center.Y - a.Y;
            return new Point(center.X + x, center.Y + y);
        }

        private Point GetCenterPoint(Point a, Point b)
        {
            int x = (a.X + b.X) / 2;
            int y = (a.Y + b.Y) / 2;
            return new Point(x, y);
        }

        private bool IsBlank(int x, int y)
        {
            Point point = new Point(x, y);
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            return bmp.GetPixel(point.X, point.Y).Name == "ffffffff";
        }

        private bool IsBlank(Point point)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            return bmp.GetPixel(point.X, point.Y).Name == "ffffffff";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = true;
            btnExport.Enabled = true;
            btnNew.Enabled = true;
            btnSave.Enabled = false;
            IsCreatingNew = false;
            lbSaved.Items.Add(SavedAreas[SavedAreas.Count - 1]);
            lbSaved.SelectedIndex = lbSaved.Items.Count - 1;
            UpdateAll();
        }

        private double GetRealDistance(double distance)
        {
            return distance * ((double)numScale.Value / 400);
        }

        private double GetRealArea(double distance)
        {
            return distance * (((double)numScale.Value * (double)numScale.Value) / (400 * 400));
        }

        private void UpdateAll()
        {
            pictureBox1.Invalidate();
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
            UpdateAll();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Blue, 2);
            SolidBrush brush = new SolidBrush(Color.Red);
            if (SavedAreas.Count >= 1 && (IsCreatingNew || (lbSaved.SelectedIndex != -1 && SavedAreas.Count >= lbSaved.SelectedIndex)))
            {
                Area visibleArea = IsCreatingNew ? SavedAreas[SavedAreas.Count - 1] : SavedAreas[lbSaved.SelectedIndex];
                for (int i = 0; i < visibleArea.Points.Count; i++)
                {
                    Point a = visibleArea.Points[i];
                    Point b = i == visibleArea.Points.Count - 1 ? visibleArea.Points[0] : visibleArea.Points[i + 1];
                    if (i == visibleArea.Points.Count - 1 && IsCreatingNew) break;
                    g.DrawLine(pen, a, b);
                }
                foreach (var point in visibleArea.Points)
                {
                    g.FillEllipse(brush, point.X - 5, point.Y - 5, 10, 10);
                }
            }
        }

        private void numScale_ValueChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string[] lines = new string[SavedAreas.Count];
            for (int i = 0; i < lines.Length; i++)
            {
                Area area = SavedAreas[i];
                lines[i] = "";
                for (int j = 0; j < area.Points.Count; j++)
                {
                    Point point = area.Points[j];
                    lines[i] += $"{point.X},{point.Y}";
                    if (j != area.Points.Count - 1)
                    {
                        lines[i] += ";";
                    }
                }
            }
            File.WriteAllLines("saved.csv", lines);
            MessageBox.Show("Úspìšnì vyexportováno do saved.csv");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(of.FileName);
                    foreach (string line in lines)
                    {
                        SavedAreas.Add(new Area(SavedAreas.Count));
                        foreach (string point in line.Split(";"))
                        {
                            string[] xAndY = point.Split(",");
                            int x = int.Parse(xAndY[0]);
                            int y = int.Parse(xAndY[1]);
                            SavedAreas[SavedAreas.Count - 1].Points.Add(new Point(x, y));
                        }
                    }
                    if (SavedAreas.Count >= 0)
                    {
                        lbSaved.Items.Clear();
                        lbSaved.Items.AddRange(SavedAreas.ToArray());
                        btnExport.Enabled = true;
                    }
                }
            }
        }
    }
}