import Vue from 'vue'
import Vuex from 'vuex';
Vue.use(Vuex);

export default  new Vuex.Store({
    state: {
        gebruiker: null,
        
 
    },
    getters: {
        gebruiker: state => state.gebruiker,
    },

    actions: {
       
    },


    mutations: {
       
    }
});

