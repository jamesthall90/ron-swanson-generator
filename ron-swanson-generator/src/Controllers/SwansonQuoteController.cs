using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces.ReadModel;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Read.Queries.Quotes;

namespace ron_swanson_generator.Controllers
{
    [Route("api/[controller]")]
    public class SwansonQuoteController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public SwansonQuoteController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }
        
        /// <summary>
        /// Returns the Ron Swanson quote
        /// corresponding to the input id
        /// </summary>
        /// <param name="id">Id of the quote to be retrieved</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        [HttpGet("GetSingle/{id}")]
        public async Task<RonSwansonQuoteDetailDto> GetSingle(int id, CancellationToken token)
        {
            var query = new GetSingleSwansonQuoteQuery(id);
            return await _queryProcessor.Process(query, token);
        }
        
        /// <summary>
        /// Generate a single, random Ron Swanson quote
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        [HttpGet("GetRandomSingle")]
        public async Task<RonSwansonQuoteDetailDto> GetRandomSingle(CancellationToken token)
        {
            var query = new GetRandomSwansonQuoteQuery();
            return await _queryProcessor.Process(query, token);
        }
    }
}