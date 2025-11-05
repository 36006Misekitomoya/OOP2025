using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise01_WinForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = openFileDialog.FileName;
                string fileContent = await ReadFileAsync(filePath);
                DisplayFileContent(fileContent);
            }
        }

        private async Task<string> ReadFileAsync(string filePath) {
            try {
                using (StreamReader reader = new StreamReader(filePath)) {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void DisplayFileContent(string fileContent) {
            this.Controls.Clear();
            TextBox fileContentTextBox = new TextBox();
            fileContentTextBox.Multiline = true;
            fileContentTextBox.Dock = DockStyle.Fill;
            fileContentTextBox.ScrollBars = ScrollBars.Both;
            fileContentTextBox.Font = new System.Drawing.Font("Arial", 12);
            fileContentTextBox.Text = fileContent;
            this.Controls.Add(fileContentTextBox);
        }

        private void button2_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;
        }
    }
}
