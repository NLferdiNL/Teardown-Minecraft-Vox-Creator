namespace MinecraftBlockCreator {
    partial class Form1 {
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
            this.imageFileSelector = new System.Windows.Forms.OpenFileDialog();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.selectedFileLabel = new System.Windows.Forms.Label();
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.generateVoxButton = new System.Windows.Forms.Button();
            this.voxFileSaveLocation = new System.Windows.Forms.SaveFileDialog();
            this.saveLocationLabel = new System.Windows.Forms.Label();
            this.openSaveDialogButton = new System.Windows.Forms.Button();
            this.materialListLabel = new System.Windows.Forms.Label();
            this.plasticMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.heavyMetalMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.weakMetalMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.plasterMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.brickMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.concreteMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.woodMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.rockMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.dirtMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.grassMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.glassMaterialRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.offsetRandomizeCheckBox = new System.Windows.Forms.CheckBox();
            this.marginNumberSelector = new System.Windows.Forms.NumericUpDown();
            this.marginLabel = new System.Windows.Forms.Label();
            this.batchJobFolderSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.batchGenerationCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marginNumberSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // imageFileSelector
            // 
            this.imageFileSelector.Filter = "Images|*.png;*.jpg|All files|*.*";
            this.imageFileSelector.Multiselect = true;
            this.imageFileSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.imageFileSelector_FileOk);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(15, 33);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(121, 23);
            this.selectFileButton.TabIndex = 0;
            this.selectFileButton.Text = "Select File(s)";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // selectedFileLabel
            // 
            this.selectedFileLabel.AutoSize = true;
            this.selectedFileLabel.Location = new System.Drawing.Point(12, 17);
            this.selectedFileLabel.Name = "selectedFileLabel";
            this.selectedFileLabel.Size = new System.Drawing.Size(97, 13);
            this.selectedFileLabel.TabIndex = 1;
            this.selectedFileLabel.Text = "Selected file: None";
            // 
            // imagePreview
            // 
            this.imagePreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.imagePreview.Location = new System.Drawing.Point(15, 62);
            this.imagePreview.Name = "imagePreview";
            this.imagePreview.Size = new System.Drawing.Size(200, 200);
            this.imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePreview.TabIndex = 2;
            this.imagePreview.TabStop = false;
            // 
            // generateVoxButton
            // 
            this.generateVoxButton.Location = new System.Drawing.Point(18, 314);
            this.generateVoxButton.Name = "generateVoxButton";
            this.generateVoxButton.Size = new System.Drawing.Size(118, 23);
            this.generateVoxButton.TabIndex = 4;
            this.generateVoxButton.Text = "Generate Vox";
            this.generateVoxButton.UseVisualStyleBackColor = true;
            this.generateVoxButton.Click += new System.EventHandler(this.generateVoxButton_Click);
            // 
            // voxFileSaveLocation
            // 
            this.voxFileSaveLocation.Filter = "Vox|*.vox";
            this.voxFileSaveLocation.FileOk += new System.ComponentModel.CancelEventHandler(this.voxFileSaveLocation_FileOk);
            // 
            // saveLocationLabel
            // 
            this.saveLocationLabel.AutoSize = true;
            this.saveLocationLabel.Location = new System.Drawing.Point(15, 269);
            this.saveLocationLabel.Name = "saveLocationLabel";
            this.saveLocationLabel.Size = new System.Drawing.Size(104, 13);
            this.saveLocationLabel.TabIndex = 4;
            this.saveLocationLabel.Text = "Save location: None";
            // 
            // openSaveDialogButton
            // 
            this.openSaveDialogButton.Location = new System.Drawing.Point(18, 285);
            this.openSaveDialogButton.Name = "openSaveDialogButton";
            this.openSaveDialogButton.Size = new System.Drawing.Size(118, 23);
            this.openSaveDialogButton.TabIndex = 3;
            this.openSaveDialogButton.Text = "Select Save Location";
            this.openSaveDialogButton.UseVisualStyleBackColor = true;
            this.openSaveDialogButton.Click += new System.EventHandler(this.openSaveDialogButton_Click);
            // 
            // materialListLabel
            // 
            this.materialListLabel.AutoSize = true;
            this.materialListLabel.Location = new System.Drawing.Point(230, 17);
            this.materialListLabel.Name = "materialListLabel";
            this.materialListLabel.Size = new System.Drawing.Size(81, 13);
            this.materialListLabel.TabIndex = 6;
            this.materialListLabel.Text = "Default Material";
            // 
            // plasticMaterialRadioButton
            // 
            this.plasticMaterialRadioButton.AutoSize = true;
            this.plasticMaterialRadioButton.Checked = true;
            this.plasticMaterialRadioButton.Location = new System.Drawing.Point(233, 39);
            this.plasticMaterialRadioButton.Name = "plasticMaterialRadioButton";
            this.plasticMaterialRadioButton.Size = new System.Drawing.Size(56, 17);
            this.plasticMaterialRadioButton.TabIndex = 7;
            this.plasticMaterialRadioButton.TabStop = true;
            this.plasticMaterialRadioButton.Text = "Plastic";
            this.plasticMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // heavyMetalMaterialRadioButton
            // 
            this.heavyMetalMaterialRadioButton.AutoSize = true;
            this.heavyMetalMaterialRadioButton.Location = new System.Drawing.Point(233, 62);
            this.heavyMetalMaterialRadioButton.Name = "heavyMetalMaterialRadioButton";
            this.heavyMetalMaterialRadioButton.Size = new System.Drawing.Size(85, 17);
            this.heavyMetalMaterialRadioButton.TabIndex = 8;
            this.heavyMetalMaterialRadioButton.TabStop = true;
            this.heavyMetalMaterialRadioButton.Text = "Heavy Metal";
            this.heavyMetalMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // weakMetalMaterialRadioButton
            // 
            this.weakMetalMaterialRadioButton.AutoSize = true;
            this.weakMetalMaterialRadioButton.Location = new System.Drawing.Point(233, 85);
            this.weakMetalMaterialRadioButton.Name = "weakMetalMaterialRadioButton";
            this.weakMetalMaterialRadioButton.Size = new System.Drawing.Size(83, 17);
            this.weakMetalMaterialRadioButton.TabIndex = 9;
            this.weakMetalMaterialRadioButton.TabStop = true;
            this.weakMetalMaterialRadioButton.Text = "Weak Metal";
            this.weakMetalMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // plasterMaterialRadioButton
            // 
            this.plasterMaterialRadioButton.AutoSize = true;
            this.plasterMaterialRadioButton.Location = new System.Drawing.Point(233, 108);
            this.plasterMaterialRadioButton.Name = "plasterMaterialRadioButton";
            this.plasterMaterialRadioButton.Size = new System.Drawing.Size(57, 17);
            this.plasterMaterialRadioButton.TabIndex = 10;
            this.plasterMaterialRadioButton.TabStop = true;
            this.plasterMaterialRadioButton.Text = "Plaster";
            this.plasterMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // brickMaterialRadioButton
            // 
            this.brickMaterialRadioButton.AutoSize = true;
            this.brickMaterialRadioButton.Location = new System.Drawing.Point(233, 131);
            this.brickMaterialRadioButton.Name = "brickMaterialRadioButton";
            this.brickMaterialRadioButton.Size = new System.Drawing.Size(49, 17);
            this.brickMaterialRadioButton.TabIndex = 11;
            this.brickMaterialRadioButton.TabStop = true;
            this.brickMaterialRadioButton.Text = "Brick";
            this.brickMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // concreteMaterialRadioButton
            // 
            this.concreteMaterialRadioButton.AutoSize = true;
            this.concreteMaterialRadioButton.Location = new System.Drawing.Point(233, 154);
            this.concreteMaterialRadioButton.Name = "concreteMaterialRadioButton";
            this.concreteMaterialRadioButton.Size = new System.Drawing.Size(68, 17);
            this.concreteMaterialRadioButton.TabIndex = 12;
            this.concreteMaterialRadioButton.TabStop = true;
            this.concreteMaterialRadioButton.Text = "Concrete";
            this.concreteMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // woodMaterialRadioButton
            // 
            this.woodMaterialRadioButton.AutoSize = true;
            this.woodMaterialRadioButton.Location = new System.Drawing.Point(233, 177);
            this.woodMaterialRadioButton.Name = "woodMaterialRadioButton";
            this.woodMaterialRadioButton.Size = new System.Drawing.Size(54, 17);
            this.woodMaterialRadioButton.TabIndex = 13;
            this.woodMaterialRadioButton.TabStop = true;
            this.woodMaterialRadioButton.Text = "Wood";
            this.woodMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // rockMaterialRadioButton
            // 
            this.rockMaterialRadioButton.AutoSize = true;
            this.rockMaterialRadioButton.Location = new System.Drawing.Point(233, 200);
            this.rockMaterialRadioButton.Name = "rockMaterialRadioButton";
            this.rockMaterialRadioButton.Size = new System.Drawing.Size(51, 17);
            this.rockMaterialRadioButton.TabIndex = 14;
            this.rockMaterialRadioButton.TabStop = true;
            this.rockMaterialRadioButton.Text = "Rock";
            this.rockMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // dirtMaterialRadioButton
            // 
            this.dirtMaterialRadioButton.AutoSize = true;
            this.dirtMaterialRadioButton.Location = new System.Drawing.Point(233, 223);
            this.dirtMaterialRadioButton.Name = "dirtMaterialRadioButton";
            this.dirtMaterialRadioButton.Size = new System.Drawing.Size(41, 17);
            this.dirtMaterialRadioButton.TabIndex = 15;
            this.dirtMaterialRadioButton.TabStop = true;
            this.dirtMaterialRadioButton.Text = "Dirt";
            this.dirtMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // grassMaterialRadioButton
            // 
            this.grassMaterialRadioButton.AutoSize = true;
            this.grassMaterialRadioButton.Location = new System.Drawing.Point(233, 245);
            this.grassMaterialRadioButton.Name = "grassMaterialRadioButton";
            this.grassMaterialRadioButton.Size = new System.Drawing.Size(52, 17);
            this.grassMaterialRadioButton.TabIndex = 16;
            this.grassMaterialRadioButton.TabStop = true;
            this.grassMaterialRadioButton.Text = "Grass";
            this.grassMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // glassMaterialRadioButton
            // 
            this.glassMaterialRadioButton.AutoSize = true;
            this.glassMaterialRadioButton.Location = new System.Drawing.Point(233, 268);
            this.glassMaterialRadioButton.Name = "glassMaterialRadioButton";
            this.glassMaterialRadioButton.Size = new System.Drawing.Size(51, 17);
            this.glassMaterialRadioButton.TabIndex = 17;
            this.glassMaterialRadioButton.TabStop = true;
            this.glassMaterialRadioButton.Text = "Glass";
            this.glassMaterialRadioButton.UseVisualStyleBackColor = true;
            // 
            // offsetRandomizeCheckBox
            // 
            this.offsetRandomizeCheckBox.AutoSize = true;
            this.offsetRandomizeCheckBox.Location = new System.Drawing.Point(233, 291);
            this.offsetRandomizeCheckBox.Name = "offsetRandomizeCheckBox";
            this.offsetRandomizeCheckBox.Size = new System.Drawing.Size(143, 17);
            this.offsetRandomizeCheckBox.TabIndex = 18;
            this.offsetRandomizeCheckBox.Text = "Randomize insides offset";
            this.offsetRandomizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // marginNumberSelector
            // 
            this.marginNumberSelector.Location = new System.Drawing.Point(278, 314);
            this.marginNumberSelector.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.marginNumberSelector.Name = "marginNumberSelector";
            this.marginNumberSelector.Size = new System.Drawing.Size(91, 20);
            this.marginNumberSelector.TabIndex = 19;
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(230, 316);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(42, 13);
            this.marginLabel.TabIndex = 20;
            this.marginLabel.Text = "Margin:";
            // 
            // batchGenerationCount
            // 
            this.batchGenerationCount.AutoSize = true;
            this.batchGenerationCount.Location = new System.Drawing.Point(142, 319);
            this.batchGenerationCount.Name = "batchGenerationCount";
            this.batchGenerationCount.Size = new System.Drawing.Size(0, 13);
            this.batchGenerationCount.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 347);
            this.Controls.Add(this.batchGenerationCount);
            this.Controls.Add(this.marginLabel);
            this.Controls.Add(this.marginNumberSelector);
            this.Controls.Add(this.offsetRandomizeCheckBox);
            this.Controls.Add(this.glassMaterialRadioButton);
            this.Controls.Add(this.grassMaterialRadioButton);
            this.Controls.Add(this.dirtMaterialRadioButton);
            this.Controls.Add(this.rockMaterialRadioButton);
            this.Controls.Add(this.woodMaterialRadioButton);
            this.Controls.Add(this.concreteMaterialRadioButton);
            this.Controls.Add(this.brickMaterialRadioButton);
            this.Controls.Add(this.plasterMaterialRadioButton);
            this.Controls.Add(this.weakMetalMaterialRadioButton);
            this.Controls.Add(this.heavyMetalMaterialRadioButton);
            this.Controls.Add(this.plasticMaterialRadioButton);
            this.Controls.Add(this.materialListLabel);
            this.Controls.Add(this.openSaveDialogButton);
            this.Controls.Add(this.saveLocationLabel);
            this.Controls.Add(this.generateVoxButton);
            this.Controls.Add(this.imagePreview);
            this.Controls.Add(this.selectedFileLabel);
            this.Controls.Add(this.selectFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Minecraft Block Creator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marginNumberSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog imageFileSelector;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label selectedFileLabel;
        private System.Windows.Forms.PictureBox imagePreview;
        private System.Windows.Forms.Button generateVoxButton;
        private System.Windows.Forms.SaveFileDialog voxFileSaveLocation;
        private System.Windows.Forms.Label saveLocationLabel;
        private System.Windows.Forms.Button openSaveDialogButton;
        private System.Windows.Forms.Label materialListLabel;
        private System.Windows.Forms.RadioButton plasticMaterialRadioButton;
        private System.Windows.Forms.RadioButton heavyMetalMaterialRadioButton;
        private System.Windows.Forms.RadioButton weakMetalMaterialRadioButton;
        private System.Windows.Forms.RadioButton plasterMaterialRadioButton;
        private System.Windows.Forms.RadioButton brickMaterialRadioButton;
        private System.Windows.Forms.RadioButton concreteMaterialRadioButton;
        private System.Windows.Forms.RadioButton woodMaterialRadioButton;
        private System.Windows.Forms.RadioButton rockMaterialRadioButton;
        private System.Windows.Forms.RadioButton dirtMaterialRadioButton;
        private System.Windows.Forms.RadioButton grassMaterialRadioButton;
        private System.Windows.Forms.RadioButton glassMaterialRadioButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox offsetRandomizeCheckBox;
        private System.Windows.Forms.NumericUpDown marginNumberSelector;
        private System.Windows.Forms.Label marginLabel;
        private System.Windows.Forms.FolderBrowserDialog batchJobFolderSelect;
        private System.Windows.Forms.Label batchGenerationCount;
    }
}

