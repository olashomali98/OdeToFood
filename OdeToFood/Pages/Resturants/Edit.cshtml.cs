using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeTofood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private readonly IResturantData resturantData;
        private readonly IHtmlHelper htmlHelper;

        public Resturant Resturant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper )
        {
            this.resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int resturantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            Resturant = resturantData.GetById(resturantId);
            if(Resturant == null)
            {
                return RedirectToPage("./NotFound");

            }
            return Page();
        }

        public IActionResult OnPost()
        {
          Resturant= resturantData.Update(Resturant);
            resturantData.commit();
            return Page();
        }
        }
}