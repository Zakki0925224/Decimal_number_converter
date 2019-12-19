using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decimal_number_comverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                string rem1 = textBox1.Text;
                int num = int.Parse(rem1);
                if (checkBox1.Checked)
                {
                    string num2 = Convert.ToString(num, 2);
                    string lastnum = num2;
                    label3.Text = lastnum;
                }
                else if (checkBox2.Checked)
                {
                    string num16 = Convert.ToString(num, 16);
                    string lastnum = num16;
                    label3.Text = lastnum;
                }
                //チェックボックスがどちらもチェックされていなければ警告を表示する。
                else if (checkBox1.Checked == false && checkBox2.Checked == false)
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
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; //押されたキーが 0～9でない場合は、イベントをキャンセルする

            }
        }
    }
}
