using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Data;
using RecipeAPI.Dtos;
using RecipeAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeAPI.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepo _repository;
        private readonly IMapper _mapper;
        public RecipeController(IRecipeRepo recipeRepo, IMapper mapper)
        {
            _repository = recipeRepo;
            _mapper = mapper;
        }

        // GET api/recipes
        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            // Synchronous
            //var allRecipes =  _repository.GetAllRecipes();
            //return allRecipes.ToList();

            IEnumerable<Recipe> allRecipes = await _repository.GetAllRecipes();

            var mappedResult = _mapper.Map<IEnumerable<RecipeReadDto>>(allRecipes);

            return StatusCode(200, new { status = "success", statusCode = 200, message = "Data successfully retrieved!", data = mappedResult });
        }

        // GET api/recipes/{id}
        [HttpGet("{id}", Name = "GetRecipeById")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var singleRecipe = await _repository.GetRecipeById(id);
            if (singleRecipe == null)
            {
                return StatusCode(404, new { status = "not found", statusCode = 404, message = $"Recipe with id {id} is not found!" });
            }

            var mappedRecipe = _mapper.Map<RecipeReadDto>(singleRecipe);

            return StatusCode(200, new { status = "success", statusCode = 200, message = "Data successfully retrieved!", data = mappedRecipe });
        }

        // POST api/recipes
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(RecipeCreateDto recipe)
        {
            var recipeModel = _mapper.Map<Recipe>(recipe);
            await _repository.CreateRecipe(recipeModel);
            await _repository.SaveChanges();

            //var convertRecipeToReadDto = _mapper.Map<RecipeReadDto>(recipeModel);

            var findCreatedRecipe = await _repository.GetRecipeById(recipeModel.Id);

            return CreatedAtRoute(nameof(GetRecipeById), new { Id = findCreatedRecipe.Id }, new { status = "created", statusCode = 201, message = "New data is successfully created!", data = findCreatedRecipe });

        }

        // DELETE api/recipes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeById(int id)
        {

            var recipe = await _repository.GetRecipeById(id);
            if (recipe == null)
            {
                return StatusCode(404, new { status = "not found", statusCode = 404, message = $"Recipe with id {id} is not found!" });
            }

            _repository.DeleteRecipe(recipe);
            await _repository.SaveChanges();

            return StatusCode(200, new { status = "success", statusCode = 200, message = $"Recipe with id {id} is succesfully deleted!", deletedRecipe = recipe });
        }

        // PUT api/recipes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipeByIdPut(int id, RecipeUpdateDto updatedRecipeData)
        {
            var recipeFromRepo = await _repository.GetRecipeById(id);
            if(recipeFromRepo == null)
            {
                return StatusCode(404, new { status = "not found", statusCode = 404, message = $"Recipe with id {id} is not found!" });
            }

            _mapper.Map(updatedRecipeData, recipeFromRepo);
            _repository.UpdateRecipe(recipeFromRepo);
            await _repository.SaveChanges();

            return StatusCode(200, new { status = "success", statusCode = 200, message = $"Recipe with id {id} is successfully updated with PUT method!" });

        }

        // PATCH api/recipes/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRecipeByIdPatch(int id, JsonPatchDocument<RecipeUpdateDto> patchRecipeData)
        {
            var recipeFromRepo = await _repository.GetRecipeById(id);
            if (recipeFromRepo == null)
            {
                return StatusCode(404, new { status = "not found", statusCode = 404, message = $"Recipe with id {id} is not found!" });
            }

            var recipeToBePatched = _mapper.Map<RecipeUpdateDto>(recipeFromRepo);
            patchRecipeData.ApplyTo(recipeToBePatched, ModelState);

            if (!TryValidateModel(recipeToBePatched))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(recipeToBePatched, recipeFromRepo);
            _repository.UpdateRecipe(recipeFromRepo);
            await _repository.SaveChanges();

            return StatusCode(200, new { status = "success", statusCode = 200, message = $"Recipe with id {id} is successfully updated with PATCH method!" });
        }
    }
}
