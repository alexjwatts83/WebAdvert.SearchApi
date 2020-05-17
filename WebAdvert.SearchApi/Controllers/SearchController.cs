using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAdvert.SearchApi.Models;
using WebAdvert.SearchApi.Services;

namespace WebAdvert.SearchApi.Controllers
{
    [Route("search/v1")]
    [ApiController]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService, ILogger<SearchController> logger)
        {
            _searchService = searchService;
            _logger = logger;
        }

        public async Task<string> Index()
        {
            var now = DateTime.Now;
            return await Task.FromResult(now.ToString()).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{keyword}")]
        public async Task<List<AdvertType>> Get(string keyword)
        {
            //_logger.LogInformation("Search method was called");
            return await _searchService.Search(keyword).ConfigureAwait(false);
        }
    }
}