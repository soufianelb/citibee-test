import Vue from 'vue'
import Vuex from 'vuex';
Vue.use(Vuex);

export default  new Vuex.Store({
    state: {
        gebruiker: null,
        parkingItems:null,
        zoekObject:{}
        
 
    },
    getters: {
        gebruiker: state => state.gebruiker,
        parkingItems: state => state.parkingItems,
        zoekObject:state=>state.zoekObject
    },

    actions: {
       
    },


    mutations: {
       
        SelecteerGarageMap(state, payload){
            state.parkingItems = payload

        },
        ZoekZoom(state, payload){
            state.zoekObject = payload
        }
    }
});

