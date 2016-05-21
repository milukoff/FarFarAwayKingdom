using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace emulatorCasketWish
{
    public static class WebApiClient
    {
        public static ResponseStatus GetStatus(string Url, out string ErrorMessage)
        {
            ErrorMessage = null;
            ResponseStatus responseStatus = new ResponseStatus();
            if (!string.IsNullOrEmpty(Url))
            {
                Uri Uri = new Uri(Url);
                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = client.GetAsync(Uri).Result;
                        var result = response.Content.ReadAsStringAsync().Result;
                        responseStatus = JsonConvert.DeserializeObject<ResponseStatus>(result);
                    }
                    catch (Exception ex)
                    {
                        Logger.AppendLineToLog("Ошибка обращения к сайту");
                        Logger.AppendLineToLog(ex.Message);
                        ErrorMessage = "Ошибка обращения к сайту, возможно он выключен, обратитсь в Тридевятое царство";
                    }
                }
            }
            return responseStatus;
        }
    }
}
