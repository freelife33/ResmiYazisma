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
            ekle();
            var dosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ResmiYazisma", "Data/Antetli_Template.docx");
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            KlasorBulid();
        }
    }
}