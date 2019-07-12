import * as types from './types';

export const actions = { 
  addRecipe :  ({commit} , payload) => {
        commit(types.ADD_RECIPE , payload)
},

 removeRecipe : ({commit} , payload) => {
        commit(types.DELETE_RECIPE , payload)
},

  editRecipe : ({commit} , payload) => {
        commit(types.EDIT_RECIPE , payload)
 }
}
