using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CheatInjector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Directory.GetCurrentDirectory() + "\\MonoInvoke.dll";
            textBox3.Text = Directory.GetCurrentDirectory() + "\\UnityGameObject.dll";
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDiag = new OpenFileDialog();

            if (fileDiag.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileDiag.FileName;
            }
        }

        private void Inject_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.GetDirectoryName(Process.GetProcessesByName(textBox2.Text)[0].MainModule.FileName) + "\\dll.txt", textBox3.Text + '\n');
            DllInjectionResult result = DllInjector.GetInstance.Inject(textBox2.Text, textBox1.Text);

            MessageBox.Show("Result: " + result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDiag = new OpenFileDialog();

            if (fileDiag.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = fileDiag.FileName;
            }
        }
    }
}
