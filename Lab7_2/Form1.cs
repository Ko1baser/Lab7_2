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
                    comboBox1.Items.Add(proc.MainWindowTitle);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRename.Visible = false;
            textBox1.Visible = false;
        }
        

        public void RefreshWindows()
        {
            comboBox1.Items.Clear();
            textBox1.Text = null;
            foreach (var proc in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    comboBox1.Items.Add(proc.MainWindowTitle);
                }
            }
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Manager.ShowCloseWindow();
        }

        private void btnRename_Click_1(object sender, EventArgs e)
        {
            foreach (var proc in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    if (comboBox1.SelectedItem.ToString() == proc.MainWindowTitle)
                    {
                        Manager.SetWindowText(proc.MainWindowHandle, textBox1.Text);
                        MessageBox.Show("Переименовано");
                        RefreshWindows();
                        Manager.ShowCloseWindow1(proc);
                        comboBox1.Text = null;
                        textBox2.Text = null;
                        break;
                    }
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            RefreshWindows();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btnRename.Visible = true;
            textBox1.Visible = true;
            textBox2.Text = null;
            foreach (var proc in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                {
                    if (comboBox1.SelectedItem.ToString() == proc.MainWindowTitle)
                    {
                        textBox2.Text = Manager.GetProperties(proc);
                        break;
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}