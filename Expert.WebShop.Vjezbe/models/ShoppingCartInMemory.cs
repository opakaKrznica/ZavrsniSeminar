﻿using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;



namespace Expert.WebShop.Vjezbe.models
{
    public class ShoppingCartInMemory   
    {
        private readonly HttpClient _httpClient;
        public  readonly NavigationManager navManager;

        public List<ShoppingCart>selectedItems { get; set; } = new ();   
        public ShoppingCartInMemory(HttpClient httpClient)   //konstruktor klase,prvo mu damo ime
        {
            _httpClient = httpClient; 

        }

     public async Task AddToShoppingCart(int productId, NavigationManager navManager)
        {
            if(selectedItems.FirstOrDefault(x => x.ProductId == productId) == null)
            { 
            var result= await _httpClient.GetAsync($"{Constants.BaseUrl}/Products/{productId}");

            if(result.IsSuccessStatusCode)  
            {
                var addProduct = await result.Content.ReadFromJsonAsync<Products>();
                ShoppingCart addToList= new ShoppingCart();
                addToList.Product = addProduct;
                    
                addToList.ProductId = addProduct.Id;//Id koji si procitao,postavi kao novi ProductId
                addToList.NumberOfItems = 1; //dodaj uvjek jedan item kad kliknes
                 
                                           
                selectedItems.Add(addToList);//dodajemo u selectedItems u tu listu

                navManager.NavigateTo("/");

            }
            }
        }
    }
}
