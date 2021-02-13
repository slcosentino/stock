import { base_api } from "../config/config";

export const getElements = async () => {
        
    const url = `${base_api}/stock`;

    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }        
    };
    
    try {

      const response = await fetch(url, requestOptions);  
      return await response.json();

    } catch (error) {        
        console.log(error);
        return [];
    }

    
        

    
}