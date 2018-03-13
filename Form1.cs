/*
 Ahmet Manga - 160202008
 Zeki Esenalp - 160202033
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
using HolyOne;
using System.Diagnostics;
namespace GezginZeplin
{
    public partial class Form1 : Form
    {
        StreamReader dosya;
        StreamWriter yaz;
        int baslangicID = 0, bitisID = 0, yolcuSayisi;
        List<int> gidilenYerler = new List<int>();
        //string[] veriler;
        Zeplin z;
        List<Sehir> sehir = new List<Sehir>();
        Thread th,th2;
        // grafik için kütüphane
        HolyOne.Turkey turkey = null;
        // sehir yazmak için
        Graphics g;
        Stopwatch sw = new Stopwatch();
        bool butonKontrol = true;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            button8.Enabled = false;
            turkey = new Turkey();
            nesneIslemleri();
        }

        public void nesneIslemleri()
        {
            for (int i = 0; i < 81; i++)
            {
                string[] veri = Form1.veriCek(i + 1);
                Sehir nesne = new Sehir(i + 1, double.Parse(veri[0]), double.Parse(veri[1]), double.Parse(veri[3]));
                sehir.Add(nesne);
            }

            for (int i = 0; i < 81; i++)
            {
                List<Sehir> komsular = new List<Sehir>();
                for (int j = 0; j < 81; j++) if (komsulukKontrol(sehir[i].plaka, sehir[j].plaka) && i != j) komsular.Add(sehir[j]);

                sehir[i].komsular = komsular;

                for (int k = 0; k < sehir[i].komsular.Count; k++) sehir[i].komsuMesafe.Add(Zeplin.MesafeHesapla(sehir[i].plaka, sehir[i].komsular[k].plaka));
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] sehir = (comboBox2.SelectedItem).ToString().Split(' ');
            bitisID = Convert.ToInt32(sehir[0]);                        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] sehir = (comboBox1.SelectedItem).ToString().Split(' ');
            baslangicID = Convert.ToInt32(sehir[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yolcuSayisiString = textBox1.Text;
            if(baslangicID == 0 || bitisID == 0) {
                MessageBox.Show("Başlangıç ve bitiş noktası seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(yolcuSayisiString))
            {
                MessageBox.Show("Yolcu Sayısı Girilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear(); textBox1.Focus();

            }else if (int.Parse(yolcuSayisiString) > 50 || int.Parse(yolcuSayisiString) < 5)
            {
                MessageBox.Show("Yolcu Sayısı Belirlenen Aralıkta Değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear(); textBox1.Focus(); 
            }else
            {
                for (int i = 0; i < 81; i++)
                {
                    List<Sehir> komsular = new List<Sehir>();
                    for (int j = 0; j < 81; j++) if (komsulukKontrol(sehir[i].plaka, sehir[j].plaka) && i != j) komsular.Add(sehir[j]);
                    sehir[i].komsular.Clear(); sehir[i].komsuMesafe.Clear();
                    sehir[i].komsular = komsular;

                    for (int k = 0; k < sehir[i].komsular.Count; k++) sehir[i].komsuMesafe.Add(Zeplin.MesafeHesapla(sehir[i].plaka, sehir[i].komsular[k].plaka));
                }
                
                yolcuSayisi = int.Parse(yolcuSayisiString);
                z = new Zeplin(baslangicID, bitisID, yolcuSayisi);
                th = new Thread(() => algoritma());
                sw.Start();  th.Start();  th.Join();  sw.Stop();
                label12.Text = "Başlangıç Noktası ve Bitiş Noktası için En Kısa Yol Hesaplanıyor";
                label13.Text = sw.ElapsedMilliseconds + " ms";
                label9.Text = Math.Round(z.karHesapla()) + " ₺";
                if(butonKontrol) button8.Enabled = true;
            }         
        }
       
        public bool durumKontrol()
        {
            for (int i = 0; i < 81; i++) if (sehir[i].agirlik == 0 && i != baslangicID)  return false;

            return true;
        }

        public void algoritma()
        {
            int konum = z.baslangicid - 1;
            Sehir min = new Sehir();
            int sayac = 0;
            while (durumKontrol() == false)
            {
                sayac++;
                if (sayac == 150) break;
                gidilenYerler.Add(konum + 1);
                Sehir k;
                try
                {
                    k = sehir[konum];
                }
                catch
                {
                    MessageBox.Show("Hata oluştu.Bazı yollar bulunamamış olabilir.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    butonKontrol = false;
                    break;
                }
                for (int i = 0; i < k.komsular.Count; i++)
                {
                    double yeniAgirlik = k.agirlik + Zeplin.MesafeHesapla(k.plaka, k.komsular[i].plaka);
                    if ((sehir[k.komsular[i].plaka - 1].agirlik > yeniAgirlik || sehir[k.komsular[i].plaka - 1].agirlik == 0) && z.giderMi(k.plaka, k.komsular[i].plaka)) {
                        if (k.komsular[i].plaka != z.baslangicid) sehir[k.komsular[i].plaka - 1].agirlik = yeniAgirlik;
                        sehir[k.komsular[i].plaka - 1].gitmeDurumu = true;
                    } 
                        
                }
                for (int i = 0; i < 81; i++)
                {
                    if (gidilenYerler.Contains(sehir[i].plaka) == false && sehir[i].gitmeDurumu == true)
                    {
                        min = sehir[i]; break;
                    }
                }
                for (int i = 0; i < 81; i++)
                {
                    if (min.plaka != sehir[i].plaka && sehir[i].agirlik <= min.agirlik && gidilenYerler.Contains(sehir[i].plaka) == false && sehir[i].gitmeDurumu == true)
                    {
                        min = sehir[i];
                    }
                }

                konum = min.plaka - 1;
                z.toplamKm = sehir[z.bitisid - 1].agirlik;
                label6.Text = (sehir[z.bitisid-1].gitmeDurumu) ? "Toplam Km: " + z.toplamKm.ToString() : "Bitiş Noktasına Ulaşılamadı";
            }
        }
        public bool mouseMoveCalisma = true;
        public void yolHaritasiGoster(int id)
        {
            pictureBox1.Refresh();
            int onceki = id;
            for (int i = 0; i < sehir[id].yolHaritasi.Count; i++)
            {
                mouseMoveCalisma = false;
                pictureBox1.Update();
                HolyOne.Turkey.City c = turkey.Cities[sehir[id].yolHaritasi[i]-1];
                HolyOne.Turkey.City c2 = turkey.Cities[onceki];
                if (i != 0)
                {
                    label5.Text += c2.CityName + " - " + c.CityName + " (" + Zeplin.MesafeHesapla(onceki + 1, sehir[id].yolHaritasi[i]) + ")\n";
                }
                onceki = sehir[id].yolHaritasi[i] - 1;
                g = pictureBox1.CreateGraphics();
         if(sehir[sehir[id].yolHaritasi[i]-1].gitmeDurumu) g.FillPolygon(Brushes.OrangeRed, c.CityCoords); else g.FillPolygon(Brushes.Turquoise, c.CityCoords);
            }
        } 
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMoveCalisma)
            {
                pictureBox1.Refresh();
                pictureBox1.Update();
                Point p = new Point(e.X, e.Y);
                Turkey.City c = turkey.getCityAtPoint(p);
                if (c == null) return;

                int index = turkey.Cities.FindIndex(
                  delegate (Turkey.City city)
                  {
                      return city.CityName.Equals(c.CityName, StringComparison.Ordinal);
                  });
                g = pictureBox1.CreateGraphics();
                g.DrawPolygon(Pens.Green, c.CityCoords);
                g.FillPolygon(Brushes.Green, c.CityCoords); string durum;
                if (sehir[index].gitmeDurumu) durum = " " + sehir[index].agirlik + " / Gidildi"; else durum = " 0 / Gidilemedi";
                label4.Text = c.CityName + durum; 
                label4.Left = e.X + pictureBox1.Left + 20;
                label4.Top = e.Y + pictureBox1.Top + 20;
            }

        }

        public void yolHaritasiCiz(int id)
        {
            int sehirbitisID = id+1;
            List<int> yol = new List<int>();
            yol.Add(sehir[id].plaka);
            for (int i = gidilenYerler.Count - 1; i > 0; i--)
            {
                int enkucuk = sehir[gidilenYerler[i]-1].komsular[0].plaka;
                if (komsulukKontrol(sehirbitisID, gidilenYerler[i]) == true && z.giderMi(sehirbitisID,gidilenYerler[i])) enkucuk = gidilenYerler[i];
                for (int j = i - 1; j > 0; j--)
                {
                    if (komsulukKontrol(sehirbitisID, gidilenYerler[j]) == true && (Zeplin.MesafeHesapla(gidilenYerler[j], z.bitisid) < Zeplin.MesafeHesapla(enkucuk, z.bitisid) || Zeplin.MesafeHesapla(gidilenYerler[j], z.baslangicid) < Zeplin.MesafeHesapla(enkucuk, z.baslangicid)) && z.giderMi(sehirbitisID,gidilenYerler[j])) enkucuk = gidilenYerler[j];
                }
                // 
                sehirbitisID = enkucuk;
                yol.Add(enkucuk);
                if (komsulukKontrol(enkucuk, baslangicID)) break;
              

            }
            yol.Add(z.baslangicid);
            yol.Reverse();
            if (yol.IndexOf(id + 1) != yol.Count - 1) yol.RemoveRange(yol.IndexOf(id+1) +1, (yol.Count- yol.IndexOf(id+1) - 1));
            for(int i = 0; i<yol.Count; i++)
            {
                for(int j = i+1; j< yol.Count; j++)
                {
                    if (yol[i] == yol[j]) yol.RemoveAt(j);
                }
            }

            for(int i = 0; i< yol.Count-1; i++)
            {
                if (komsulukKontrol(yol[i], z.bitisid))
                {
                    yol.RemoveRange(i+1, yol.Count - i - 2);
                }
            }
            sehir[id].yolHaritasi = yol;

            
        }

  

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoveCalisma = true;
        }

        public static string[] veriCek(int id)
        {
            StreamReader dosya2 = new StreamReader("latlong.txt");

            for (int j = 0; j < id; j++) dosya2.ReadLine();

            string[] veriler = dosya2.ReadLine().Split(',');
            dosya2.Close();
            return veriler;
        }

        public void butonIslemleri( int sayi)
        {
            sw.Start();
            sifirla();
            textBox1.Text = sayi.ToString();
            label4.Text = ""; label5.Text = "";
            z.yolcusayisi = sayi; z.dereceHesapla(); z.toplamKm = 0;
            th = new Thread(new ThreadStart(algoritma));
            th.Start(); th.Join(); sw.Stop();
            label13.Text = sw.ElapsedMilliseconds + " ms"; label12.Text = sayi + " Yolcu için ücret ve yol hesaplanıyor";
            label9.Text = Math.Round(z.karHesapla()) + " ₺";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] yolcuSayisi = { 5,10, 20, 30, 40, 50 };
            double[] karMiktarlari = new double[6];
            double[] agirliklar = new double[6];
            for(int i = 0; i < yolcuSayisi.Length; i++)
            {
                butonIslemleri(yolcuSayisi[i]);
                agirliklar[i] = sehir[z.bitisid - 1].agirlik;
                karMiktarlari[i] = z.karHesapla();
            }
            double eb = karMiktarlari[0];
            double ek_agirlik = agirliklar[0];
            for (int i = 1; i < karMiktarlari.Length; i++) if (karMiktarlari[i] > eb && ek_agirlik < agirliklar[i]) eb = karMiktarlari[i];

            butonIslemleri(yolcuSayisi[Array.IndexOf(karMiktarlari, eb)]);
            MessageBox.Show("En iyi sonuç şuanda gösteriliyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button8_Click(e, e);
            yaz = new StreamWriter("problem1.txt");
            yaz.WriteLine("Baslangic : " + z.baslangicid + " Bitis : " + z.bitisid + " Yolcu Sayisi : " + z.yolcusayisi);
            yaz.WriteLine("Toplam elde edilen kar (1 kişi) : " + eb + " Toplam km : " + z.toplamKm);
            yaz.WriteLine("mesafe / baslangic lat-long / bitis lat-long / baslangic - bitis");
            for(int i = 0; i< sehir[z.bitisid - 1].yolHaritasi.Count; i++)
            {
                if(i != sehir[z.bitisid - 1].yolHaritasi.Count - 1)
                {
                    yaz.WriteLine(Zeplin.MesafeHesapla(sehir[z.bitisid-1].yolHaritasi[i],sehir[z.bitisid-1].yolHaritasi[i+1]) + " / " + Zeplin.lat_baslangic + " - " + Zeplin.lng_baslangic + " / " + Zeplin.lat_bitis + " - " + Zeplin.lng_bitis + " / " + sehir[z.bitisid - 1].yolHaritasi[i] + " - " + sehir[z.bitisid - 1].yolHaritasi[i + 1]);
                }
            }
            yaz.Close();
        }
        Thread th3;
        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            th.Abort();
            sw.Start();
            label5.Text = "";
            th3 = new Thread(() => yolHaritasiCiz(z.bitisid - 1));
            th3.Priority = ThreadPriority.Highest;  th3.Start();
            th3.Join();
            th2 = new Thread(() => yolHaritasiGoster(z.bitisid - 1));
            th2.Start();
            sw.Stop();
            label13.Text = sw.ElapsedMilliseconds + " ms"; label12.Text = "Yol Haritası Gösteriliyor";
            button8.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            butonIslemleri(10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            butonIslemleri(20);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            butonIslemleri(30);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            butonIslemleri(40);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            butonIslemleri(50);
        }

        public void problemCoz()
        {
           
            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
            sw.Start();

            sifirla();
            z.yolcusayisi = 5; z.dereceHesapla(); z.toplamKm = 0;
            th = new Thread(() => algoritma());
            th.Priority = ThreadPriority.Highest; th.Start();
            th.Join();
            double enCokKar = z.sabitUcretKar();
            int yolcu = 5; double gidilenYol = z.toplamKm;
            th.Abort();
            for (int i = 5; i <= 50; i++)
            {
                sifirla();
                z.yolcusayisi = i; z.dereceHesapla(); z.toplamKm = 0;
                Thread yeni_thread = new Thread(() => algoritma());
                yeni_thread.Start();
                yeni_thread.Join();
                if (z.sabitUcretKar() > enCokKar && sehir[z.bitisid - 1].gitmeDurumu == true)
                {
                    enCokKar = z.sabitUcretKar();
                    yolcu = i;
                    gidilenYol = z.toplamKm;
                }
                yeni_thread.Abort();
            }
            butonIslemleri(yolcu);
            string yazi = "Cevap: " + yolcu + " / 1 Kişi: " + Zeplin.sabitUcret + "₺ \n Elde Edilen Kar: " + enCokKar + " ₺ \n Toplam Km: " + gidilenYol;
            label11.Text = yazi;

            button8_Click(e, e);
            yaz = new StreamWriter("problem2.txt");
            yaz.WriteLine("Baslangic : " + z.baslangicid + " Bitis : " + z.bitisid + " Yolcu Sayisi : " + z.yolcusayisi);
            yaz.WriteLine(yazi);
            yaz.WriteLine("mesafe / baslangic lat-long / bitis lat-long / baslangic - bitis");
            for (int i = 0; i < sehir[z.bitisid - 1].yolHaritasi.Count; i++)
            {
                if (i != sehir[z.bitisid - 1].yolHaritasi.Count - 1)
                {
                    yaz.WriteLine(Zeplin.MesafeHesapla(sehir[z.bitisid - 1].yolHaritasi[i], sehir[z.bitisid - 1].yolHaritasi[i + 1]) + " / " + Zeplin.lat_baslangic + " - " + Zeplin.lng_baslangic + " / " + Zeplin.lat_bitis + " - " + Zeplin.lng_bitis + " / " + sehir[z.bitisid - 1].yolHaritasi[i] + " - " + sehir[z.bitisid - 1].yolHaritasi[i + 1]);
                }
            }
            yaz.Close();

            sw.Stop();
            label13.Text = sw.ElapsedMilliseconds + " ms"; label12.Text = "En çok kar için gereken yolcu sayısı hesaplanıyor";
            button10.Enabled = true;        
        }
      

        private void button9_Click(object sender, EventArgs e)
        {
            th.Abort(); //th2.Abort(); th3.Abort();
            Application.Restart();
        }

        public bool komsulukKontrol(int id, int aranan)
        {
            dosya = new StreamReader("komsular.txt");
            for (int i = 0; i < id - 1; i++) dosya.ReadLine();
                string[] sehirler = dosya.ReadLine().Split(':');

                string[] sehirIDString = sehirler[1].Split(',');
                int[] sehirID = Array.ConvertAll(sehirIDString, int.Parse);
                bool durum = sehirID.Contains(aranan);
            dosya.Close();
                return durum;
          
        }

        public void sifirla()
        {
            th.Abort(); //th2.Abort(); th3.Abort();
            for (int i = 0; i<81; i++)
            {
                sehir[i].agirlik = 0;
                sehir[i].komsuMesafe.Clear();
                sehir[i].yolHaritasi.Clear();
                sehir[i].gitmeDurumu = false;
            }
            gidilenYerler.Clear();
        }
    }
}
