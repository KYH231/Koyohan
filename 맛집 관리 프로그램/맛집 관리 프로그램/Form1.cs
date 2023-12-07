using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해 주세요.");
                return;
            }

            ListViewItem selectedItem = listView1.SelectedItems[0];
            selectedItem.SubItems[0].Text = textBox1.Text;
            selectedItem.SubItems[1].Text = textBox2.Text;
            selectedItem.SubItems[2].Text = textBox3.Text;
            selectedItem.SubItems[3].Text = textBox4.Text;
            selectedItem.SubItems[4].Text = textBox5.Text;

            // 입력 필드를 지웁니다
            ClearTextBoxes();

            MessageBox.Show("정보가 변경되었습니다.");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                textBox1.Text = selectedItem.SubItems[0].Text;
                textBox2.Text = selectedItem.SubItems[1].Text;
                textBox3.Text = selectedItem.SubItems[2].Text;
                textBox4.Text = selectedItem.SubItems[3].Text;
                textBox5.Text = selectedItem.SubItems[4].Text;
            }
        }
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private Stack<ListViewItem> deletedStack = new Stack<ListViewItem>();

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 항목이 삭제됩니다.\r계속 하시겠습니다?", "항목 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int index = listView1.FocusedItem.Index;

                    ListViewItem deletedItem = listView1.Items[index].Clone() as ListViewItem;// 
                    deletedStack.Push(deletedItem); // 삭제한 항목 스텍에 푸쉬 // 수정자 - 박정호

                    listView1.Items.RemoveAt(index);

                    MessageBox.Show("삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("선택된 항목이 없습니다.");
                }
            }
        }
        private List<ListViewItem> deletedItems = new List<ListViewItem>();

        private void 검색_Click(object sender, EventArgs e)
        {
            string 이름 = textBox6.Text;

            foreach (ListViewItem 가게이름 in listView1.Items)
            {
                ListViewItem.ListViewSubItemCollection subItem = 가게이름.SubItems; // 리스트뷰 가게이름 가져오기

                if (subItem[0].Text == 이름)
                {
                    if (MessageBox.Show("가게이름\t전화번호\t주소\t종류\t메모\n" +
                        subItem[0].Text + "\t" + subItem[1].Text + "\t" + subItem[2].Text + "\t" + subItem[3].Text + "\t" + subItem[4].Text + "\n" +
                        "네이버에 검색하시겠습니까?",
                        subItem[0].Text + " 검색 결과", MessageBoxButtons.YesNo) == DialogResult.Yes) // 메세지박스 YES == 네이버에 해당 가게이름 검색
                    {
                        Process.Start("https://map.naver.com/p/search/" + subItem[0].Text);
                    }
                }
                else
                {
                    if (MessageBox.Show("검색 결과가 없습니다.", "오류") == DialogResult.OK)
                        textBox6.Focus();
                }
            }
            foreach (ListViewItem 가게이름 in listView1.Items)
            {

                if (!가게이름.Text.Contains(이름))
                {
                    listView1.Items.Remove(가게이름);
                    deletedItems.Add(가게이름);
                }
            }
        }

        private void 되돌리_Click(object sender, EventArgs e)
        {
            foreach (var item in deletedItems)
            {
                listView1.Items.Add(item); // 삭제된 항목을 다시 ListView에 추가
            }
            deletedItems.Clear(); // 삭제된 항목을 삭제합니다.
        }
    }
}
