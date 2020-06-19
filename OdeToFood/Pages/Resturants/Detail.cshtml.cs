using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeTofood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class DetailModel : PageModel
    {
        private readonly IResturantData resturantData;

        public Resturant Resturant { get; set; }
        public DetailModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public IActionResult OnGet(int resturantId)
        {
            Resturant = resturantData.GetById(resturantId);
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}