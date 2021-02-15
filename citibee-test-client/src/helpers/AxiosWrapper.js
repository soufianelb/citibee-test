/* eslint-disable */
import axios from 'axios';
import CitibeeStore from "../store/CitibeeStore";
export default class AxiosWrapper{
    constructor(){
      this.events=new function() {
        var _triggers = {};
  
        this.on = function(event,callback) {
            if(!_triggers[event])
                _triggers[event] = [];
            _triggers[event].push( callback );
          }
  
        this.triggerHandlerSuccess = function() {
            if( _triggers['successResponseResult'] ) {
                for(let i in _triggers['successResponseResult'] )
                    _triggers['successResponseResult'][i]();
            }

        }

        this.triggerHandlerError = function(data) {
            
            if( _triggers['errorResponseResult'] ) {
                for(let i in _triggers['errorResponseResult'] )
                    _triggers['errorResponseResult'][i](data);
            }
        }
      };
      
    }
  async Request(url, method, data){
        const options = {
            method: method,
            url:url,
            data: data
          };
          var me =this;
          CitibeeStore.commit('LaadPagina', true)
          return new Promise(function(resolve, reject){
            axios(options).then((resultaat)=>{
                console.log(resultaat)
                me.events.triggerHandlerSuccess('successResponseResult');
                CitibeeStore.commit('LaadPagina', false)
                resolve(resultaat.data);
            }).catch((err)=>{
                me.events.triggerHandlerError(err.response.data.responseException.exceptionMessage,'errorResponseResult');
                CitibeeStore.commit('LaadPagina', false)
                reject(err)
            })
    
          })

      
    }
 
}  