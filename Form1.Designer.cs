namespace _6th_LAB_OOP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.colorBtn = new System.Windows.Forms.Button();
            this.chosedShare = new System.Windows.Forms.Label();
            this.shapesComboBox = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBtn = new System.Windows.Forms.Button();
            this.ungroupBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.fileDialogBtn = new System.Windows.Forms.Button();
            this.nodeTreeView = new System.Windows.Forms.TreeView();
            this.shapeLinkingBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(582, 470);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // colorBtn
            // 
            this.colorBtn.Location = new System.Drawing.Point(12, 476);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(45, 48);
            this.colorBtn.TabIndex = 1;
            this.colorBtn.UseVisualStyleBackColor = true;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // chosedShare
            // 
            this.chosedShare.AutoSize = true;
            this.chosedShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chosedShare.Location = new System.Drawing.Point(63, 505);
            this.chosedShare.Name = "chosedShare";
            this.chosedShare.Size = new System.Drawing.Size(0, 25);
            this.chosedShare.TabIndex = 4;
            // 
            // shapesComboBox
            // 
            this.shapesComboBox.FormattingEnabled = true;
            this.shapesComboBox.Items.AddRange(new object[] {
            "Circle",
            "Triangle",
            "Square"});
            this.shapesComboBox.Location = new System.Drawing.Point(63, 476);
            this.shapesComboBox.Name = "shapesComboBox";
            this.shapesComboBox.Size = new System.Drawing.Size(121, 21);
            this.shapesComboBox.TabIndex = 5;
            this.shapesComboBox.TabStop = false;
            this.shapesComboBox.SelectedIndexChanged += new System.EventHandler(this.shapesComboBox_SelectedIndexChanged);
            this.shapesComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shapesComboBox_KeyDown);
            // 
            // groupBtn
            // 
            this.groupBtn.Location = new System.Drawing.Point(190, 476);
            this.groupBtn.Name = "groupBtn";
            this.groupBtn.Size = new System.Drawing.Size(75, 23);
            this.groupBtn.TabIndex = 6;
            this.groupBtn.Text = "Group";
            this.groupBtn.UseVisualStyleBackColor = true;
            this.groupBtn.Click += new System.EventHandler(this.groupBtn_Click);
            // 
            // ungroupBtn
            // 
            this.ungroupBtn.Location = new System.Drawing.Point(190, 505);
            this.ungroupBtn.Name = "ungroupBtn";
            this.ungroupBtn.Size = new System.Drawing.Size(75, 23);
            this.ungroupBtn.TabIndex = 7;
            this.ungroupBtn.Text = "Ungroup";
            this.ungroupBtn.UseVisualStyleBackColor = true;
            this.ungroupBtn.Click += new System.EventHandler(this.ungroupBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(464, 476);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(112, 23);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save (CTRL + C)";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Enabled = false;
            this.loadBtn.Location = new System.Drawing.Point(464, 505);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(112, 23);
            this.loadBtn.TabIndex = 9;
            this.loadBtn.Text = "Load (CTRL + V)";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // fileDialogBtn
            // 
            this.fileDialogBtn.Location = new System.Drawing.Point(383, 476);
            this.fileDialogBtn.Name = "fileDialogBtn";
            this.fileDialogBtn.Size = new System.Drawing.Size(75, 23);
            this.fileDialogBtn.TabIndex = 10;
            this.fileDialogBtn.Text = "Choose File";
            this.fileDialogBtn.UseVisualStyleBackColor = true;
            this.fileDialogBtn.Click += new System.EventHandler(this.fileDialogBtn_Click);
            // 
            // nodeTreeView
            // 
            this.nodeTreeView.Location = new System.Drawing.Point(588, 0);
            this.nodeTreeView.Name = "nodeTreeView";
            this.nodeTreeView.Size = new System.Drawing.Size(161, 470);
            this.nodeTreeView.TabIndex = 11;
            this.nodeTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nodeTreeView_AfterSelect);
            // 
            // shapeLinkingBtn
            // 
            this.shapeLinkingBtn.Location = new System.Drawing.Point(588, 475);
            this.shapeLinkingBtn.Name = "shapeLinkingBtn";
            this.shapeLinkingBtn.Size = new System.Drawing.Size(161, 23);
            this.shapeLinkingBtn.TabIndex = 12;
            this.shapeLinkingBtn.Text = "Shape linking";
            this.shapeLinkingBtn.UseVisualStyleBackColor = true;
            this.shapeLinkingBtn.Click += new System.EventHandler(this.shapeLinkingBtn_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(752, 536);
            this.Controls.Add(this.shapeLinkingBtn);
            this.Controls.Add(this.nodeTreeView);
            this.Controls.Add(this.fileDialogBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.ungroupBtn);
            this.Controls.Add(this.groupBtn);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.chosedShare);
            this.Controls.Add(this.colorBtn);
            this.Controls.Add(this.shapesComboBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Label chosedShare;
        private System.Windows.Forms.ComboBox shapesComboBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button groupBtn;
        private System.Windows.Forms.Button ungroupBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button fileDialogBtn;
        private System.Windows.Forms.TreeView nodeTreeView;
        private System.Windows.Forms.Button shapeLinkingBtn;
    }
}

