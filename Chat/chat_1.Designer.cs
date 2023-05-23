/// @autor Ключерев Артемий 
namespace Chat
{
    partial class Form_user
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_user));
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.button_username = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(26, 26);
            this.textBox_username.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_username.Multiline = true;
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(287, 38);
            this.textBox_username.TabIndex = 0;
            // 
            // button_username
            // 
            this.button_username.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_username.Location = new System.Drawing.Point(26, 90);
            this.button_username.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_username.Name = "button_username";
            this.button_username.Size = new System.Drawing.Size(287, 43);
            this.button_username.TabIndex = 1;
            this.button_username.Text = "Ввод";
            this.button_username.UseVisualStyleBackColor = true;
            this.button_username.Click += new System.EventHandler(this.button_username_Click);
            // 
            // Form_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(345, 164);
            this.Controls.Add(this.button_username);
            this.Controls.Add(this.textBox_username);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form_user";
            this.Text = "Введите имя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button button_username;
    }
}

