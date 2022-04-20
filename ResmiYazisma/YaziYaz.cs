using DevExpress.XtraEditors;
using ResmiYazisma.Contexts;
using ResmiYazisma.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResmiYazisma
{
    public partial class YaziYaz : DevExpress.XtraEditors.XtraForm
    {
        public YaziYaz()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YaziBilgileri yaziBilgileri = new YaziBilgileri
            { 
                Tarih=Convert.ToDateTime(dtTarih.EditValue),
                Konu=txtKonu.Text,
                Sayi= "DİBMT/DİB/23/03/2022",
                Ilgi=txtIlgi.Text,
                Temsilci=txtTemsilci.Text,
                Icerik=txtIcerik.Text,
            };

            DosyaIslemleri dosyaIslemleri = new DosyaIslemleri();
            dosyaIslemleri.ekle(yaziBilgileri);
        }
    }
}