using ResmiYazisma.Data;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
namespace ResmiYazisma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        Object missing = Type.Missing;

        //DÝBMT/DÝB/23/03/2022


        private void ekle()
        {
            try
            {

                Microsoft.Office.Interop.Word.Document doc = null;
                Object filename = Application.StartupPath + "Antetli_Template.docx";
                doc = app.Documents.Open(filename, missing, missing);
                app.Selection.Find.ClearFormatting();
                app.Selection.Find.Replacement.ClearFormatting();

                app.Selection.Find.Execute("[Sayi]", missing, missing, missing, missing, missing, missing, missing, missing, "DÝBMT/DÝB/23/03/2022", 2);

                app.Selection.Find.Execute("[Konu]", missing, missing, missing, missing, missing, missing, missing, missing, "Test Konu Hk.", 2);
                app.Selection.Find.Execute("[Tarih]", missing, missing, missing, missing, missing, missing, missing, missing, DateTime.Now.ToShortDateString(), 2);
                app.Selection.Find.Execute("[Temsilci]", missing, missing, missing, missing, missing, missing, missing, missing, "Faruk SEÇKÝN", 2);


                object saveAsfile = (object)System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\sonuc1.docx";
                doc.SaveAs2(saveAsfile, missing, missing, missing);
                object dosyaadi = saveAsfile;
                object sadeceokunur = false;
                object gorunur = true;
                object missing2 = System.Reflection.Missing.Value;
                app.Visible = true;
                doc = app.Documents.Open(ref dosyaadi, ref missing2, ref sadeceokunur, ref missing2, ref missing2, ref missing2, ref missing2, ref missing2, ref missing2, ref missing2, ref missing2, ref gorunur, ref missing2, ref missing2, ref missing2, ref missing2);
                doc.Activate();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            catch
            {
                MessageBox.Show("hatavar.");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DosyaAc();
            //ekle();
           // var dosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ResmiYazisma", "Data/Antetli_Template.docx");
            //MessageBox.Show(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        }
        private void KlasorBulid()
        {
            if (Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\Resmi Yazýþmalar"))
            {
               // Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Resmi Yazýþmalar");
               // MessageBox.Show("Var");
            }
            else
            {
              //  MessageBox.Show("Yok");
                Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Resmi Yazýþmalar");
            }
        }

        private void DosyaAc()
        {
            try
            {

                Microsoft.Office.Interop.Word.Document doc = null;
                Object filename = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Resmi Yazýþmalar\\sonuc1.docx";
                doc = app.Documents.Open(filename, missing, missing);
               

               
                app.Visible = true;
                //doc = app.Documents.Open(ref dosyaadi, ref missing2, ref sadeceokunur, ref missing2, ref missing2, ref missing2, ref missing2, ref missing2, ref missing2, ref missing2, ref missing2, ref gorunur, ref missing2, ref missing2, ref missing2, ref missing2);
                doc.Activate();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            catch
            {
                MessageBox.Show("hatavar.");
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // KlasorBulid();
            Contexts.Connection dbContext = new Contexts.Connection();
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\\dbResmiYazismalar.accdb");
            connect.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From Sayi", connect);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            OleDbCommand command = new OleDbCommand("SELECT COUNT(*) FROM Sayi", connect);
            int sonuc=command.ExecuteNonQuery();
           
           command.Dispose();
            //gridControl1.DataSource = dataTable;
            connect.Close();
            DirectoryInfo klasor=new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Resmi Yazýþmalar");
            FileInfo[] dosyalar =klasor.GetFiles();
            DosyaListesi dosyaList;
            List<DosyaListesi> list = new List<DosyaListesi>();
            foreach (var dosya in dosyalar)
            {
                dosyaList = new DosyaListesi
                { 
                    DosyaAdi = dosya.Name,
                    OlusturulmaTarihi = dosya.CreationTime.ToString(),
                    SonGuncellenmeTarihi = dosya.LastWriteTime.ToString(),
                    SonGirisTarihi = dosya.LastAccessTime.ToString(),
                };
                list.Add(dosyaList);
            }
            gridControl1.DataSource = list.ToList();
           // MessageBox.Show(dataTable.Rows.Count.ToString());
         
        }
    }
}