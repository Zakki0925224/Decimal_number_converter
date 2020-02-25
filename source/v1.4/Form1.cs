using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Decimal_number_converter
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //変換処理
        private void Numconv(int way)
        {
            try
            {
                long num = long.Parse(textBox1.Text);
                label3.Text = Convert.ToString(num, way);
            }
            catch (ArithmeticException)
            {
                MessageBox.Show("エラーが発生しました。入力されたものが適切な数値か確認してください。");
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //テキストボックスが空ならば警告を表示する
            if (textBox1.Text == "")
            {
                MessageBox.Show("10進数が入力されていません。");
            }
            else
            {
                if (checkBox1.Checked)
                {
                    Numconv(2);
                }
                else if (checkBox2.Checked)
                {
                    Numconv(16);
                }
                else if (checkBox3.Checked)
                {
                    Numconv(8);
                }
                //チェックボックスがどれもチェックされていなければ警告を表示する
                else if (checkBox1.Checked == false && checkBox2.Checked == false　&& checkBox3.Checked == false)
                {
                    MessageBox.Show("変換先を指定してください。");
                }
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label3.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0~9とbackspace以外の入力を無効化する
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && (e.KeyChar != '\b') && (e.KeyChar != '-'))
            {
                e.Handled = true; 

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //乱数生成
            Random r = new Random();
            long i = r.Next(int.MinValue, int.MaxValue);
            textBox1.Text = Convert.ToString(i);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "";

            //
            if(Properties.Settings.Default.topmost == true)
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                //最前面に固定
                this.TopMost = true;
                Properties.Settings.Default.topmost = true;
            }
            else
            {
                //固定解除
                this.TopMost = false;
                Properties.Settings.Default.topmost = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //終了時に設定を保存
            Properties.Settings.Default.Save();
        }
    }
}
