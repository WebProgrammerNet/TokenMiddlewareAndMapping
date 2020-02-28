using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TokenMiddlewareAndMapping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // WebHost.Start("https://localhost:44318", httpcontext => httpcontext.Response.WriteAsync("Selamin Eleykum"));
            //using (var host = WebHost.Start("https://localhost:8080", httpcontext => httpcontext.Response.WriteAsync("Selamin Eleykum"))) {
            //    Console.WriteLine("Application has been Started");
            //    Console.ReadLine();
            //    host.WaitForShutdown();
            //}


            CreateWebHostBuilder(args).Build().Run();


            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //      .UseStartup<Startup>()
            //    .Build();
            //host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)//IWebHosBuilder
                .UseStartup<Startup>();
    }

    //WebHost.CreateDefaultBuilder(args) Static Method
    //Zdes ustanovlivaet kornevoy katalog qde WebHost budut iskat neobxodimie fayli
    //Kak Pravile eto katalog Proekta
    //Dannaya opciya nactoivaet configurachiya i Logirovaniye
    //Danniy method obecpecivaet integracciya IIS servera
    //S etom putem danniy method budut sozdavat IWebHostBuilder.
    //Potom Mu smojem Vizivat IWebHostBuildera Druqie methodi dlya initilizasiya Web Hosta.
    //V Nije Mi ispolzuem odin iz nix UseStartup. danniy method ustanovlivaet
    //Startuyu class Prilojeniya.
    //S pomosu methoda Build cozdayotsya Obyekt IWebHosBuilder;
    //V Methodo Main Vizivaetsya  CreateWebHostBuilder(args).Build().Run(); 
    //Kotoriy WebHostBuilder ot IWebHostBuilder -a.
    //V methode method run fakticeski vipuskaet prilojeniya.
    //I posle etovo methoda nasi prilojeniya qotovi prinimat i obrabotivat prilojeniya.
    //To ist tokim obrazom vipuskaetsya prilojeniya asp.netcore
    //Odnoka mi smojenm ispolzovat i druqie s[posiobi dly initilizasiya 

    //Danniy Slucae mi budim isopolzovat 2 servera
    // IISServer i Kestrel Server 
    //Danniyb Slucxae IIS budut vistupat v role proxy Servera 
    //Zapros budut idti 'po nachalo po IIS potom IIS budut perenapravlyat danniy 
    //zapros na Kestrel Server. To ist vse zamodeystvie budut .pereyti po servera IIS Seerver.
    //Potomu cto Kestrel ne smojet obespecivat BEZAPOASNOSTI ANd ADMINISTRIROVONIE
    //pOETOMU SAM WINDOWS PEREDLAQAET NAM - OE MESTO ISPOLZOVAT iis a NE cUSTOM.
    //potomu cto IIS Obecpecivaet Security AND Admistration.

}
