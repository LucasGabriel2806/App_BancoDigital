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
        private static readonly string servidor = "http://10.0.2.2:8000";

        protected static async Task<string> GetDataFromService(string rota)
        {
            string json_response;

            string uri = servidor + rota;

            /**
             * utiliza a classe Connectivity do namespace Xamarin.Essentials 
             * para obter o estado atual da conectividade de rede.
             * 
             * Connectivity.NetworkAccess é uma propriedade estática da classe 
             * Connectivity que fornece informações sobre o estado da conectividade 
             * de rede. Ela retorna um valor do tipo NetworkAccess, que é uma 
             * enumeração que pode ter os seguintes valores:
               NetworkAccess.Unknown: Indica que o estado da conectividade 
               é desconhecido.
               NetworkAccess.None: Indica que não há nenhuma conectividade 
               de rede disponível.
               NetworkAccess.Local: Indica que há apenas conectividade de 
               rede local disponível.
               NetworkAccess.ConstrainedInternet: Indica que há conectividade 
               de rede, mas é limitada ou restrita.
               NetworkAccess.Internet: Indica que há conectividade de rede 
               à Internet disponível.
             */
            var current = Connectivity.NetworkAccess;


            if (current != NetworkAccess.Internet)
            {
                /**
                 * Nesse caso, o código lança uma exceção do tipo Exception 
                 * com a mensagem de erro "Por favor, conecte-se à Internet.".
                   Essa exceção pode ser capturada e tratada em outro local 
                   do código, permitindo que você tome medidas apropriadas 
                   quando não há conexão com a Internet, como exibir uma 
                   mensagem de erro ao usuário ou interromper a execução 
                   de determinada funcionalidade que requer conectividade 
                   com a Internet.
                 */
                throw new Exception("Por favor, conecte-se à Internet.");
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

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

            return json_response;
        }


        /**
         * Método que envia os dados para o servidor via post
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

            return json_response;
        }

        private static string DecodeServerError(System.Net.HttpStatusCode status_code)
        {
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
