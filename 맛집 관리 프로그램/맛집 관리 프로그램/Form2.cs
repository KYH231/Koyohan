using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 맛집_관리_프로그램
{
    public partial class Form2 : Form
    {
        private Form1 _Form1;
        public Form2(Form1 form1)
        {
            _Form1 = form1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bt_OK();
        }
        private void bt_OK()
        {
            if (tb1.Text.Equals("wp2") && textBox2.Text.Equals("1234"))
            {
                _Form1.LoginCheck = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("아이디 또는 패스워드가 잘못 입력되었습니다.");

                tb1.Text = "아이디를 입력 해주세요.";
                textBox2.Text = "비밀번호를 입력 해주세요.";
                textBox2.PasswordChar = '\0';
                tb1.Focus();
            }
        }

        private void tb1_Click(object sender, EventArgs e)
        {
            ID_click();
        }
        private void ID_click()
        {
            if (tb1.Text == "아이디를 입력 해주세요.") tb1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "비밀번호를 입력 해주세요.")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '\0';
            }
        }

        private void tb1_Leave(object sender, EventArgs e)
        {
            if (tb1.Text == "") tb1.Text = "아이디를 입력 해주세요.";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "비밀번호를 입력 해주세요.";
                textBox2.PasswordChar = '\0';
            }
        }
    }
}
