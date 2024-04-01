<template>

  <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModal" aria-hidden="true">
    <div class="modal-dialog modal-xl w-100">
      <div v-if="activeRecipe" class="modal-content">
        <!-- <div class="modal-header">
          <h1 class="modal-title fs-5" id="recipeModalLabel">{{ activeRecipe.title }}</h1>
        </div> -->
        <div class="modal-body p-0 d-flex ">

          <img :src="activeRecipe.img" :alt="activeRecipe.title" class="m-0 rounded-start w-50">
          <div class="m-1 d-flex-column pt-3 mx-auto">

            <h4 class="text-center">{{ activeRecipe.title }}</h4>

            <div class="card m-1 p-1">
              <h5>Instructions</h5>

              <form @submit.prevent="saveEditedInstructions(activeRecipe.id)" v-if="activeRecipeEditing"
                class="d-flex align-items-end">
                <textarea v-model="editableInstructionData.instructions" name="instructions" id="editInstructions"
                  cols="35" rows="3"></textarea>
                <button type="submit" class="btn btn-success ms-3 mb-0">+</button>
              </form>
              <p v-else>
                {{ activeRecipe.instructions }}
              </p>
              <div class="d-flex justify-content-end">
                <button @click="setActiveInstructionsEditing(activeRecipe.id)"
                  v-if="activeRecipe.creatorId = account.id && !activeRecipeEditing"
                  class="btn btn-success ms-3">Edit</button>
              </div>

            </div>


            <!-- NOTE INGREDIENTS CARD AND FORM -->
            <div class="card m-1 p-1">
              <h5>Ingredients</h5>
              <ul v-for="ingredient in activeRecipeIngredients" :key="ingredient.id"
                class="d-flex justify-content-between">
                <li>
                  {{ ingredient.name }} - {{ ingredient.quantity }}
                </li>
                <button @click="removeIngredient(ingredient.id)" type="button" class="border-0 text-danger bg-white"
                  title="remove ingredient from list">X</button>
              </ul>
              <div v-if="activeRecipe.creatorId = account.id">
                <form @submit="createIngredient(activeRecipe.id)" class="d-flex">
                  <div class="input-group m-1">
                    <input v-model="editableIngredientData.name" type="text" class="form-control w-" placeholder="Name"
                      aria-label="addIngredient" aria-describedby="button-addon2" required>
                  </div>
                  <div class="input-group m-1">
                    <input v-model="editableIngredientData.quantity" type="text" class="form-control"
                      placeholder="Quantity" aria-label="Recipient's username" aria-describedby="button-addon2">
                    <button class="btn btn-outline-secondary" type="submit" id="button-addon2" required>+</button>
                  </div>
                </form>
              </div>

            </div>

          </div>
        </div>

        <!-- NOTE FOOTER BUTTONS -->
        <div class="modal-footer d-flex justify-content-between">
          <div v-if="activeRecipe.creatorId = account.id">
            <button @click="removeRecipe(activeRecipe.id)" class="btn btn-warning" type="button">Delete Recipe</button>
          </div>
          <div class="d-flex">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary" title="Favorite this recipe"><i
                class="mdi mdi-heart"></i></button>
          </div>
        </div>
      </div>


    </div>
  </div>


</template>


<script>
import { computed, onMounted, ref, watch } from 'vue';
import { AppState } from '../AppState.js';
import { ingredientsService } from '../services/IngredientsService.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { Modal } from 'bootstrap';


export default {
  setup() {
    const editableInstructionData = ref({ instructions: '' })
    const editableIngredientData = ref({ name: '', quantity: '' })
    const activeRecipe = computed(() => AppState.activeRecipe)
    watch(activeRecipe, () => { editableInstructionData.value = { ...activeRecipe.value } }, { immediate: true })

    return {
      activeRecipeEditing: computed(() => AppState.activeRecipeEditing),
      activeRecipeIngredients: computed(() => AppState.activeRecipeIngredients),
      account: computed(() => AppState.account),
      editableIngredientData,
      editableInstructionData,
      activeRecipe,

      async removeRecipe(recipeId) {
        try {
          const wantsToRemove = await Pop.confirm('Are you sure you would like to delete this recipe?')

          if (!wantsToRemove) {
            return
          }

          await recipesService.removeRecipe(recipeId)
          Pop.success('Recipe has been removed.')

        }
        catch (error) {
          Pop.error(error);
        }
      },

      async removeIngredient(ingredientId) {
        try {
          const wantsToRemove = await Pop.confirm('Are you sure you would like to remove this ingredient?')
          if (!wantsToRemove) {
            return
          }
          await ingredientsService.removeIngredient(ingredientId)
          Pop.success('Ingredient has been removed')
          Modal.getOrCreateInstance('#recipeModal').hide()

        }
        catch (error) {
          Pop.error(error);
        }
      },

      async createIngredient(recipeId) {
        try {
          const newIngredient = await ingredientsService.createIngredient(editableIngredientData.value, recipeId)
          editableIngredientData.value = { name: '', quantity: '' }
        }
        catch (error) {
          Pop.error(error);
        }
      },

      setActiveInstructionsEditing(activeRecipeId) {
        recipesService.setActiveInstructionsEditing(activeRecipeId)
      },

      async saveEditedInstructions(recipeId) {
        try {
          await recipesService.saveEditedInstructions(editableInstructionData.value, recipeId)
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
img {
  // max-height: 50vh;
  // max-width: 100;
  aspect-ratio: 1/1.4;
  object-fit: cover;
}

textarea {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
  width: 100%
}
</style>