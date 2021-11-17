using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Geo
{
    public class Us
    {
        public string id { get; set; }
        public List<Coordinat> сoordinates { get; set; } = new List<Coordinat>();
    }
    public class Coordinat
    {
        public Coordinat(double lat, double lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
        public double lat { get; set; }
        public double lon { get; set; }

    }
    public class UsStart
    {
        public string id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
    public static class UsM
    {
        public static List<Us> GetList(this List<Us> uss, string path, bool delNullAnd0 = false)
        {
            List<UsStart> usStarts = GetUsStarts(path, delNullAnd0);
            return usStarts.GetUs();
        }
        public static List<List<Us>> GetListWhereDifference(this List<Us> uss, double difference = 0.0001)
        {
            List<List<Us>> groups = new List<List<Us>>();
            List<UsStart> usStarts = uss.GetUsStarts().OrderBy(r => r.lat).ThenBy(r => r.lon).ThenBy(r => r.id).ToList();
            List<UsStart> ls = new List<UsStart>();
            for (int i = 0; i < usStarts.Count; i++)
            {
                if (i > 0 && (Math.Abs(usStarts[i].lat - usStarts[i - 1].lat) > difference || Math.Abs(usStarts[i].lon - usStarts[i - 1].lon) > difference))
                {
                    if (ls.Count > 2) { groups.Add(ls.GetUs()); }
                    ls = new List<UsStart>();
                }
                else { ls.Add(usStarts[i]); }
            }
            return groups.Where(r => r.Count > 1).ToList();
        }
        public static List<UsStart> GetUsStarts(this List<Us> uss)
        {
            List<UsStart> usStarts = new List<UsStart>();
            foreach (Us us in uss)
            {
                foreach (Coordinat coordinat in us.сoordinates)
                {
                    usStarts.Add(new UsStart() { id = us.id, lat = coordinat.lat, lon = coordinat.lon });
                }
            }
            return usStarts;
        }
        public static List<UsStart> GetUsStarts(string path, bool delNullAnd0 = false)
        {
            List<UsStart> usStarts = new List<UsStart>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] col = line.Split('\t');
                    UsStart usStart = new UsStart()
                    {
                        id = col[0],
                        lat = Convert.ToDouble(col[1].Replace(".", ",")),
                        lon = Convert.ToDouble(col[2].Replace(".", ","))
                    };
                    if (delNullAnd0 && /*usStart.lat == 0 &&*/ usStart.lon == 0) { continue; }
                    usStarts.Add(usStart);
                }
            }
            return usStarts;
        }
        public static List<Us> GetUs(this List<UsStart> usStarts)
        {
            List<Us> uss = new List<Us>();
            var a = usStarts.GroupBy(r => r.id).ToList();
            foreach (var b in a)
            {
                Us us = new Us();
                us.id = b.Key;
                foreach (var c in b)
                {
                    us.сoordinates.Add(new Coordinat(c.lat, c.lon));
                }
                uss.Add(us);
            }
            return uss;

        }
        public static List<Us> GetListUs(this List<List<Us>> LLus)
        {
            List<Us> LUs = new List<Us>();
            foreach (List<Us> Lus in LLus)
            {
                LUs = LUs.Concat(Lus).ToList();
            }
            return LUs;
        }
        public static List<Us> DropByListId(this List<Us> Lus, List<Us> Lus2)
        {
            List<Us> res = new List<Us>();
            foreach (Us us in Lus)
            {
                if (Lus2.AsParallel().FirstOrDefault(r => r.id == us.id) == null) { res.Add(us); }
            }
            return res;
        }
        public static void Write(this List<List<Us>> LLus, string fileName = "res.txt", bool ChangeFile = true)
        {
            string filePath = Environment.CurrentDirectory + "/" + fileName;
            if (File.Exists(filePath))
            {
                if (ChangeFile) { File.Delete(filePath); }
                else { filePath = filePath.Replace(".txt", "New.txt"); }
            }
            foreach (List<Us> Lus in LLus)
            {
                Lus.Write(fileName, true);
            }
        }
        public static void Write(this List<Us> Lus, string fileName = "res.txt", bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append, Encoding.UTF8))
            {
                foreach (Us us in Lus)
                {
                    foreach (Coordinat coordinat in us.сoordinates)
                    {
                        sw.WriteLine(us.id + "\t" + coordinat.lat + "\t" + coordinat.lon);
                    }
                }
            }
        }
        public static void Write(this List<UsStart> uss, string fileName = "UsStart.txt", bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append, Encoding.UTF8))
            {
                foreach (UsStart us in uss)
                {
                    sw.WriteLine(us.id + "\t" + us.lat + "\t" + us.lon);
                }
            }
        }
    }
}
