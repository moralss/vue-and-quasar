using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Data.Processes;
using RecipeApplication.Data.Artefact;
using RecipeApplication.Data.Artefact.Common;
using System.Net;
using RecipeApplication.Data.Artefact.Content;

namespace RecipeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RecipeController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> AddRecipes([FromBody] RecipeNew recipe)
        {
            try
            {
                var retVal = await ContentProcesses.CreateRecipeAsync(recipe);
                switch (retVal.State)
                {
                    case CallReturnState.Success:
                        return Ok(retVal);
                    case CallReturnState.Warning:
                    case CallReturnState.ValidationError:
                        return BadRequest(retVal.Errors);
                    case CallReturnState.Failure:
                        return StatusCode((int)HttpStatusCode.InternalServerError, retVal.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }


        [HttpPut]
        public void Put([FromBody] RecipeNew recipe)
        {

        }

    
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var retVal = await ContentProcesses.GetRecipe(id);
                switch (retVal.State)
                {
                    case CallReturnState.Success:
                        return Ok(retVal);
                    case CallReturnState.Warning:
                    case CallReturnState.ValidationError:
                        return BadRequest(retVal.Errors);
                    case CallReturnState.Failure:
                        return StatusCode((int)HttpStatusCode.InternalServerError, retVal.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return 
        }
}
