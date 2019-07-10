<template>
  <div>
    <h2>
      <strong>recipe name :</strong>
      {{recipe.recipeName}}
    </h2>
      <p>{{recipe.ingredients}}</p>
    <button @click="removeRecipe(index)">delete</button>
    <button @click="isEdit = !isEdit"> edit </button>
    <Edit v-if="isEdit"
          :recipe="recipe"
          :index="index"
          v-on:edit_event="editRecipe"
     ></Edit>
  </div>
</template>
<script>
export default {
  name: 'Recipe',
  props: ['recipe' , 'index'],
  data(){
      return {
        isEdit : false,
      }
  },
  methods: {
  removeRecipe(index) {  
    this.$emit('remove_event', index)
  },
  editRecipe(recipeInfo){
      this.isEdit = false
      this.$emit('edit_event' , recipeInfo)
  }
},
  components: {
    Edit : require('./Edit').default,
 }
}
</script>
<style>
</style>
