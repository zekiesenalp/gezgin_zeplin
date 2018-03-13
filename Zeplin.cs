/*
 Ahmet Manga - 160202008
 Zeki Esenalp - 160202033
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GezginZeplin
{
    class Zeplin
    {
        private int baslangicID, bitisID;
        public static double maliyet = 10, sabitUcret = 100;
        public static double derece = 0;
        public static double sabitYukseklik = 50;
        public static double lat_baslangic, lng_baslangic, lat_bitis, lng_bitis, rakim_baslangic, rakim_bitis;
        public double toplamKm;
        public int baslangicid { get { return baslangicID; } set
            {
                if (value > 81)
                {
                    baslangicID = 34;
                } else
                {
                    baslangicID = value;
                }
            } }
        public int bitisid
        {
            get { return bitisID;  }
            set
            {
                if(value > 81)
                {
                    bitisID = 34;
                }
                else
                {
                    bitisID = value;
                }
            }
        }
        private int yolcuSayisi;
        public int yolcusayisi
        {
            get
            {
                return yolcuSayisi;
            }
            set
            {
                if(value > 50)
                {
                    yolcuSayisi = 50;
                }else if(value < 5)
                {
                    yolcuSayisi = 5;
                }
                else
                {
                    yolcuSayisi = value;
                }

            }
        }
      
        public Zeplin(int baslangic, int bitis, int yolcuSayisiFonksiyon)
        {
            baslangicid = baslangic; bitisid = bitis; yolcusayisi = yolcuSayisiFonksiyon;
            dereceHesapla();
        }
        
        public void dereceHesapla()
        {
            derece = 80 - yolcuSayisi;
        }
        
        public static void latlongCek(int bas, int bitis) {
            string[] veri = Form1.veriCek(bas);
            lat_baslangic = Convert.ToDouble(veri[0].Replace('.',',')); lng_baslangic = Convert.ToDouble(veri[1].Replace('.', ',')); rakim_baslangic = Convert.ToDouble(veri[3].Replace('.', ','));
            veri = Form1.veriCek(bitis);
            lat_bitis = Convert.ToDouble(veri[0].Replace('.', ',')); lng_bitis = Convert.ToDouble(veri[1].Replace('.', ',')); rakim_bitis = Convert.ToDouble(veri[3].Replace('.', ','));
        }

        static int Rm = 3961;
        static int Rk = 6371;
        public static double findDistance(double firstLat, double firstLng, double secondLat, double secondLng)
        {
            double lat1, lon1, lat2, lon2, dlat, dlon, a, c, dm, dk, mi, km;

            lat1 = firstLat * Math.PI / 180;
            lon1 = firstLng * Math.PI / 180;
            lat2 = secondLat * Math.PI / 180;
            lon2 = secondLng * Math.PI / 180;

            dlat = lat2 - lat1;
            dlon = lon2 - lon1;
            a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2);
            c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            dm = c * Rm; // mil cinsinden
            dk = c * Rk; // kilometre cinsinden

            mi = Math.Round(dm, 3);
            km = Math.Round(dk, 3);

            return km;
        }
         
        public double karHesapla()
        {
            double toplamPara = (toplamKm * maliyet) + (toplamKm * maliyet) / 2.0;
            return toplamPara / yolcusayisi;
        }

        public double dereceHesaplanan(int baslangic, int bitis)
        {
            latlongCek(baslangic, bitis);
            double km = findDistance(lat_baslangic, lng_baslangic, lat_bitis, lng_bitis);
            double yukseklik = 0;
            if(baslangic == baslangicid && bitis != bitisid)
            {
                yukseklik = rakim_baslangic - (rakim_bitis + sabitYukseklik);
            }else if (bitis == bitisid && baslangic != baslangicid) {
                yukseklik = (rakim_baslangic + 50) - rakim_bitis;
            }else
            {
                yukseklik = rakim_baslangic - rakim_bitis;
            }
            double hesapla = Math.Atan(yukseklik / km);
            return Math.Abs(hesapla * (180 / Math.PI));
        }
        public bool giderMi(int bas, int bitis)
        {
            if (derece >= dereceHesaplanan(bas,bitis) ) return true; else return false;
        }

        public static double MesafeHesapla(int bas, int bitis)
        {
            latlongCek(bas, bitis);
            return findDistance(lat_baslangic, lng_baslangic, lat_bitis, lng_bitis);
        }

        public double sabitUcretKar()
        {
            return (yolcuSayisi * sabitUcret) - (toplamKm * maliyet);
        }

    }
}
