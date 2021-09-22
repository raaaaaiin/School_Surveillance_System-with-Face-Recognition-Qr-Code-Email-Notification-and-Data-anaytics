namespace Surveillance_FaceRecognition
{
    partial class SSlogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SSlogIn));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Button1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Textbox2 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.Textbox1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Surveillance_FaceRecognition.Properties.Resources.Asset_4;
            this.pictureBox1.Location = new System.Drawing.Point(22, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Configure";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(142, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 89);
            this.panel1.TabIndex = 7;
            // 
            // Button1
            // 
            this.Button1.Active = false;
            this.Button1.Activecolor = System.Drawing.Color.Gold;
            this.Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button1.BorderRadius = 0;
            this.Button1.ButtonText = "LogIn";
            this.Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button1.DisabledColor = System.Drawing.Color.Gray;
            this.Button1.Iconcolor = System.Drawing.Color.Transparent;
            this.Button1.Iconimage = ((System.Drawing.Image)(resources.GetObject("Button1.Iconimage")));
            this.Button1.Iconimage_right = null;
            this.Button1.Iconimage_right_Selected = null;
            this.Button1.Iconimage_Selected = null;
            this.Button1.IconMarginLeft = 0;
            this.Button1.IconMarginRight = 0;
            this.Button1.IconRightVisible = true;
            this.Button1.IconRightZoom = 0D;
            this.Button1.IconVisible = true;
            this.Button1.IconZoom = 90D;
            this.Button1.IsTab = false;
            this.Button1.Location = new System.Drawing.Point(22, 299);
            this.Button1.Name = "Button1";
            this.Button1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button1.OnHovercolor = System.Drawing.Color.Gold;
            this.Button1.OnHoverTextColor = System.Drawing.Color.White;
            this.Button1.selected = false;
            this.Button1.Size = new System.Drawing.Size(241, 48);
            this.Button1.TabIndex = 3;
            this.Button1.Text = "LogIn";
            this.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button1.Textcolor = System.Drawing.Color.White;
            this.Button1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Textbox2
            // 
            this.Textbox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Textbox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.Textbox2.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Textbox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Textbox2.Font = new System.Drawing.Font("Roboto", 12F);
            this.Textbox2.ForeColor = System.Drawing.Color.White;
            this.Textbox2.HintForeColor = System.Drawing.Color.White;
            this.Textbox2.HintText = "Password";
            this.Textbox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Textbox2.isPassword = false;
            this.Textbox2.LineFocusedColor = System.Drawing.Color.Gold;
            this.Textbox2.LineIdleColor = System.Drawing.Color.DimGray;
            this.Textbox2.LineMouseHoverColor = System.Drawing.Color.Gold;
            this.Textbox2.LineThickness = 4;
            this.Textbox2.Location = new System.Drawing.Point(22, 199);
            this.Textbox2.Margin = new System.Windows.Forms.Padding(4);
            this.Textbox2.MaxLength = 32767;
            this.Textbox2.Name = "Textbox2";
            this.Textbox2.Size = new System.Drawing.Size(241, 33);
            this.Textbox2.TabIndex = 2;
            this.Textbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Textbox1
            // 
            this.Textbox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Textbox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.Textbox1.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Textbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Textbox1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textbox1.ForeColor = System.Drawing.Color.White;
            this.Textbox1.HintForeColor = System.Drawing.Color.White;
            this.Textbox1.HintText = "Username";
            this.Textbox1.isPassword = false;
            this.Textbox1.LineFocusedColor = System.Drawing.Color.Gold;
            this.Textbox1.LineIdleColor = System.Drawing.Color.DimGray;
            this.Textbox1.LineMouseHoverColor = System.Drawing.Color.Gold;
            this.Textbox1.LineThickness = 4;
            this.Textbox1.Location = new System.Drawing.Point(22, 158);
            this.Textbox1.Margin = new System.Windows.Forms.Padding(4);
            this.Textbox1.MaxLength = 32767;
            this.Textbox1.Name = "Textbox1";
            this.Textbox1.Size = new System.Drawing.Size(241, 33);
            this.Textbox1.TabIndex = 1;
            this.Textbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Textbox1.OnValueChanged += new System.EventHandler(this.bunifuMaterialTextbox1_OnValueChanged);
            // 
            // logIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(282, 359);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Textbox2);
            this.Controls.Add(this.Textbox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "logIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuMaterialTextbox Textbox1;
        private Bunifu.Framework.UI.BunifuFlatButton Button1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox Textbox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
    }
}

