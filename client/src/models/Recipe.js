export class Recipe{
    constructor(data){
        this.id = data.id 
        this.timeCreatedAt = new Date(data.createdAt).toLocaleTimeString
        this.dateCreatedAt = new Date(data.createdAt).toLocaleDateString
        this.timeUpdatedAt = new Date(data.updatedAt).toLocaleTimeString
        this.dateUpdatedAt = new Date(data.updatedAt).toLocaleDateString
        this.title = data.title
        this.instructions = data.instructions
        this.imgUrl = data.img
        this.category = data.category
        this.creatorId = data.creatorId
        this.creator = data.creator
        this.subtitle = data.subtitle || this.subtitleIntro
    }

    get subtitleIntro(){
        let subtitle = this.instructions.substring(0, 20)
        return subtitle + ' ...'
    }
}