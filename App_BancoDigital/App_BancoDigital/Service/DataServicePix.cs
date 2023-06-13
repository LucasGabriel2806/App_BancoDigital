using App_BancoDigital.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace App_BancoDigital.Service
{
    public class DataServicePix : DataService
    {
        /**
         * Envia um Pix
         */
        public static async Task<Transacao> EnviarAsync(Transacao t)
        {
            var json_a_enviar = JsonConvert.SerializeObject(t);

            string json = await DataService.PostDataToService(json_a_enviar, "/pix/enviar");

            return JsonConvert.DeserializeObject<Transacao>(json);
        }


        /**
         * Recebe um Pix
         */
        public static async Task<Transacao> ReceberAsync(Transacao t)
        {
            var json_a_enviar = JsonConvert.SerializeObject(t);

            string json = await DataService.PostDataToService(json_a_enviar, "/pix/receber");

            return JsonConvert.DeserializeObject<Transacao>(json);
        }
    }
}
