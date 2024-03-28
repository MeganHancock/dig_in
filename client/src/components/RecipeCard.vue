<template>
    <p>{{ recipe }}
    </p>
</template>


<script>
import { Recipe } from '../models/Recipe.js';

export default {
    props: { recipe: { type: Recipe } },

    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped></style>