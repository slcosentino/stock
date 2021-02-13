import { base_api } from "../config/config";

export const deleteElement = async (id) => {

    const url = `${base_api}/stock/${id}`;

    const requestOptions = {
        method: 'DELETE',
        //headers: { 'Content-Type': 'application/json' },
        //body: 1
    };

    const response = await fetch(url, requestOptions);   
    
    return  await response.json();

}