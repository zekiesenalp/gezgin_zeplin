﻿/*
Copyright HolyOne
Aytek Üstündağ
http://www.tahribat.com
holyone@tahribat.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace HolyOne
{
    public class Turkey
    {
        public class City
        {
            public string CityName { get; set; }
            public System.Drawing.PointF[] CityCoords { get; set; }

            public City(string name, System.Drawing.PointF[] coords)
            {
                CityName = name;
                CityCoords = coords;
            }

            public City(string name, int[] coordpoints)
            {
                CityName = name;
                int i = 0;
                List<PointF> pp = new List<PointF>();
                while (i < coordpoints.Length)
                {
                    PointF p = new PointF(coordpoints[i++], coordpoints[i++]);
                    pp.Add(p);
                }
                CityCoords = pp.ToArray();

            }
        }

        public List<City> Cities = new List<City>();

        public Turkey()
        {

            Cities.Add(new City("Adana", new int[] { 490, 416, 509, 428, 543, 403, 547, 385, 538, 386, 548, 350, 559, 350, 566, 314, 555, 305, 522, 337, 522, 349, 504, 346, 484, 352, 480, 370, 492, 380, 500, 412 }));
            Cities.Add(new City("Adıyaman", new int[] { 667, 361, 643, 363, 623, 354, 633, 334, 662, 328, 671, 315, 698, 330, 709, 316, 719, 317, 710, 326, 693, 347 }));
            Cities.Add(new City("Afyonkarahisar", new int[] { 250, 242, 218, 286, 230, 304, 206, 326, 217, 334, 225, 335, 284, 289, 292, 297, 309, 279, 315, 253, 293, 240, 276, 247 }));
            Cities.Add(new City("Ağrı", new int[] { 919, 179, 872, 195, 886, 207, 882, 219, 900, 250, 912, 245, 917, 224, 934, 217, 949, 228, 954, 219, 984, 214, 986, 194, 932, 197 }));
            Cities.Add(new City("Amasya", new int[] { 498, 124, 497, 147, 520, 153, 515, 176, 536, 161, 558, 161, 564, 141, 556, 129, 546, 139, 517, 131, 508, 126 }));
            Cities.Add(new City("Ankara", new int[] { 367, 147, 356, 156, 316, 172, 293, 165, 291, 172, 278, 179, 281, 187, 321, 189, 333, 203, 327, 207, 338, 225, 338, 243, 328, 249, 334, 261, 361, 261, 386, 244, 424, 282, 430, 258, 410, 237, 400, 218, 407, 196, 424, 173, 405, 167, 401, 173, 386, 152 }));
            Cities.Add(new City("Antalya", new int[] { 180, 431, 214, 377, 235, 368, 263, 376, 285, 368, 314, 369, 353, 412, 358, 455, 328, 423, 255, 397, 240, 440, 201, 444 }));
            Cities.Add(new City("Artvin", new int[] { 814, 95, 826, 108, 813, 128, 822, 145, 839, 137, 845, 121, 865, 117, 880, 97, 863, 84, 842, 89, 828, 85 }));
            Cities.Add(new City("Aydın", new int[] { 148, 308, 79, 322, 67, 331, 74, 353, 86, 340, 147, 350, 160, 333, 159, 318 }));
            Cities.Add(new City("Balıkesir", new int[] { 105, 156, 99, 191, 60, 193, 57, 200, 73, 200, 54, 220, 60, 225, 81, 213, 121, 222, 133, 241, 159, 238, 157, 228, 178, 209, 143, 190, 139, 153 }));
            Cities.Add(new City("Bilecik", new int[] { 230, 156, 261, 167, 266, 177, 245, 197, 235, 195, 231, 207, 219, 203, 219, 174 }));
            Cities.Add(new City("Bingöl", new int[] { 753, 247, 772, 243, 773, 288, 817, 275, 824, 251, 812, 230, 777, 223 }));
            Cities.Add(new City("Bitlis", new int[] { 912, 250, 862, 267, 862, 279, 837, 283, 848, 305, 864, 309, 877, 306, 900, 325, 905, 322, 902, 284 }));
            Cities.Add(new City("Bolu", new int[] { 328, 123, 328, 129, 310, 134, 308, 146, 282, 146, 281, 155, 269, 154, 263, 167, 268, 177, 277, 178, 290, 171, 293, 163, 317, 171, 356, 155, 367, 145, 368, 137, 352, 123 }));
            Cities.Add(new City("Burdur", new int[] { 216, 337, 242, 334, 261, 348, 269, 367, 264, 374, 235, 365, 211, 375, 209, 388, 187, 386, 201, 354 }));
            Cities.Add(new City("Bursa", new int[] { 140, 152, 144, 189, 187, 209, 203, 190, 220, 193, 218, 174, 233, 149, 221, 144, 215, 148, 186, 149, 186, 157, 186, 157 }));
            Cities.Add(new City("Çanakkale", new int[] { 71, 123, 80, 124, 77, 136, 104, 154, 98, 189, 60, 191, 54, 201, 26, 203, 41, 147, 70, 134 }));
            Cities.Add(new City("Çankırı", new int[] { 430, 124, 393, 123, 370, 137, 368, 145, 389, 151, 401, 171, 405, 166, 437, 176, 447, 166, 439, 138, 427, 138 }));
            Cities.Add(new City("Çorum", new int[] { 467, 106, 455, 118, 458, 138, 442, 139, 450, 165, 440, 177, 453, 195, 499, 194, 502, 178, 513, 178, 517, 157, 495, 148, 495, 124, 485, 113 }));
            Cities.Add(new City("Denizli", new int[] { 157, 309, 166, 300, 203, 303, 216, 287, 227, 304, 204, 325, 214, 335, 197, 354, 184, 388, 172, 385, 148, 352, 159, 339, 164, 333 }));
            Cities.Add(new City("Diyarbakır", new int[] { 826, 287, 812, 341, 795, 339, 777, 354, 755, 355, 752, 332, 716, 326, 723, 315, 714, 311, 722, 305, 735, 310, 777, 293, 783, 286, 819, 279 }));
            Cities.Add(new City("Edirne", new int[] { 88, 38, 81, 94, 66, 101, 69, 128, 35, 126, 35, 120, 52, 106, 53, 85, 68, 80, 56, 51, 73, 39 }));
            Cities.Add(new City("Elazığ", new int[] { 688, 268, 673, 292, 733, 306, 771, 292, 769, 247, 749, 251, 745, 270 }));
            Cities.Add(new City("Erzincan", new int[] { 671, 198, 701, 190, 735, 203, 754, 188, 769, 189, 792, 221, 777, 221, 741, 216, 689, 236, 687, 260, 674, 251 }));
            Cities.Add(new City("Erzurum", new int[] { 773, 191, 798, 224, 831, 230, 846, 241, 862, 234, 884, 209, 870, 195, 887, 187, 859, 163, 883, 154, 881, 134, 866, 122, 846, 125, 841, 142, 822, 148, 809, 132, 780, 156, 779, 171, 793, 175, 780, 188 }));
            Cities.Add(new City("Eskişehir", new int[] { 275, 180, 263, 179, 247, 198, 237, 198, 234, 207, 244, 209, 250, 220, 252, 238, 258, 244, 276, 244, 295, 237, 315, 251, 324, 250, 336, 241, 336, 225, 320, 190, 279, 188 }));
            Cities.Add(new City("Gaziantep", new int[] { 654, 406, 629, 416, 596, 393, 580, 408, 569, 399, 593, 376, 602, 387, 633, 363, 651, 366, 642, 387 }));
            Cities.Add(new City("Giresun", new int[] { 654, 131, 646, 144, 657, 154, 659, 174, 697, 191, 699, 166, 686, 157, 705, 138, 703, 122, 671, 131 }));
            Cities.Add(new City("Gümüşhane", new int[] { 709, 139, 690, 158, 706, 167, 701, 187, 732, 199, 742, 193, 733, 183, 754, 153, 740, 146, 732, 156 }));
            Cities.Add(new City("Hakkari", new int[] { 985, 357, 991, 379, 1019, 357, 1004, 345, 1004, 325, 978, 332, 978, 323, 947, 334, 938, 354, 949, 364, 970, 365, 977, 356 }));
            Cities.Add(new City("Hatay", new int[] { 548, 396, 568, 401, 579, 410, 581, 448, 553, 476, 531, 445, 556, 424, 545, 402 }));
            Cities.Add(new City("Isparta", new int[] { 284, 292, 229, 334, 244, 330, 264, 346, 272, 367, 291, 366, 307, 318, 292, 300 }));
            Cities.Add(new City("Mersin", new int[] { 360, 456, 360, 438, 392, 426, 380, 407, 440, 391, 476, 371, 490, 381, 497, 410, 486, 415, 474, 409, 433, 443, 399, 455 }));
            Cities.Add(new City("İstanbul", new int[] { 137, 106, 203, 127, 232, 110, 147, 74 }));
            Cities.Add(new City("İzmir", new int[] { 91, 218, 79, 216, 61, 228, 58, 282, 36, 259, 31, 285, 81, 318, 130, 312, 143, 306, 135, 291, 81, 270, 76, 250, 99, 239, 97, 228 }));
            Cities.Add(new City("Kars", new int[] { 922, 109, 919, 118, 899, 123, 899, 138, 884, 141, 885, 157, 863, 163, 889, 185, 940, 169, 933, 145, 940, 128, 932, 114 }));
            Cities.Add(new City("Kastamonu", new int[] { 380, 68, 386, 76, 382, 87, 394, 87, 399, 99, 389, 104, 388, 114, 395, 122, 432, 123, 430, 137, 455, 136, 451, 118, 465, 104, 465, 90, 473, 85, 457, 79, 454, 63, 411, 58 }));
            Cities.Add(new City("Kayseri", new int[] { 537, 244, 507, 267, 495, 264, 499, 293, 489, 303, 507, 319, 507, 344, 520, 345, 519, 333, 554, 301, 568, 313, 586, 292, 582, 283, 594, 261, 582, 252, 552, 256 }));
            Cities.Add(new City("Kırklareli", new int[] { 89, 38, 83, 84, 116, 90, 147, 71, 142, 44, 117, 46, 105, 34 }));
            Cities.Add(new City("Kırşehir", new int[] { 447, 209, 413, 236, 449, 272, 478, 246, 465, 220 }));
            Cities.Add(new City("Kocaeli", new int[] { 234, 110, 203, 128, 235, 134, 213, 138, 207, 146, 214, 146, 220, 142, 233, 146, 247, 139, 256, 106 }));
            Cities.Add(new City("Konya", new int[] { 318, 254, 311, 283, 293, 298, 311, 317, 293, 367, 318, 366, 353, 409, 375, 399, 364, 387, 393, 359, 421, 352, 441, 385, 461, 375, 458, 345, 442, 328, 404, 330, 395, 311, 403, 291, 390, 277, 403, 264, 386, 246, 364, 263, 331, 263, 325, 253 }));
            Cities.Add(new City("Kütahya", new int[] { 215, 194, 204, 194, 190, 212, 181, 210, 160, 231, 179, 263, 223, 256, 226, 267, 249, 241, 242, 211, 215, 205 }));
            Cities.Add(new City("Malatya", new int[] { 671, 253, 628, 262, 614, 295, 639, 303, 633, 330, 660, 326, 671, 310, 697, 326, 713, 306, 669, 294, 677, 277, 685, 265 }));
            Cities.Add(new City("Manisa", new int[] { 95, 219, 101, 241, 76, 253, 83, 267, 136, 286, 146, 304, 154, 309, 164, 272, 176, 266, 159, 240, 134, 244, 119, 224 }));
            Cities.Add(new City("Kahramanmaraş", new int[] { 588, 293, 572, 315, 562, 349, 560, 370, 575, 367, 582, 381, 594, 371, 603, 384, 630, 360, 620, 356, 631, 331, 635, 306, 610, 297 }));
            Cities.Add(new City("Mardin", new int[] { 857, 344, 857, 357, 844, 360, 842, 373, 850, 380, 773, 398, 754, 359, 777, 358, 796, 343, 814, 344, 819, 357, 840, 356 }));
            Cities.Add(new City("Muğla", new int[] { 145, 354, 86, 342, 73, 376, 178, 429, 206, 390, 169, 388, 159, 369 }));
            Cities.Add(new City("Muş", new int[] { 817, 233, 827, 251, 820, 276, 831, 286, 859, 277, 857, 264, 898, 252, 880, 220, 863, 239, 847, 245, 831, 234 }));
            Cities.Add(new City("Nevşehir", new int[] { 485, 244, 453, 274, 463, 289, 463, 302, 484, 302, 496, 293, 492, 277, 494, 256 }));
            Cities.Add(new City("Niğde", new int[] { 445, 325, 460, 342, 462, 374, 478, 367, 481, 348, 504, 343, 504, 319, 489, 307, 461, 304, 462, 314 }));
            Cities.Add(new City("Ordu", new int[] { 602, 118, 592, 134, 581, 135, 591, 146, 608, 147, 627, 159, 632, 173, 656, 157, 643, 144, 652, 130, 629, 119, 623, 128 }));
            Cities.Add(new City("Rize", new int[] { 771, 123, 775, 150, 782, 152, 809, 128, 822, 109, 812, 99 }));
            Cities.Add(new City("Sakarya", new int[] { 257, 108, 249, 140, 235, 147, 235, 156, 263, 166, 268, 153, 280, 153, 280, 127, 287, 117 }));
            Cities.Add(new City("Samsun", new int[] { 520, 86, 517, 107, 507, 113, 498, 103, 491, 114, 497, 120, 545, 135, 556, 125, 565, 135, 589, 131, 599, 119, 586, 105, 577, 103, 569, 114, 550, 98, 548, 88, 544, 80, 544, 80 }));
            Cities.Add(new City("Siirt", new int[] { 911, 322, 900, 327, 876, 307, 865, 312, 847, 306, 833, 324, 851, 332, 850, 339, 858, 339, 860, 345, 880, 346, 893, 332, 912, 339, 915, 330 }));
            Cities.Add(new City("Sinop", new int[] { 455, 63, 458, 78, 474, 84, 466, 91, 466, 104, 488, 112, 499, 100, 506, 110, 515, 104, 517, 86, 498, 67, 494, 54, 483, 65 }));
            Cities.Add(new City("Sivas", new int[] { 581, 182, 620, 188, 654, 161, 657, 178, 689, 191, 688, 195, 667, 196, 669, 248, 626, 261, 612, 293, 589, 291, 585, 283, 597, 260, 584, 247, 554, 252, 541, 242, 555, 220, 546, 201, 580, 200 }));
            Cities.Add(new City("Tekirdağ", new int[] { 146, 73, 115, 91, 83, 86, 83, 95, 68, 102, 70, 122, 82, 123, 79, 135, 111, 109, 134, 111 }));
            Cities.Add(new City("Tokat", new int[] { 577, 136, 589, 149, 606, 149, 622, 161, 630, 173, 618, 186, 600, 179, 578, 180, 576, 198, 546, 198, 543, 187, 518, 177, 540, 163, 558, 162, 570, 137 }));
            Cities.Add(new City("Trabzon", new int[] { 706, 121, 708, 135, 731, 151, 740, 141, 757, 152, 773, 152, 768, 126, 737, 125 }));
            Cities.Add(new City("Tunceli", new int[] { 775, 221, 750, 248, 742, 266, 690, 266, 692, 239, 741, 220 }));
            Cities.Add(new City("Şanlıurfa", new int[] { 772, 399, 750, 357, 748, 336, 738, 340, 713, 328, 709, 354, 688, 370, 669, 366, 652, 368, 644, 388, 656, 405, 676, 403, 693, 414, 721, 416 }));
            Cities.Add(new City("Uşak", new int[] { 222, 266, 220, 258, 167, 272, 158, 299, 201, 300, 220, 278 }));
            Cities.Add(new City("Van", new int[] { 907, 323, 904, 286, 921, 227, 933, 222, 950, 232, 956, 221, 966, 222, 993, 287, 994, 325, 979, 330, 978, 320, 946, 331, 917, 330, 913, 321 }));
            Cities.Add(new City("Yozgat", new int[] { 500, 196, 455, 196, 449, 206, 467, 217, 498, 261, 506, 265, 519, 252, 546, 236, 552, 220, 540, 191, 515, 180, 503, 181, 502, 189 }));
            Cities.Add(new City("Zonguldak", new int[] { 344, 86, 310, 103, 307, 115, 311, 120, 345, 121, 355, 102, 351, 89 }));
            Cities.Add(new City("Aksaray", new int[] { 406, 291, 399, 310, 406, 327, 441, 323, 459, 311, 460, 290, 450, 275, 432, 259, 424, 286 }));
            Cities.Add(new City("Bayburt", new int[] { 756, 154, 736, 182, 743, 189, 752, 185, 777, 187, 791, 177, 776, 174, 778, 155 }));
            Cities.Add(new City("Karaman", new int[] { 419, 355, 394, 362, 366, 388, 378, 401, 354, 411, 356, 436, 388, 425, 378, 407, 418, 395, 437, 389, 437, 389 }));
            Cities.Add(new City("Kırıkkale", new int[] { 427, 174, 411, 196, 404, 219, 411, 234, 444, 208, 450, 196, 438, 178 }));
            Cities.Add(new City("Batman", new int[] { 845, 332, 852, 344, 839, 352, 819, 354, 815, 339, 824, 312, 829, 290, 836, 288, 844, 304, 830, 326 }));
            Cities.Add(new City("Şırnak", new int[] { 945, 334, 934, 359, 908, 359, 897, 376, 885, 379, 883, 367, 875, 367, 852, 380, 845, 372, 848, 361, 860, 359, 860, 348, 882, 348, 894, 335, 914, 341, 917, 333 }));
            Cities.Add(new City("Bartın", new int[] { 379, 68, 346, 84, 356, 102, 381, 87, 385, 77, 381, 72 }));
            Cities.Add(new City("Ardahan", new int[] { 876, 85, 884, 96, 869, 121, 886, 137, 896, 136, 898, 120, 917, 115, 922, 102, 881, 76, 877, 80 }));
            Cities.Add(new City("Iğdır", new int[] { 921, 177, 933, 193, 987, 191, 975, 174, 938, 172 }));
            Cities.Add(new City("Yalova", new int[] { 205, 146, 178, 149, 175, 143, 184, 137, 213, 137 }));
            Cities.Add(new City("Karabük", new int[] { 381, 89, 356, 103, 347, 121, 354, 121, 370, 136, 393, 122, 385, 114, 387, 103, 396, 98, 391, 87 }));
            Cities.Add(new City("Kilis", new int[] { 596, 395, 581, 409, 601, 419, 624, 421, 626, 417 }));
            Cities.Add(new City("Osmaniye", new int[] { 559, 354, 550, 352, 541, 383, 550, 382, 550, 393, 565, 397, 579, 382, 573, 371, 557, 373, 558, 365 }));
            Cities.Add(new City("Düzce", new int[] { 288, 117, 282, 127, 283, 144, 307, 145, 310, 133, 325, 128, 326, 122, 310, 121, 305, 115 }));

        }


        public void Scale(float zoom)
        {

            foreach (City c in Cities)
            {
                for (int i = 0; i < c.CityCoords.Length; i++)
                {
                    //  Point  p = c.CityCoords[i];
                    c.CityCoords[i].X = (int)(c.CityCoords[i].X * zoom);
                    c.CityCoords[i].Y = (int)(c.CityCoords[i].Y * zoom);
                }

            }

        }

        public void DrawToControl(Control cnt)
        {

            DrawToControl(cnt, Pens.Black);
        }
        public void DrawToControl(Control cnt, Pen pen)
        {
            Graphics g = cnt.CreateGraphics();

            foreach (City c in Cities)
            {
                g.DrawPolygon(pen, c.CityCoords);
                //  g.Flush();
            }
            g.Save();

            g.Dispose();


        }

        static bool PointInPolygon(PointF p, PointF[] poly)
        {
            PointF p1, p2;

            bool inside = false;

            if (poly.Length < 3)
            {
                return inside;
            }
            PointF oldPoint = new PointF(
        poly[poly.Length - 1].X, poly[poly.Length - 1].Y);
            for (int i = 0; i < poly.Length; i++)
            {
                PointF newPoint = new PointF(poly[i].X, poly[i].Y);

                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;

                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;

                }

                if ((newPoint.X < p.X) == (p.X <= oldPoint.X)

                    && (p.Y - p1.Y) * (p2.X - p1.X)

                     < (p2.Y - p1.Y) * (p.X - p1.X))
                {
                    inside = !inside;
                }
                oldPoint = newPoint;
            }
            return inside;
        }
        public City getCityAtPoint(System.Drawing.PointF p)
        {

            foreach (City c in Cities)
            {
                if (PointInPolygon(p, c.CityCoords)) return c;
            }
            return null;
        }
    }
}