using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliService1;
using System.ServiceModel.Description;

namespace WinFormHost
{
    public partial class Form1 : Form
    {
        ServiceHost host = null;
        Uri baseAddress = new Uri("http://localhost:32541/hello");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (host == null)
                {
                    host = new ServiceHost(typeof(Service1), baseAddress);

                    // Enable metadata publishing.
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    host.Description.Behaviors.Add(smb);
                }

                host.Open();

                textBox1.Text = host.State.ToString();
                label2.Text = typeof(Service1).ToString();
            }
            catch (Exception er)
            {
                textBox1.Text = er.Message;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            try
            {
                host.Close();
                
                textBox1.Text = host.State.ToString();
                host = null;
            }
            catch (Exception er)
            {
                textBox1.Text = er.Message;
            }
        }
    }
}
