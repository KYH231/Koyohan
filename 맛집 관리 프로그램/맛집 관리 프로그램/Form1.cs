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

    }
}
