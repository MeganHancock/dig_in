import App from "../App.vue"
import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService{
    async getRecipes() {
        // logger.log('recipes service')
        const response = await api.get('api/recipes')
        logger.log('response data', response.data)
        AppState.recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
        logger.log('mapped recipes', AppState.recipes)
    }
    async setActiveRecipe(recipeId) {
        const response = await api.get(`api/recipes/${recipeId}`)
        logger.log('response data', response.data)
        const foundRecipe = new Recipe(response.data)
        AppState.activeRecipe = foundRecipe
        logger.log('appstate recipe', AppState.activeRecipe)
    }

}
export const recipesService = new RecipesService()