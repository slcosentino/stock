import {elementTypes} from '../data/elementTypes'

export const getElementTypeById = (id) =>{   
    return elementTypes.find( elementType => parseInt(elementType.id) === parseInt(id));
}

 