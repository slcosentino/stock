import { base_api } from "../config/config";

export const setElement = async (element) => {
        
    const url = `${base_api}/stock`;

    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(element)
    };

    const response = await fetch(url, requestOptions);
   
    return  await response.json();

}