namespace CteckaCipuWin
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cbCOM = new System.Windows.Forms.ComboBox();
            this.btnOtevritZavrit = new System.Windows.Forms.Button();
            this.btnKopirovat = new System.Windows.Forms.Button();
            this.tbRFID = new System.Windows.Forms.TextBox();
            this.tbRFIDTemp = new System.Windows.Forms.TextBox();
            this.btnOdeslatRAK = new System.Windows.Forms.Button();
            this.lblCOMStatus = new System.Windows.Forms.Label();
            this.chbOdeslatRAKAuto = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbCOM
            // 
            this.cbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(12, 12);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(121, 21);
            this.cbCOM.TabIndex = 0;
            // 
            // btnOtevritZavrit
            // 
            this.btnOtevritZavrit.BackColor = System.Drawing.Color.Transparent;
            this.btnOtevritZavrit.Location = new System.Drawing.Point(139, 11);
            this.btnOtevritZavrit.Name = "btnOtevritZavrit";
            this.btnOtevritZavrit.Size = new System.Drawing.Size(75, 23);
            this.btnOtevritZavrit.TabIndex = 1;
            this.btnOtevritZavrit.Text = "Otevřít";
            this.btnOtevritZavrit.UseVisualStyleBackColor = false;
            this.btnOtevritZavrit.Click += new System.EventHandler(this.BtnOtevritZavrit_Click);
            // 
            // btnKopirovat
            // 
            this.btnKopirovat.Location = new System.Drawing.Point(13, 201);
            this.btnKopirovat.Name = "btnKopirovat";
            this.btnKopirovat.Size = new System.Drawing.Size(478, 39);
            this.btnKopirovat.TabIndex = 2;
            this.btnKopirovat.Text = "Kopírovat do schránky";
            this.btnKopirovat.UseVisualStyleBackColor = true;
            this.btnKopirovat.Click += new System.EventHandler(this.BtnKopirovat_Click);
            // 
            // tbRFID
            // 
            this.tbRFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbRFID.Location = new System.Drawing.Point(13, 135);
            this.tbRFID.Name = "tbRFID";
            this.tbRFID.Size = new System.Drawing.Size(478, 60);
            this.tbRFID.TabIndex = 3;
            this.tbRFID.Text = "0000000000000000";
            this.tbRFID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRFIDTemp
            // 
            this.tbRFIDTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbRFIDTemp.Location = new System.Drawing.Point(13, 69);
            this.tbRFIDTemp.Name = "tbRFIDTemp";
            this.tbRFIDTemp.Size = new System.Drawing.Size(478, 60);
            this.tbRFIDTemp.TabIndex = 4;
            this.tbRFIDTemp.Text = "0000000000000000";
            this.tbRFIDTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOdeslatRAK
            // 
            this.btnOdeslatRAK.Location = new System.Drawing.Point(12, 246);
            this.btnOdeslatRAK.Name = "btnOdeslatRAK";
            this.btnOdeslatRAK.Size = new System.Drawing.Size(478, 39);
            this.btnOdeslatRAK.TabIndex = 5;
            this.btnOdeslatRAK.Text = "Odeslat do RAK";
            this.btnOdeslatRAK.UseVisualStyleBackColor = true;
            this.btnOdeslatRAK.Click += new System.EventHandler(this.BtnOdeslatRAK_Click);
            // 
            // lblCOMStatus
            // 
            this.lblCOMStatus.BackColor = System.Drawing.Color.Red;
            this.lblCOMStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCOMStatus.Location = new System.Drawing.Point(220, 12);
            this.lblCOMStatus.Name = "lblCOMStatus";
            this.lblCOMStatus.Size = new System.Drawing.Size(20, 21);
            this.lblCOMStatus.TabIndex = 6;
            // 
            // chbOdeslatRAKAuto
            // 
            this.chbOdeslatRAKAuto.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbOdeslatRAKAuto.Location = new System.Drawing.Point(13, 291);
            this.chbOdeslatRAKAuto.Name = "chbOdeslatRAKAuto";
            this.chbOdeslatRAKAuto.Size = new System.Drawing.Size(477, 39);
            this.chbOdeslatRAKAuto.TabIndex = 7;
            this.chbOdeslatRAKAuto.Text = "Odesílat do RAK automaticky";
            this.chbOdeslatRAKAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbOdeslatRAKAuto.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 339);
            this.Controls.Add(this.chbOdeslatRAKAuto);
            this.Controls.Add(this.lblCOMStatus);
            this.Controls.Add(this.btnOdeslatRAK);
            this.Controls.Add(this.tbRFIDTemp);
            this.Controls.Add(this.tbRFID);
            this.Controls.Add(this.btnKopirovat);
            this.Controls.Add(this.btnOtevritZavrit);
            this.Controls.Add(this.cbCOM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Čtečka čipů";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCOM;
        private System.Windows.Forms.Button btnOtevritZavrit;
        private System.Windows.Forms.Button btnKopirovat;
        private System.Windows.Forms.TextBox tbRFID;
        private System.Windows.Forms.TextBox tbRFIDTemp;
        private System.Windows.Forms.Button btnOdeslatRAK;
        private System.Windows.Forms.Label lblCOMStatus;
        private System.Windows.Forms.CheckBox chbOdeslatRAKAuto;
    }
}

