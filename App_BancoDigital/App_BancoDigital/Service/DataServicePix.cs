using App_BancoDigital.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace App_BancoDigital.Service
{
    public class DataServicePix : DataService
    {
        /**
         * Envia um Pix
         * 
         * envia uma transação para um serviço remoto usando 
         * uma solicitação HTTP POST. Ela recebe um objeto 
         * Transacao como parâmetro e retorna um objeto Transacao 
         * como resultado
         * 
         * Essa função é útil para enviar uma transação para o serviço 
         * remoto e receber a resposta do servidor como um objeto 
         * Transacao. Ela usa a biblioteca Newtonsoft.Json (Json.NET) 
         * para serializar o objeto em uma string JSON e desserializar
         * a resposta JSON em um objeto Transacao. A função 
         * PostDataToService é responsável por enviar a solicitação 
         * HTTP POST e retornar a resposta JSON do serviço.
         */
        public static async Task<Transacao> EnviarAsync(Transacao t)
        {
            /**
             * Converte o objeto t em uma string JSON usando o 
             * método SerializeObject da classe JsonConvert. 
             * Isso é necessário para enviar o objeto no corpo 
             * da solicitação HTTP.
             */
            var json_a_enviar = JsonConvert.SerializeObject(t);

            /**
             * Chama o método PostDataToService da classe 
             * DataService, que envia a string JSON para o 
             * serviço remoto usando uma solicitação HTTP POST. 
             * O retorno dessa chamada é uma string JSON recebida 
             * como resposta do serviço.
             */
            string json = await DataService.PostDataToService(json_a_enviar, "/pix/enviar");

            /**
             * Converte a string JSON recebida em um objeto 
             * Transacao usando o método DeserializeObject da 
             * classe JsonConvert. Isso permite que o aplicativo 
             * trabalhe com o objeto Transacao retornado pelo serviço.
             */
            return JsonConvert.DeserializeObject<Transacao>(json);
        }


        /**
         * Recebe um Pix
         * 
         * recebe uma transação através de uma solicitação HTTP POST 
         * para um serviço remoto. Ela recebe um objeto Transacao como 
         * parâmetro e retorna um objeto Transacao como resultado.
         * 
         * Essa função é útil para receber uma transação do serviço 
         * remoto através de uma solicitação HTTP POST e retornar o 
         * objeto Transacao correspondente. Ela usa a biblioteca 
         * Newtonsoft.Json (Json.NET) para serializar o objeto em 
         * uma string JSON e desserializar a resposta JSON em um 
         * objeto Transacao. A função PostDataToService é responsável 
         * por enviar a solicitação HTTP POST e retornar a resposta 
         * JSON do serviço.
         */
        public static async Task<Transacao> ReceberAsync(Transacao t)
        {
            /**
             * Converte o objeto t em uma string JSON usando o método 
             * SerializeObject da classe JsonConvert. Isso é necessário 
             * para enviar o objeto no corpo da solicitação HTTP.
             */
            var json_a_enviar = JsonConvert.SerializeObject(t);

            /**
             * Chama o método PostDataToService da classe DataService, 
             * que envia a string JSON para o serviço remoto usando uma 
             * solicitação HTTP POST. O retorno dessa chamada é uma string 
             * JSON recebida como resposta do serviço.
             */
            string json = await DataService.PostDataToService(json_a_enviar,
                "/pix/receber");

            /**
             * Converte a string JSON recebida em um objeto Transacao 
             * usando o método DeserializeObject da classe JsonConvert. 
             * Isso permite que o aplicativo trabalhe com o objeto 
             * Transacao retornado pelo serviço.
             */
            return JsonConvert.DeserializeObject<Transacao>(json);
        }
    }
}
