namespace analyzaGrafickehoPodkladu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoad = new Button();
            numScale = new NumericUpDown();
            labelInfo1 = new Label();
            labelInfo2 = new Label();
            pictureBox1 = new PictureBox();
            labelInfoLast = new Label();
            labelInfoDistance = new Label();
            labelInfoPerimeter = new Label();
            labelInfoArea = new Label();
            labelInfoLastArea = new Label();
            lbSaved = new ListBox();
            btnNew = new Button();
            btnSave = new Button();
            btnImport = new Button();
            btnExport = new Button();
            lbPoints = new ListBox();
            cbOverwrite = new CheckBox();
            labelDistance = new Label();
            labelLast = new Label();
            labelPerimeter = new Label();
            labelArea = new Label();
            labelLastArea = new Label();
            ((System.ComponentModel.ISupportInitialize)numScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(12, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(97, 23);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Načíst obrázek";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // numScale
            // 
            numScale.Location = new Point(251, 12);
            numScale.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numScale.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numScale.Name = "numScale";
            numScale.Size = new Size(58, 23);
            numScale.TabIndex = 1;
            numScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numScale.ValueChanged += numScale_ValueChanged;
            // 
            // labelInfo1
            // 
            labelInfo1.AutoSize = true;
            labelInfo1.Location = new Point(115, 16);
            labelInfo1.Name = "labelInfo1";
            labelInfo1.Size = new Size(130, 15);
            labelInfo1.TabIndex = 2;
            labelInfo1.Text = "Šířka obrázku odpovídá";
            // 
            // labelInfo2
            // 
            labelInfo2.AutoSize = true;
            labelInfo2.Location = new Point(315, 16);
            labelInfo2.Name = "labelInfo2";
            labelInfo2.Size = new Size(53, 15);
            labelInfo2.TabIndex = 3;
            labelInfo2.Text = "metrům.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.mapa;
            pictureBox1.Location = new Point(12, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // labelInfoLast
            // 
            labelInfoLast.AutoSize = true;
            labelInfoLast.Location = new Point(423, 65);
            labelInfoLast.Name = "labelInfoLast";
            labelInfoLast.Size = new Size(124, 15);
            labelInfoLast.TabIndex = 5;
            labelInfoLast.Text = "Poslední vybraný bod:";
            // 
            // labelInfoDistance
            // 
            labelInfoDistance.AutoSize = true;
            labelInfoDistance.Location = new Point(423, 41);
            labelInfoDistance.Name = "labelInfoDistance";
            labelInfoDistance.Size = new Size(226, 15);
            labelInfoDistance.TabIndex = 6;
            labelInfoDistance.Text = "Vzdálenost posledních 2 vybraných bodů:";
            // 
            // labelInfoPerimeter
            // 
            labelInfoPerimeter.AutoSize = true;
            labelInfoPerimeter.Location = new Point(423, 293);
            labelInfoPerimeter.Name = "labelInfoPerimeter";
            labelInfoPerimeter.Size = new Size(129, 15);
            labelInfoPerimeter.TabIndex = 7;
            labelInfoPerimeter.Text = "Obvod vybrané oblasti:";
            // 
            // labelInfoArea
            // 
            labelInfoArea.AutoSize = true;
            labelInfoArea.Location = new Point(423, 268);
            labelInfoArea.Name = "labelInfoArea";
            labelInfoArea.Size = new Size(127, 15);
            labelInfoArea.TabIndex = 8;
            labelInfoArea.Text = "Obsah vybrané oblasti:";
            // 
            // labelInfoLastArea
            // 
            labelInfoLastArea.AutoSize = true;
            labelInfoLastArea.Location = new Point(423, 89);
            labelInfoLastArea.Name = "labelInfoLastArea";
            labelInfoLastArea.Size = new Size(136, 15);
            labelInfoLastArea.TabIndex = 9;
            labelInfoLastArea.Text = "Aktuální celková plocha:";
            // 
            // lbSaved
            // 
            lbSaved.FormattingEnabled = true;
            lbSaved.ItemHeight = 15;
            lbSaved.Location = new Point(423, 152);
            lbSaved.Name = "lbSaved";
            lbSaved.Size = new Size(171, 109);
            lbSaved.TabIndex = 10;
            lbSaved.SelectedIndexChanged += lbSaved_SelectedIndexChanged;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(421, 12);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(173, 23);
            btnNew.TabIndex = 11;
            btnNew.Text = "Nová oblast";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(600, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(188, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Ukončit oblast a uložit";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(423, 123);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(75, 23);
            btnImport.TabIndex = 13;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnExport
            // 
            btnExport.Enabled = false;
            btnExport.Location = new Point(504, 123);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 14;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // lbPoints
            // 
            lbPoints.FormattingEnabled = true;
            lbPoints.ItemHeight = 15;
            lbPoints.Location = new Point(600, 152);
            lbPoints.Name = "lbPoints";
            lbPoints.Size = new Size(188, 109);
            lbPoints.TabIndex = 15;
            // 
            // cbOverwrite
            // 
            cbOverwrite.AutoSize = true;
            cbOverwrite.Location = new Point(603, 127);
            cbOverwrite.Name = "cbOverwrite";
            cbOverwrite.Size = new Size(185, 19);
            cbOverwrite.TabIndex = 16;
            cbOverwrite.Text = "Přepsat zvolený bod kliknutím";
            cbOverwrite.UseVisualStyleBackColor = true;
            // 
            // labelDistance
            // 
            labelDistance.AutoSize = true;
            labelDistance.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelDistance.Location = new Point(655, 41);
            labelDistance.Name = "labelDistance";
            labelDistance.Size = new Size(0, 15);
            labelDistance.TabIndex = 17;
            // 
            // labelLast
            // 
            labelLast.AutoSize = true;
            labelLast.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelLast.Location = new Point(553, 65);
            labelLast.Name = "labelLast";
            labelLast.Size = new Size(0, 15);
            labelLast.TabIndex = 18;
            // 
            // labelPerimeter
            // 
            labelPerimeter.AutoSize = true;
            labelPerimeter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPerimeter.Location = new Point(553, 293);
            labelPerimeter.Name = "labelPerimeter";
            labelPerimeter.Size = new Size(0, 15);
            labelPerimeter.TabIndex = 19;
            // 
            // labelArea
            // 
            labelArea.AutoSize = true;
            labelArea.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelArea.Location = new Point(551, 269);
            labelArea.Name = "labelArea";
            labelArea.Size = new Size(0, 15);
            labelArea.TabIndex = 20;
            // 
            // labelLastArea
            // 
            labelLastArea.AutoSize = true;
            labelLastArea.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelLastArea.Location = new Point(558, 89);
            labelLastArea.Name = "labelLastArea";
            labelLastArea.Size = new Size(0, 15);
            labelLastArea.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 464);
            Controls.Add(labelLastArea);
            Controls.Add(labelArea);
            Controls.Add(labelPerimeter);
            Controls.Add(labelLast);
            Controls.Add(labelDistance);
            Controls.Add(cbOverwrite);
            Controls.Add(lbPoints);
            Controls.Add(btnExport);
            Controls.Add(btnImport);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(lbSaved);
            Controls.Add(labelInfoLastArea);
            Controls.Add(labelInfoArea);
            Controls.Add(labelInfoPerimeter);
            Controls.Add(labelInfoDistance);
            Controls.Add(labelInfoLast);
            Controls.Add(pictureBox1);
            Controls.Add(labelInfo2);
            Controls.Add(labelInfo1);
            Controls.Add(numScale);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private NumericUpDown numScale;
        private Label labelInfo1;
        private Label labelInfo2;
        private PictureBox pictureBox1;
        private Label labelInfoLast;
        private Label labelInfoDistance;
        private Label labelInfoPerimeter;
        private Label labelInfoArea;
        private Label labelInfoLastArea;
        private ListBox lbSaved;
        private Button btnNew;
        private Button btnSave;
        private Button btnImport;
        private Button btnExport;
        private ListBox lbPoints;
        private CheckBox cbOverwrite;
        private Label labelDistance;
        private Label labelLast;
        private Label labelPerimeter;
        private Label labelArea;
        private Label labelLastArea;
    }
}