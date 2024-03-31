import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService{
    async getRecipes() {
        // logger.log('recipes service')
        const response = await api.get('api/recipes')
        // logger.log('response data', response.data)
        AppState.recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
        logger.log('mapped recipes', AppState.recipes)
    }
    setActiveRecipe(recipe) {
        AppState.activeRecipe = null
        AppState.activeRecipe = recipe
        // logger.log('active recipe', AppState.activeRecipe)
    }

    
}
export const recipesService = new RecipesService()