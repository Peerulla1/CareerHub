using CareerHub.Repository;
using CareerHub.Service;

namespace CareerHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carrerhub careerhub = new Carrerhub();


            HubService hubService = new HubService(careerhub);


            hubService.InsertJob();


            hubService.InsertCompany();


           // hubService.InsertApplicant();


            Console.ReadLine();
        }
    }
}
            
        