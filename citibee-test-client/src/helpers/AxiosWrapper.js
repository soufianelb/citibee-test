/* eslint-disable */
import axios from 'axios';
export default class AxiosWrapper{
    constructor(){
      
    }
    Request(url, method, data){
        const options = {
            method: method,
            url:url,
            data: data
          };
        axios(options).then((resultaat)=>{
            
            return resultaat.data.result
        }).catch((err)=>{
           
        })

    }
 
}  