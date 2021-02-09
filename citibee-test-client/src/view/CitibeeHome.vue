<template>
  <div>
  <CitibeeMap :lijstParkeergarage='parkeergarages'></CitibeeMap>
  </div>
</template>

<script>
import CitibeeMap from '../components/CitibeeMap.vue'
import ParkeergarageService from '../services/ParkeergarageService'
    const parkeergarageService = new ParkeergarageService();
export default {
  name: 'CitibeeHome',
  data(){
    return{
        parkeergarages:[]
    }
  },
  components: {
    CitibeeMap
  },
 created(){
     var me =this;
    parkeergarageService.Parkeergarage().then((data)=>{
        me.parkeergarages = data.data.result
    })
 },
methods:{
 
}

}
</script>

<style>
 
</style>
