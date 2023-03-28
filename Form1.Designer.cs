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
            this.btn_SendAllToMongo = new System.Windows.Forms.Button();
            this.btn_LoadTemp = new System.Windows.Forms.Button();
            this.btn_Write = new System.Windows.Forms.Button();
            this.btn_LoadCSVData = new System.Windows.Forms.Button();
            this.bn_Quit = new System.Windows.Forms.Button();
            this.lbox_Status = new System.Windows.Forms.ListBox();
            this.txbx_WorkOrderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_ToolID = new System.Windows.Forms.ComboBox();
            this.txbx_WorkOrderNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_SendWorkOrder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_SendAllToMongo);
            this.panel1.Controls.Add(this.btn_LoadTemp);
            this.panel1.Controls.Add(this.btn_Write);
            this.panel1.Controls.Add(this.btn_LoadCSVData);
            this.panel1.Controls.Add(this.bn_Quit);
            this.panel1.Location = new System.Drawing.Point(672, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 528);
            this.panel1.TabIndex = 0;
            // 
            // btn_SendAllToMongo
            // 
            this.btn_SendAllToMongo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_SendAllToMongo.Location = new System.Drawing.Point(9, 102);
            this.btn_SendAllToMongo.Name = "btn_SendAllToMongo";
            this.btn_SendAllToMongo.Size = new System.Drawing.Size(112, 40);
            this.btn_SendAllToMongo.TabIndex = 4;
            this.btn_SendAllToMongo.Text = "SendZTRDatalToMongo";
            this.btn_SendAllToMongo.UseVisualStyleBackColor = true;
            this.btn_SendAllToMongo.Click += new System.EventHandler(this.btn_SendAllToMongo_Click);
            // 
            // btn_LoadTemp
            // 
            this.btn_LoadTemp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_LoadTemp.Location = new System.Drawing.Point(9, 368);
            this.btn_LoadTemp.Name = "btn_LoadTemp";
            this.btn_LoadTemp.Size = new System.Drawing.Size(112, 23);
            this.btn_LoadTemp.TabIndex = 3;
            this.btn_LoadTemp.Text = "Load Thermo";
            this.btn_LoadTemp.UseVisualStyleBackColor = true;
            this.btn_LoadTemp.Visible = false;
            this.btn_LoadTemp.Click += new System.EventHandler(this.btn_LoadTemp_Click);
            // 
            // btn_Write
            // 
            this.btn_Write.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Write.Location = new System.Drawing.Point(9, 406);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(112, 23);
            this.btn_Write.TabIndex = 2;
            this.btn_Write.Text = "WriteCSV";
            this.btn_Write.UseVisualStyleBackColor = true;
            this.btn_Write.Visible = false;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // btn_LoadCSVData
            // 
            this.btn_LoadCSVData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_LoadCSVData.Location = new System.Drawing.Point(9, 56);
            this.btn_LoadCSVData.Name = "btn_LoadCSVData";
            this.btn_LoadCSVData.Size = new System.Drawing.Size(112, 23);
            this.btn_LoadCSVData.TabIndex = 1;
            this.btn_LoadCSVData.Text = "Load ZTRData";
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
            this.lbox_Status.Location = new System.Drawing.Point(6, 211);
            this.lbox_Status.Name = "lbox_Status";
            this.lbox_Status.Size = new System.Drawing.Size(660, 327);
            this.lbox_Status.TabIndex = 1;
            // 
            // txbx_WorkOrderID
            // 
            this.txbx_WorkOrderID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txbx_WorkOrderID.Location = new System.Drawing.Point(328, 10);
            this.txbx_WorkOrderID.Name = "txbx_WorkOrderID";
            this.txbx_WorkOrderID.Size = new System.Drawing.Size(127, 25);
            this.txbx_WorkOrderID.TabIndex = 2;
            this.txbx_WorkOrderID.Text = "230326P1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(296, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(269, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tool ID";
            // 
            // cbox_ToolID
            // 
            this.cbox_ToolID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbox_ToolID.FormattingEnabled = true;
            this.cbox_ToolID.Location = new System.Drawing.Point(328, 46);
            this.cbox_ToolID.Name = "cbox_ToolID";
            this.cbox_ToolID.Size = new System.Drawing.Size(202, 25);
            this.cbox_ToolID.TabIndex = 5;
            // 
            // txbx_WorkOrderNotes
            // 
            this.txbx_WorkOrderNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txbx_WorkOrderNotes.Location = new System.Drawing.Point(328, 89);
            this.txbx_WorkOrderNotes.Multiline = true;
            this.txbx_WorkOrderNotes.Name = "txbx_WorkOrderNotes";
            this.txbx_WorkOrderNotes.Size = new System.Drawing.Size(338, 99);
            this.txbx_WorkOrderNotes.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(278, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Notes";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(6, 29);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(8, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Work Order";
            // 
            // btn_SendWorkOrder
            // 
            this.btn_SendWorkOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_SendWorkOrder.Location = new System.Drawing.Point(548, 12);
            this.btn_SendWorkOrder.Name = "btn_SendWorkOrder";
            this.btn_SendWorkOrder.Size = new System.Drawing.Size(112, 40);
            this.btn_SendWorkOrder.TabIndex = 10;
            this.btn_SendWorkOrder.Text = "SendWorkOrderToMongo";
            this.btn_SendWorkOrder.UseVisualStyleBackColor = true;
            this.btn_SendWorkOrder.Click += new System.EventHandler(this.btn_SendWorkOrder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 541);
            this.ControlBox = false;
            this.Controls.Add(this.btn_SendWorkOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbx_WorkOrderNotes);
            this.Controls.Add(this.cbox_ToolID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbx_WorkOrderID);
            this.Controls.Add(this.lbox_Status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "CSVPlot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button bn_Quit;
        private Button btn_LoadCSVData;
        private Button btn_Write;
        private ListBox lbox_Status;
        private Button btn_LoadTemp;
        private TextBox txbx_WorkOrderID;
        private Label label1;
        private Label label2;
        private Button btn_SendAllToMongo;
        private ComboBox cbox_ToolID;
        private TextBox txbx_WorkOrderNotes;
        private Label label3;
        private MonthCalendar monthCalendar1;
        private Label label4;
        private Button btn_SendWorkOrder;
    }
}