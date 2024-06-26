namespace dig_in.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;
    private readonly Auth0Provider _auth0Provider;
    private readonly IngredientsService _ingredientsService;

    public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider, IngredientsService ingredientsService)
    {
        _recipesService = recipesService;
        _auth0Provider = auth0Provider;
        _ingredientsService = ingredientsService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = _recipesService.CreateRecipe(recipeData);
            return recipe;
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }

    }


    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
        try
        {
            List<Recipe> recipes = _recipesService.GetAllRecipes();
            return Ok(recipes);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipesService.GetRecipeById(recipeId);
            return Ok(recipe);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


    [HttpDelete("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<string>> DestroyRecipe(int recipeId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _recipesService.DestroyRecipe(recipeId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


    [HttpPut("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId, [FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Recipe recipe = _recipesService.UpdateRecipe(recipeId, userInfo.Id, recipeData);
            return Ok(recipe);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }

    }

    // NOTE ingredient http requests

    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
    {
        try
        {
            List<Ingredient> ingredient = _ingredientsService.GetIngredientsByRecipeId(recipeId);
            return ingredient;
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


}

