using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SSDLDotNetCore.RestApiWithNLayer.Features.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        public async Task<bl_Mmproverbs> GetDataFromApi()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
            if (!response.IsSuccessStatusCode) return null;

            string jsonStr = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<bl_Mmproverbs>(jsonStr);
            return model;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await GetDataFromApi();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("{titleName}")]
        public async Task<IActionResult> Get(string titleName)
        {
            var model = await GetDataFromApi();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null) return NotFound();

            var titleId = item.TitleId;
            var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);

            List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
            {
                TitleId = x.TitleId,
                ProverbId = x.ProverbId,
                ProverbName = x.ProverbName
            }).ToList();

            return Ok(lst);
        }

        [HttpGet("{TitleId}/{ProverbId}")]
        public async Task<IActionResult> Get(int TitleId, int ProverbId)
        {
            var model = await GetDataFromApi();
            var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == TitleId && x.ProverbId == ProverbId);

            return Ok(item);
        }

        public class bl_Mmproverbs
        {
            public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
            public Tbl_MmproverbsDetail[] Tbl_MMProverbs { get; set; }
        }

        public class Tbl_Mmproverbstitle
        {
            public int TitleId { get; set; }
            public string TitleName { get; set; }
        }

        public class Tbl_MmproverbsDetail
        {
            public int TitleId { get; set; }
            public int ProverbId { get; set; }
            public string ProverbName { get; set; }
            public string ProverbDesp { get; set; }
        }

        // Remove "ProverbDesp" property because we don't need this in this page or Api yet
        public class Tbl_MmproverbsHead
        {
            public int TitleId { get; set; }
            public int ProverbId { get; set; }
            public string ProverbName { get; set; }
        }
    }
}
