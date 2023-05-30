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
    public partial class Сhat_1 : Form
    {
        public Сhat_1()
        {
            Program.form_user = this; // теперь form_user будет ссылкой на форму Сhat_1
            InitializeComponent();
            KeyPreview = true;// форма получит все события клавиш
        }

        // при нажатии на кнопку "ввод"
        private void button_username_Click(object sender, EventArgs e)
        {
            this.Hide();//Скрывает элемент управления от пользователя
            var form2 = new Сhat_2();//создаем форму
            form2.Show();//отображаем ее на экран

            //проверяет, не является ли текст пустой строкой
            if (this.textBox_username.Text != "")
            {
                // передача второй форме имени пользователя
                form2.Txt = this.textBox_username.Text;
            }
            else form2.Txt = "user123456789";//задаем имя пользователя,если он ничего не ввел
        }


        // ввод имени при нажатии на enter
        private void Chat1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_username.PerformClick();
            }
        }
    }
}
