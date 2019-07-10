<template>
  <div>
      <label for="">recipeName</label>
      <input type="text" v-model="recipe.recipeName" placeholder="recipeName" />
      <label for="">ingredient</label>
      <input type="text"  v-model="recipe.ingredients" placeholder="ingredient" />
      <button @click="submitEditedRecipe(recipe.recipeName , recipe.ingredients)"> submit </button>
  </div>
</template>
<script>
export default {
  name: 'Edit',
  props:['recipe' ,'index'],
  data(){
    return {
        recipeName : "",
        ingredients: ""
    }
  },
  methods: {
  submitEditedRecipe(recipeName ,ingredients) {    
    this.isEditCompeleted = true;  
    this.recipeName = recipeName
    this.ingredients = ingredients
    const recipeInfo = {recipeName: this.recipeName , ingredients: this.ingredients , index: this.index};
    this.$emit('edit_event', recipeInfo)
  },
 }
}
</script>
<style scoped>
</style>
