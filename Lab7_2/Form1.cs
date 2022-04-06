using System.Diagnostics;
using windows_manager;

namespace Lab7_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (var proc in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    listBox1.Items.Add(proc.MainWindowTitle);
                    listBox2.Items.Add(proc.Id);
                    listBox3.Items.Add(Math.Round(proc.VirtualMemorySize64 / Math.Pow(2, 20), 3));
                    listBox4.Items.Add(Math.Round(proc.WorkingSet / Math.Pow(2, 20), 3));
                    comboBox1.Items.Add(proc.MainWindowTitle);
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRename.Visible = true;
            textBox1.Visible = true;
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            Process[] taskProcesses = Process.GetProcesses();
            foreach (Process proc in taskProcesses)
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    if (comboBox1.SelectedItem.ToString() == proc.MainWindowTitle)
                    {
                        Manager.SetWindowText(proc.MainWindowHandle, textBox1.Text);
                        MessageBox.Show("Переименовано");
                        comboBox1.Text = null;
                        textBox1.Text = null;
                        Refresh();
                        break;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            btnRename.Visible = false;
            textBox1.Visible = false;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            comboBox1.Items.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            textBox1.Text = null;
            foreach (var proc in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    listBox1.Items.Add(proc.MainWindowTitle);
                    listBox2.Items.Add(proc.Id);
                    listBox3.Items.Add(Math.Round(proc.VirtualMemorySize64 / Math.Pow(2, 20), 3));
                    listBox4.Items.Add(Math.Round(proc.WorkingSet / Math.Pow(2, 20), 3));
                    comboBox1.Items.Add(proc.MainWindowTitle);
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcesses();

            Manager.Minimize_Maximize(proc[comboBox1.SelectedIndex]);




            //foreach (var proc in Process.GetProcesses())
            //{
            //    if (!string.IsNullOrEmpty(proc.MainWindowTitle))
            //    {
            //        if (ComboBox1.SelectedItem.ToString() == proc.MainWindowTitle)
            //        {
            //            if (!Manager.IsIconic(proc.Handle))
            //            {
            //                Manager.ShowWindow(proc.Handle, (int)Manager.ShowWindowEnum.ShowNormal);
            //            }
            //            else if (Manager.IsIconic(proc.Handle))
            //            {
            //                Manager.ShowWindow(proc.Handle, (int)Manager.ShowWindowEnum.Hide);
            //            }
            //            break;
            //        }
            //    }
            //}
        }
    }
}