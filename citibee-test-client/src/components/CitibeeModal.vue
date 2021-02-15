<template>
<div>
   <div class="modal" style="display: block;">
              <div class="modal-dialog">
                <div class="modal-content">
            
                  <div class="modal-header">
                    <h4 class="modal-title">{{reserveringItem.itemType.naam}}-{{reserveringItem.parkingnr}}</h4>
                    <button type="button" class="close" @click="$emit('sluit')" data-dismiss="modal">×</button>
                  </div>
                 
                  <div class="modal-body">
                    <div>
                        <label for="example-datepicker">Kies een Datum</label>
                        <b-form-datepicker :min="min" id="datepicker" v-model="geselecteerdeDag" class="mb-2"></b-form-datepicker>
                         
                        <label for="example-datepicker">Kies een Begintijd </label>
                        <b-form-timepicker id="begin-timepicker" v-model="begintijd" class="mb-2"></b-form-timepicker>
                        
                           
                        <label for="example-datepicker">Kies een Eindtijd </label>
                        <b-form-timepicker id="eind-timepicker" v-model="eindtijd" class="mb-2"></b-form-timepicker>
                    </div>
                      <button type="button" @click="CheckBeschikbaar()" class="btn btn-primary" data-dismiss="modal">Check</button><br>
                    <slot v-if="beschikbaar!=null">
                    <label>Er zijn beschikbare reservaties op deze tijdstip.</label>
                    <button type="button" @click="Reserveer()" class="btn btn-success" data-dismiss="modal">Bevestig</button>
                    </slot>
                  </div>
            
                  <div class="modal-footer">
                    <button type="button" @click="$emit('sluit')" class="btn btn-danger" data-dismiss="modal">Sluiten</button>
                  </div>
                </div>
              </div>
            </div>
 </div>
</template>

<script>
export default {
  name: "CitibeeModal",
  props:['reserveringItem'],
  components: {
    
  },     
  data() {
       const nu = new Date()
       const vandaag = new Date(nu.getFullYear(), nu.getMonth(), nu.getDate())
       const minDate = new Date(vandaag)
    return {
      geselecteerdeDag:null,
      begintijd:null,
      eindtijd:null,
      min:minDate,
      beschikbaar:null,
      checkBeschikbaarheid:{}
    };
  },
  methods:{
     CheckBeschikbaar(){
            var me =this;
            me.checkBeschikbaarheid={
            begintijd:new Date(this.geselecteerdeDag + ' ' + this.begintijd),
            eindtijd:new Date(this.geselecteerdeDag + ' ' + this.eindtijd),
            parkingId:me.reserveringItem.id
        };
        me.$ParkeergarageService.Beschikbaarheid(me.checkBeschikbaarheid).then((data)=>{
            console.log(data)
           me.beschikbaar = me.checkBeschikbaarheid
        }).catch((err)=>{console.log(err)})
      },

     Reserveer(){
         var me=this
         var gereserveerdeItemm={
             startDatum:this.checkBeschikbaarheid.begintijd,
             eindDatum:this.checkBeschikbaarheid.eindtijd,
             reserveringItemId:this.reserveringItem.id,
             //dit zou normaal gezien niet mogen: gebruiker mee geven via parameter, moet via token gaan 
             gebruikerId:this.$store.state.gebruiker.id
         }
           me.$ParkeergarageService.BevestigReservatie(gereserveerdeItemm).then((data)=>{
            console.log(data)
            me.$emit('sluit')
        }).catch((err)=>{console.log(err)})
      },

     }   

  
  
};
</script>
<style>
.modal-active{
	display:block;
}
</style>