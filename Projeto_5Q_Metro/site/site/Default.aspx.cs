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

        SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        protected void Page_Load(object sender, EventArgs e)
        {
			  lblInvalido.Visible = false;
			  txtLogin.Focus();
        }


		protected void btnEntrar_Click(object sender, EventArgs e) {
            using (conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"SELECT login, senha, cod_cargo FROM Usuario 
                                                        WHERE login = @login AND senha = @senha;", conn))
                {
                    /*
                     * Verifica se os campos estão preenchidos, se sim, então faz a validação checando login e senha,
                     * senão exibe uma mensagem de erro.
                     */
                    if (txtLogin.Text != "" && txtSenha.Text != "")
                    {

                        cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                        cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                        //Com o dataReader eu consigo guardar a consulta em uma variavel, essa consulta vem como um conjunto de dados
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            //Leia a consulta, após ler eu consigo entender o conjunto de dados que tinha e trabalhar com eles
                            dr.Read();
                            int codCargo = 0;

                            /*
                             * se HasRows = true, então significa que ele conseguiu achar a consulta, que retornou uma linha
                             * no banco de dados, ou seja o usuário acertou o login e a senha.
                             */
                            if (dr.HasRows)
                                {
                                    codCargo = dr.GetInt32(2);

                                    if (codCargo == 1)//Se for funcionário, codCargo = 1, então vai pra página dele
                                    {
                                        Response.Redirect("http://localhost:2616/Home.aspx");
                                    }
                                    else//Se for administrador, codCargo = 2, então vai para página dele
                                    {
                                        Response.Redirect("http://localhost:2616/Home2.aspx");
                                    }
                                }
                            else//Caso contrário, ele errou um dos dois e exibe a mensagem para ele corrigir
                            {
                                lblInvalido.Text = "Login ou senha inválidos, digite novamente!";
                                lblInvalido.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        lblInvalido.Text = "Preencha todos os campos";
                        lblInvalido.Visible = true;
                    }
                }
            }
		}
	}
}
