using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLR.CFM.DCP.Import
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CimProject p = new CimProject();

            for (int i = 1; i < 11; i++)
            {
                Sequence s = new Sequence("Stn " + i.ToString("00"));
                p.Add(s);
            }

            for (int i = 1; i < 11; i++)
            {
                Robot r = new Robot("Rbt " + i.ToString("00"));
                p.Add(r);
            }

            for (int i = 1; i < 11; i++)
            {
                TrimStation t = new TrimStation("And " + i.ToString("00"));
                p.Add(t);
            }


            foreach (Sequence s in p.Sequnces())
                treeView1.Nodes.Add(s.ID);

            foreach (Robot r in p.Robots())
                treeView1.Nodes.Add(r.ID);

            foreach (TrimStation t in p.TrimStations())
                treeView1.Nodes.Add(t.ID);

            foreach (Station x in p.Stations())
                treeView1.Nodes.Add(x.ID);

            Sequence s1 = p.Sequnces("Stn 01");
            treeView1.Nodes.Add(s1.ID);




        }
    }
}
