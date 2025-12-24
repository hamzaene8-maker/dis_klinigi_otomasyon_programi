namespace dis_klinigi_otomasyon_programi
{
    public partial class Form1 : Form
    {
        // Kullanıcı listesi (kullanıcı adı, şifre)
        private readonly Dictionary<string, string> kullanicilar = new Dictionary<string, string>
        {
            { "admin", "admin123" },
            { "doktor", "doktor123" },
            { "ilker", "1234" },
            { "asistan", "asistan123" },
            { "sekreter", "sekreter123" }
        };

        public Form1()
        {
            InitializeComponent();
            // Şifre alanını gizli yap
            textBox2.PasswordChar = '*';
            // RadioButton'a click event ekle
            radioButton1.Click += radioButton1_Click;
            // Şifremi Göster checkbox event
            checkBoxSifreGoster.CheckedChanged += checkBoxSifreGoster_CheckedChanged;
        }

        private void checkBoxSifreGoster_CheckedChanged(object? sender, EventArgs e)
        {
            if (checkBoxSifreGoster.Checked)
            {
                textBox2.PasswordChar = '\0'; // Şifreyi göster
            }
            else
            {
                textBox2.PasswordChar = '*'; // Şifreyi gizle
            }
        }

        private void radioButton1_Click(object? sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text.Trim();
            string sifre = textBox2.Text;

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcı doğrulama
            if (kullanicilar.TryGetValue(kullaniciAdi, out string? kayitliSifre) && kayitliSifre == sifre)
            {
                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Randevu formunu aç
                randevu randevuForm = new randevu();
                randevuForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
