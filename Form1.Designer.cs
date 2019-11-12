namespace GameOfLife
{
    partial class GOL
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvcells = new System.Windows.Forms.DataGridView();
            this.tmrspeed = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblgen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcells)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvcells
            // 
            this.dgvcells.AllowUserToAddRows = false;
            this.dgvcells.AllowUserToDeleteRows = false;
            this.dgvcells.AllowUserToResizeColumns = false;
            this.dgvcells.AllowUserToResizeRows = false;
            this.dgvcells.BackgroundColor = System.Drawing.Color.White;
            this.dgvcells.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvcells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcells.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcells.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcells.GridColor = System.Drawing.Color.LightGray;
            this.dgvcells.Location = new System.Drawing.Point(0, 44);
            this.dgvcells.Name = "dgvcells";
            this.dgvcells.ReadOnly = true;
            this.dgvcells.RowHeadersVisible = false;
            this.dgvcells.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvcells.Size = new System.Drawing.Size(1018, 552);
            this.dgvcells.TabIndex = 0;
            // 
            // tmrspeed
            // 
            this.tmrspeed.Interval = 1000;
            this.tmrspeed.Tick += new System.EventHandler(this.tmrspeed_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generation";
            // 
            // lblgen
            // 
            this.lblgen.AutoSize = true;
            this.lblgen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgen.ForeColor = System.Drawing.Color.Black;
            this.lblgen.Location = new System.Drawing.Point(100, 11);
            this.lblgen.Name = "lblgen";
            this.lblgen.Size = new System.Drawing.Size(19, 21);
            this.lblgen.TabIndex = 2;
            this.lblgen.Text = "1";
            // 
            // GOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 599);
            this.Controls.Add(this.lblgen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvcells);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GOL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Of Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcells)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvcells;
        private System.Windows.Forms.Timer tmrspeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblgen;
    }
}

