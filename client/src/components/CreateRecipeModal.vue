<template>

    <!-- Modal -->
    <div class="modal fade" id="createRecipeFormModal" tabindex="-1" aria-labelledby="createRecipeFormModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-fullscreen-sm-down modal-lg">
            <div class="modal-content">
                <div class="modal-header modalhdr">
                    <h1 class="create-title">Create a recipe</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">

                    <form @submit="createRecipe()">
                        <div class="d-flex justify-content-between">
                            <div class="mb-3">
                                <label for="recipeTitle" class="form-label">Title</label>
                                <input v-model="editableRecipeData.title" type="string" class="form-control"
                                    id="recipeTitle" aria-describedby="recipeTitle" minlength="3" maxLength="50"
                                    required>
                            </div>

                            <div class="mb-3">
                                <label for="recipeSubtitle" class="form-label">Subtitle</label>
                                <input v-model="editableRecipeData.subtitle" type="string" class="form-control"
                                    id="recipeSubtitle" aria-describedby="recipeSubtitle" minlength="3" maxLength="50"
                                    required>
                            </div>
                        </div>

                        <div class="mb-3">
                            <label for="eventType" class="form-label">Recipe Category (select one)</label>
                            <select v-model="editableRecipeData.category" class="form-select" id="eventType"
                                aria-label="Floating label select example" required>
                                <option v-for="recipeCategory in recipeCategories" :key="recipeCategory"
                                    :value="recipeCategory">{{ recipeCategory }}</option>
                            </select>
                        </div>

                        <div class="mb-3">
                            <label for="recipeInstructions" class="form-label">Recipe Instructions</label>
                            <textarea v-model="editableRecipeData.instructions" type="string" class="form-control"
                                id="recipeInstructions" aria-describedby="recipeInstructions" minlength="1"
                                maxLength="1000" required></textarea>
                        </div>

                        <div class="mb-3">
                            <label for="recipeImageUrl" class="form-label">Recipe Image URL</label>
                            <input v-model="editableRecipeData.img" type="string" class="form-control"
                                id="recipeImageUrl" aria-describedby="recipeImageUrl" minlength="1" maxLength="1000"
                                required>
                        </div>
                        <div class="text-end">
                            <button type="button" class="btn me-3" data-bs-dismiss="modal">Close</button>
                            <button type="submit" class="btn btn-success">Submit</button>
                        </div>

                    </form>

                </div>
                <!-- <div class="modal-footer">
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div> -->
            </div>
        </div>
    </div>

</template>


<script>
import { ref } from 'vue'
// import { useRouter } from 'vue-router'
import Pop from '../utils/Pop.js'
import { recipesService } from '../services/RecipesService.js'
import { Modal } from 'bootstrap'


export default {
    setup() {
        // const router = useRouter()
        const editableRecipeData = ref({ title: '', category: '', subtitle: '', instructions: '', img: '' })
        return {
            editableRecipeData,
            recipeCategories: ['cheese', 'italian', 'soup', 'mexican', 'coffee'],

            async createRecipe() {
                try {
                    const newRecipe = await recipesService.createRecipe(editableRecipeData.value)
                    editableRecipeData.value = { title: '', category: '', subtitle: '', instructions: '', img: '' }
                    Modal.getOrCreateInstance('#createRecipeFormModal').hide()
                    Modal.getOrCreateInstance('#recipeModal').show()
                }
                catch (error) {
                    Pop.error(error);
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.modalhdr {
    background-color: green;
    ;
}

.create-title {
    background-color: green;
}
</style>