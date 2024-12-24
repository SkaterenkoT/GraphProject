namespace TryForGraph
{
    partial class GraphSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphSettings));
            this.vertCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.directedCheck = new System.Windows.Forms.CheckBox();
            this.autoFillCheck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vertCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vertCount
            // 
            this.vertCount.Location = new System.Drawing.Point(143, 25);
            this.vertCount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.vertCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.vertCount.Name = "vertCount";
            this.vertCount.Size = new System.Drawing.Size(120, 22);
            this.vertCount.TabIndex = 3;
            this.vertCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество вершин:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1102, 595);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CompleteBtn);
            this.panel1.Controls.Add(this.directedCheck);
            this.panel1.Controls.Add(this.autoFillCheck);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.vertCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(393, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 167);
            this.panel1.TabIndex = 6;
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.Location = new System.Drawing.Point(159, 132);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(75, 23);
            this.CompleteBtn.TabIndex = 8;
            this.CompleteBtn.Text = "Готово";
            this.CompleteBtn.UseVisualStyleBackColor = true;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // directedCheck
            // 
            this.directedCheck.AutoSize = true;
            this.directedCheck.Location = new System.Drawing.Point(3, 65);
            this.directedCheck.Name = "directedCheck";
            this.directedCheck.Size = new System.Drawing.Size(264, 20);
            this.directedCheck.TabIndex = 7;
            this.directedCheck.Text = "Допускать ориентированные ребра";
            this.directedCheck.UseVisualStyleBackColor = true;
            // 
            // autoFillCheck
            // 
            this.autoFillCheck.AutoSize = true;
            this.autoFillCheck.Location = new System.Drawing.Point(3, 91);
            this.autoFillCheck.Name = "autoFillCheck";
            this.autoFillCheck.Size = new System.Drawing.Size(314, 20);
            this.autoFillCheck.TabIndex = 6;
            this.autoFillCheck.Text = "Автоматически создать и заполнить ребра";
            this.autoFillCheck.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(100, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Заполните данные о графе:";
            // 
            // GraphSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1102, 595);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GraphSettings";
            this.Text = "GraphSettings";
            ((System.ComponentModel.ISupportInitialize)(this.vertCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown vertCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox autoFillCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.CheckBox directedCheck;
    }
}