import React, { useContext } from 'react'
import {deleteElement} from '../helpers/deleteElement'
import { UserContext } from './UserContext';

export const ListItem = ({id, name,type,expiredDate}) => {
       
    
    const {elements, setElements} = useContext(UserContext);    

    const handleDelete = async () => {
        await deleteElement(id);
        const elems =  elements.filter( x => x.id !== id)        
        setElements(elems);
    };

    return (
        <div className="media text-muted pt-3">

            
                <div className="col-md-1">
                {id}       
                </div>
                <div className="col-md-4">                    
                    {name}                    
                </div>
                <div className="col-md-3">
                    {type.name}
                </div>
                <div className="col-md-3">                    
                    {expiredDate}                    
                </div>
                <div className="col-md-1">
                    <button type="button" className="btn btn-danger" onClick={handleDelete}  >Delete</button>
                </div>

            

           
        </div>
    )
}
