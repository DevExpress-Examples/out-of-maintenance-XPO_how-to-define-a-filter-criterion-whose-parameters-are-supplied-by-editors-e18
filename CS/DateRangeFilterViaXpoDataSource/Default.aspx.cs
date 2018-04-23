using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DateRangeFilterViaXpoDataSource {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            XpoDataSource1.Session = XpoHelper.GetNewSession();

            deStartDate.Date = new DateTime(1996, 1, 1);
            deEndDate.Date = DateTime.Today;
        }
        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}
