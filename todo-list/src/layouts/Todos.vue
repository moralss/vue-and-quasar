<template>
 
</template>

<script>
import { openURL } from 'quasar'

export default {
  name: 'Todos',
  data () {
    return {
      leftDrawerOpen: this.$q.platform.is.desktop
    }
  }
}
</script>

<style>
</style>
