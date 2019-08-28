namespace CrystalButton
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new CrystalButton.Button();
            this.button2 = new CrystalButton.Button();
            this.button3 = new CrystalButton.Button();
            this.button4 = new CrystalButton.Button();
            this.button5 = new CrystalButton.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.CornerRadius = 75F;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.ImageSize = new System.Drawing.Size(24, 24);
            this.button1.Location = new System.Drawing.Point(38, 23);
            this.button1.Name = "button1";
            this.button1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Size = new System.Drawing.Size(150, 150);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.CornerRadius = 3F;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.ImageSize = new System.Drawing.Size(24, 24);
            this.button2.Location = new System.Drawing.Point(254, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.CornerRadius = 25F;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.ImageSize = new System.Drawing.Size(24, 24);
            this.button3.Location = new System.Drawing.Point(352, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 80);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // button4
            // 
            this.button4.CornerRadius = 3F;
            this.button4.Image = global::CrystalButton.Properties.Resources.radio_button_on_24px;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.ImageSize = new System.Drawing.Size(24, 24);
            this.button4.Location = new System.Drawing.Point(254, 219);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 67);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            this.button5.CornerRadius = 15F;
            this.button5.Image = global::CrystalButton.Properties.Resources.radio_button_on_24px;
            this.button5.ImageSize = new System.Drawing.Size(24, 24);
            this.button5.Location = new System.Drawing.Point(364, 219);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 44);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 338);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}

