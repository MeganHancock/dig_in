export class Ingredient{
    constructor(data){
        this.id = data.id
        this.timeCreatedAt = new Date(data.createdAt).toLocaleTimeString
        this.dateCreatedAt = new Date(data.createdAt).toLocaleDateString
        this.timeUpdatedAt = new Date(data.updatedAt).toLocaleTimeString
        this.dateUpdatedAt = new Date(data.updatedAt).toLocaleDateString
        this.name = data.name
        this.quantity = data.quantity
        this.recipeId = data.recipeId
    }
}