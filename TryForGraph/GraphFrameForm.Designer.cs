namespace TryForGraph
{
    partial class GraphFrameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphFrameForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.DataForRemoved = new System.Windows.Forms.DataGridView();
            this.edgesRemainingLabel = new System.Windows.Forms.Label();
            this.Vert1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vert2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.edgesLevelSumLab = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataForRemoved)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.edgesLevelSumLab);
            this.panel1.Controls.Add(this.edgesRemainingLabel);
            this.panel1.Controls.Add(this.DataForRemoved);
            this.panel1.Controls.Add(this.descriptionLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(772, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 550);
            this.panel1.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(3, 9);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(232, 80);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Во избежании циклов,\r\nа также для сохранения\r\nминимального значения путей\r\nв граф" +
    "е были удалены следующие\r\nребра:";
            // 
            // DataForRemoved
            // 
            this.DataForRemoved.AllowUserToAddRows = false;
            this.DataForRemoved.AllowUserToDeleteRows = false;
            this.DataForRemoved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataForRemoved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vert1,
            this.Vert2,
            this.Level});
            this.DataForRemoved.Location = new System.Drawing.Point(0, 92);
            this.DataForRemoved.Name = "DataForRemoved";
            this.DataForRemoved.ReadOnly = true;
            this.DataForRemoved.RowHeadersWidth = 51;
            this.DataForRemoved.RowTemplate.Height = 24;
            this.DataForRemoved.Size = new System.Drawing.Size(265, 299);
            this.DataForRemoved.TabIndex = 1;
            // 
            // edgesRemainingLabel
            // 
            this.edgesRemainingLabel.AutoSize = true;
            this.edgesRemainingLabel.Location = new System.Drawing.Point(3, 394);
            this.edgesRemainingLabel.Name = "edgesRemainingLabel";
            this.edgesRemainingLabel.Size = new System.Drawing.Size(114, 16);
            this.edgesRemainingLabel.TabIndex = 2;
            this.edgesRemainingLabel.Text = "Ребер осталось:";
            // 
            // Vert1
            // 
            this.Vert1.HeaderText = "v1";
            this.Vert1.MinimumWidth = 6;
            this.Vert1.Name = "Vert1";
            this.Vert1.ReadOnly = true;
            this.Vert1.Width = 40;
            // 
            // Vert2
            // 
            this.Vert2.HeaderText = "v2";
            this.Vert2.MinimumWidth = 6;
            this.Vert2.Name = "Vert2";
            this.Vert2.ReadOnly = true;
            this.Vert2.Width = 40;
            // 
            // Level
            // 
            this.Level.HeaderText = "Value";
            this.Level.MinimumWidth = 6;
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            this.Level.Width = 60;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 59);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(747, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // edgesLevelSumLab
            // 
            this.edgesLevelSumLab.AutoSize = true;
            this.edgesLevelSumLab.Location = new System.Drawing.Point(3, 410);
            this.edgesLevelSumLab.Name = "edgesLevelSumLab";
            this.edgesLevelSumLab.Size = new System.Drawing.Size(139, 16);
            this.edgesLevelSumLab.TabIndex = 3;
            this.edgesLevelSumLab.Text = "Общая сумма ребер:";
            // 
            // GraphFrameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GraphFrameForm";
            this.Text = "Каркас";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataForRemoved)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.DataGridView DataForRemoved;
        private System.Windows.Forms.Label edgesRemainingLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vert1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vert2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label edgesLevelSumLab;
    }
}