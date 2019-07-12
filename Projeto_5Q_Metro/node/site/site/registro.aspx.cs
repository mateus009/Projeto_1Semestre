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
    public partial class Registro : System.Web.UI.Page
    {
        //======================================================================================//
        protected void Page_Load(object sender, EventArgs e)
        {
            btnlabel.Visible = false;
            Label2.Visible = false;

            // aqui voce apaga as mensagens de erros
        }
        //======================================================================================//
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (btnSenha.Text != btnSenha1.Text)
            {
                btnlabel.Visible = true;
                return;
            }
            // confirma se as senhas batem
            if (string.IsNullOrWhiteSpace(btnNome.Text) || string.IsNullOrWhiteSpace(btnSenha.Text)
                || string.IsNullOrWhiteSpace(btnSenha1.Text) || string.IsNullOrWhiteSpace(btnId.Text))
            {
                Label2.Visible = true;
                return;
            }// obriga o usuario a preencher todos os espaços

           

            using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();
                //=====================================================================================//
                using (SqlCommand cmd = new SqlCommand("INSERT INTO usuario (nome, senha, id) VALUES (@nome, @senha, @id)", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", btnNome.Text.Trim());
                    cmd.Parameters.AddWithValue("@senha", btnSenha.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", btnId.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }
            // aqui é o codigo pra integrar o registro com o banco de dados

        }
    }
}
