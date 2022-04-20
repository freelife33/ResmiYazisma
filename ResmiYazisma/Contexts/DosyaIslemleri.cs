using ResmiYazisma.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResmiYazisma.Contexts
{
    public class DosyaIslemleri
    {

        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        Object missing = Type.Missing;
        public void ekle(YaziBilgileri yaziBilgileri)
        {
            try
            {

                Microsoft.Office.Interop.Word.Document doc = null;
                Object filename = Application.StartupPath + "Antetli_Template.docx";
                doc = app.Documents.Open(filename, missing, missing);
                app.Selection.Find.ClearFormatting();
                app.Selection.Find.Replacement.ClearFormatting();

                app.Selection.Find.Execute("[Sayi]", missing, missing, missing, missing, missing, missing, missing, missing, "DİBMT/DİB/"+yaziBilgileri.Sayi+"/"+yaziBilgileri.Tarih.Month.ToString()+"/2022", 2);
                string konu = yaziBilgileri.Konu + " " + yaziBilgileri.Sayi;
                app.Selection.Find.Execute("[Konu]", missing, missing, missing, missing, missing, missing, missing, missing, konu, 2);
                app.Selection.Find.Execute("[Tarih]", missing, missing, missing, missing, missing, missing, missing, missing, yaziBilgileri.Tarih.ToShortDateString(), 2);
                app.Selection.Find.Execute("[ilgi]", missing, missing, missing, missing, missing, missing, missing, missing, yaziBilgileri.Ilgi, 2);
                //app.Selection.Find.Execute("[icerik]", missing, missing, missing, missing, missing, missing, missing, missing, yaziBilgileri.Icerik, 2);
                app.Selection.Find.Execute("[Temsilci]", missing, missing, missing, missing, missing, missing, missing, missing, yaziBilgileri.Temsilci, 2);


                object saveAsfile = (object)System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+konu+".docx";
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
                MessageBox.Show("hata var.");
            }
        }
        private void KlasorBulid()
        {
            if (Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Resmi Yazışmalar"))
            {
               
            }
            else
            {              
                Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Resmi Yazışmalar");
            }
        }
    }
}
