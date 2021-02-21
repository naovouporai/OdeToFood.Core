using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;
using System;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }


        // testes meus que nada têm a ver com o projecto
        //public CuisineType Cuisine { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData,
                            ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogError("Executing ListModel");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);






            // testes meus que nada têm a ver com o projecto
            /*Message = "Cuisine Types: ";
            foreach (CuisineType cuisine in Enum.GetValues(typeof(CuisineType)))
            {
                Message += cuisine.ToString() + ", ";
            }*/


        }
    }
}
