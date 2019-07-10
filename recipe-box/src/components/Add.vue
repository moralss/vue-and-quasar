<template>
  <div>
      <label for="">Recipe Name</label>
      <input type="text" v-model="recipeName" placeholder="recipeName" />
      <label for="">Ingredient</label>
      <input type="text"  v-model="ingredients" placeholder="ingredient" />
      <button @click="addRecipe"> submit </button>
  </div>
</template>
<script>
export default {
  name: 'Add',
  data(){
    return {
        recipeName : "",
        ingredients: ""
    }
  },
  methods: {
  addRecipe() {    
    const recipe = {recipeName:this.recipeName , ingredients : this.ingredient};
    this.recipeName = "";
    this.ingredients = "";
    this.$emit('add_event', recipe)
  },
 }
}
</script>
<style >
</style>
