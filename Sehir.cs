/*
 Ahmet Manga - 160202008
 Zeki Esenalp - 160202033
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GezginZeplin
{
    class Sehir
    {
        public int plaka;
        public double lat, lng, rakim,agirlik=0;
        public List<Sehir> komsular = new List<Sehir>();
        public List<double> komsuMesafe = new List<double>();
        public List<int> yolHaritasi = new List<int>();
        public bool gitmeDurumu = false;
        public Sehir(int p, double lt, double ln, double rk)
        {
            plaka = p; lat = lt; lng = ln; rakim = rk;
        }

        public Sehir()
        {
        }        

    }
}
