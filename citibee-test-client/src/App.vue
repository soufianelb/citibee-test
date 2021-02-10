<template>
  <Login v-if="gebruikerId == null" @aanmelden="Aangemeld"></Login>
  <CitibeeHome v-else></CitibeeHome>
</template>

<script>

import Login from './view/Login.vue'
import CitibeeHome from './view/CitibeeHome.vue'
 
 
export default {
  name: 'App',
  data(){
    return{
      //dit zou normaal gezien een token moeten zijn
      //Opslaan in localStorage maar in dit geval maak ik gebruik van op de state/Store om de gebruiker op te slaan
      //TODO via de state
      gebruikerId:null
    }
  },
  components: {
    Login,
    CitibeeHome
  },
 created(){
   if(this.$store.state.gebruiker!=null){
     this.gebruikerId =this.this.$store.state.gebruiker.id;
   }
 },
methods:{
  Aangemeld(value){
    console.log(value)
    this.gebruikerId = value.id
  this.$store.state.gebruiker =value;
  }
}

}
</script>

<style>
 
</style>
