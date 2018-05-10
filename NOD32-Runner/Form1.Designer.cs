namespace NOD32_Runner
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serviceEnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.showGuiButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // serviceEnabledCheckbox
            // 
            this.serviceEnabledCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceEnabledCheckbox.AutoSize = true;
            this.serviceEnabledCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "isServiceCheckboxChecked", true));
            this.serviceEnabledCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSource, "isServiceCheckboxEnabled", true));
            this.serviceEnabledCheckbox.Location = new System.Drawing.Point(21, 19);
            this.serviceEnabledCheckbox.Name = "serviceEnabledCheckbox";
            this.serviceEnabledCheckbox.Size = new System.Drawing.Size(140, 17);
            this.serviceEnabledCheckbox.TabIndex = 0;
            this.serviceEnabledCheckbox.Text = "Enable NOD32 service";
            this.serviceEnabledCheckbox.UseVisualStyleBackColor = true;
            this.serviceEnabledCheckbox.Click += new System.EventHandler(this.serviceEnabledCheckbox_Click);
            // 
            // showGuiButton
            // 
            this.showGuiButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showGuiButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSource, "IsGuiButtonEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.showGuiButton.Location = new System.Drawing.Point(21, 47);
            this.showGuiButton.Name = "showGuiButton";
            this.showGuiButton.Size = new System.Drawing.Size(141, 23);
            this.showGuiButton.TabIndex = 1;
            this.showGuiButton.Text = "Show NOD32 GUI";
            this.showGuiButton.UseVisualStyleBackColor = true;
            this.showGuiButton.Click += new System.EventHandler(this.showGuiButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "isProgressBarVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.progressBar1.Location = new System.Drawing.Point(-1, -1);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(186, 11);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Value = 50;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NOD32_Runner.FormViewModel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 87);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.showGuiButton);
            this.Controls.Add(this.serviceEnabledCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESET NOD32";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox serviceEnabledCheckbox;
        private System.Windows.Forms.Button showGuiButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}

