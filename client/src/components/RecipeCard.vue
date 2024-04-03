<template>

    <div @click="setActiveRecipe()" type="button" class="" data-bs-toggle="modal" data-bs-target="#recipeModal">

        <div class="position-relative">
            <p class="label-decoration fw-bold rounded-3 position-absolute mt-2 ms-2 p-1">{{ recipe.category }}</p>

        </div>
        <!-- <div class="position-relative">
            <i class="mdi mdi-heart-outline position-absolute mt-2 ms-2 p-1 right-0 fs-1"></i>

        </div> -->

        <img :src="recipe.img" :alt="recipe.title">
        <p class=" title-label label-decoration rounded-3"><b>{{ recipe.title
                }}</b><br>
            <span class="d-none d-md-block">
                {{ recipe.subtitle }}
            </span>
        </p>


    </div>

</template>


<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import { ingredientsService } from '../services/IngredientsService.js';
// import { Ingredient } from '../models/Ingredient.js';


export default {
    props: {
        recipe: { type: Recipe, required: true },
    },

    setup(props) {
        return {

            setActiveRecipe() {
                try {
                    recipesService.setActiveRecipe(props.recipe)
                    ingredientsService.getRecipeIngredientsByRecipeId(props.recipe.id)
                } catch (error) {
                    Pop.error(error)
                }
            },
        }
    }
}
</script>


<style lang="scss" scoped>
img {
    aspect-ratio: 1/1;
    max-width: 100%;
    object-fit: cover;
    height: 30vh;
}

.label-decoration {
    background-color: gray;
    color: white;
    max-width: auto;
}

a {
    border: none;
    color: transparent;
}
</style>