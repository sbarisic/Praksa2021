using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PraksaFront;

namespace PraksaFront {
	public partial class Page : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			status_label.Visible = false;
		}

		protected void OnConfirm(object sender, EventArgs e) {
			string Password = inputPassword2.Value;

			if (string.IsNullOrEmpty(Password)) {
				WriteError("Please enter password");
				return;
			}

			if (Password == "root")
				WriteSuccess("Success!");
			else
				WriteError("Password is incorrect");
		}

		void WriteSuccess(string Txt) {
			status_label.InnerText = Txt;
			status_label.Attributes.Add("class", "badge badge-success");
			status_label.Visible = true;
		}

		void WriteError(string Txt) {
			status_label.InnerText = Txt;
			status_label.Attributes.Add("class", "badge badge-danger");
			status_label.Visible = true;
		}
	}
}