using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dis_klinigi_otomasyon_programi
{
    public partial class reçeteler : Form
    {
        private int seciliReceteId = -1;

        public reçeteler()
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
            label6.Location = new Point(30, 175);
            comboBox3.Location = new Point(130, 175);
            comboBox3.Size = new Size(150, 27);
            label2.Location = new Point(30, 215);
            label3.Location = new Point(30, 255);
            textBox1.Location = new Point(130, 255);
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.Size = new Size(150, 27);
            label4.Location = new Point(30, 295);
            textBox2.Location = new Point(130, 295);
            textBox2.Font = new Font("Segoe UI", 11F);
            textBox2.Size = new Size(150, 27);

            // İşlem butonları (kaydet, sil, yazdır)
            radioButton1.Location = new Point(30, 350);
            radioButton3.Location = new Point(130, 350);
            radioButton4.Location = new Point(210, 350);
            radioButton4.BackColor = Color.Black;

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

            // Tedavi combobox ekle (textBox6 yerine)
            ComboBox cmbTedavi = new ComboBox();
            cmbTedavi.Name = "cmbTedavi";
            cmbTedavi.Location = new Point(130, 215);
            cmbTedavi.Size = new Size(150, 27);
            cmbTedavi.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (var t in VeriDeposu.Tedaviler)
            {
                cmbTedavi.Items.Add(t.TedaviAdi);
            }
            cmbTedavi.SelectedIndexChanged += (s, e) => {
                if (cmbTedavi.SelectedItem != null)
                {
                    var tedavi = VeriDeposu.Tedaviler.FirstOrDefault(t => t.TedaviAdi == cmbTedavi.SelectedItem.ToString());
                    if (tedavi != null)
                    {
                        textBox1.Text = tedavi.Tutar.ToString();
                    }
                }
            };
            this.Controls.Add(cmbTedavi);
            textBox6.Visible = false;

            // DataGridView ayarları
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 50 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "AdSoyad", HeaderText = "Ad Soyad", DataPropertyName = "AdSoyad", Width = 120 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "TedaviAdi", HeaderText = "Tedavi", DataPropertyName = "TedaviAdi", Width = 110 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tutar", HeaderText = "Tutar", DataPropertyName = "Tutar", Width = 100 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Miktar", HeaderText = "Miktar", DataPropertyName = "Miktar", Width = 80 });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            // Event'leri bağla
            radioButton1.Click += btnKaydet_Click;
            radioButton3.Click += btnSil_Click;
            radioButton2.Click += btnAra_Click;
            radioButton5.Click += btnYenile_Click;
            radioButton4.Click += btnYazdir_Click;
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

            // Tedaviler butonu
            Button btnTedaviler = new Button();
            btnTedaviler.Text = "Tedaviler";
            btnTedaviler.Location = new Point(645, 475);
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

        private ComboBox? GetTedaviComboBox()
        {
            return this.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Name == "cmbTedavi");
        }

        private void GridYenile()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = VeriDeposu.Receteler.ToList();
            FormuTemizle();
        }

        private void GridFiltrele(string aramaMetni)
        {
            var filtrelenmis = VeriDeposu.Receteler
                .Where(r => r.AdSoyad.ToLower().Contains(aramaMetni.ToLower()))
                .ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtrelenmis;
        }

        private void FormuTemizle()
        {
            comboBox3.SelectedIndex = -1;  // ad soyad
            var cmbTedavi = GetTedaviComboBox();
            if (cmbTedavi != null) cmbTedavi.SelectedIndex = -1;
            textBox1.Text = "";  // tutar
            textBox2.Text = "";  // miktar
            seciliReceteId = -1;
        }

        private void btnKaydet_Click(object? sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen hasta seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cmbTedavi = GetTedaviComboBox();
            if (cmbTedavi == null || cmbTedavi.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tedavi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal tutar))
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox2.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeniRecete = new ReceteBilgisi
            {
                Id = ++VeriDeposu.SonReceteId,
                AdSoyad = comboBox3.SelectedItem!.ToString()!,
                TedaviAdi = cmbTedavi.SelectedItem!.ToString()!,
                Tutar = tutar,
                Miktar = miktar
            };

            VeriDeposu.Receteler.Add(yeniRecete);
            MessageBox.Show("Reçete başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GridYenile();
        }

        private void btnSil_Click(object? sender, EventArgs e)
        {
            if (seciliReceteId == -1)
            {
                MessageBox.Show("Lütfen silmek istediğiniz reçeteyi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sonuc = MessageBox.Show("Bu reçeteyi silmek istediğinizden emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                var silinecek = VeriDeposu.Receteler.FirstOrDefault(r => r.Id == seciliReceteId);
                if (silinecek != null)
                {
                    VeriDeposu.Receteler.Remove(silinecek);
                    MessageBox.Show("Reçete başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnYazdir_Click(object? sender, EventArgs e)
        {
            if (seciliReceteId == -1)
            {
                MessageBox.Show("Lütfen yazdırmak istediğiniz reçeteyi seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var recete = VeriDeposu.Receteler.FirstOrDefault(r => r.Id == seciliReceteId);
            if (recete != null)
            {
                string receteMetni = $@"
╔════════════════════════════════════════╗
║        İSTANBUL DENTAL KLİNİK         ║
║              REÇETE                    ║
╠════════════════════════════════════════╣
║ Reçete No: {recete.Id}
║ Tarih: {DateTime.Now:dd.MM.yyyy}
║────────────────────────────────────────║
║ Hasta: {recete.AdSoyad}
║ Tedavi: {recete.TedaviAdi}
║ Miktar: {recete.Miktar}
║ Tutar: {recete.Tutar:N2} TL
╚════════════════════════════════════════╝
";
                MessageBox.Show(receteMetni, "Reçete Yazdır", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var seciliSatir = dataGridView1.SelectedRows[0];
                seciliReceteId = Convert.ToInt32(seciliSatir.Cells["Id"].Value);

                string adSoyad = seciliSatir.Cells["AdSoyad"].Value?.ToString() ?? "";
                string tedaviAdi = seciliSatir.Cells["TedaviAdi"].Value?.ToString() ?? "";
                string tutar = seciliSatir.Cells["Tutar"].Value?.ToString() ?? "";
                string miktar = seciliSatir.Cells["Miktar"].Value?.ToString() ?? "";

                comboBox3.SelectedItem = adSoyad;
                var cmbTedavi = GetTedaviComboBox();
                if (cmbTedavi != null) cmbTedavi.SelectedItem = tedaviAdi;
                textBox1.Text = tutar;
                textBox2.Text = miktar;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
