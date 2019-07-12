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
    public partial class tabelasevagoes : System.Web.UI.Page
    {
        string[] validator;
        int valtrem = 0;
        int nmrvagoes = 0;
        int contador = 0;
        int numeradorvalidador = 0;
        int conta = 0;
        //contador necessario para nao zerar o vetor, deve ficar fora dos protegidos
        ListItem item;
        SqlConnection conn = Default.conecao();
        protected void Page_Load(object sender, EventArgs e)
        {

           
                conn.Open();
                //=====================================================================================//
               using (SqlCommand cmd = new SqlCommand("SELECT cod_trem,nome_trem From Trem order by cod_trem", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true) //ele ira ler do 0 até o ultimo dado 
                        {
                            int valor = reader.GetInt32(0);
                            string valor1 = valor.ToString();
                            string descricao = reader.GetString(1);
                            //pegando as informaços que foram lidas
                            item = new ListItem(descricao,valor1 );  //descricao é oq o usuario ve
                            //valor é o id do item, "value"
                            if (IsPostBack == false)
                            {
                                trens.Items.Add(item);
                            }// aqui ele adiciona no dropdown 
                            // aqui ele ira ler os codigos que estao no banco de dados e registrar no dropdown
                        }
                    }
                }
            
        }
        protected void registrotrem_Click(object sender, EventArgs e)
        {
            if (Trem.Text.Length == 0)
            {
                Trem.Text = "coloque um nome";
                return;
            }// valida se o campo esta em branco
            using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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

                                Trem.Text = "o trem ja existe tente outro";
                                return;
                            }// aqui valida se o vagao ja tem nomeação igual

                        }
                    }
                }             
                if (Trem.Text == "coloque um nome")
                {
                    Trem.Text = "ta de sacanagem né?";
                    return;
                }
                if (Trem.Text =="ta de sacanagem né?")
                {
                    Trem.Text = "coloque um nome";
                    return;
                }
                //=====================================================================================//
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Trem VALUES (@linha,@nome_trem)", conn))
                {
                  
                    cmd.Parameters.AddWithValue("@linha", "amarela");
                    cmd.Parameters.AddWithValue("@nome_trem", Trem.Text.Trim());
                    //registra o trem
                    cmd.ExecuteNonQuery();
                }
            }

        }
        protected void registrovagao_Click(object sender, EventArgs e)
            
        {
            if (nomevagao.Text.Length == 0 || quantidade.Text.Length ==0 )
            {
                nomevagao.Text = "preencha todos os campos";
                return;
            }// validando campo vazio

            int quantidadeDeVagao;
            if (int.TryParse(quantidade.Text, out quantidadeDeVagao) == false)
            {
                nomevagao.Text = "coloque um numero";

                // O return encerra a execução por aqui
                return;
            }

       //    if (quantidadeDeVagao > 9)
       //    {
       //        nomevagao.Text = "muitos vagoes";
       //        return;
       //    }//aqui valida se ele exagerou nos vagoes
            

            while (quantidadeDeVagao > 0)
            {
                int codtrem;
                string opcoesDeTrem = trens.SelectedValue; //seleciona o ID do dropdown
                int.TryParse(opcoesDeTrem, out codtrem); // transforma o ID do drowpdown em int
                if (trens.SelectedValue == "0")
                {
                    nomevagao.Text = "preencha um trem";
                    return;
                }// aqui valida se ele preencheu o dropdown
                
                using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                { 
                conn.Open();
                    string[] vagao = new string[50];
                    using (SqlCommand cmd = new SqlCommand($"SELECT nome_vagao from Vagao where cod_trem={codtrem}", conn))
                    {
                        int cont = 0;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            
                            
                          while (reader.Read() == true)
                            {

                                
                                vagao[cont] = reader.GetString(0);
                                cont++;
                            }
                            
                            
                           
                        }
                        
                        int pola = cont;
                        string[] capivara = new string[50];
                        while (pola > 0)
                        {
                           capivara[pola] = nomevagao.Text + " " + pola;
                            pola = pola - 1;
                        }
                        
                        while (cont > 0)
                        {
                            
                            int cont1 = cont;
                            while (cont1 > 0)
                            {
                                
                                if (vagao[cont] ==capivara[cont1])
                                {
                                    nomevagao.Text = "vagao ja existe";
                                    return;

                                }
                                cont1 = cont1 - 1;
                            }
                            cont = cont - 1;
                        }
                        

                        
                    }
                    
                   
                        //  if (nmrvagoes >= 9)
                        //  {
                        //      Trem.Text = "quantidade de vagoes excedida";
                        //      return; //valida o numeros de vagoes para nao serem criados infinitos vagoes em um trem
                        //  }




                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Vagao VALUES (@cod_trem,@nome_vagao)", conn))
                    {
                         contador++;
                       // string[] nomesVagoes = new string[50  + contador];
                        
                        string nomesVagoes = nomevagao.Text;

                        //nomesVagoes = nomesVagoes[contador] +" "+ contador;
                        cmd.Parameters.AddWithValue("@cod_trem", codtrem);
                       //seleciona o trem pelo dropdown
                        cmd.Parameters.AddWithValue("@nome_vagao", nomesVagoes + " " + contador);
                        //gera o nome do vagao, e se for registrado ira começar o vetor

                        quantidadeDeVagao = quantidadeDeVagao - 1;
                      
                        cmd.ExecuteNonQuery();
                        
                    }//conta a quantidade de vagoes que foram feitos e classifica: trem1,trem2...trem7
                    using (SqlCommand cmd = new SqlCommand("select max(cod_vagao) from arduino", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                conta = reader.GetInt32(0);
                               //cmd.ExecuteNonQuery();

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

                        quantidadeDeVagao = quantidadeDeVagao - 1;

                       cmd.ExecuteNonQuery();

                    }
                }
                
            }
        }
    }
}