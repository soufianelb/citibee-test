<template>
  <div>
  <Menubar :gebruiker='gebruiker'></Menubar>
  <Zoekbar @reset="ResetMapTabel" :lijstparkings='parkeergarages'></Zoekbar>
  <CitibeeMap :mapsParams="paramsMap" :lijstParkeergarage='parkeergarages'></CitibeeMap>
  <CustomTabel @reserveer="OpenModal" :velden="itemVelden" ></CustomTabel>
  <CitibeeModal :reserveringItem="selectieReservering" @sluit="Sluiten" v-if="isOpenModal==true"></CitibeeModal>
  </div>
</template>

<script>
import Zoekbar from '../components/Zoekbar.vue'
import CitibeeMap from '../components/CitibeeMap.vue'
import Menubar from '../components/Menubar.vue'
import CitibeeModal from '../components/CitibeeModal.vue'
import CustomTabel from '../components/CustomTabel.vue'
export default {
  name: 'CitibeeHome',
  data(){
    return{
        paramsMap:{},
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
    CustomTabel,
    Zoekbar
  },
  created(){
     var me =this;
     me.paramsMap = {
      url: "https://{s}.tile.osm.org/{z}/{x}/{y}.png",
      zoom: 9,
      center: [51.2103889,4.425369,13],
      bounds: null
     }
    me.$ParkeergarageService.Parkeergarage().then((data)=>{
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
      },
      ResetMapTabel(){
        this.paramsMap = {
          url: "https://{s}.tile.osm.org/{z}/{x}/{y}.png",
          zoom: 10,
          center: [51.2103889,4.425369,13],
          bounds: null
         }
         this.$store.commit('SelecteerGarageMap', ""  )
      }
}

}
</script>

<style>
 
</style>
