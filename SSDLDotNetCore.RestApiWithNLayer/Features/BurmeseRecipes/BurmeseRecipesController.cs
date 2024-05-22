using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using static SSDLDotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin.LatHtaukBayDinController;

namespace SSDLDotNetCore.RestApiWithNLayer.Features.BurmeseRecipes
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurmeseRecipesController : ControllerBase
    {
        public async Task<BurmeseRecipeList> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("BurmeseRecipes.json");
            var arrayJson = jsonStr.ToArray();
            var model = JsonConvert.DeserializeObject<BurmeseRecipeList>(jsonStr);
            return model;
        }
        [HttpGet()]
        public async Task<IActionResult> BurmeseRecipeMenu()
        {
            var model = await GetDataAsync();
            return Ok(model.BurmeseRecipe);
        }

        //[HttpGet("{guid}")]
        //public async Task<IActionResult> Detail(string guid)
        //{
        //    var model = await GetDataAsync();
        //    return Ok(model.BurmeseRecipe.FirstOrDefault(x => x.Guid == guid));
        //}

        [HttpGet("{UserEngType}")]
        public async Task<IActionResult> GetBurmeseRecipeByType(string UserEngType)
        {
            var model = await GetDataAsync();
            var item = model.UserTypes.FirstOrDefault(x => x.UserEngType == UserEngType);
            if (item is null) return NotFound();

            var UserCode = item.UserCode;
            var lst = model.BurmeseRecipe.Where(x => x.UserType == UserCode);
            return Ok(lst);
        }

        public class BurmeseRecipeList
        {
            public BurmeseRecipe[] BurmeseRecipe { get; set; }
            public Usertype[] UserTypes { get; set; }
        }

        public class BurmeseRecipe
        {
            public string Guid { get; set; }
            public string Name { get; set; }
            public string Ingredients { get; set; }
            public string CookingInstructions { get; set; }
            public string UserType { get; set; }
        }

        public class Usertype
        {
            public int UserId { get; set; }
            public string UserCode { get; set; }
            public string UserMMType { get; set; }
            public string UserEngType { get; set; }
        }


    }
}
