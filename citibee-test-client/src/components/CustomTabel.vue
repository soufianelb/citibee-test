<template>
 <div class="tabel">
 <vuetable ref="vuetable"
  :api-mode="false"
  :fields="velden"
  :data="reserveringItem"
  :css="css.table">
 <template slot="actions" slot-scope="props">
      <div class="table-button-container">
          <button class="btn btn-success btn-sm" @click="Reserveer(props.rowData)">
            <span class="glyphicon glyphicon-calendar"></span>Reserveer</button>&nbsp;&nbsp;
      </div>
      </template>
</vuetable>
</div>
</template>

<script>
 import Vuetable from 'vuetable-2'
import VuetableCss from '../helpers/VuetableCss.js'
 import { mapState } from 'vuex';
export default {
  name: "CustomTabel",
  props:['velden'],
  components: {
    Vuetable
  },
  data() {
    return {
      reserveringItem:null,
      css:VuetableCss
    };
  },
  computed:mapState(['parkingItems']), 
  watch:{
      parkingItems(){
          this.$refs.vuetable.setData(this.$store.state.parkingItems)
      }
  },
  methods:{
       Reserveer(data){
          this.$emit('reserveer',data )
      }
  }

};
</script>
<style>
.tabel{
   height: 187px; 
    width:100%;
    position: absolute;
    
    bottom: 0px; 
    float:right;
    display: block;
    position:fixed;
    overflow-x: auto; 
    overflow-y: auto; 
     
    white-space: nowrap
}
</style>
