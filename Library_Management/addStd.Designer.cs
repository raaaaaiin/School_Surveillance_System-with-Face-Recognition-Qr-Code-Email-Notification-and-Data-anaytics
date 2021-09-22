namespace Library_Management
{
    partial class AddstudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddstudentForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.LastNameText = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel6 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
            this.MiddleNameText = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.accountType = new Bunifu.UI.WinForms.BunifuDropdown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FirstNameText = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.secD = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Progd = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Yeard = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuLabel8 = new Bunifu.UI.WinForms.BunifuLabel();
            this.SuffixText = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuButton2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LastNameText
            // 
            this.LastNameText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.LastNameText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.LastNameText.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.LastNameText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LastNameText.Font = new System.Drawing.Font("Roboto", 11F);
            this.LastNameText.ForeColor = System.Drawing.Color.White;
            this.LastNameText.HintForeColor = System.Drawing.Color.White;
            this.LastNameText.HintText = "LastName";
            this.LastNameText.isPassword = false;
            this.LastNameText.LineFocusedColor = System.Drawing.Color.Gold;
            this.LastNameText.LineIdleColor = System.Drawing.Color.Gray;
            this.LastNameText.LineMouseHoverColor = System.Drawing.Color.Gold;
            this.LastNameText.LineThickness = 2;
            this.LastNameText.Location = new System.Drawing.Point(15, 20);
            this.LastNameText.Margin = new System.Windows.Forms.Padding(4);
            this.LastNameText.MaxLength = 32767;
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.Size = new System.Drawing.Size(79, 31);
            this.LastNameText.TabIndex = 1;
            this.LastNameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.LastNameText.Click += new System.EventHandler(this.LastNameText_Click);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.Silver;
            this.bunifuLabel1.Location = new System.Drawing.Point(104, 8);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(59, 17);
            this.bunifuLabel1.TabIndex = 8;
            this.bunifuLabel1.Text = "First Name";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.ForeColor = System.Drawing.Color.Silver;
            this.bunifuLabel2.Location = new System.Drawing.Point(15, 8);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(58, 17);
            this.bunifuLabel2.TabIndex = 9;
            this.bunifuLabel2.Text = "Last Name";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.CursorType = null;
            this.bunifuLabel3.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel3.ForeColor = System.Drawing.Color.Silver;
            this.bunifuLabel3.Location = new System.Drawing.Point(355, 8);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(26, 17);
            this.bunifuLabel3.TabIndex = 10;
            this.bunifuLabel3.Text = "Year";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.AutoEllipsis = false;
            this.bunifuLabel4.CursorType = null;
            this.bunifuLabel4.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel4.ForeColor = System.Drawing.Color.Silver;
            this.bunifuLabel4.Location = new System.Drawing.Point(414, 8);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(46, 17);
            this.bunifuLabel4.TabIndex = 11;
            this.bunifuLabel4.Text = "Program";
            this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel5
            // 
            this.bunifuLabel5.AutoEllipsis = false;
            this.bunifuLabel5.CursorType = null;
            this.bunifuLabel5.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel5.ForeColor = System.Drawing.Color.Silver;
            this.bunifuLabel5.Location = new System.Drawing.Point(502, 8);
            this.bunifuLabel5.Name = "bunifuLabel5";
            this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel5.Size = new System.Drawing.Size(41, 17);
            this.bunifuLabel5.TabIndex = 12;
            this.bunifuLabel5.Text = "Section";
            this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel6
            // 
            this.bunifuLabel6.AutoEllipsis = false;
            this.bunifuLabel6.CursorType = null;
            this.bunifuLabel6.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel6.ForeColor = System.Drawing.Color.Silver;
            this.bunifuLabel6.Location = new System.Drawing.Point(573, 5);
            this.bunifuLabel6.Name = "bunifuLabel6";
            this.bunifuLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel6.Size = new System.Drawing.Size(69, 17);
            this.bunifuLabel6.TabIndex = 13;
            this.bunifuLabel6.Text = "Account type";
            this.bunifuLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel6.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuLabel6.Click += new System.EventHandler(this.bunifuLabel6_Click);
            // 
            // bunifuLabel7
            // 
            this.bunifuLabel7.AutoEllipsis = false;
            this.bunifuLabel7.CursorType = null;
            this.bunifuLabel7.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel7.ForeColor = System.Drawing.Color.Silver;
            this.bunifuLabel7.Location = new System.Drawing.Point(216, 8);
            this.bunifuLabel7.Name = "bunifuLabel7";
            this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel7.Size = new System.Drawing.Size(70, 17);
            this.bunifuLabel7.TabIndex = 16;
            this.bunifuLabel7.Text = "Middle Name";
            this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // MiddleNameText
            // 
            this.MiddleNameText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.MiddleNameText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.MiddleNameText.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.MiddleNameText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MiddleNameText.Font = new System.Drawing.Font("Roboto", 11F);
            this.MiddleNameText.ForeColor = System.Drawing.Color.White;
            this.MiddleNameText.HintForeColor = System.Drawing.Color.White;
            this.MiddleNameText.HintText = "";
            this.MiddleNameText.isPassword = false;
            this.MiddleNameText.LineFocusedColor = System.Drawing.Color.Gold;
            this.MiddleNameText.LineIdleColor = System.Drawing.Color.Gray;
            this.MiddleNameText.LineMouseHoverColor = System.Drawing.Color.Gold;
            this.MiddleNameText.LineThickness = 2;
            this.MiddleNameText.Location = new System.Drawing.Point(216, 21);
            this.MiddleNameText.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleNameText.MaxLength = 32767;
            this.MiddleNameText.Name = "MiddleNameText";
            this.MiddleNameText.Size = new System.Drawing.Size(79, 31);
            this.MiddleNameText.TabIndex = 3;
            this.MiddleNameText.Text = "MiddleName";
            this.MiddleNameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.MiddleNameText.Click += new System.EventHandler(this.MiddleNameText_Click);
            this.MiddleNameText.Enter += new System.EventHandler(this.MiddleNameText_Click);
            // 
            // accountType
            // 
            this.accountType.AllowDrop = true;
            this.accountType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.accountType.BorderRadius = 1;
            this.accountType.Color = System.Drawing.Color.Gray;
            this.accountType.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.accountType.DisabledColor = System.Drawing.SystemColors.ControlDarkDark;
            this.accountType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.accountType.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.accountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountType.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.accountType.FillDropDown = false;
            this.accountType.FillIndicator = false;
            this.accountType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountType.ForeColor = System.Drawing.Color.White;
            this.accountType.FormattingEnabled = true;
            this.accountType.Icon = null;
            this.accountType.IndicatorColor = System.Drawing.Color.Gold;
            this.accountType.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.accountType.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.accountType.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.accountType.ItemForeColor = System.Drawing.Color.White;
            this.accountType.ItemHeight = 18;
            this.accountType.ItemHighLightColor = System.Drawing.Color.Gold;
            this.accountType.Items.AddRange(new object[] {
            "Student",
            "Admin"});
            this.accountType.Location = new System.Drawing.Point(573, 26);
            this.accountType.Name = "accountType";
            this.accountType.Size = new System.Drawing.Size(66, 24);
            this.accountType.TabIndex = 8;
            this.accountType.Text = "Student";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.FirstNameText);
            this.panel1.Controls.Add(this.secD);
            this.panel1.Controls.Add(this.Progd);
            this.panel1.Controls.Add(this.Yeard);
            this.panel1.Controls.Add(this.bunifuLabel8);
            this.panel1.Controls.Add(this.bunifuLabel7);
            this.panel1.Controls.Add(this.bunifuLabel5);
            this.panel1.Controls.Add(this.bunifuLabel1);
            this.panel1.Controls.Add(this.bunifuLabel2);
            this.panel1.Controls.Add(this.bunifuLabel3);
            this.panel1.Controls.Add(this.bunifuLabel4);
            this.panel1.Controls.Add(this.bunifuLabel6);
            this.panel1.Controls.Add(this.SuffixText);
            this.panel1.Controls.Add(this.accountType);
            this.panel1.Controls.Add(this.LastNameText);
            this.panel1.Controls.Add(this.MiddleNameText);
            this.panel1.Controls.Add(this.bunifuButton1);
            this.panel1.Location = new System.Drawing.Point(-8, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 67);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FirstNameText
            // 
            this.FirstNameText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.FirstNameText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.FirstNameText.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.FirstNameText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FirstNameText.Font = new System.Drawing.Font("Roboto", 11F);
            this.FirstNameText.ForeColor = System.Drawing.Color.White;
            this.FirstNameText.HintForeColor = System.Drawing.Color.White;
            this.FirstNameText.HintText = "FirstName";
            this.FirstNameText.isPassword = false;
            this.FirstNameText.LineFocusedColor = System.Drawing.Color.Gold;
            this.FirstNameText.LineIdleColor = System.Drawing.Color.Gray;
            this.FirstNameText.LineMouseHoverColor = System.Drawing.Color.Gold;
            this.FirstNameText.LineThickness = 2;
            this.FirstNameText.Location = new System.Drawing.Point(103, 21);
            this.FirstNameText.Margin = new System.Windows.Forms.Padding(4);
            this.FirstNameText.MaxLength = 32767;
            this.FirstNameText.Name = "FirstNameText";
            this.FirstNameText.Size = new System.Drawing.Size(104, 31);
            this.FirstNameText.TabIndex = 2;
            this.FirstNameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // secD
            // 
            this.secD.AllowDrop = true;
            this.secD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.secD.BorderRadius = 1;
            this.secD.Color = System.Drawing.Color.Gray;
            this.secD.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.secD.DisabledColor = System.Drawing.SystemColors.ControlDarkDark;
            this.secD.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.secD.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.secD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secD.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.secD.FillDropDown = false;
            this.secD.FillIndicator = false;
            this.secD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secD.ForeColor = System.Drawing.Color.White;
            this.secD.FormattingEnabled = true;
            this.secD.Icon = null;
            this.secD.IndicatorColor = System.Drawing.Color.Gold;
            this.secD.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.secD.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.secD.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.secD.ItemForeColor = System.Drawing.Color.White;
            this.secD.ItemHeight = 18;
            this.secD.ItemHighLightColor = System.Drawing.Color.Gold;
            this.secD.Location = new System.Drawing.Point(502, 27);
            this.secD.Name = "secD";
            this.secD.Size = new System.Drawing.Size(65, 24);
            this.secD.TabIndex = 7;
            this.secD.Text = null;
            // 
            // Progd
            // 
            this.Progd.AllowDrop = true;
            this.Progd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Progd.BorderRadius = 1;
            this.Progd.Color = System.Drawing.Color.Gray;
            this.Progd.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.Progd.DisabledColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Progd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Progd.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.Progd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Progd.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Progd.FillDropDown = false;
            this.Progd.FillIndicator = false;
            this.Progd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Progd.ForeColor = System.Drawing.Color.White;
            this.Progd.FormattingEnabled = true;
            this.Progd.Icon = null;
            this.Progd.IndicatorColor = System.Drawing.Color.Gold;
            this.Progd.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Progd.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Progd.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Progd.ItemForeColor = System.Drawing.Color.White;
            this.Progd.ItemHeight = 18;
            this.Progd.ItemHighLightColor = System.Drawing.Color.Gold;
            this.Progd.Location = new System.Drawing.Point(414, 27);
            this.Progd.Name = "Progd";
            this.Progd.Size = new System.Drawing.Size(82, 24);
            this.Progd.TabIndex = 6;
            this.Progd.Text = null;
            this.Progd.SelectedIndexChanged += new System.EventHandler(this.Progd_SelectedIndexChanged);
            // 
            // Yeard
            // 
            this.Yeard.AllowDrop = true;
            this.Yeard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Yeard.BorderRadius = 1;
            this.Yeard.Color = System.Drawing.Color.Gray;
            this.Yeard.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.Yeard.DisabledColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Yeard.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Yeard.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.Yeard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Yeard.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Yeard.FillDropDown = false;
            this.Yeard.FillIndicator = false;
            this.Yeard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yeard.ForeColor = System.Drawing.Color.White;
            this.Yeard.FormattingEnabled = true;
            this.Yeard.Icon = null;
            this.Yeard.IndicatorColor = System.Drawing.Color.Gold;
            this.Yeard.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Yeard.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Yeard.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Yeard.ItemForeColor = System.Drawing.Color.White;
            this.Yeard.ItemHeight = 18;
            this.Yeard.ItemHighLightColor = System.Drawing.Color.Gold;
            this.Yeard.Location = new System.Drawing.Point(355, 26);
            this.Yeard.Name = "Yeard";
            this.Yeard.Size = new System.Drawing.Size(53, 24);
            this.Yeard.TabIndex = 5;
            this.Yeard.Text = null;
            this.Yeard.SelectedIndexChanged += new System.EventHandler(this.Yeard_SelectedIndexChanged);
            // 
            // bunifuLabel8
            // 
            this.bunifuLabel8.AutoEllipsis = false;
            this.bunifuLabel8.CursorType = null;
            this.bunifuLabel8.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel8.ForeColor = System.Drawing.Color.Silver;
            this.bunifuLabel8.Location = new System.Drawing.Point(302, 8);
            this.bunifuLabel8.Name = "bunifuLabel8";
            this.bunifuLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel8.Size = new System.Drawing.Size(32, 17);
            this.bunifuLabel8.TabIndex = 31;
            this.bunifuLabel8.Text = "suffix";
            this.bunifuLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel8.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // SuffixText
            // 
            this.SuffixText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.SuffixText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.SuffixText.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.SuffixText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SuffixText.Font = new System.Drawing.Font("Roboto", 11F);
            this.SuffixText.ForeColor = System.Drawing.Color.White;
            this.SuffixText.HintForeColor = System.Drawing.Color.White;
            this.SuffixText.HintText = "";
            this.SuffixText.isPassword = false;
            this.SuffixText.LineFocusedColor = System.Drawing.Color.Gold;
            this.SuffixText.LineIdleColor = System.Drawing.Color.Gray;
            this.SuffixText.LineMouseHoverColor = System.Drawing.Color.Gold;
            this.SuffixText.LineThickness = 2;
            this.SuffixText.Location = new System.Drawing.Point(305, 21);
            this.SuffixText.Margin = new System.Windows.Forms.Padding(4);
            this.SuffixText.MaxLength = 32767;
            this.SuffixText.Name = "SuffixText";
            this.SuffixText.Size = new System.Drawing.Size(29, 31);
            this.SuffixText.TabIndex = 4;
            this.SuffixText.Text = "Jr";
            this.SuffixText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SuffixText.Click += new System.EventHandler(this.SuffixText_Click);
            this.SuffixText.Enter += new System.EventHandler(this.SuffixText_Enter);
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowToggling = false;
            this.bunifuButton1.AnimationSpeed = 200;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.Gold;
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.ButtonText = "Del";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.ColorContrastOnClick = 45;
            this.bunifuButton1.ColorContrastOnHover = 45;
            this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton1.CustomizableEdges = borderEdges1;
            this.bunifuButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton1.IconMarginLeft = 11;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.Gold;
            this.bunifuButton1.IdleBorderRadius = 3;
            this.bunifuButton1.IdleBorderThickness = 1;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.Gold;
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(669, -3);
            this.bunifuButton1.Name = "bunifuButton1";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            stateProperties1.BorderRadius = 3;
            stateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            stateProperties1.ForeColor = System.Drawing.Color.White;
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.bunifuButton1.onHoverState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            stateProperties2.BorderRadius = 3;
            stateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            stateProperties2.ForeColor = System.Drawing.Color.White;
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.bunifuButton1.OnPressedState = stateProperties2;
            this.bunifuButton1.Size = new System.Drawing.Size(37, 70);
            this.bunifuButton1.TabIndex = 10;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuButton2
            // 
            this.bunifuButton2.AllowToggling = false;
            this.bunifuButton2.AnimationSpeed = 200;
            this.bunifuButton2.AutoGenerateColors = false;
            this.bunifuButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton2.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton2.BackgroundImage")));
            this.bunifuButton2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.ButtonText = "Add";
            this.bunifuButton2.ButtonTextMarginLeft = 0;
            this.bunifuButton2.ColorContrastOnClick = 45;
            this.bunifuButton2.ColorContrastOnHover = 45;
            this.bunifuButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.bunifuButton2.CustomizableEdges = borderEdges2;
            this.bunifuButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton2.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton2.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton2.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton2.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton2.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton2.IconMarginLeft = 11;
            this.bunifuButton2.IconPadding = 10;
            this.bunifuButton2.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton2.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.IdleBorderRadius = 3;
            this.bunifuButton2.IdleBorderThickness = 1;
            this.bunifuButton2.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.IdleIconLeftImage = null;
            this.bunifuButton2.IdleIconRightImage = null;
            this.bunifuButton2.IndicateFocus = false;
            this.bunifuButton2.Location = new System.Drawing.Point(694, -1);
            this.bunifuButton2.Name = "bunifuButton2";
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.BorderRadius = 3;
            stateProperties3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties3.BorderThickness = 1;
            stateProperties3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.ForeColor = System.Drawing.Color.White;
            stateProperties3.IconLeftImage = null;
            stateProperties3.IconRightImage = null;
            this.bunifuButton2.onHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Gold;
            stateProperties4.BorderRadius = 3;
            stateProperties4.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties4.BorderThickness = 1;
            stateProperties4.FillColor = System.Drawing.Color.Gold;
            stateProperties4.ForeColor = System.Drawing.Color.White;
            stateProperties4.IconLeftImage = null;
            stateProperties4.IconRightImage = null;
            this.bunifuButton2.OnPressedState = stateProperties4;
            this.bunifuButton2.Size = new System.Drawing.Size(45, 61);
            this.bunifuButton2.TabIndex = 9;
            this.bunifuButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton2.TextMarginLeft = 0;
            this.bunifuButton2.UseDefaultRadiusAndThickness = true;
            this.bunifuButton2.Click += new System.EventHandler(this.bunifuButton2_Click);
            // 
            // AddstudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(753, 58);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuButton2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddstudentForm";
            this.Text = "Addstudent";
            this.Load += new System.EventHandler(this.Addstudent_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMaterialTextbox LastNameText;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel5;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel6;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox MiddleNameText;
        private Bunifu.UI.WinForms.BunifuDropdown accountType;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox SuffixText;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel8;
        private Bunifu.UI.WinForms.BunifuDropdown secD;
        private Bunifu.UI.WinForms.BunifuDropdown Progd;
        private Bunifu.UI.WinForms.BunifuDropdown Yeard;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox FirstNameText;
    }
}