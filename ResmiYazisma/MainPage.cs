using DevExpress.XtraBars;
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
    public partial class MainPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void barResmiYazilar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = new YaziYaz();
            form.MdiParent= this;
            form.Show();

        }
    }
}