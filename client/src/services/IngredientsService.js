import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class IngredientsService{
async createIngredient(ingredientData, recipeId) {
ingredientData.recipeId = recipeId
// logger.log('ingredient data', ingredientData)
const response = await api.post('api/ingredients', ingredientData)
// logger.log('new ingredient frm api', response.data)
const newIngredient = new Ingredient(response.data)
AppState.activeRecipeIngredients.push(newIngredient)
}
async getRecipeIngredientsByRecipeId(recipeId) {
AppState.activeRecipeIngredients = null
const response = await api.get(`api/recipes/${recipeId}/ingredients`)
AppState.activeRecipeIngredients = response.data.map(ingredientPOJO => new Ingredient(ingredientPOJO))
}

}
export const ingredientsService = new IngredientsService()