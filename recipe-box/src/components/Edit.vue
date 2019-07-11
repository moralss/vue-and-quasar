<template>
  <div>
    <label for>recipeName</label>
    <input type="text" v-model="recipe.recipeName" placeholder="recipeName" />
    <label for>ingredient</label>
    <input type="text" v-model="recipe.ingredients" placeholder="ingredient" />
    <button @click="submitEditedRecipe(recipe.recipeName , recipe.ingredients)">submit</button>
  </div>
</template>
<script>
import { mapActions, mapMutations } from "vuex";
import { TOGGLE_IS_EDIT } from "../store/types";
export default {
  name: "Edit",
  props: ["recipe", "index"],
  methods: {
    ...mapActions(["editRecipe"]),
    ...mapMutations( [TOGGLE_IS_EDIT]),
    submitEditedRecipe(recipeName, ingredients) {
      this.$store.commit(TOGGLE_IS_EDIT, { index: this.index });
      const recipeInfo = { recipeName, ingredients, index: this.index };
      this.$store.dispatch("editRecipe", recipeInfo);
    }
  }
};
</script>
<style scoped>
</style>
