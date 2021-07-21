using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Api.Search.Interfaces;
using MicroServices.Api.Search.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Api.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody]SearchTerm searchTerm)
        {
            var result = await _searchService.Search(searchTerm.CustomerId);
            if (result.isSuccesfull)
            {
                return Ok(result.searchResult);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
