using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 맛집_관리_프로그램
{
    public partial class Form1 : Form
    {
        private List<ListViewItem> allItems = new List<ListViewItem>();

        private Boolean m_blLoginCheck = false;
        public Form1()
        {
            InitializeComponent();
        }

        public Boolean LoginCheck
        {
            get { return m_blLoginCheck; }
            set { m_blLoginCheck = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                // 가게 이름, 전화번호, 주소, 음식 종류, 메모 텍스트 박스 정보를 받음.
                ListViewItem item = new ListViewItem(textBox1.Text);
                item.SubItems.Add(textBox2.Text);
                item.SubItems.Add(textBox3.Text);
                item.SubItems.Add(textBox4.Text);
                item.SubItems.Add(textBox5.Text);

                // 가게 이름, 전화번호, 주소, 음식 종류, 메모를 리스트뷰에 추가.
                listView1.Items.Add(item);

                // 백업 리스트에도 정보 저장 /     -   -   -   -   -   -   -   -   -   -   -   -   (11.15) 음식 종류 - 오금빈
                allItems.Add((ListViewItem)item.Clone());


                // 가게 이름, 전화번호, 주소, 음식 종류 텍스트박스 초기화.
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            // 가게 이름, 전화번호, 주소, 음식 종류중 미입력 정보가 있으면 메세지박스 띄움.
            // 메세지박스 확인후 키보드 포커스 설정
            else if (textBox1.Text == "")
            {
                if (MessageBox.Show("가게 이름을 입력해 주세요.", "error") == DialogResult.OK)
                    textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                if (MessageBox.Show("전화번호를 입력해 주세요.", "error") == DialogResult.OK)
                    textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                if (MessageBox.Show("주소를 입력해 주세요.", "error") == DialogResult.OK)
                    textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                if (MessageBox.Show("음식 종류를 입력해 주세요.", "error") == DialogResult.OK)
                    textBox4.Focus();
            }
        }
    }
}
