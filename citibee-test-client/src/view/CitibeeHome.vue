<template>
  <div>
   
  <Menubar :gebruiker='gebruiker'></Menubar>
  <CitibeeMap :lijstParkeergarage='parkeergarages'></CitibeeMap>
  <CustomTabel @reserveer="OpenModal" :velden="itemVelden" ></CustomTabel>
  <CitibeeModal :reserveringItem="selectieReservering" @sluit="Sluiten" v-if="isOpenModal==true"></CitibeeModal>
  </div>
</template>

<script>
 
import CitibeeMap from '../components/CitibeeMap.vue'
import Menubar from '../components/Menubar.vue'
import CitibeeModal from '../components/CitibeeModal.vue'
import CustomTabel from '../components/CustomTabel.vue'
import ParkeergarageService from '../services/ParkeergarageService'
    const parkeergarageService = new ParkeergarageService();
export default {
  name: 'CitibeeHome',
  data(){
    return{
        isOpenModal:false,
        parkeergarages:[],
        gebruiker:{},
        selectieReservering:{},
        itemVelden:[{  name: 'actions',  title: 'Acties', titleClass: 'text-center',  dataClass: 'text-center', width: '15% ' },'itemType.naam','barcode', 'parkingnr']
    }
  },
  components: {
    CitibeeMap,
    Menubar,
    CitibeeModal,
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
      OpenModal(data){
       this.selectieReservering = data
        this.isOpenModal = true;
      },
      Sluiten(){
        this.selectieReservering ={};
        this.isOpenModal = false;
      }
}

}
</script>

<style>
 
</style>
