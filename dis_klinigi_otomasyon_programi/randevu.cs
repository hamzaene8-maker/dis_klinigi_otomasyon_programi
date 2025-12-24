using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dis_klinigi_otomasyon_programi
{
    public partial class randevu : Form
    {
        private int seciliRandevuId = -1;

        public randevu()
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
            comboBox3.Location = new Point(130, 175);
            comboBox3.Size = new Size(150, 27);
            label3.Location = new Point(30, 215);
            comboBox4.Location = new Point(130, 215);
            comboBox4.Size = new Size(150, 27);
            label4.Location = new Point(30, 255);
            comboBox2.Location = new Point(130, 255);
            comboBox2.Size = new Size(150, 27);
            label6.Location = new Point(30, 295);
            comboBox5.Location = new Point(130, 295);
            comboBox5.Size = new Size(150, 27);

            // İşlem butonları (kaydet, düzenle, sil)
            radioButton1.Location = new Point(30, 350);
            radioButton4.Location = new Point(130, 350);
            radioButton3.Location = new Point(240, 350);

            // Sağ taraftaki elemanlar
            textBox7.Location = new Point(450, 115);
            textBox7.Font = new Font("Segoe UI", 11F);
            textBox7.Size = new Size(120, 27);
            radioButton2.Location = new Point(580, 115);
            radioButton5.Location = new Point(650, 115);

            // DataGridView
            dataGridView1.Location = new Point(330, 160);
            dataGridView1.Size = new Size(500, 250);

            // Hasta combobox doldur
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(VeriDeposu.Hastalar);

            // Tarih combobox doldur
            comboBox2.Items.Clear();
            for (int i = 0; i < 30; i++)
            {
                comboBox2.Items.Add(DateTime.Now.AddDays(i).ToString("dd.MM.yyyy"));
            }

            // Tedavi combobox doldur (veritabanından)
            comboBox5.Items.Clear();
            foreach (var t in VeriDeposu.Tedaviler)
            {
                comboBox5.Items.Add(t.TedaviAdi);
            }

            // DataGridView ayarları
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 50 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "AdSoyad", HeaderText = "Ad Soyad", DataPropertyName = "AdSoyad", Width = 120 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tarih", HeaderText = "Tarih", DataPropertyName = "Tarih", Width = 90 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Saat", HeaderText = "Saat", DataPropertyName = "Saat", Width = 100 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tedavi", HeaderText = "Tedavi", DataPropertyName = "Tedavi", Width = 100 });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // Event'leri bağla
            radioButton1.Click += btnKaydet_Click;
            radioButton4.Click += btnDuzenle_Click;
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
            // Tedaviler butonu
            Button btnTedaviler = new Button();
            btnTedaviler.Text = "Tedaviler";
            btnTedaviler.Location = new Point(540, 475);
            btnTedaviler.Size = new Size(95, 35);
            btnTedaviler.BackColor = Color.DarkTurquoise;
            btnTedaviler.ForeColor = Color.White;
            btnTedaviler.FlatStyle = FlatStyle.Flat;
            btnTedaviler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTedaviler.Click += (s, e) => {
                tedavi tedaviForm = new tedavi();
                tedaviForm.Show();
                this.Hide();
            };
            this.Controls.Add(btnTedaviler);

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
            dataGridView1.DataSource = VeriDeposu.Randevular.ToList();
            FormuTemizle();
        }

        private void GridFiltrele(string aramaMetni)
        {
            var filtrelenmis = VeriDeposu.Randevular
                .Where(r => r.AdSoyad.ToLower().Contains(aramaMetni.ToLower()))
                .ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrelenmis;
        }

        private void FormuTemizle()
        {
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            seciliRandevuId = -1;
        }

        private void btnKaydet_Click(object? sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen hasta seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen saat seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tarih seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tedavi türü seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string secilenTarih = comboBox2.SelectedItem!.ToString()!;
            string secilenSaat = comboBox4.SelectedItem!.ToString()!;

            bool cakismaVar = VeriDeposu.Randevular.Any(r => r.Tarih == secilenTarih && r.Saat == secilenSaat);
            if (cakismaVar)
            {
                MessageBox.Show("Bu tarih ve saatte başka bir randevu mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeniRandevu = new RandevuBilgisi
            {
                Id = ++VeriDeposu.SonRandevuId,
                AdSoyad = comboBox3.SelectedItem!.ToString()!,
                Saat = secilenSaat,
                Tarih = secilenTarih,
                Tedavi = comboBox5.SelectedItem!.ToString()!
            };

            VeriDeposu.Randevular.Add(yeniRandevu);
            MessageBox.Show("Randevu başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GridYenile();
        }

        private void btnDuzenle_Click(object? sender, EventArgs e)
        {
            if (seciliRandevuId == -1)
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz randevuyu seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1 || comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string secilenTarih = comboBox2.SelectedItem!.ToString()!;
            string secilenSaat = comboBox4.SelectedItem!.ToString()!;

            bool cakismaVar = VeriDeposu.Randevular.Any(r => r.Tarih == secilenTarih && r.Saat == secilenSaat && r.Id != seciliRandevuId);
            if (cakismaVar)
            {
                MessageBox.Show("Bu tarih ve saatte başka bir randevu mevcut!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mevcutRandevu = VeriDeposu.Randevular.FirstOrDefault(r => r.Id == seciliRandevuId);
            if (mevcutRandevu != null)
            {
                mevcutRandevu.AdSoyad = comboBox3.SelectedItem!.ToString()!;
                mevcutRandevu.Saat = secilenSaat;
                mevcutRandevu.Tarih = secilenTarih;
                mevcutRandevu.Tedavi = comboBox5.SelectedItem!.ToString()!;

                MessageBox.Show("Randevu başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridYenile();
            }
        }

        private void btnSil_Click(object? sender, EventArgs e)
        {
            if (seciliRandevuId == -1)
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuyu seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sonuc = MessageBox.Show("Bu randevuyu silmek istediğinizden emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var silinecek = VeriDeposu.Randevular.FirstOrDefault(r => r.Id == seciliRandevuId);
                if (silinecek != null)
                {
                    VeriDeposu.Randevular.Remove(silinecek);
                    MessageBox.Show("Randevu başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridYenile();
                }
            }
        }

        private void btnAra_Click(object? sender, EventArgs e)
        {
            string aramaMetni = textBox7.Text.Trim();
            if (string.IsNullOrEmpty(aramaMetni))
            {
                MessageBox.Show("Lütfen arama yapmak için bir isim giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                seciliRandevuId = Convert.ToInt32(seciliSatir.Cells["Id"].Value);

                string adSoyad = seciliSatir.Cells["AdSoyad"].Value?.ToString() ?? "";
                string saat = seciliSatir.Cells["Saat"].Value?.ToString() ?? "";
                string tarih = seciliSatir.Cells["Tarih"].Value?.ToString() ?? "";
                string tedaviAdi = seciliSatir.Cells["Tedavi"].Value?.ToString() ?? "";

                comboBox3.SelectedItem = adSoyad;
                comboBox4.SelectedItem = saat;
                comboBox2.SelectedItem = tarih;
                comboBox5.SelectedItem = tedaviAdi;
            }
        }
    }
}
