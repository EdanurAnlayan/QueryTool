using java.nio.file;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryTool
{
    public static class Helper
    {
        public static List<MuseumModel> FillMuseum(MySqlDataReader dr)
        {
            List<MuseumModel> museums = new List<MuseumModel>();
            museums.Add(new MuseumModel
            {
                DistId = "-",
                DistName = "Tümü"
            });
            while (dr.Read())
            {
                museums.Add(new MuseumModel
                {
                    DistId = dr["dist_id"].ToString(),
                    DistName = dr["dist_name"].ToString(),
                    DistCon1 = dr["db_connection"].ToString(),
                    DistCon2 = dr["db_connection_2"].ToString()
                });
            }
            dr.Close();
            return museums;
        }
        public static void FillCheckList(List<MuseumModel> museums,ref CheckedListBox listOfMuseum)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var museum in museums)
            {
                dictionary.Add(museum.DistId, museum.DistName);
            }
            listOfMuseum.DataSource = new BindingSource(dictionary, null);
            listOfMuseum.DisplayMember = "Value";
            listOfMuseum.ValueMember = "Key";

        }
        public static void SaveInformationTxt(string text)
        {
            string location = Extentions.GetDirection();
            string path = Extentions.GetFileDirection("querys.txt");
            var file = new FileInfo(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                    sw.WriteLine(text + " ");
            }
        }
    }
}
