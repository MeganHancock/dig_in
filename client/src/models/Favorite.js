import { Recipe } from "./Recipe.js"

export class Favorite extends Recipe{
    constructor(data){
        super(data)
            // this.recipeId = data.recipeId
            this.favoriteId = data.favoriteId
            // this.createdAt = new Date(data.createdAt)
            // this.updatedAt = new Date(data.updatedAt)
        }
    }


// {
//     "recipeId": 0,
//     "favoriteId": 16,
//     "id": 13,
//     "createdAt": "2024-03-31T22:27:54",
//     "updatedAt": "2024-03-31T22:27:54",
//     "title": "cheese",
//     "instructions": "",
//     "img": "https://images.unsplash.com/photo-1627935722051-395636b0d8a5?q=80&w=873&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
//     "category": "cheese",
//     "creatorId": "65ea1327f93050d16317c396",
//     "creator": null
// }