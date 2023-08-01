using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App_BancoDigital.Service
{
    public class DataService
    {
        /**
         * Servidor:
         */
        private static readonly string servidor = "http://10.0.2.2:8000";
        /**
         * rota: rota para o qual uma 
         * solicitação HTTP GET será feita.
         * 
         * Essa função faz solicitações GET a um serviço remoto.
         * obtem dados em JSON e retorna resposta em string, etc.
         */
        protected static async Task<string> GetDataFromService(string rota)
        {
            /**
             * armazenar a resposta JSON recebida do serviço.
             */
            string json_response;
            /**
             * formar a URL completa para a solicitação HTTP.
             */
            string uri = servidor + rota;

            /**
             * Connectivity.NetworkAccess é uma propriedade estática 
             * que fornece informações sobre o estado da conectividade 
             * de rede. Para saber mais sobre valores retornados, pesquisar.
             */
            var current = Connectivity.NetworkAccess;

            /**
             * Verifica se há conexão a internet disponivel.
             */
            if (current != NetworkAccess.Internet)
            {
                throw new Exception("Por favor, conecte-se à Internet.");
            }

            /**
             * HttpClient, é uma classe usada para enviar solicitações HTTP.
             */
            using (HttpClient client = new HttpClient())
            {
                /**
                 *  Faz uma solicitação HTTP GET assíncrona para 
                 *  a URL especificada e aguarda a resposta.
                 */
                HttpResponseMessage response = await client.GetAsync(uri);

                /**
                 *  Imprime o conteúdo da resposta no console.
                 */
                Console.WriteLine("_______________________________");
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("_______________________________");

                /**
                 * Verifica se a resposta foi bem-sucedida com base no código 
                 * de status HTTP.
                 */

                if (response.IsSuccessStatusCode)
                {
                    json_response = response.Content.ReadAsStringAsync().Result;
                }
                else
                    /**
                    * Se a resposta não for bem-sucedida (código de status 
                    * diferente de 200), é lançada uma exceção contendo uma 
                    * mensagem de erro gerada pela função DecodeServerError, 
                    * que decodifica o código de status HTTP em uma mensagem 
                    * legível para o usuário.
                    */
                    throw new Exception(DecodeServerError(response.StatusCode));
            }
            /** Retorna a resposta JSON como uma string. */
            return json_response;
        }


        /**
         * Método que envia os dados para o servidor via post
         * json_object, representa o objeto JSON a ser 
         * enviado no corpo da solicitação, e rota, que 
         * indica a rota ou caminho 
         * para o qual a solicitação será feita.
         */
        protected static async Task<string> PostDataToService(string json_object, string rota)
        {
            
            string json_response;
            
            string uri = servidor + rota;

            
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                throw new Exception("Por favor, conecte-se à Internet.");
            }

            using (HttpClient client = new HttpClient())
            {
                /**
                 * Realiza uma solicitação HTTP POST assíncrona para 
                 * a URL especificada. O StringContent é usado para 
                 * fornecer o objeto JSON como conteúdo da solicitação. 
                 * É especificado que o conteúdo é do tipo 
                 * "application/json" usando a codificação UTF-8.
                 */
                HttpResponseMessage response = await client.PostAsync(
                    uri,
                    new StringContent(json_object, Encoding.UTF8, "application/json")
                );

                
                Console.WriteLine("_______________________________");
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("_______________________________");

                if (response.IsSuccessStatusCode)
                {
                    json_response = response.Content.ReadAsStringAsync().Result;
                }
                else
                    throw new Exception(DecodeServerError(response.StatusCode));
            }
            /**
             * Retorna a resposta JSON como uma string.
             */
            return json_response;
        }

        /**
         * Essa função é um método responsável por decodificar o código de status 
         * HTTP recebido e retornar uma mensagem de erro correspondente.
         */
        private static string DecodeServerError(System.Net.HttpStatusCode status_code)
        {
            /**
             * armazenar msg de erro correspondente 
             * ao código de status HTTP recebido.
             */
            string msg_erro;

            switch (status_code)
            {
                
                case System.Net.HttpStatusCode.BadRequest:
                    msg_erro = "A requisição não pode ser atendida agora. Tente mais tarde.";
                    break;

                case System.Net.HttpStatusCode.NotFound:
                    msg_erro = "Recurso indisponível no momento. Tente mais tarde.";
                    break;

                case System.Net.HttpStatusCode.InternalServerError:
                    msg_erro = "Nosso banco de dados está indisponível. Tente mais tarde.";
                    break;
               
                case System.Net.HttpStatusCode.RequestTimeout:
                    msg_erro = "O servidor está demorando muito para responder. Tente novamente.";
                    break;

                case System.Net.HttpStatusCode.Forbidden:
                    msg_erro = "Recurso temporariamente indisponível. Tente mais tarde.";
                    break;

                default:
                    msg_erro = "Estamos com dificuldades para acessar nosso servidor, tente novamente.";
                    break;
            }

            return msg_erro;

        }
    }
}
