/// @autor Ключерев Артемий 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chat
{
    // форма используется для ввода имени пользователя
    public partial class Form_user : Form
    {
        public Form_user()
        {
            Program.form_user = this; // теперь form_user будет ссылкой на форму Form_user
            InitializeComponent();
            KeyPreview = true;
        }

        // при нажатии на кнопку "ввод"
        private void button_username_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form_Chat();
            form2.Show();
            
            if (this.textBox_username.Text != "")
            {
                // передача второй форме имени пользователя
                form2.Txt = this.textBox_username.Text;
            }
            else form2.Txt = "user123456789";
        }
    }
}
