using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;


namespace site
{
    public partial class Home2 : System.Web.UI.Page
    {
        //int index;
      
        int contador = 0;
     
        int conta = 0;
        ListItem[] vags = new ListItem[20];
        int[] vags1 = new int[20];
        string[] nomes = new string[80];
        HttpCookie cookie;

        //contador necessario para nao zerar o vetor, deve ficar fora dos protegidos
        ListItem item;
        //SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        SqlConnection conn = Default.conecao();

        string statusvalidar;
        /*
         * DataBind() - vincula o DataSource com o dropDownList, ou seja, agora que ele tinha os valores
         * graças ao DataSource, eu uso o DataBind pra inserir eles no DropDownList, através de dois campos
         * de referência: DataTextField="cargo_nome" que serviu para passar o texto vindo do banco de dados;
         *                DataValueField="cod_cargo" que serviu para informar o valor daquele campo.
         * Os valores dos campos de referência tem que referênciar as colunas que você ta chamando,
         * ou seja, valor com mesmo nome das colunas.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string cargo, nome;
            cookie = Request.Cookies["cookie"];
            if (cookie == null)
            {
                Response.Redirect("http://new5q.azurewebsites.net/");
                return;
            }
             nome = cookie.Values["nome"];
            cargo = cookie.Values["cargo"];

            if (nome == null || cargo == "1")
            {
               
                Response.Redirect("http://new5q.azurewebsites.net/");
            }
            lab1.Text = nome ;
            //aqui ele vai validar se o usuario esta logado, se nao estiver ele nao conseguira entrar no site
            //se ele tambem nao for administrador ele nao conseguira
            label6.Text = "Online";
            label0.Text = Media().ToString() + "Cº";
            label1.Text = Media().ToString() + "Cº";
            label2.Text = Mediana().ToString() + "Cº";
            label3.Text = maximo().ToString() + "Cº";
            label4.Text = minimo().ToString() + "Cº";
            label5.Text = Mediana().ToString() + "Cº";
          
          

       
            conn.Open();
         //=====================================================================================//
         using (SqlCommand cmd = new SqlCommand("SELECT cod_trem,nome_trem From Trem order by cod_trem", conn))
         {
                
               
             using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    


                    int cont = 0;
                    while (reader.Read() == true) //ele ira ler do 0 até o ultimo dado 
                    {
                        int valor = reader.GetInt32(0);
                        string valor1 = valor.ToString();
                        string descricao = reader.GetString(1);
                        //pegando as informaços que foram lidas

                        item = new ListItem(descricao, valor1);  //descricao é oq o usuario ve
                        vags[cont] = item;
                        if (dropvagao.Items.Contains(vags[cont]) == false)
                        {
                            dropvagao.Items.Add(item);
                        }
                        if (trens.Items.Contains(vags[cont]) == false)
                        {
                            trens.Items.Add(item);
                        }
                      
                        
                        
                    
                        cont++;
                        if (cont == 7)
                        {
                           // cmd.ExecuteNonQuery();
                        }

                    }
                    // aqui ele adiciona no dropdown 
                    // aqui ele ira ler os codigos que estao no banco de dados e registrar no dropdown
                  
             }
         } conn.Close();
            
            conn.Open();
            using (SqlCommand cmd = new SqlCommand($"SELECT nome_vagao From vagao where cod_trem = {dropvagao.SelectedValue} ", conn))
            {
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                     while(reader.Read() == true )  
                    {

                        nomes[contador] = reader.GetString(0);
                        contador++;
                    }
                    
                }
            }
           
            conn.Close();
            label10.Text = nomes[0];
            
            

           

            //Esse IF faz com que o Load só rode na primeira vez que a página é carregada
           if (IsPostBack == true)
           {
               txtSenha.Attributes["value"] = txtSenha.Text;
               txtSenha.Attributes["value"] = txtConfirmarSenha.Text;
               return;
           }
         
          
            //Escondendo a label do erro, vai aparecer só quando tiver ERRO
            lblErro.Visible = false;

            //Preenchendo o dropDownList com os cargos do banco de dados.
            using (conn)
            {
                conn.Open();

                using (SqlCommand codigoSql = new SqlCommand("SELECT cod_cargo, nome_cargo FROM Cargo;", conn))
                {
                    dropDownList.Items.Insert(0, "Selecione o cargo");//Inserindo um novo item, nome autoexplicativo.

                    using (SqlDataReader dr = codigoSql.ExecuteReader())
                    {
                        dropDownList.DataSource = dr;//Informa onde esta o bloco de dados para preencher o dropDown
                        dropDownList.DataValueField = "cod_cargo";
                        dropDownList.DataTextField = "nome_cargo";
                        dropDownList.DataBind();
                    }
                }
            }conn.Close();
        }
        public string nome1(int numero)
        {
            return nomes[numero];
        }

         protected void registrotrem_Click(object sender, EventArgs e)
         {
            Session["teste"] = "o";
            hiddenmodal.Text = Session["teste"].ToString();
           
      
            if (Trem.Text == "")
            {
                lebel.Text = "digite um nome de trem";
                return;
            }
            if (lebel.Text == "coloque um nome")
            {
                lebel.Text = "ta de sacanagem né?";
                return;
            }
            if (lebel.Text == "ta de sacanagem né?")
            {
                lebel.Text = "coloque um nome";
                return;
            }
            using (conn)
             {
                 conn.Open();
                 using (SqlCommand cmd = new SqlCommand("SELECT nome_trem from trem", conn))
                 {
                     using (SqlDataReader reader = cmd.ExecuteReader())
                     {
                         //Obtém os registros, um por vez
                         while (reader.Read() == true)
                         {
       
                             string validacao;
                             validacao = reader.GetString(0);
       
                             if (validacao == Trem.Text)
                             {
       
                                 lebel.Text = "o trem ja existe tente outro";
                                 return;
                             }// aqui valida se o vagao ja tem nomeação igual
       
                         }
                     }
                 }
                
                //=====================================================================================//
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Trem VALUES (@linha,@nome_trem)", conn))
                 {
                    
       
                     cmd.Parameters.AddWithValue("@linha", "amarela");
                     cmd.Parameters.AddWithValue("@nome_trem", Trem.Text.Trim());
                     //registra o trem
                     cmd.ExecuteNonQuery();
                    
                }
                lebel.Text = "trem cadastrado com sucesso !!";

                using (SqlCommand cmd = new SqlCommand("SELECT cod_trem,nome_trem From Trem order by cod_trem", conn))
                {


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {


                        trens.Items.Clear();
                        int cont = 0;
                        while (reader.Read() == true) //ele ira ler do 0 até o ultimo dado 
                        {
                            int valor = reader.GetInt32(0);
                            string valor1 = valor.ToString();
                            string descricao = reader.GetString(1);
                            //pegando as informaços que foram lidas

                            item = new ListItem(descricao, valor1);  //descricao é oq o usuario ve
                            vags[cont] = item;
                            if (dropvagao.Items.Contains(vags[cont]) == false)
                            {
                                dropvagao.Items.Add(item);
                            }


                            trens.Items.Add(item);

                            cont++;
                            if (cont == 7)
                            {
                                // cmd.ExecuteNonQuery();
                            }

                        }
                        // aqui ele adiciona no dropdown 
                        // aqui ele ira ler os codigos que estao no banco de dados e registrar no dropdown

                    }
                }
                conn.Close();
            }
         }
         protected void registrovagao_Click(object sender, EventArgs e)
         {
            Session["teste"] = "o";
            hiddenmodal.Text = Session["teste"].ToString();

            if (nomevagao.Text.Length == 0 || quantidade.Text.Length == 0)
             {
                 lebel.Text = "preencha todos os campos";
                 return;
             }// validando campo vazio
       
             int quantidadeDeVagao;
             if (int.TryParse(quantidade.Text, out quantidadeDeVagao) == false)
             {
                 lebel.Text = "coloque um numero";
       
                 // O return encerra a execução por aqui
                 return;
             }
             if (quantidadeDeVagao > 8)
            {
                lebel.Text = "muitos vagoes";
                return;
            }
            if (trens.SelectedValue == "0")
            {
                lebel.Text = "preencha um trem";
                return;
            }// aqui valida se ele preencheu o dropdown
            int codtrem;
            string opcoesDeTrem = trens.SelectedValue; //seleciona o ID do dropdown
            int.TryParse(opcoesDeTrem, out codtrem); // transforma o ID do drowpdown em int
            contador = 0;
            while (contador < quantidadeDeVagao)
             {
                contador = contador + 1 ;
               
               
              
                 using (SqlConnection conn = Default.conecao())
                 {
                     conn.Open();
                    
                     using (SqlCommand cmd = new SqlCommand("INSERT INTO Vagao VALUES (@cod_trem,@nome_vagao)", conn))
                     {

                        // string[] nomesVagoes = new string[50  + contador];
                        
                        string nomesVagoes = nomevagao.Text;
                        
                         //nomesVagoes = nomesVagoes[contador] +" "+ contador;
                         cmd.Parameters.AddWithValue("@cod_trem", codtrem);
                         //seleciona o trem pelo dropdown
                         cmd.Parameters.AddWithValue("@nome_vagao", nomesVagoes + " " + contador);
                        //gera o nome do vagao, e se for registrado ira começar o vetor


                        lebel.Text = "vagao cadastrado com sucesso!";
                        cmd.ExecuteNonQuery();
       
                     }
                     //conta a quantidade de vagoes que foram feitos e classifica: trem1,trem2...trem7
                     using (SqlCommand cmd = new SqlCommand("select max(cod_vagao) from arduino", conn))
                     {
                         using (SqlDataReader reader = cmd.ExecuteReader())
                         {
                             while (reader.Read() == true)
                             {
                                 conta = reader.GetInt32(0);
                                 // cmd.ExecuteNonQuery();
                                
                             }
                         }
       
       
                     }
       
                     using (SqlCommand cmd = new SqlCommand("INSERT INTO arduino VALUES (@cod_vagao,@cod_trem)", conn))
                     {
                         conta++;
       
                         string nomesVagoes = nomevagao.Text;
                         cmd.Parameters.AddWithValue("@cod_vagao", conta);
                         //seleciona o trem pelo dropdown
                         cmd.Parameters.AddWithValue("@cod_trem", codtrem);
                         //gera o nome do vagao, e se for registrado ira começar o vetor
       
                        
       
                         cmd.ExecuteNonQuery();
       
                     }

                     
                 }
       
             }
            conn.Close();
         }
       
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

           

            Session["teste"] = "z";
            hiddenmodal.Text = Session["teste"].ToString();
            // esses sessions servem para deixar as modais solidas

           
            if (txtNome.Text != "" && txtLogin.Text != "" && txtSenha.Text != "" && txtConfirmarSenha.Text != ""
               && dropDownList.SelectedIndex != 0)
            {
                    using (conn)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("SELECT login FROM usuario WHERE login = @login;", conn))
                        {
                            cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                            String login = Convert.ToString(cmd.ExecuteScalar());

                            if (login == txtLogin.Text)
                            {
                                lblErro.Text = "Não é possivel cadastrar, o login digitado já existe!!";
                                lblErro.Visible = true;
                                return;
                            }
                            else
                            {
                                if (txtSenha.Text == txtConfirmarSenha.Text)
                                {
                                    lblErro.Text = "Usuario cadastrado com sucesso!!";
                                    lblErro.Visible = true;
                                    using (conn)
                                    {
                                        using (SqlCommand codigoSql = new SqlCommand(@"INSERT INTO usuario (nome, login, senha, cod_cargo) 
                                                           VALUES (@nome, @login, @senha, @cargo)", conn))
                                        {
                                            codigoSql.Parameters.AddWithValue("@nome", txtNome.Text);
                                            codigoSql.Parameters.AddWithValue("@login", txtLogin.Text);
                                            codigoSql.Parameters.AddWithValue("@senha", txtSenha.Text);
                                            codigoSql.Parameters.AddWithValue("@cargo", dropDownList.SelectedValue);
                                           
                                            codigoSql.ExecuteNonQuery();
                                        }
                                       
                                         
                                    }
                                }
                                else
                                {
                                    lblErro.Text = "As senhas não estão iguais";
                                    lblErro.Visible = true;
                                    return;
                                }
                            }
                        }

                    }
                
            } 
            else
            {
                lblErro.Text = "Preencha todos os campos!!";
                lblErro.Visible = true;
                return;
            }

        }
        public static double maximo()
        {
            int medea = 0;
            int a = 0;
            int b = 0;
            SqlConnection conn = Default.conecao();
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT MAX ( cod_temperatura) FROM Temperatura", conn))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {  

                       if (dr.Read() == true)
                       {   
                            a = dr.GetInt32(0);
                            medea = a - 60;
                            //aqui eu fiz um algoritimo pra ele pegar a ultima temperatura dada,
                            // e a ultima a 60 segundos atras
                       }
                       

                    }

                   
                }
                
                
                    
                using (SqlCommand cmd = new SqlCommand($"SELECT max(temperatura) FROM Temperatura WHERE cod_temperatura between {medea} and {a}", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {
                            double po = dr.GetDouble(0);
                            conn.Close();
                            return po;
                            //continuação do que ue falei acima, ele vai verificar as temperaturas entre a ultima
                            //temperatura dada e a ultima 60segundos atras, e vai pegar o maximo entre elas
                        }
                        else { return 0; }
                         
                    }

                }
                
            }

        }

        public static double minimo()
        {// metodo pra pegar a temp minima
            int medea = 0;
            int a = 0;
            SqlConnection conn = Default.conecao();
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT MAX ( cod_temperatura) FROM Temperatura", conn))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read() == true)
                        {
                            a = dr.GetInt32(0);
                            medea = a - 60;
                            //aqui eu fiz um algoritimo pra ele pegar a ultima temperatura dada,
                            // e a ultima a 60 segundos atras
                        }
                        else { return 0; }
                        conn.Close();

                    }



                }
                conn.Open();
             
                using (SqlCommand cmd = new SqlCommand($"SELECT min(temperatura) FROM Temperatura WHERE cod_temperatura between {medea} and {a}", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {
                            double po = dr.GetDouble(0);
                            conn.Close();
                            return po;
                            
                            //continuação do que ue falei acima, ele vai verificar as temperaturas entre a ultima
                            //temperatura dada e a ultima 60segundos atras, e vai pegar o minimo entre elas
                        }
                        else { return 0; }
                       
                    }
                }
            }
        }
        



        public static double Media()
        {
            int medea = 0;
            int a = 0;
            SqlConnection conn = Default.conecao();
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT MAX ( cod_temperatura) FROM Temperatura", conn))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                       if (dr.Read() == true)
                        {
                            
                            a = dr.GetInt32(0);
                            medea = a - 60;
                            
                            //aqui eu fiz um algoritimo pra ele pegar a ultima temperatura dada,
                            // e a ultima a 60 segundos atras
                        } else { return 0; }
                        
                   
                    }


                }

                using (SqlCommand cmd = new SqlCommand($"SELECT round(avg(temperatura),2) FROM Temperatura WHERE cod_temperatura between {medea} and {a}", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {

                            double po = dr.GetDouble(0);
                            conn.Close();
                            return po;

                            //aqui o comando vai dar diretamente a media entre a ultima temperatura dada e a ultima a 60
                            //segundos atras, e logo em seguida ele só ira deixar 2 casas pós virgula
                        }
                        else { return 0; }
                    }


                    
                
                }
            }
        }
        
        public static double Mediana()
        {

            double xa = 0, b = 0, medea = 0;

            SqlConnection conn = Default.conecao();
            {   
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT MAX (cod_temperatura) FROM Temperatura", conn))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                         
                       if (dr.Read() == true)
                        {
                            xa = dr.GetInt32(0) - 30;

                            //como só iremos pegar a temperatura de 1 em 1 minuto, ou seja, a cada 60 segundos
                            // eu coloquei pra pegar a mediana direto.


                        }
                        else { return 0; }

                    }


                }

                using (SqlCommand cmd = new SqlCommand($"SELECT temperatura FROM Temperatura WHERE cod_temperatura = {xa}", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {
                            medea = dr.GetDouble(0);
                           
                            // aqui ele vai pegar a temperatura mediana 
                        }
                        else { cmd.ExecuteNonQuery(); return 1001; }
                    }





                }
                using (SqlCommand cmd = new SqlCommand($"SELECT temperatura FROM Temperatura WHERE cod_temperatura = {xa + 1}", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {
                            b = dr.GetDouble(0);
                            // e aqui ele vai pegar a mediana 31, que como é numero par ele ira
                            // fazer o 30+31 (que é o meio do 60 mas é par entao o meio é duplo)

                        }
                        else
                        {
                            return 1001;
                        }

                    }
                }
                conn.Close();
                return (medea + b) / 2;
                // esse é o calculo da mediana par

            }
        }



        [WebMethod]
        public static double TemperaturaAtual()
        {
            
            //SqlConnection conn = new SqlConnection(@"Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlConnection conn = Default.conecao();
            using (conn)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT temperatura FROM Temperatura WHERE cod_temperatura = (SELECT MAX(cod_Temperatura) FROM temperatura)", conn))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() == true)
                        {
                            return double.Parse(dr["temperatura"].ToString());
                        }
                        else
                        {
                            return 0;
                        }
                    }

                }

            }
        }
        
        protected void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Media().ToString() + "Cº";
            label0.Text = Media().ToString() + "Cº";
            label5.Text = Mediana().ToString() + "Cº";
           
            statusvalidar = hiddentemp.Text;

            if (TemperaturaAtual().ToString() == statusvalidar)
            {
                label6.Text = "Offline";
                //label6.BackColor = System.Drawing.Color.Red ;
            }
            else
            {
                label6.Text = "Online";
              //  label6.BackColor = System.Drawing.Color.Green;
            }
            hiddentemp.Text = TemperaturaAtual().ToString();
        }



        protected void btnSair_Click(object sender, EventArgs e)
        {
            cookie.Expires = DateTime.Now.AddYears(-1); // expira o cookie fazendo o usuario perder o save na pagina
            Response.Cookies.Set(cookie);
            Response.Redirect("http://new5q.azurewebsites.net/"); 
            
        }

        protected void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = Mediana().ToString() + "Cº";
            
            

        }

        protected void timer4_Tick(object sender, EventArgs e)
        {
            label3.Text = maximo().ToString() + "Cº";
        }

        protected void timer3_Tick(object sender, EventArgs e)
        {
            label4.Text = minimo().ToString() + "Cº";
        }

        protected void dropvagao_SelectedIndexChanged(object sender, EventArgs e)
        {
            hiddenmodal.Text = "zta";
        }
    }
}