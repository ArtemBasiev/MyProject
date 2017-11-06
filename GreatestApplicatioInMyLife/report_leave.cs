using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace GreatestApplicatioInMyLife
{
    public partial class report_leave : DevExpress.XtraReports.UI.XtraReport
    {
        public report_leave()
        {
            InitializeComponent();
            
        }

        void date_doc_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            date_doc.Text = string.Format("{dd.MM.yyy}");
        }

    }
}
