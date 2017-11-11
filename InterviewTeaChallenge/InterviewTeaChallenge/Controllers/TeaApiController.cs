using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JO.InterviewTeaChallenge.Data.Models;
using JO.InterviewTeaChallenge.Core.Services.Interfaces;
using JO.InterviewTeaChallenge.Core.SafeExceptions;
using JO.InterviewTeaChallenge.WebApi.Responses;
using System.Net;
using JO.InterviewTeaChallenge.WebApi.Controllers;
using JO.InterviewTeaChallenge.WebApi.ViewModels;

namespace InterviewTeaChallenge.Controllers
{
    [Route("api/v1/[controller]")]
    public class TeaApiController : BaseController
    {
        private readonly ITeaService _teaService;
        public TeaApiController(ITeaService teaService)
        {
            _teaService = teaService;
        }

        // GET api/v1/Tea
        [HttpGet("/tea")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var teas = await _teaService.GetTeasAsync();

                if (teas == null) return NotFound();

                return Ok(new TeasResponse()
                {
                    Teas = teas,
                });
            }
            catch (Exception ex)
            {
                var tea = new TeasResponse();

                tea.IsSuccess = false;
                tea.Errors = GetErrors(ex, tea.Errors);

                return StatusCode((int) HttpStatusCode.InternalServerError, tea);
            }
        }

        // GET api/values/5
        [HttpGet("/tea/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var tea = await _teaService.GetTeaAsync(id);

                if (tea == null) throw new NotFoundException();


                return Ok(new TeaResponse()
                {
                    Tea = tea,
                });
            }
            catch (NotFoundException ex)
            {
                var tea = new TeaResponse();

                tea.IsSuccess = false;
                tea.Errors = GetErrors(ex, tea.Errors);
                return NotFound(tea);
            }
            catch (Exception ex)
            {
                var tea = new TeaResponse();

                tea.IsSuccess = false;
                tea.Errors = GetErrors(ex, tea.Errors);

                return StatusCode((int)HttpStatusCode.InternalServerError, tea);
            }
        }

        // POST api/values
        [HttpPost("/tea")]
        public async Task<IActionResult> Post([FromBody]CreateTeaViewModel createTeaViewModel)
        {
            try
            {
                var newTeaId = await _teaService.CreateTeaAsync(createTeaViewModel.Name, createTeaViewModel.RequiresMilk);

                var tea = await _teaService.GetTeaAsync(newTeaId);

                return Ok(new TeaResponse()
                {
                    Tea = tea,
                });
            }
            catch (Exception ex)
            {
                var tea = new TeaResponse();

                tea.IsSuccess = false;
                tea.Errors = GetErrors(ex, tea.Errors);

                return StatusCode((int)HttpStatusCode.InternalServerError, tea);
            }
        }

        // PUT api/values/5
        [HttpPut("/tea/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]UpdateTeaViewModel updateTeaViewModel)
        {
            try
            {
                await _teaService.UpdateTeaAsync(id, updateTeaViewModel.Name, updateTeaViewModel.RequiresMilk);

                var tea = await _teaService.GetTeaAsync(id);

                if (tea == null) return NotFound();

                return Ok(new TeaResponse()
                {
                    Tea = tea,
                });
            }
            catch (NotFoundException ex)
            {
                var tea = new TeaResponse();

                tea.IsSuccess = false;
                tea.Errors = GetErrors(ex, tea.Errors);
                return NotFound(tea);
            }
            catch (Exception ex)
            {
                var tea = new TeaResponse();

                tea.IsSuccess = false;
                tea.Errors = GetErrors(ex, tea.Errors);

                return StatusCode((int)HttpStatusCode.InternalServerError, tea);
            }
        }

        // DELETE api/values/5
        [HttpDelete("/tea/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _teaService.DeleteTeaAsync(id);

                return Ok(new TeaResponse()
                {
                    Tea = null,
                });
            }
            catch (Exception ex)
            {
                var tea = new TeaResponse();

                tea.IsSuccess = false;
                tea.Errors = GetErrors(ex, tea.Errors);

                return StatusCode((int)HttpStatusCode.InternalServerError, tea);
            }
        }
    }
}
