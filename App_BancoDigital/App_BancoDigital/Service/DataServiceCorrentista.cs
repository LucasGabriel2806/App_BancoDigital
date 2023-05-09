using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App_BancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {
        /**
         * Obtém a lista de pessoas
         */
        public static async Task<List<Correntista>> GetPessoasAsync()
        {
            string json = await DataService.GetDataFromService("/correntista");

            List<Correntista> arr_correntistas = JsonConvert.DeserializeObject<List<Correntista>>(json);

            return arr_correntistas;
        }

        /**
         * Envia um Model em forma de JSON ara insert no banco.
         */
        public static async Task<Correntista> Cadastrar(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/salvar");

            Correntista p = JsonConvert.DeserializeObject<Correntista>(json);

            return p;
        }

        /**
         * Realiza uma busca de pessoas no banco de dados.
         */
        public static async Task<List<Correntista>> SearchAsync(string q)
        {
            var json_a_enviar = JsonConvert.SerializeObject(q);

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/buscar");

            List<Correntista> arr_pessoas = JsonConvert.DeserializeObject<List<Correntista>>(json);

            return arr_correntistas;
        }

        /**
         * Deleta uma pessoa do banco de dados.
         */
        public static async Task<List<Correntista>> DeleteAsync(int id)
        {
            var json_a_enviar = JsonConvert.SerializeObject(id);

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/delete");

            List<Correntista> arr_correntistas = JsonConvert.DeserializeObject<List<Correntista>>(json);

            return arr_correntistas;
        }

    }
}
