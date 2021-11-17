using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geo
{
    public partial class DopF : Form
    {
        public DopF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.ShowDialog();
            textBox1.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Us> uss = new List<Us>().GetList(textBox1.Text);
            List<List<Us>> LLUs = uss.GetListWhereDifference((double)numericUpDown1.Value);
            List<List<Us>> TopLLUs = LLUs.OrderByDescending(r => r.Count).Skip((int)numericUpDown3.Value).Take((int)numericUpDown2.Value).ToList();
            uss.Clear();
            LLUs.Write();
            TopLLUs.Write("top"+ numericUpDown2.Value+".txt");
            LLUs.Clear();
            GC.Collect();
        }
    }
}
