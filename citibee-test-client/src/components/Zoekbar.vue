<template>
<div>
    <div class="zoekbar">
        <select v-model="geselecteerd" v-for='item in lijstparkings' :key='item.id' class="form-control form-control-xs selectpicker" name="" data-size="7" data-live-search="true" data-title="Location" id="state_list" data-width="100%">
                        <option v-bind:value='item' selected>{{item.naam}}</option>
                      </select>
    
    </div>
 <button type="button" @click="Zoekparking"  class="btn btn-primary zoeken" data-dismiss="modal">Zoek</button>
</div>
</template>

<script>
 
export default {
  name: "Zoekbar",
  components: {
    
  },     
  props:['lijstparkings'],
  data() {
    return {
      geselecteerd:null
    };
  },
  methods:{
      Zoekparking(){
        this.$store.commit('ZoekZoom', this.geselecteerd)
      }
  }
  

};
</script>
<style>
.zoekbar{
   height: 187px; 
    width:18%;
    position: absolute;
    
    top: 60px; 
    float:right;
    display: block;
    position:fixed;
 
}
.zoeken{
    
    position: absolute;
    left:300px;
    top: 60px; 
    float:right;
    position:fixed;
 
}
</style>