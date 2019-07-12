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
        int contador = 0;
        int numeradorvalidador = 0;
        //contador necessario para nao zerar o vetor, deve ficar fora dos protegidos

        ListItem item;
       
        protected void Page_Load(object sender, EventArgs e)
        { 
            using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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

                            trens.Items.Add(item); // aqui ele adiciona no dropdown 
                            // aqui ele ira ler os codigos que estao no banco de dados e registrar no dropdown
 
                        }
                    }
                  
                }
            }
        }
        protected void registrotrem_Click(object sender, EventArgs e)
        {
            if (Trem.Text.Length == 0)
            {
                Trem.Text = "coloque um nome";
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

            if (quantidadeDeVagao > 9)
            {
                nomevagao.Text = "muitos vagoes";
                return;
            }//aqui valida se ele exagerou nos vagoes

            while (quantidadeDeVagao > 0)
            {
                int codtrem;
                string opcoesDeTrem = item.Value; //seleciona o ID do dropdown
                if (int.TryParse(opcoesDeTrem, out codtrem) == false) // transforma o ID do drowpdown em int
                {
                    // Campo não contém um número inteiro!

                    // O return encerra a execução por aqui
                    return;
                }
                if (trens.SelectedValue == "0")
                {
                    nomevagao.Text = "preencha um trem";
                    return;
                }// aqui valida se ele preencheu o dropdown

                using (SqlConnection conn = new SqlConnection("Server=tcp:tab132.database.windows.net,1433;Initial Catalog=esporte;Persist Security Info=False;User ID=mateus383@tab132;Password=123456sS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT nome_vagao from Vagao", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //Obtém os registros, um por vez
                            while (reader.Read() == true)
                            {
                                
                             
                                numeradorvalidador++;
                                
                                nomevagao.Text.ToString();
                                string[] validator = new string[10 + numeradorvalidador];
                                validator[numeradorvalidador] =nomevagao.Text;
                                
                                if (reader.GetString(0) == validator[numeradorvalidador]+" "+ numeradorvalidador )
                                {// aqui estou igualando ele ao banco de dados, ja que a string se transforma

                                    nomevagao.Text = "o trem ja existe tente outro";
                                    return;
                                }// aqui valida se o vagao ja tem nomeação igual

                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Vagao VALUES (@cod_trem,@nome_vagao)", conn))
                    {

                                contador++;
                        string[] nomesVagoes = new string[50  + contador];
                        
                        nomesVagoes[contador] = nomevagao.Text;

                        nomesVagoes[contador] = nomesVagoes[contador] +" "+ contador;
                        cmd.Parameters.AddWithValue("@cod_trem", codtrem);
                       //seleciona o trem pelo dropdown
                        cmd.Parameters.AddWithValue("@nome_vagao", nomesVagoes[contador]);
                        //gera o nome do vagao, e se for registrado ira começar o vetor

                        quantidadeDeVagao = quantidadeDeVagao - 1;
                        
                        cmd.ExecuteNonQuery();
                  }//conta a quantidade de vagoes que foram feitos e classifica: trem1,trem2...trem7
                }
            }
        }
    }
}