using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;



namespace site
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			lblInvalido.Visible = false;
			txtLogin.Focus();
        }

		protected void btnEntrar_Click(object sender, EventArgs e) {
			using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")) {
				conn.Open();

				using (SqlCommand cmd = new SqlCommand("Select id,senha from usuario where id = @id AND senha = @senha", conn)) {

					cmd.Parameters.AddWithValue("@id", txtLogin.Text);
					cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
					Boolean verifica = cmd.ExecuteReader().HasRows;

					if (txtLogin.Text != "" || txtSenha.Text != "") {
						if (verifica != true) {
							lblInvalido.Text = "Login ou senha inválidos, digite novamente!";
							lblInvalido.Visible = true;
							return;
						}
						//verifica se as informações que o usuario colocou batem com alguma que esta no banco
						else {
							Response.Redirect("http://localhost:2616/registro.aspx");
						}
					} else {
						lblInvalido.Text = "Preencha todos os campos";
						lblInvalido.Visible = true;
						return;
					}
				}
			}
		}
	}
}
