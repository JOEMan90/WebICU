using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net;

namespace WebICU
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract, WebInvoke(UriTemplate = "/sum", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double sum(double x, double y);
    }//IWebsite

    public class Calculator:ICalculator
    {
        public double sum(double x, double y)
        {
            return x + y;
        }//sum
    }//Website

    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:7777/Calculator";
            WebServiceHost myHost = new WebServiceHost(typeof(Calculator), new Uri(baseAddress));
            Console.WriteLine("Starting web service...");
            myHost.Open();
            Console.WriteLine("Press any key to stop the process...");
            Console.ReadKey();
            myHost.Close();
            Console.WriteLine("The process has been stopped.");
        }
    }
}
