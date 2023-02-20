namespace ImageCropResize
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.OriginalImageBox = new System.Windows.Forms.PictureBox();
            this.CroppedImageBox = new System.Windows.Forms.PictureBox();
            this.Preset1Button = new System.Windows.Forms.Button();
            this.Preset2Button = new System.Windows.Forms.Button();
            this.Preset3Button = new System.Windows.Forms.Button();
            this.Preset1_XYLabel = new System.Windows.Forms.Label();
            this.Preset1_WidthHeightLabel = new System.Windows.Forms.Label();
            this.Preset1_ResizeWHLabel = new System.Windows.Forms.Label();
            this.Preset2_XYLabel = new System.Windows.Forms.Label();
            this.Preset2_WidthHeightLabel = new System.Windows.Forms.Label();
            this.Preset2_ResizeWHLabel = new System.Windows.Forms.Label();
            this.Preset3_XYLabel = new System.Windows.Forms.Label();
            this.Preset3_WidthHeightLabel = new System.Windows.Forms.Label();
            this.Preset3_ResizeWHLabel = new System.Windows.Forms.Label();
            this.SaveNewSettingsButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.OriginalImageLabel = new System.Windows.Forms.Label();
            this.ConvertedImageLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CroppedImageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginalImageBox
            // 
            this.OriginalImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalImageBox.Location = new System.Drawing.Point(23, 57);
            this.OriginalImageBox.Name = "OriginalImageBox";
            this.OriginalImageBox.Size = new System.Drawing.Size(350, 197);
            this.OriginalImageBox.TabIndex = 1;
            this.OriginalImageBox.TabStop = false;
            // 
            // CroppedImageBox
            // 
            this.CroppedImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CroppedImageBox.Location = new System.Drawing.Point(419, 57);
            this.CroppedImageBox.Name = "CroppedImageBox";
            this.CroppedImageBox.Size = new System.Drawing.Size(350, 197);
            this.CroppedImageBox.TabIndex = 2;
            this.CroppedImageBox.TabStop = false;
            // 
            // Preset1Button
            // 
            this.Preset1Button.Location = new System.Drawing.Point(22, 9);
            this.Preset1Button.Name = "Preset1Button";
            this.Preset1Button.Size = new System.Drawing.Size(120, 27);
            this.Preset1Button.TabIndex = 1;
            this.Preset1Button.Text = "Preset 1";
            this.Preset1Button.UseVisualStyleBackColor = true;
            this.Preset1Button.Click += new System.EventHandler(this.Preset1Button_Click);
            // 
            // Preset2Button
            // 
            this.Preset2Button.Location = new System.Drawing.Point(20, 10);
            this.Preset2Button.Name = "Preset2Button";
            this.Preset2Button.Size = new System.Drawing.Size(120, 27);
            this.Preset2Button.TabIndex = 2;
            this.Preset2Button.Text = "Preset 2";
            this.Preset2Button.UseVisualStyleBackColor = true;
            this.Preset2Button.Click += new System.EventHandler(this.Preset2Button_Click);
            // 
            // Preset3Button
            // 
            this.Preset3Button.Location = new System.Drawing.Point(21, 11);
            this.Preset3Button.Name = "Preset3Button";
            this.Preset3Button.Size = new System.Drawing.Size(120, 27);
            this.Preset3Button.TabIndex = 3;
            this.Preset3Button.Text = "Preset 3";
            this.Preset3Button.UseVisualStyleBackColor = true;
            this.Preset3Button.Click += new System.EventHandler(this.Preset3Button_Click);
            // 
            // Preset1_XYLabel
            // 
            this.Preset1_XYLabel.Location = new System.Drawing.Point(8, 49);
            this.Preset1_XYLabel.Name = "Preset1_XYLabel";
            this.Preset1_XYLabel.Size = new System.Drawing.Size(135, 19);
            this.Preset1_XYLabel.TabIndex = 27;
            this.Preset1_XYLabel.Text = "X Value x Y Value";
            // 
            // Preset1_WidthHeightLabel
            // 
            this.Preset1_WidthHeightLabel.Location = new System.Drawing.Point(8, 75);
            this.Preset1_WidthHeightLabel.Name = "Preset1_WidthHeightLabel";
            this.Preset1_WidthHeightLabel.Size = new System.Drawing.Size(135, 19);
            this.Preset1_WidthHeightLabel.TabIndex = 28;
            this.Preset1_WidthHeightLabel.Text = "Width x Height";
            // 
            // Preset1_ResizeWHLabel
            // 
            this.Preset1_ResizeWHLabel.Location = new System.Drawing.Point(8, 100);
            this.Preset1_ResizeWHLabel.Name = "Preset1_ResizeWHLabel";
            this.Preset1_ResizeWHLabel.Size = new System.Drawing.Size(135, 19);
            this.Preset1_ResizeWHLabel.TabIndex = 29;
            this.Preset1_ResizeWHLabel.Text = "Resize H x W";
            // 
            // Preset2_XYLabel
            // 
            this.Preset2_XYLabel.Location = new System.Drawing.Point(7, 50);
            this.Preset2_XYLabel.Name = "Preset2_XYLabel";
            this.Preset2_XYLabel.Size = new System.Drawing.Size(137, 19);
            this.Preset2_XYLabel.TabIndex = 30;
            this.Preset2_XYLabel.Text = "X Value x Y Value";
            // 
            // Preset2_WidthHeightLabel
            // 
            this.Preset2_WidthHeightLabel.Location = new System.Drawing.Point(7, 76);
            this.Preset2_WidthHeightLabel.Name = "Preset2_WidthHeightLabel";
            this.Preset2_WidthHeightLabel.Size = new System.Drawing.Size(137, 19);
            this.Preset2_WidthHeightLabel.TabIndex = 31;
            this.Preset2_WidthHeightLabel.Text = "Width x Height";
            // 
            // Preset2_ResizeWHLabel
            // 
            this.Preset2_ResizeWHLabel.Location = new System.Drawing.Point(7, 101);
            this.Preset2_ResizeWHLabel.Name = "Preset2_ResizeWHLabel";
            this.Preset2_ResizeWHLabel.Size = new System.Drawing.Size(137, 19);
            this.Preset2_ResizeWHLabel.TabIndex = 32;
            this.Preset2_ResizeWHLabel.Text = "Resize H x W";
            // 
            // Preset3_XYLabel
            // 
            this.Preset3_XYLabel.Location = new System.Drawing.Point(8, 50);
            this.Preset3_XYLabel.Name = "Preset3_XYLabel";
            this.Preset3_XYLabel.Size = new System.Drawing.Size(136, 19);
            this.Preset3_XYLabel.TabIndex = 33;
            this.Preset3_XYLabel.Text = "X Value x Y Value";
            // 
            // Preset3_WidthHeightLabel
            // 
            this.Preset3_WidthHeightLabel.Location = new System.Drawing.Point(8, 77);
            this.Preset3_WidthHeightLabel.Name = "Preset3_WidthHeightLabel";
            this.Preset3_WidthHeightLabel.Size = new System.Drawing.Size(136, 19);
            this.Preset3_WidthHeightLabel.TabIndex = 34;
            this.Preset3_WidthHeightLabel.Text = "Width x Height";
            // 
            // Preset3_ResizeWHLabel
            // 
            this.Preset3_ResizeWHLabel.Location = new System.Drawing.Point(8, 102);
            this.Preset3_ResizeWHLabel.Name = "Preset3_ResizeWHLabel";
            this.Preset3_ResizeWHLabel.Size = new System.Drawing.Size(136, 19);
            this.Preset3_ResizeWHLabel.TabIndex = 35;
            this.Preset3_ResizeWHLabel.Text = "Resize H x W";
            // 
            // SaveNewSettingsButton
            // 
            this.SaveNewSettingsButton.Location = new System.Drawing.Point(337, 436);
            this.SaveNewSettingsButton.Name = "SaveNewSettingsButton";
            this.SaveNewSettingsButton.Size = new System.Drawing.Size(115, 23);
            this.SaveNewSettingsButton.TabIndex = 36;
            this.SaveNewSettingsButton.Text = "New Settings";
            this.SaveNewSettingsButton.UseVisualStyleBackColor = true;
            this.SaveNewSettingsButton.Click += new System.EventHandler(this.SaveNewSettingsButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Enabled = false;
            this.UndoButton.Location = new System.Drawing.Point(242, 436);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 37;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // OriginalImageLabel
            // 
            this.OriginalImageLabel.Location = new System.Drawing.Point(23, 257);
            this.OriginalImageLabel.Name = "OriginalImageLabel";
            this.OriginalImageLabel.Size = new System.Drawing.Size(350, 15);
            this.OriginalImageLabel.TabIndex = 40;
            this.OriginalImageLabel.Text = "Original Image";
            this.OriginalImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConvertedImageLabel
            // 
            this.ConvertedImageLabel.Location = new System.Drawing.Point(419, 257);
            this.ConvertedImageLabel.Name = "ConvertedImageLabel";
            this.ConvertedImageLabel.Size = new System.Drawing.Size(350, 15);
            this.ConvertedImageLabel.TabIndex = 41;
            this.ConvertedImageLabel.Text = "Converted Image";
            this.ConvertedImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MessageLabel.Location = new System.Drawing.Point(23, 8);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(746, 35);
            this.MessageLabel.TabIndex = 42;
            this.MessageLabel.Text = "Status";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Preset1Button);
            this.panel1.Controls.Add(this.Preset1_XYLabel);
            this.panel1.Controls.Add(this.Preset1_WidthHeightLabel);
            this.panel1.Controls.Add(this.Preset1_ResizeWHLabel);
            this.panel1.Location = new System.Drawing.Point(133, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 129);
            this.panel1.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Preset2Button);
            this.panel2.Controls.Add(this.Preset2_XYLabel);
            this.panel2.Controls.Add(this.Preset2_WidthHeightLabel);
            this.panel2.Controls.Add(this.Preset2_ResizeWHLabel);
            this.panel2.Location = new System.Drawing.Point(311, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 129);
            this.panel2.TabIndex = 44;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Preset3_WidthHeightLabel);
            this.panel3.Controls.Add(this.Preset3Button);
            this.panel3.Controls.Add(this.Preset3_XYLabel);
            this.panel3.Controls.Add(this.Preset3_ResizeWHLabel);
            this.panel3.Location = new System.Drawing.Point(489, 288);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(162, 129);
            this.panel3.TabIndex = 45;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(470, 436);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 46;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.ConvertedImageLabel);
            this.Controls.Add(this.OriginalImageLabel);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.SaveNewSettingsButton);
            this.Controls.Add(this.CroppedImageBox);
            this.Controls.Add(this.OriginalImageBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Image Crop & Resize";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CroppedImageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox OriginalImageBox;
        private PictureBox CroppedImageBox;
        private Button Preset1Button;
        private Button Preset2Button;
        private Button Preset3Button;
        private Label Preset1_XYLabel;
        private Label Preset1_WidthHeightLabel;
        private Label Preset1_ResizeWHLabel;
        private Label Preset2_XYLabel;
        private Label Preset2_WidthHeightLabel;
        private Label Preset2_ResizeWHLabel;
        private Label Preset3_XYLabel;
        private Label Preset3_WidthHeightLabel;
        private Label Preset3_ResizeWHLabel;
        private Button UndoButton;
        public Button SaveNewSettingsButton;
        private Label OriginalImageLabel;
        private Label ConvertedImageLabel;
        private Label MessageLabel;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button ExitButton;
    }
}