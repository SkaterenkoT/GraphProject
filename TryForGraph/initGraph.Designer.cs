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
            this.maxFrameBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.helpBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.frameAlgbtn = new System.Windows.Forms.Button();
            this.modePanel = new System.Windows.Forms.Panel();
            this.EdgesCountLabel = new System.Windows.Forms.Label();
            this.VertMaxCountLabel = new System.Windows.Forms.Label();
            this.createEdgebtn = new System.Windows.Forms.Button();
            this.deleteItemsbtn = new System.Windows.Forms.Button();
            this.moveVertbtn = new System.Windows.Forms.Button();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.rightPanel.SuspendLayout();
            this.modePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rightPanel.Controls.Add(this.maxFrameBtn);
            this.rightPanel.Controls.Add(this.label1);
            this.rightPanel.Controls.Add(this.helpBtn);
            this.rightPanel.Controls.Add(this.clearBtn);
            this.rightPanel.Controls.Add(this.frameAlgbtn);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(961, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(176, 592);
            this.rightPanel.TabIndex = 0;
            // 
            // maxFrameBtn
            // 
            this.maxFrameBtn.Location = new System.Drawing.Point(0, 80);
            this.maxFrameBtn.Name = "maxFrameBtn";
            this.maxFrameBtn.Size = new System.Drawing.Size(176, 59);
            this.maxFrameBtn.TabIndex = 5;
            this.maxFrameBtn.Text = "Максимальный каркас";
            this.maxFrameBtn.UseVisualStyleBackColor = true;
            this.maxFrameBtn.Click += new System.EventHandler(this.maxFrameBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Можете выбрать тип\r\nкаркаса для графа:";
            // 
            // helpBtn
            // 
            this.helpBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.helpBtn.Location = new System.Drawing.Point(0, 526);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(176, 31);
            this.helpBtn.TabIndex = 2;
            this.helpBtn.Text = "Помощь";
            this.helpBtn.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clearBtn.Location = new System.Drawing.Point(0, 557);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(176, 35);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Задать заново";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // frameAlgbtn
            // 
            this.frameAlgbtn.Location = new System.Drawing.Point(0, 35);
            this.frameAlgbtn.Name = "frameAlgbtn";
            this.frameAlgbtn.Size = new System.Drawing.Size(176, 48);
            this.frameAlgbtn.TabIndex = 0;
            this.frameAlgbtn.Text = "Минимальный каркас";
            this.frameAlgbtn.UseVisualStyleBackColor = true;
            this.frameAlgbtn.Click += new System.EventHandler(this.frameAlgbtn_Click);
            // 
            // modePanel
            // 
            this.modePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.modePanel.Controls.Add(this.EdgesCountLabel);
            this.modePanel.Controls.Add(this.VertMaxCountLabel);
            this.modePanel.Controls.Add(this.createEdgebtn);
            this.modePanel.Controls.Add(this.deleteItemsbtn);
            this.modePanel.Controls.Add(this.moveVertbtn);
            this.modePanel.Controls.Add(this.descriptionLabel);
            this.modePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.modePanel.Location = new System.Drawing.Point(0, 0);
            this.modePanel.Name = "modePanel";
            this.modePanel.Size = new System.Drawing.Size(961, 48);
            this.modePanel.TabIndex = 1;
            // 
            // EdgesCountLabel
            // 
            this.EdgesCountLabel.AutoSize = true;
            this.EdgesCountLabel.Location = new System.Drawing.Point(694, 25);
            this.EdgesCountLabel.Name = "EdgesCountLabel";
            this.EdgesCountLabel.Size = new System.Drawing.Size(25, 16);
            this.EdgesCountLabel.TabIndex = 6;
            this.EdgesCountLabel.Text = "......";
            // 
            // VertMaxCountLabel
            // 
            this.VertMaxCountLabel.AutoSize = true;
            this.VertMaxCountLabel.Location = new System.Drawing.Point(694, 9);
            this.VertMaxCountLabel.Name = "VertMaxCountLabel";
            this.VertMaxCountLabel.Size = new System.Drawing.Size(25, 16);
            this.VertMaxCountLabel.TabIndex = 5;
            this.VertMaxCountLabel.Text = "......";
            // 
            // createEdgebtn
            // 
            this.createEdgebtn.Location = new System.Drawing.Point(61, 22);
            this.createEdgebtn.Name = "createEdgebtn";
            this.createEdgebtn.Size = new System.Drawing.Size(67, 23);
            this.createEdgebtn.TabIndex = 3;
            this.createEdgebtn.Text = "v→v";
            this.createEdgebtn.UseVisualStyleBackColor = true;
            this.createEdgebtn.Click += new System.EventHandler(this.createEdgebtn_Click);
            // 
            // deleteItemsbtn
            // 
            this.deleteItemsbtn.Location = new System.Drawing.Point(120, 22);
            this.deleteItemsbtn.Name = "deleteItemsbtn";
            this.deleteItemsbtn.Size = new System.Drawing.Size(48, 23);
            this.deleteItemsbtn.TabIndex = 2;
            this.deleteItemsbtn.Text = "del";
            this.deleteItemsbtn.UseVisualStyleBackColor = true;
            this.deleteItemsbtn.Click += new System.EventHandler(this.deleteItemsbtn_Click);
            // 
            // moveVertbtn
            // 
            this.moveVertbtn.Location = new System.Drawing.Point(3, 22);
            this.moveVertbtn.Name = "moveVertbtn";
            this.moveVertbtn.Size = new System.Drawing.Size(65, 23);
            this.moveVertbtn.TabIndex = 1;
            this.moveVertbtn.Text = "move";
            this.moveVertbtn.UseVisualStyleBackColor = true;
            this.moveVertbtn.Click += new System.EventHandler(this.moveVertbtn_Click);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.descriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(260, 16);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Выберите режим для работы с графом:";
            // 
            // initGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 592);
            this.Controls.Add(this.modePanel);
            this.Controls.Add(this.rightPanel);
            this.Name = "initGraph";
            this.Text = "Визуализация/инициализация графа";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.initGraph_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.initGraph_MouseUp);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.modePanel.ResumeLayout(false);
            this.modePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Button frameAlgbtn;
        private System.Windows.Forms.Panel modePanel;
        private System.Windows.Forms.Button moveVertbtn;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button createEdgebtn;
        private System.Windows.Forms.Button deleteItemsbtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Button maxFrameBtn;
        private System.Windows.Forms.Label VertMaxCountLabel;
        private System.Windows.Forms.Label EdgesCountLabel;
    }
}

