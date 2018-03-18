using System.Threading.Tasks;
using System.Web.Http;
using HarmonizationService.Pull;

namespace HarmonizationService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        protected void Application_Start()
        {
            var dataPuller = new DataPuller();
            // start background puller
            Task.Factory.StartNew(dataPuller.StartPulling);
                

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
