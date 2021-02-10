<template>
 <div class="tabel">
 <vuetable ref="vuetable"
  :api-mode="false"
  :fields="velden"
  :data="reserveringItem"
  :css="css.table"
></vuetable>
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
  }

};
</script>
<style>
.tabel{
   height: 100px; 
    width:100%;
    position: absolute;
    left: 14%;
    bottom: 0; 
    float:right;
    display: block;
    position:fixed;
    overflow-x: auto; 
    overflow-y: auto; 
    margin: 0 auto;
    white-space: nowrap
}
</style>
