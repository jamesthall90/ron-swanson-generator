using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces.ReadModel;
using Infrastructure.Interfaces.WriteModel;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.RonSwansonQuote;
using Read.Queries.Quotes;
using Write.Commands;

namespace ron_swanson_generator.Controllers
{
    [Route("api/[controller]")]
    public class SwansonQuoteController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;

        public SwansonQuoteController(IQueryProcessor queryProcessor, ICommandDispatcher commandDispatcher)
        {
            _queryProcessor = queryProcessor;
            _commandDispatcher = commandDispatcher;
        }

        /// <summary>
        /// Returns the Ron Swanson quote
        /// corresponding to the input id
        /// </summary>
        /// <param name="id">Id of the quote to be retrieved</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        /// 
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
        /// 
        [HttpGet("GetRandomSingle")]
        public async Task<RonSwansonQuoteDetailDto> GetRandomSingle(CancellationToken token)
        {
            var query = new GetRandomSwansonQuoteQuery();
            return await _queryProcessor.Process(query, token);
        }

        /// <summary>
        /// Create a single new Ron Swanson quote
        /// </summary>
        /// <param name="input">Quote to create</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateSingle")]
        public async Task<RonSwansonQuoteDetailDto> CreateSingle(
            [FromBody] CreateRonSwansonQuoteInputDto input, CancellationToken token)
        {
            var command = new CreateRonSwansonQuoteCommand(input);
            return await _commandDispatcher.Execute(command, token);
        }

        /// <summary>
        /// Create a multiple new Ron Swanson quotes
        /// from an input list
        /// </summary>
        /// <param name="inputList">List of quotes to create</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        /// 
        [HttpPost("BulkCreate")]
        public async Task<List<RonSwansonQuoteDetailDto>> BulkCreate(
            [FromBody] List<CreateRonSwansonQuoteInputDto> inputList, CancellationToken token)
        {
            var command = new BulkCreateRonSwansonQuoteCommand(inputList);
            return await _commandDispatcher.Execute(command, token);
        }
    }
}