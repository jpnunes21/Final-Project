using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{    
    public readonly IRecipeService _service;
    
    public RecipesController(IRecipeService service)
    {
        this._service = service;        
    }

    //Read
    [HttpGet]
    public IActionResult Get()
    {
        // throw new NotImplementedException();
        List<Recipe> response = _service.GetRecipes();

        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }

    //Read
    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {                
        // throw new NotImplementedException();
        Recipe response = _service.GetRecipe(name);

        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Create([FromBody]Recipe recipe)
    {
        // throw new NotImplementedException();
        if (recipe == null)
        {
            return BadRequest();
        }
        _service.AddRecipe(recipe);
        return CreatedAtRoute("/RecipesController", recipe);
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody]Recipe recipe)
    {
        // throw new NotImplementedException();
        Recipe recipeResponse = _service.GetRecipe(name);
        if (recipeResponse == null || recipe == null)
        {
            return BadRequest();
        }
        _service.UpdateRecipe(recipe);
        return NoContent();
    }

    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        // throw new NotImplementedException();
        Recipe recipe = _service.GetRecipe(name);
        if (recipe == null)
        {
            return NotFound();
        }
        _service.DeleteRecipe(name);
        return NoContent();
    }    
}
