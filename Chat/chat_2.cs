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
    // форма для общения с чатботом
    public partial class Сhat_2 : Form
    {
        ChatB user;

        public Сhat_2()
        {
            InitializeComponent();

            user = new ChatB();

            // справка
            ToolStripMenuItem aboutItem = new ToolStripMenuItem("Справка");
            

            //назначив оброботчик для события click,мы можемобробатывать нажатия на пункты меню
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);

            // обработчик при закрытии форма
            FormClosing += new FormClosingEventHandler(Chat2_Closing);

            KeyPreview = true;
        }

        // нажатие на справку
        void aboutItem_Click(object sender, EventArgs e)
        {
            textBox_out.Text += "Справка " + Environment.NewLine +
                "Что умеет ЧатБот:\n" + Environment.NewLine +
                "1. Отвечает на приветствие(любое слово, имеющее 'прив')\n" + Environment.NewLine +
                "2. Показывает дату(дат) и время(врем)\n" + Environment.NewLine +
                "3. Умеет складывать,вычитать,делить,умножать числа(сложи число и число,умножь и т.д.)\n" + Environment.NewLine +
                "4. Отвечает на прощание(любое слово, которое заканчивается на 'пока')\n" + Environment.NewLine  ;
        }

        // используется для передачи данных между формами
        public string Txt
        {
            get { return user.username_get(); }
            set { user.username_set(value); }
        }

        // отправка сообщений по кнопке
        private void button_send_Click(object sender, EventArgs e)
        {
            if (textBox_In.Text != "")
            {
                // сообщение пользователя  
                textBox_out.Text += textBox_In.Text + "(" + user.username_get() + ", " + DateTime.Now.ToString("T") + ")\n" + Environment.NewLine;
                // ответ чатбота
                textBox_out.Text += user.answer(textBox_In.Text) + Environment.NewLine + Environment.NewLine;
                // сохранение сообщения
                user.SaveToHist(textBox_In.Text + "(" + user.username_get() + ", " + DateTime.Now.ToString("T") + ")\n" + user.answer(textBox_In.Text));
            
            }
            // очистка поля ввода
            textBox_In.Text = "";
        }


        // горячая клавиша для отправки сообщения(enter)
        private void Chat2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_send.PerformClick();
                // чтобы при нажатии на enter курсор в поле ввода оставался на первой строчке
                e.SuppressKeyPress = true;
            }
        }



        // сохранение данных при закрытии формы
        private void Chat2_Closing(object sender, FormClosingEventArgs e)
        {
            string path = @"File";
            // Символ @ перед строкой означает то, что escape-последовательности не обрабатываются.

            //user.SaveToHist(textBox_out.Text);                  
            user.SaveToFile(path, user.hist);//получает историю чата
                                             

            // закрытие первой невидимой формы(чтобы закрывалась и вся программа)
            Program.form_user.Close();
        }


        // выводит на экран историю чат бота из файла
        private void Chat2_Load(object sender, EventArgs e)
        {
            // название файла
            string path = "File";
            // проверка на существование файла
            user.LoadHistory(path);

            for (int i = 0; i < user.hist.Count(); i++)
            {
                //writer.WriteLine(hist[i]);
                textBox_out.Text += user.hist[i];
                textBox_out.Text += Environment.NewLine;
                textBox_out.Text += Environment.NewLine;
            }

            File.Delete(path);
        }


        // очистка чат бота
        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_out.Text = "";
        }
    }
}
