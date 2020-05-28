using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonReadRepository _personReadRepository;
        private readonly IMediator _mediator;

        public PersonController(IPersonReadRepository personReadRepository, IMediator mediator)
        {
            _personReadRepository = personReadRepository;
            _mediator = mediator;
        }


        /// <summary>
        /// Lists all the persons
        /// </summary>
        /// <returns>A list of person</returns>
        /// <response code="200">All persons returned successfully</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _personReadRepository.GetAsync();
            return Ok(data);
        }

        /// <summary>
        /// Return the person by the id
        /// </summary>
        /// <returns>A person</returns>
        /// <response code="200">Person returned successfully</response>
        /// <response code="404">If there is no person with the id given or the if the id is 0</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:long}", Name = "GetPersonById")]
        public async Task<IActionResult> GetById(long id)
        {
            if (id == 0)
                return NotFound();

            var data = await _personReadRepository.GetById(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        /// <summary>
        /// Adds a new Person
        /// </summary>
        /// <remarks>
        /// Requistion example:
        ///     POST /Person
        ///  {
        ///      "name": "teste",
        ///      "familyName": "teste",
        ///      "address": "streetblabla",
        ///      "countryOfOrigin": "brazil",
        ///      "emailAdress": "test@test.com.br",
        ///      "age": 20,
        ///      "hired": true
        ///   }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>New person</returns>
        /// <response code="201">Returns the added person </response>
        /// <response code="400">In case of invalid request</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] May2020.Domain.Mediator.Person.Add.Request request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return CreatedAtRoute("GetPersonById", new { id = response.Result.Id }, response.Result);
        }

        /// <summary>
        /// Edits a person
        /// </summary>
        /// <remarks>
        /// Requistion example:
        ///     PUT /Person/{id}
        ///  {
        ///      "name": "teste",
        ///      "familyName": "teste",
        ///      "address": "streetblabla",
        ///      "age": 20,
        ///      "hired": true
        ///   }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>The edited person</returns>
        /// <response code="201">Returns the edited person </response>
        /// <response code="400">In case of invalid request</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, [FromBody] May2020.Domain.Mediator.Person.Update.Request request)
        {
            request.Id = id;
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        /// <summary>
        /// Delets a person
        /// </summary>
        /// <param name="id">Id of the person you want to delete</param>
        /// <returns></returns>
        /// <response code="200">Person deleted</response>
        /// <response code="400">In case that the id you passed is not related to any person</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var request = new May2020.Domain.Mediator.Person.Delete.Request();
            request.Id = id;
            var response = await _mediator.Send(request).ConfigureAwait(false);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok();
        }


    }
}
