namespace FindInLogBuildFile
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenFileWithFiles = new System.Windows.Forms.Button();
            this.buttonOpenFileWithLogFile = new System.Windows.Forms.Button();
            this.buttonOpenReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpenFileWithFiles
            // 
            this.buttonOpenFileWithFiles.Location = new System.Drawing.Point(23, 13);
            this.buttonOpenFileWithFiles.Name = "buttonOpenFileWithFiles";
            this.buttonOpenFileWithFiles.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFileWithFiles.TabIndex = 0;
            this.buttonOpenFileWithFiles.Text = "Files";
            this.buttonOpenFileWithFiles.UseMnemonic = false;
            this.buttonOpenFileWithFiles.UseVisualStyleBackColor = true;
            this.buttonOpenFileWithFiles.Click += new System.EventHandler(this.buttonOpenFileWithFiles_Click);
            // 
            // buttonOpenFileWithLogFile
            // 
            this.buttonOpenFileWithLogFile.Location = new System.Drawing.Point(134, 13);
            this.buttonOpenFileWithLogFile.Name = "buttonOpenFileWithLogFile";
            this.buttonOpenFileWithLogFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFileWithLogFile.TabIndex = 1;
            this.buttonOpenFileWithLogFile.Text = "LogFile";
            this.buttonOpenFileWithLogFile.UseVisualStyleBackColor = true;
            this.buttonOpenFileWithLogFile.Click += new System.EventHandler(this.buttonOpenFileWithLogFile_Click);
            // 
            // buttonOpenReport
            // 
            this.buttonOpenReport.Location = new System.Drawing.Point(23, 43);
            this.buttonOpenReport.Name = "buttonOpenReport";
            this.buttonOpenReport.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenReport.TabIndex = 2;
            this.buttonOpenReport.Text = "OpenReport";
            this.buttonOpenReport.UseVisualStyleBackColor = true;
            this.buttonOpenReport.Click += new System.EventHandler(this.buttonOpenReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 79);
            this.Controls.Add(this.buttonOpenReport);
            this.Controls.Add(this.buttonOpenFileWithLogFile);
            this.Controls.Add(this.buttonOpenFileWithFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFileWithFiles;
        private System.Windows.Forms.Button buttonOpenFileWithLogFile;
        private System.Windows.Forms.Button buttonOpenReport;
    }
}

