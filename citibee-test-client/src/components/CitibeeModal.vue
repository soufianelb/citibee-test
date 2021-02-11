<template>
<div>
   <div class="modal" style="display: block;">
              <div class="modal-dialog">
                <div class="modal-content">
                  <!-- Modal Header -->
                  <div class="modal-header">
                    <h4 class="modal-title">{{reserveringItem.itemType.naam}}-{{reserveringItem.parkingnr}}</h4>
                    <button type="button" class="close" @click="$emit('sluit')" data-dismiss="modal">×</button>
                  </div>
                  <!-- Modal body -->
                  <div class="modal-body">
                    <div>
                        <label for="example-datepicker">Kies een dag</label>
                        <b-form-datepicker id="example-datepicker" v-model="value" class="mb-2"></b-form-datepicker>
                         
                    </div>
                    <slot></slot>
                  </div>
                  <!-- Modal footer -->
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
    return {
      
    };
  }
  
};
</script>
<style>
.modal-active{
	display:block;
}
</style>