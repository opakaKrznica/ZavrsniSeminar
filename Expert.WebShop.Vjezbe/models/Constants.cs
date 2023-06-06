namespace Expert.WebShop.Vjezbe.models
{
    public static class Constants
    {
#if DEBUG

         //public static readonly string BaseUrl = "https://localhost:7247/api";
       public static readonly string BaseUrl = "https://expertshopapi.azurewebsites.net/api";

#else
        public static readonly string BaseUrl = "https://expertshopapi.azurewebsites.net/api";
#endif
        public static readonly string ErrorMessage = "Ups! Ima neka greška";
    }
}