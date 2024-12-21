namespace TryForGraph
{
    partial class initGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rightPanel = new System.Windows.Forms.Panel();
            this.frameAlgbtn = new System.Windows.Forms.Button();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rightPanel.Controls.Add(this.frameAlgbtn);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(961, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(176, 592);
            this.rightPanel.TabIndex = 0;
            // 
            // frameAlgbtn
            // 
            this.frameAlgbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.frameAlgbtn.Location = new System.Drawing.Point(0, 0);
            this.frameAlgbtn.Name = "frameAlgbtn";
            this.frameAlgbtn.Size = new System.Drawing.Size(176, 48);
            this.frameAlgbtn.TabIndex = 0;
            this.frameAlgbtn.Text = "Минимальный каркас";
            this.frameAlgbtn.UseVisualStyleBackColor = true;
            this.frameAlgbtn.Click += new System.EventHandler(this.frameAlgbtn_Click);
            // 
            // initGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 592);
            this.Controls.Add(this.rightPanel);
            this.Name = "initGraph";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.initGraph_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseUp);
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Button frameAlgbtn;
    }
}

