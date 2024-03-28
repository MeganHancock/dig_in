<template>
    <div class="position-relative">
        <p class="label-decoration fw-bold rounded-3 position-absolute mt-2 ms-2 p-1">{{ recipe.category }}</p>
        <img :src="recipe.imgUrl" :alt="recipe.title">
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


export default {
    props: { recipe: { type: Recipe } },

    setup() {
        return {

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

// .title-label {
//     position: absolute;
//     top: -110px;
//     // right: 2;
//     width: 100%;
//     margin: 10;
//     // height: 100px;
// }</style>