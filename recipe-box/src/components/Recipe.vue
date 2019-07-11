<template>
  <div>
    <h2>
      <strong>recipe name :</strong>
      {{recipe.recipeName}}
    </h2>
    <p>{{recipe.ingredients}}</p>
    <button @click="removeRecipe(index)">delete</button>
    <button @click="changeIsEdited({index})">edit</button>
    <Edit v-if="recipe.isEdited" :recipe="recipe" :index="index"></Edit>
  </div>
</template>
<script>
import { mapMutations, mapActions } from "vuex";
import { TOGGLE_IS_EDIT } from "../store/types";
export default {
  name: "Recipe",
  props: ["recipe", "index"],

  methods: {
    ...mapActions(["removeRecipe"]),
    ...mapMutations({"changeIsEdited" : TOGGLE_IS_EDIT}),
    removeRecipe(index) {
      this.$store.dispatch("removeRecipe", index);
    }
  },
  components: {
    Edit: require("./Edit").default
  }
};
</script>
<style>
</style>
