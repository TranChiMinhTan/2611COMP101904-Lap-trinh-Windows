namespace COMP1019_Lab08_SimplePaint
{
    partial class FrmPaint
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblMode = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.btnColor = new System.Windows.Forms.Button();
            this.pnlCurrentColor = new System.Windows.Forms.Panel();
            this.chkFill = new System.Windows.Forms.CheckBox();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.canvas = new COMP1019_Lab08_SimplePaint.DoubleBufferedPanel();
            this.lblStatus = new System.Windows.Forms.Label();

            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.SuspendLayout();

            //
            // pnlToolbar
            //
            this.pnlToolbar.Controls.Add(this.lblMode);
            this.pnlToolbar.Controls.Add(this.cboMode);
            this.pnlToolbar.Controls.Add(this.lblWidth);
            this.pnlToolbar.Controls.Add(this.nudWidth);
            this.pnlToolbar.Controls.Add(this.btnColor);
            this.pnlToolbar.Controls.Add(this.pnlCurrentColor);
            this.pnlToolbar.Controls.Add(this.chkFill);
            this.pnlToolbar.Controls.Add(this.btnBackColor);
            this.pnlToolbar.Controls.Add(this.btnUndo);
            this.pnlToolbar.Controls.Add(this.btnClear);
            this.pnlToolbar.Controls.Add(this.btnOpenImage);
            this.pnlToolbar.Controls.Add(this.btnSave);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(960, 44);
            this.pnlToolbar.TabIndex = 2;

            //
            // lblMode
            //
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(10, 13);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(49, 15);
            this.lblMode.Text = "Chế độ:";

            //
            // cboMode
            //
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Location = new System.Drawing.Point(62, 9);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(95, 23);
            this.cboMode.TabIndex = 0;
            this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);

            //
            // lblWidth
            //
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(170, 13);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(48, 15);
            this.lblWidth.Text = "Độ dày:";

            //
            // nudWidth
            //
            this.nudWidth.Location = new System.Drawing.Point(225, 9);
            this.nudWidth.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(55, 23);
            this.nudWidth.TabIndex = 1;
            this.nudWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });

            //
            // btnColor
            //
            this.btnColor.Location = new System.Drawing.Point(295, 7);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(85, 28);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Chọn màu";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);

            //
            // pnlCurrentColor
            //
            this.pnlCurrentColor.BackColor = System.Drawing.Color.Black;
            this.pnlCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCurrentColor.Location = new System.Drawing.Point(386, 9);
            this.pnlCurrentColor.Name = "pnlCurrentColor";
            this.pnlCurrentColor.Size = new System.Drawing.Size(24, 24);
            this.pnlCurrentColor.TabStop = false;

            //
            // chkFill
            //
            this.chkFill.AutoSize = true;
            this.chkFill.Enabled = false;
            this.chkFill.Location = new System.Drawing.Point(422, 12);
            this.chkFill.Name = "chkFill";
            this.chkFill.Size = new System.Drawing.Size(66, 19);
            this.chkFill.TabIndex = 3;
            this.chkFill.Text = "Tô màu";
            this.chkFill.UseVisualStyleBackColor = true;

            //
            // btnBackColor
            //
            this.btnBackColor.Location = new System.Drawing.Point(500, 7);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(85, 28);
            this.btnBackColor.TabIndex = 4;
            this.btnBackColor.Text = "Màu nền";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);

            //
            // btnUndo
            //
            this.btnUndo.Location = new System.Drawing.Point(595, 7);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(70, 28);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);

            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(671, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 28);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            //
            // btnOpenImage
            //
            this.btnOpenImage.Location = new System.Drawing.Point(751, 7);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(100, 28);
            this.btnOpenImage.TabIndex = 7;
            this.btnOpenImage.Text = "Mở ảnh nền";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);

            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(857, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu PNG";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            //
            // canvas
            //
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 44);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(960, 532);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseLeave += new System.EventHandler(this.canvas_MouseLeave);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);

            //
            // lblStatus
            //
            this.lblStatus.AutoSize = false;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 576);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblStatus.Size = new System.Drawing.Size(960, 24);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Tọa độ: -";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            //
            // FrmPaint
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlToolbar);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "FrmPaint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Paint - COMP1019 Lab 08";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPaint_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPaint_KeyDown);
            this.Load += new System.EventHandler(this.FrmPaint_Load);

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Panel pnlCurrentColor;
        private System.Windows.Forms.CheckBox chkFill;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Button btnSave;
        private DoubleBufferedPanel canvas;
        private System.Windows.Forms.Label lblStatus;
    }
}
