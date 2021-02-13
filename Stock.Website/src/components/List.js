import React from 'react'

import { ListItem } from './ListItem'


export const List = ({elements}) => {

   let visible = (elements.length > 0) ? "" : "none";


    return (
        <div className="my-3 p-3 bg-white rounded box-shadow" style={{display: visible}}>
            <div className="media text-muted pt-3">


                <div className="col-md-1">
                    #
                </div>
                <div className="col-md-4">
                    <p className="media-body pb-3 mb-0 small lh-125">
                        <strong className="d-block text-gray-dark">Name</strong>
                    </p>
                </div>
                <div className="col-md-3">
                    <p className="media-body pb-3 mb-0 small lh-125  ">
                        <strong className="d-block text-gray-dark">Type</strong>
                    </p>
                </div>
                <div className="col-md-3">
                    <p className="media-body pb-3 mb-0 small lh-125  ">
                        <strong className="d-block text-gray-dark">ExpiredDate</strong>
                    </p>
                </div>
                <div className="col-md-1">
                    &nbsp;
                </div>




            </div>
            {    
                elements.length > 0 && elements.map( (item,index) => (
                   <ListItem key={index}  {...item} />
                   )

                )
            }


        </div>
    )
}
