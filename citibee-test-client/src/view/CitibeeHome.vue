<template>
  <div>
   
  <Menubar :gebruiker='gebruiker'></Menubar>
  <CitibeeMap :lijstParkeergarage='parkeergarages'></CitibeeMap>
  <CustomTabel @reserveer="OpenModal" :velden="itemVelden" ></CustomTabel>
  </div>
</template>

<script>
 
import CitibeeMap from '../components/CitibeeMap.vue'
import Menubar from '../components/Menubar.vue'
 
import CustomTabel from '../components/CustomTabel.vue'
import ParkeergarageService from '../services/ParkeergarageService'
    const parkeergarageService = new ParkeergarageService();
export default {
  name: 'CitibeeHome',
  data(){
    return{
        parkeergarages:[],
        gebruiker:{},
        itemVelden:[{  name: 'actions',  title: 'Acties', titleClass: 'text-center',  dataClass: 'text-center', width: '15% ' },'itemType.naam','barcode', 'parkingnr']
    }
  },
  components: {
    CitibeeMap,
    Menubar,
  
    CustomTabel
  },
 created(){
     var me =this;
    parkeergarageService.Parkeergarage().then((data)=>{
        me.parkeergarages = data.data.result
    })
    me.gebruiker = this.$store.state.gebruiker;
 },
methods:{
      OpenModal(){//obj param
      //TODO open modal en reserveer een parking
        
      }
}

}
</script>

<style>
 
</style>
