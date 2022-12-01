namespace Sirma_task_UI
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
            this.btn_Upload = new System.Windows.Forms.Button();
            this.lbox_commonProjects = new System.Windows.Forms.ListBox();
            this.btn_Display = new System.Windows.Forms.Button();
            this.lbl_maxPair = new System.Windows.Forms.Label();
            this.lbl_maxPairInfo = new System.Windows.Forms.Label();
            this.lbl_allProjects = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Upload
            // 
            this.btn_Upload.Location = new System.Drawing.Point(12, 374);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(143, 64);
            this.btn_Upload.TabIndex = 0;
            this.btn_Upload.Text = "Upload";
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // lbox_commonProjects
            // 
            this.lbox_commonProjects.FormattingEnabled = true;
            this.lbox_commonProjects.ItemHeight = 15;
            this.lbox_commonProjects.Location = new System.Drawing.Point(12, 157);
            this.lbox_commonProjects.Name = "lbox_commonProjects";
            this.lbox_commonProjects.Size = new System.Drawing.Size(728, 199);
            this.lbox_commonProjects.TabIndex = 1;
            // 
            // btn_Display
            // 
            this.btn_Display.Location = new System.Drawing.Point(290, 374);
            this.btn_Display.Name = "btn_Display";
            this.btn_Display.Size = new System.Drawing.Size(157, 64);
            this.btn_Display.TabIndex = 2;
            this.btn_Display.Text = "Display";
            this.btn_Display.UseVisualStyleBackColor = true;
            this.btn_Display.Click += new System.EventHandler(this.btn_Display_Click);
            // 
            // lbl_maxPair
            // 
            this.lbl_maxPair.AutoSize = true;
            this.lbl_maxPair.Location = new System.Drawing.Point(12, 41);
            this.lbl_maxPair.Name = "lbl_maxPair";
            this.lbl_maxPair.Size = new System.Drawing.Size(207, 15);
            this.lbl_maxPair.TabIndex = 3;
            this.lbl_maxPair.Text = "Pair with most days working together:";
            // 
            // lbl_maxPairInfo
            // 
            this.lbl_maxPairInfo.AutoSize = true;
            this.lbl_maxPairInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_maxPairInfo.Location = new System.Drawing.Point(225, 35);
            this.lbl_maxPairInfo.Name = "lbl_maxPairInfo";
            this.lbl_maxPairInfo.Size = new System.Drawing.Size(0, 21);
            this.lbl_maxPairInfo.TabIndex = 4;
            // 
            // lbl_allProjects
            // 
            this.lbl_allProjects.AutoSize = true;
            this.lbl_allProjects.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_allProjects.Location = new System.Drawing.Point(12, 129);
            this.lbl_allProjects.Name = "lbl_allProjects";
            this.lbl_allProjects.Size = new System.Drawing.Size(162, 21);
            this.lbl_allProjects.TabIndex = 5;
            this.lbl_allProjects.Text = "All Projects of the pair";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(591, 374);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(149, 64);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lbl_allProjects);
            this.Controls.Add(this.lbl_maxPairInfo);
            this.Controls.Add(this.lbl_maxPair);
            this.Controls.Add(this.btn_Display);
            this.Controls.Add(this.lbox_commonProjects);
            this.Controls.Add(this.btn_Upload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Upload;
        private ListBox lbox_commonProjects;
        private Button btn_Display;
        private Label lbl_maxPair;
        private Label lbl_maxPairInfo;
        private Label lbl_allProjects;
        private Button btn_Exit;
    }
}