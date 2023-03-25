namespace CSVPlot
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_LoadTemp = new System.Windows.Forms.Button();
            this.btn_Write = new System.Windows.Forms.Button();
            this.btn_LoadCSVData = new System.Windows.Forms.Button();
            this.bn_Quit = new System.Windows.Forms.Button();
            this.lbox_Status = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_LoadTemp);
            this.panel1.Controls.Add(this.btn_Write);
            this.panel1.Controls.Add(this.btn_LoadCSVData);
            this.panel1.Controls.Add(this.bn_Quit);
            this.panel1.Location = new System.Drawing.Point(672, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 528);
            this.panel1.TabIndex = 0;
            // 
            // btn_LoadTemp
            // 
            this.btn_LoadTemp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_LoadTemp.Location = new System.Drawing.Point(9, 106);
            this.btn_LoadTemp.Name = "btn_LoadTemp";
            this.btn_LoadTemp.Size = new System.Drawing.Size(112, 23);
            this.btn_LoadTemp.TabIndex = 3;
            this.btn_LoadTemp.Text = "LoadTEMP";
            this.btn_LoadTemp.UseVisualStyleBackColor = true;
            this.btn_LoadTemp.Click += new System.EventHandler(this.btn_LoadTemp_Click);
            // 
            // btn_Write
            // 
            this.btn_Write.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Write.Location = new System.Drawing.Point(9, 477);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(112, 23);
            this.btn_Write.TabIndex = 2;
            this.btn_Write.Text = "WriteCSV";
            this.btn_Write.UseVisualStyleBackColor = true;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // btn_LoadCSVData
            // 
            this.btn_LoadCSVData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_LoadCSVData.Location = new System.Drawing.Point(9, 56);
            this.btn_LoadCSVData.Name = "btn_LoadCSVData";
            this.btn_LoadCSVData.Size = new System.Drawing.Size(112, 23);
            this.btn_LoadCSVData.TabIndex = 1;
            this.btn_LoadCSVData.Text = "LoadZTR";
            this.btn_LoadCSVData.UseVisualStyleBackColor = true;
            this.btn_LoadCSVData.Click += new System.EventHandler(this.btn_LoadCSVData_Click);
            // 
            // bn_Quit
            // 
            this.bn_Quit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bn_Quit.Location = new System.Drawing.Point(9, 18);
            this.bn_Quit.Name = "bn_Quit";
            this.bn_Quit.Size = new System.Drawing.Size(112, 23);
            this.bn_Quit.TabIndex = 0;
            this.bn_Quit.Text = "Quit";
            this.bn_Quit.UseVisualStyleBackColor = true;
            this.bn_Quit.Click += new System.EventHandler(this.bn_Quit_Click);
            // 
            // lbox_Status
            // 
            this.lbox_Status.BackColor = System.Drawing.Color.Blue;
            this.lbox_Status.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbox_Status.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbox_Status.FormattingEnabled = true;
            this.lbox_Status.ItemHeight = 17;
            this.lbox_Status.Location = new System.Drawing.Point(6, 7);
            this.lbox_Status.Name = "lbox_Status";
            this.lbox_Status.Size = new System.Drawing.Size(660, 531);
            this.lbox_Status.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 541);
            this.ControlBox = false;
            this.Controls.Add(this.lbox_Status);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "CSVPlot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button bn_Quit;
        private Button btn_LoadCSVData;
        private Button btn_Write;
        private ListBox lbox_Status;
        private Button btn_LoadTemp;
    }
}