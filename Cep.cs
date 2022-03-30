/*
* Carrega as bibliotecas necessárias para uso na aplicação
*/
using Newtonsoft.Json;

namespace PrcoruarCEP
{
    /*
    * Cria atributos para poder receber os dados vindos via API do CEP
    */
    public class Cep
    {
        /*
         * O JsonProperty serve para dar o nome do campo que será recuperado pela Api
        */

        [JsonProperty("cep")]
        public string Code { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("ibge")]
        public string Ibge { get; set; }
    }
}
