using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using javax.xml.crypto;
using MySql.Data.MySqlClient;
using sun.management.counter.perf;
using Regex = System.Text.RegularExpressions.Regex;

namespace QueryTool
{
    public partial class Form1 : Form
    {
        string location =Extentions.GetDirection();
        string path = Extentions.GetFileDirection("Documents.xlsx");
        MySqlConnection con;
        MySqlCommand cmd;
        List<MuseumModel> museums = new List<MuseumModel>();
        List<SelectedMuseums> selectedMuseum = new List<SelectedMuseums>();
        bool isWorking = false;
        public Form1()
        {
            InitializeComponent();
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.UserID = "";
            builder.Password = "";
            builder.Database = "";
            builder.Server = "";
            con = new MySqlConnection(builder.ToString());
            con.Open();
            string query = "";
            cmd = new MySqlCommand(query, con);
            museums = Helper.FillMuseum(cmd.ExecuteReader());
            con.Close();
            Helper.FillCheckList(museums, ref ListOfMuseum);
        }
        private void ListOfMuseum_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isWorking)
                return;
            isWorking = true;
            CheckedListBox chbox = (CheckedListBox)sender;
            if (chbox.SelectedIndex == 0)
            {
                var isCheck = ListOfMuseum.GetItemChecked(0) ? false : true;
                for (int i = 0; i < ListOfMuseum.Items.Count; i++)
                    ListOfMuseum.SetItemChecked(i, isCheck);
            }
            else
            {
                for (int i = 0; i < ListOfMuseum.Items.Count; i++)
                {
                    if (ListOfMuseum.GetItemChecked(i) == false)
                    {
                        ListOfMuseum.SetItemChecked(i, false);
                    }
                }
            }
            isWorking = false;
        }
        private void GetQuery_Click(object sender, EventArgs e)
        {
            string querySavedText = Query.Text + " " + DateTime.Now.ToString();
            try
            {
                museums.ForEach(a =>
                {
                    a.Run = false;
                    a.AffectedRowCount = 0;
                });
                foreach (KeyValuePair<string, string> item in ListOfMuseum.CheckedItems)
                {
                    var museum = museums.FirstOrDefault(x => x.DistId == item.Key);
                    museum.Run = true;
                }
                if (museums.Where(x => x.Run == true).ToList().Count <= 0)
                {
                    MessageBox.Show("Please select an item.");
                    return;
                }
                if (string.IsNullOrEmpty(Query.Text) || string.IsNullOrWhiteSpace(Query.Text))
                {
                    MessageBox.Show("Plese write runnig query.");
                    return;
                }
                string regexValue = @"(^insert)|(^update)|(^delete)|(^INSERT)|(^UPDATE)|(^DELETE)";
                if (!new Regex(regexValue).IsMatch(Query.Text))
                {
                    if (museums.Where(x => x.Run == true).ToList().Count != 1)
                    {
                        MessageBox.Show("Sadece 1 tane müze seçilmek zorundadır.");
                        return;
                    }
                    if (LimitBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("Lütfen limit seçiniz","Information Page");
                        return;
                    }
                    var selectedMuseum = museums.FirstOrDefault(x => x.Run == true);
                    con = new MySqlConnection(selectedMuseum.DistCon1);
                    con.Open();
                    foreach (var item in LimitBox.CheckedItems)
                    {
                        if (LimitBox.SelectedIndex == 4)
                        {
                            cmd = new MySqlCommand(Query.Text, con);
                        }
                        else
                        {
                            cmd = new MySqlCommand(Query.Text + " limit " + item.ToString(), con);
                        }
                    }
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                    Helper.SaveInformationTxt(querySavedText);
                }
                else
                {
                    foreach (var museum in museums.Where(x => x.Run == true))
                    {
                        con = new MySqlConnection(museum.DistCon1);
                        con.Open();
                        cmd = new MySqlCommand(Query.Text, con);
                        museum.AffectedRowCount = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    var sucMuseums = System.String.Join(" , ", museums.Where(x => x.Run == true && x.AffectedRowCount > 0).Select(x => x.DistId).ToList());
                    var unSucMuseums = System.String.Join(" , ", museums.Where(x => x.Run == true && x.AffectedRowCount <= 0).Select(x => x.DistId).ToList());
                    var affectedMuseum = museums.Where(x => x.Run == true && x.AffectedRowCount > 0 ).Select(x => x.AffectedRowCount.ToString()).ToList();
                    var museumsCounter = museums.Where(x => x.Run == true).Select(x => x.DistId).ToList() ; 
                    var selectedMuseumCounter = 0;
                    var count = 0;
                    var _data = (museums.Where(x => x.Run == true).Select(x => x.DistName).ToList()); 
                    foreach (var item in affectedMuseum)
                    {
                        count++;
                    }
                    foreach (var item in museumsCounter)
                    {
                        selectedMuseumCounter++;
                    }
                    DialogResult dialog = MessageBox.Show("Seçtiğiniz "+selectedMuseumCounter+" müze için işleminizi onaylıyor musunuz ? ","Information Page",MessageBoxButtons.OKCancel);
                    if (dialog == DialogResult.OK)
                    {
                        selectedMuseum.Add(new SelectedMuseums
                        {
                            sucedMuseums = "Başarılı Müzeler",
                            unsucedMuseum = "Başarısız Müzeler",
                            afRows = "Etkilenen Müze Sayısı"
                        });
                        foreach (var item in _data)
                        {
                            selectedMuseum.Add(new SelectedMuseums
                            {
                                sucedMuseums = (museums.Where(x => x.Run == true && x.AffectedRowCount > 0).Select(x => x.DistId).ToList()).ToString(),
                                unsucedMuseum = unSucMuseums,
                                afRows = count.ToString()
                            });
                        }
                        MessageBox.Show("Başarılı Müzeler: " + sucMuseums
                        + Environment.NewLine
                        + "Başarısız Müzeler: " + unSucMuseums
                        + Environment.NewLine
                        + "Etkilenen Müze Sayısı: " + count, "Information Page");
                        DialogResult dR = MessageBox.Show("Bilgileri kaydetmek ister misiniz ?", "Information Page", MessageBoxButtons.YesNo);
                        if (dR == DialogResult.Yes)
                        {
                            string filePath = "SelectedMuseumsDocuments.txt";
                            var file_Info = new FileInfo(filePath);
                            if (!File.Exists(filePath))
                            {
                                File.Create(filePath);
                            }
                            else
                            {
                                string text1 = "Başarılı Müzeler: " + sucMuseums 
                                    + Environment.NewLine 
                                    + "Başarısız Müzeler: " + unSucMuseums
                                    + Environment.NewLine
                                    + "Etkilenen Müze Sayısı: " + count + " //Tarih: " + DateTime.Now.ToString();
                                using (StreamWriter stw = new StreamWriter(filePath, true))
                                    stw.WriteLine(text1 + Environment.NewLine);
                            }
                        }
                        else
                        {
                            Helper.SaveInformationTxt(querySavedText);
                            return;
                        }

                    }
                    else
                    {
                        return;
                    }
                    
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    private void LimitBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < LimitBox.Items.Count; i++)
            {
                if (LimitBox.GetItemChecked(i) == true)
                {
                    count++;
                    if (count > 1)
                    {
                        LimitBox.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void saveDocument_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount <= 0)
            {
                MessageBox.Show("No data displayed","Information Page");
            }
            else
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                object Missing = Type.Missing;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Missing);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }
                StartRow++;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {
                            DataGridViewCell cell = dataGridView1[j, i];
                            sheet1.Cells[i + 2, j + 1] = cell.Value;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                try
                {
                    workbook.SaveAs(path);
                    workbook.Close(true, Missing, Missing);
                    excel.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Saved Succed","Information Page");
            }
            
        }
    }
}
