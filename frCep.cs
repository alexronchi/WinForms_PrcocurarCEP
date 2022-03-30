/*
* Carrega as bibliotecas necessárias para uso na aplicação
*/
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace PrcoruarCEP
{
    public partial class frCep : Form
    {
        public frCep()
        {
            /*
            * Inicializa os objetos e componetentes que serão utlizados no form
            */
            InitializeComponent();
        }

        private async void btnProcurar_Click(object sender, EventArgs e)
        {
            /*
            * Recuperar somente os números digitados no campo do CEP
            */
            string zipcode = String.Join("", System.Text.RegularExpressions.Regex.Split(txtCep.Text, @"[^\d]"));
            string url = $"https://viacep.com.br/ws/{zipcode}/json/";

            /*
            * O try serve para caso ocorra um erro, poder fazer um tratamento para
            * exibição de mensagem redirecionado para o catch
            */
            try
            {
                /*
                * Verifica se o CEP foi digitado, caso contrário cria uma exceção para o cacth
                */
                if (string.IsNullOrEmpty(zipcode))
                    throw new Exception("Digite um CEP corretamente");

                /*
                * Faz a requisição ao site ViaCep, passando como paràmetro o CEP digitado, que
                * se o resultaddo for OK, retorna os dados para exibição
                */
                var client = new HttpClient();
                var json = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<Cep>(json);

                /*
                * Caso encontre dados referentes ao CEP, exibe na tela
                */
                if (result != null)
                {
                    txtLogradouro.Text = result.Logradouro;
                    txtBairro.Text = result.Bairro;
                    txtCidade.Text = result.Localidade;
                    txtUf.Text = result.Uf;
                    txtIbge.Text = result.Ibge;
                }
            }
            catch (Exception ex)
            {
                /*
                * Se ocorrer algum erro mostra um alerta na tela
                */
                MessageBox.Show(ex.Message);
            }
        }
    }
}
