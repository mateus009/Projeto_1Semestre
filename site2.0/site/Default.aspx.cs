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
        HttpCookie cookie;
        string b;
        public static SqlConnection conecao()

        {
            
        SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;
        Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;
         Encrypt=True;TrustServerCertificate=False;Connection Timeout=3000;max pool size=100000");
          return conn;
            
        }

        // coloquei em um metodo a conecao string
        
        protected void Page_Load(object sender, EventArgs e)
        {
           HttpCookie coke = Request.Cookies["cookie"];
            if (coke != null)
            {
               string cargo = coke.Values["cargo"];
               if (cargo == "2")
               {
                   Response.Redirect("http://new5q.azurewebsites.net/home2.aspx");
               }
              else
              { Response.Redirect("http://new5q.azurewebsites.net/home.aspx"); }
            }




            lblInvalido.Visible = false;
            txtLogin.Focus();

        }


        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            
            
            using (conecao())
            {
                SqlConnection conn = conecao();
                 conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"SELECT login, senha,nome, cod_cargo FROM Usuario 
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

                                //Session["nome"] = dr.GetString(2);
                               
                                cookie = new HttpCookie("cookie");
                                cookie.Values.Set("nome", dr.GetString(2));
                                cookie.Values.Set("cargo", dr.GetInt32(3).ToString());
                                // aqui ele ira salvar esses dados no pc do usuario
                                cookie.Expires = DateTime.MinValue; // o cookie só sai quando o usuario fechar o navegador
                                // ou deslogar no site
                                Response.Cookies.Set(cookie);

                                codCargo = dr.GetInt32(3);

                                if (codCargo == 1)//Se for funcionário, codCargo = 1, então vai pra página dele
                                {
                                    Response.Redirect("http://new5q.azurewebsites.net/home.aspx");
                                }
                                else//Se for administrador, codCargo = 2, então vai para página dele
                                {
                                    Response.Redirect("http://new5q.azurewebsites.net/home2.aspx");
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
