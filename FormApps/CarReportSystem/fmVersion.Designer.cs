namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btOk = new Button();
            label1 = new Label();
            lbVesion = new Label();
            SuspendLayout();
            // 
            // btOk
            // 
            btOk.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btOk.Location = new Point(272, 147);
            btOk.Name = "btOk";
            btOk.Size = new Size(72, 33);
            btOk.TabIndex = 0;
            btOk.Text = "OK";
            btOk.UseVisualStyleBackColor = true;
            btOk.Click += btOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(26, 19);
            label1.Name = "label1";
            label1.Size = new Size(253, 32);
            label1.TabIndex = 1;
            label1.Text = "試乗レポート管理システム";
            // 
            // lbVesion
            // 
            lbVesion.AutoSize = true;
            lbVesion.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbVesion.Location = new Point(265, 81);
            lbVesion.Name = "lbVesion";
            lbVesion.Size = new Size(79, 25);
            lbVesion.TabIndex = 2;
            lbVesion.Text = "ver.0.0.1";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(356, 192);
            Controls.Add(lbVesion);
            Controls.Add(label1);
            Controls.Add(btOk);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btOk;
        private Label label1;
        private Label lbVesion;
    }
}