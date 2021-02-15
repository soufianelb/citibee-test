/* eslint-disable */
import axios from 'axios';
export default class ParkeergarageService{
    constructor(axios){
     this.axiosWrapper = axios;
    }
 
    Parkeergarage() {
        const options = {
          method: 'GET',
          url:`${process.env.VUE_APP_URLAPI}Parkeergarage`
         
        };
      return  axios(options) 
       
    }
 
    ReserveringItems(id) {
      const options = {
        method: 'GET',
        url:`${process.env.VUE_APP_URLAPI}Reserveringitem/Garage?garage=${id}`
       
      };
    return  axios(options) 
     
    }

    Beschikbaarheid(zoekobj) {
    const options = {
      method: 'POST',
      url:`${process.env.VUE_APP_URLAPI}Reserveringitem/CheckBeschikbaar`,
      data:zoekobj
     
    };
  return  axios(options) 
   
  }
    BevestigReservatie(obj){
      const options = {
        method: 'POST',
        url:`${process.env.VUE_APP_URLAPI}Reserveringitem/Reserveren`,
        data:obj
       
      };
    return  axios(options) 
    }
 
}  