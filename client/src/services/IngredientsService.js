import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class IngredientsService{
async setRecipeIngredientsByRecipeId(recipeId) {
const response = await api.get(`api/recipes/${recipeId}/ingredients`)
logger.log('ingredient response data', response.data)
AppState.activeRecipeIngredients = response.data.map(ingredientPOJO => new Ingredient(ingredientPOJO))
logger.log('mapped ingredients', AppState.activeRecipeIngredients)
}

}
export const ingredientsService = new IngredientsService()