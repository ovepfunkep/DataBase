namespace DBIvancheva
{
    partial class MainForm
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
            this.MainDataGrid = new System.Windows.Forms.DataGridView();
            this.AddPatientBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainDataGrid
            // 
            this.MainDataGrid.AllowUserToAddRows = false;
            this.MainDataGrid.AllowUserToDeleteRows = false;
            this.MainDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainDataGrid.Location = new System.Drawing.Point(31, 138);
            this.MainDataGrid.Name = "MainDataGrid";
            this.MainDataGrid.ReadOnly = true;
            this.MainDataGrid.Size = new System.Drawing.Size(734, 287);
            this.MainDataGrid.TabIndex = 0;
            this.MainDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDataGrid_CellDoubleClick);
            // 
            // AddPatientBtn
            // 
            this.AddPatientBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPatientBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.AddPatientBtn.Location = new System.Drawing.Point(31, 12);
            this.AddPatientBtn.Name = "AddPatientBtn";
            this.AddPatientBtn.Size = new System.Drawing.Size(734, 120);
            this.AddPatientBtn.TabIndex = 1;
            this.AddPatientBtn.Text = "ADD PATIENT";
            this.AddPatientBtn.UseVisualStyleBackColor = true;
            this.AddPatientBtn.Click += new System.EventHandler(this.AddPatientBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddPatientBtn);
            this.Controls.Add(this.MainDataGrid);
            this.Name = "MainForm";
            this.Text = "MyProject";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MainDataGrid;
        private System.Windows.Forms.Button AddPatientBtn;
    }
}

