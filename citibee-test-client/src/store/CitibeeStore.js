import Vue from 'vue'
import Vuex from 'vuex';
Vue.use(Vuex);

export default  new Vuex.Store({
    state: {
        gebruiker: null,
        parkingItems:null,
        
 
    },
    getters: {
        gebruiker: state => state.gebruiker,
        parkingItems: state => state.parkingItems,
    },

    actions: {
       
    },


    mutations: {
       
        SelecteerGarageMap(state, payload){
            console.log(payload)
            state.parkingItems = payload

        }
    }
});

