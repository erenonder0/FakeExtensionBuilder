namespace FakeExtensionBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Bir dosya seçin";
            openFileDialog1.Filter = "Tüm Dosyalar|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;
                textBox1.Text = selectedFile;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string originalPath = textBox1.Text;
            string unicode = "\u2800";

            if (string.IsNullOrWhiteSpace(originalPath))
            {
                MessageBox.Show("Lütfen dosya seçin!");
                return;
            }

            string inputName = Microsoft.VisualBasic.Interaction.InputBox("Yeni dosya adını girin:", "Dosya Adı", "yeni_isim");

            if (string.IsNullOrWhiteSpace(inputName))
            {
                MessageBox.Show("Dosya adı girilmedi.");
                return;
            }

            string directory = Path.GetDirectoryName(originalPath);
            string fileName = inputName;
            string extension = Path.GetExtension(originalPath);

            int baseNameLength = fileName.Length + extension.Length;
            int baseFullPathLength = Path.Combine(directory, fileName + extension).Length;

            int maxTotalPathLength = 250;
            int remainingLength = maxTotalPathLength - baseFullPathLength;

            if (remainingLength < 0)
            {
                MessageBox.Show("Klasör yolu çok uzun, unicode karakter eklenemez.");
                return;
            }

            string ekle = string.Concat(Enumerable.Repeat(unicode, remainingLength));
            string newFileName = fileName + ekle + extension;
            string newPath = Path.Combine(directory, newFileName);

            try
            {
                if (File.Exists(newPath))
                {
                    MessageBox.Show("Aynı isimde bir dosya zaten var.");
                    return;
                }

                File.Copy(originalPath, newPath);
                MessageBox.Show("Dosya yeniden adlandırıldı:\n" + newFileName);
                textBox1.Clear();
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Giriş/Çıkış hatası:\n" + ioEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata:\n" + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://linktr.ee/eren.onder",
                UseShellExecute = true
            });
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/erenonder0/",
                UseShellExecute = true
            });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://erenonder0.github.io/",
                UseShellExecute = true
            });
        }
    }
}
