import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class FavoritesService{
    async getFavoritesByAccountId() {
        const response = await api.get('account/favorites')
        const accountFavorites = response.data.map(favPOJO => new Favorite(favPOJO))
        AppState.allAccountFavorites = accountFavorites
        logger.log('appstate account favorites', AppState.allAccountFavorites)
    }
    async createFavorite(recipeId) {
        const response = await api.post('api/favorites', {recipeId})
        logger.log('making fav',response.data)
        const newFavorite = new Favorite(response.data)
        AppState.allAccountFavorites.push(newFavorite)
        AppState.activeFavorite = newFavorite
        logger.log('making a fav', AppState.allAccountFavorites)
        }
    async removeFavorite(favoriteId) {
        const response = await api.delete(`api/favorites/${favoriteId}`)
        logger.log('removing fav', response.data)
        const index = AppState.allAccountFavorites.findIndex(fav => fav.favoriteId == favoriteId)
        AppState.allAccountFavorites.splice(index, 1)
    }

}

export const favoritesService = new FavoritesService()