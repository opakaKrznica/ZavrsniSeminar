using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;



namespace Expert.WebShop.Vjezbe.models
{
    public class ShoppingCartInMemory   
    {
        private readonly HttpClient _httpClient;
        public  readonly NavigationManager navManager;

        public List<ShoppingCart>selectedItems { get; set; } = new ();   // ovo je krace od- new List<Products>()
                                                                     // -on ga ovako prepozna
        public ShoppingCartInMemory(HttpClient httpClient)   //konstruktor klase,prvo mu damo ime
        {
            _httpClient = httpClient; 

        }

        /// <summary>
        /// Ovo je metoda za dodavanje u kosaricu
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
     public async Task AddToShoppingCart(int productId, NavigationManager navManager)
        {
            if(selectedItems.FirstOrDefault(x => x.ProductId == productId) == null)
            { 
            var result= await _httpClient.GetAsync($"https://expertshopapi.azurewebsites.net/api/Products/{productId}");

            if(result.IsSuccessStatusCode)  
            {
                var addProduct = await result.Content.ReadFromJsonAsync<Products>();
                ShoppingCart addToList= new ShoppingCart();
                addToList.Product = addProduct;
                    
                addToList.ProductId = addProduct.Id;//Id koji si procitao,postavi kao novi ProductId
                addToList.NumberOfItems = 1; //dodaj uvjek jedan item kad kliknes
                selectedItems.Add(addToList);//dodajemo u selectedItems u tu listu
                navManager.NavigateTo("/Admin/product-list");

            }
            }
        }
    }
}
