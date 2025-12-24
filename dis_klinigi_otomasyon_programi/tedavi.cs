using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dis_klinigi_otomasyon_programi
{
    public partial class tedavi : Form
    {
        private int seciliTedaviId = -1;

        public tedavi()
        {
            InitializeComponent();
            FormYukle();
        }

        private void FormYukle()
        {
            // Form boyutunu ayarla
            this.ClientSize = new Size(850, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Sol taraftaki elemanların konumlarını düzelt
            label5.Location = new Point(120, 115);
            label2.Location = new Point(30, 175);
            textBox6.Location = new Point(130, 175);
            textBox6.Font = new Font("Segoe UI", 11F);
            textBox6.Size = new Size(150, 27);
            label3.Location = new Point(30, 215);
            textBox1.Location = new Point(130, 215);
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.Size = new Size(150, 27);
            label4.Location = new Point(30, 255);
            textBox2.Location = new Point(130, 255);
            textBox2.Font = new Font("Segoe UI", 11F);
            textBox2.Size = new Size(150, 27);

            // İşlem butonları (kaydet, güncelle, sil)
            radioButton1.Location = new Point(30, 310);
            radioButton4.Location = new Point(130, 310);
            radioButton3.Location = new Point(240, 310);

            // Sağ taraftaki elemanlar
            textBox7.Location = new Point(450, 115);
            textBox7.Font = new Font("Segoe UI", 11F);
            textBox7.Size = new Size(120, 27);
            radioButton2.Location = new Point(580, 115);
            radioButton5.Location = new Point(650, 115);

            // DataGridView
            dataGridView1.Location = new Point(330, 160);
            dataGridView1.Size = new Size(500, 250);

            // DataGridView ayarları
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 50 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "TedaviAdi", HeaderText = "Tedavi Adı", DataPropertyName = "TedaviAdi", Width = 130 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tutar", HeaderText = "Tutar", DataPropertyName = "Tutar", Width = 100 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Aciklama", HeaderText = "Açıklama", DataPropertyName = "Aciklama", Width = 180 });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // Event'leri bağla
            radioButton1.Click += btnKaydet_Click;
            radioButton4.Click += btnGuncelle_Click;
            radioButton3.Click += btnSil_Click;
            radioButton2.Click += btnAra_Click;
            radioButton5.Click += btnYenile_Click;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            // Navigasyon butonları ekle
            NavButonlariEkle();

            GridYenile();
        }

        private void NavButonlariEkle()
        {
            // Randevular butonu
            Button btnRandevular = new Button();
            btnRandevular.Text = "Randevular";
            btnRandevular.Location = new Point(540, 475);
            btnRandevular.Size = new Size(95, 35);
            btnRandevular.BackColor = Color.DarkTurquoise;
            btnRandevular.ForeColor = Color.White;
            btnRandevular.FlatStyle = FlatStyle.Flat;
            btnRandevular.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRandevular.Click += (s, e) => {
                randevu randevuForm = new randevu();
                randevuForm.Show();
                this.Hide();
            };
            this.Controls.Add(btnRandevular);

            // Reçeteler butonu
            Button btnReceteler = new Button();
            btnReceteler.Text = "Reçeteler";
            btnReceteler.Location = new Point(645, 475);
            btnReceteler.Size = new Size(95, 35);
            btnReceteler.BackColor = Color.DarkTurquoise;
            btnReceteler.ForeColor = Color.White;
            btnReceteler.FlatStyle = FlatStyle.Flat;
            btnReceteler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReceteler.Click += (s, e) => {
                reçeteler receteForm = new reçeteler();
                receteForm.Show();
                this.Hide();
            };
            this.Controls.Add(btnReceteler);

            // Çıkış butonu
            Button btnCikis = new Button();
            btnCikis.Text = "Çıkış";
            btnCikis.Location = new Point(750, 475);
            btnCikis.Size = new Size(85, 35);
            btnCikis.BackColor = Color.IndianRed;
            btnCikis.ForeColor = Color.White;
            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCikis.Click += (s, e) => {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            };
            this.Controls.Add(btnCikis);
        }

        private void GridYenile()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = VeriDeposu.Tedaviler.ToList();
            FormuTemizle();
        }

        private void GridFiltrele(string aramaMetni)
        {
            var filtrelenmis = VeriDeposu.Tedaviler
                .Where(t => t.TedaviAdi.ToLower().Contains(aramaMetni.ToLower()))
                .ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrelenmis;
        }

        private void FormuTemizle()
        {
            textBox6.Text = "";  // tedavi adı
            textBox1.Text = "";  // tutar
            textBox2.Text = "";  // açıklama
            seciliTedaviId = -1;
        }

        private void btnKaydet_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Lütfen tedavi adı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal tutar))
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aynı isimde tedavi var mı kontrol et
            if (VeriDeposu.Tedaviler.Any(t => t.TedaviAdi.ToLower() == textBox6.Text.Trim().ToLower()))
            {
                MessageBox.Show("Bu tedavi zaten mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeniTedavi = new TedaviBilgisi
            {
                Id = ++VeriDeposu.SonTedaviId,
                TedaviAdi = textBox6.Text.Trim(),
                Tutar = tutar,
                Aciklama = textBox2.Text.Trim()
            };

            VeriDeposu.Tedaviler.Add(yeniTedavi);
            MessageBox.Show("Tedavi başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GridYenile();
        }

        private void btnGuncelle_Click(object? sender, EventArgs e)
        {
            if (seciliTedaviId == -1)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz tedaviyi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Lütfen tedavi adı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal tutar))
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aynı isimde başka tedavi var mı kontrol et (kendi hariç)
            if (VeriDeposu.Tedaviler.Any(t => t.TedaviAdi.ToLower() == textBox6.Text.Trim().ToLower() && t.Id != seciliTedaviId))
            {
                MessageBox.Show("Bu tedavi adı zaten mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mevcutTedavi = VeriDeposu.Tedaviler.FirstOrDefault(t => t.Id == seciliTedaviId);
            if (mevcutTedavi != null)
            {
                mevcutTedavi.TedaviAdi = textBox6.Text.Trim();
                mevcutTedavi.Tutar = tutar;
                mevcutTedavi.Aciklama = textBox2.Text.Trim();

                MessageBox.Show("Tedavi başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridYenile();
            }
        }

        private void btnSil_Click(object? sender, EventArgs e)
        {
            if (seciliTedaviId == -1)
            {
                MessageBox.Show("Lütfen silmek istediğiniz tedaviyi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sonuc = MessageBox.Show("Bu tedaviyi silmek istediğinizden emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var silinecek = VeriDeposu.Tedaviler.FirstOrDefault(t => t.Id == seciliTedaviId);
                if (silinecek != null)
                {
                    VeriDeposu.Tedaviler.Remove(silinecek);
                    MessageBox.Show("Tedavi başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridYenile();
                }
            }
        }

        private void btnAra_Click(object? sender, EventArgs e)
        {
            string aramaMetni = textBox7.Text.Trim();
            if (string.IsNullOrEmpty(aramaMetni))
            {
                MessageBox.Show("Lütfen arama yapmak için bir tedavi adı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GridFiltrele(aramaMetni);
        }

        private void btnYenile_Click(object? sender, EventArgs e)
        {
            textBox7.Text = "";
            GridYenile();
        }

        private void dataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var seciliSatir = dataGridView1.SelectedRows[0];
                seciliTedaviId = Convert.ToInt32(seciliSatir.Cells["Id"].Value);

                textBox6.Text = seciliSatir.Cells["TedaviAdi"].Value?.ToString() ?? "";
                textBox1.Text = seciliSatir.Cells["Tutar"].Value?.ToString() ?? "";
                textBox2.Text = seciliSatir.Cells["Aciklama"].Value?.ToString() ?? "";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
