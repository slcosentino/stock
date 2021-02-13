import React, { useContext, useEffect, useState } from 'react'
import { useForm } from '../hooks/useForm'
import { FormHeader } from './FormHeader'
import { setElement } from '../helpers/setElement'
import { getElements } from '../helpers/getElements'
import { UserContext } from './UserContext'
import { getAllElementsType } from '../selectors/getAllElementsType'
import { getElementTypeById } from '../selectors/getElementTypeById'


export const Form = () => {

    const initialStateAlert = {
        error: { title: "", text: "" },
        success: { title: "", text: "" }
    };

    const {setElements } = useContext(UserContext);
    const [alert, setAlert] = useState(initialStateAlert)
    
     useEffect(() => {
        (async function() {
            const elems = await getElements();
            setElements(elems);
        })();
    }, [setElements]);

    

    const defaultElementType = getAllElementsType()[0].id;     
    const [formValues, handleInputChange, reset] = useForm({
        id: 0,
        name: "",
        type: defaultElementType,
        expiredDate: ""
    });

    const { id, name, type, expiredDate } = formValues;

    const types = getAllElementsType();


    const handleSubmit = async (e) => {
        e.preventDefault();
        const elementType = getElementTypeById(type);       
        const error = validateForm();
         
        if (error.length > 0)
            setErrorAlert("There are some errors in the form:", error);
        else {
            const response = await setElement({ id, name, type: elementType, expiredDate });
            processResponse(response);
        }
        
    };

    const processResponse = async (response) => {
        if (response.error) {
            setErrorAlert(response.error, response.message)            
        }
        else {
            setSuccessAlert( "OK", response.data);
            setElements(await getElements());
            reset();
        }



    }

    const validateForm = () => {

        let errors = "";
        if (name.trim().length === 0)
            errors += "The filed name can not be empty.\n";

        if (expiredDate.trim().length === 0)
            errors +="The field expired date can not be empty.\n";

        return errors;
    };

    const setErrorAlert = (title, errors) => {
        setAlert(
            {
                success: {
                    title: "",
                    text: ""
                },
                error: {
                    title: title,
                    text: errors
                }
            }
        )
    };

    const setSuccessAlert = (title, text) => {
        setAlert(
            {
                error: { 
                    title: "", 
                    text: "" },
                success: {
                    title: title,
                    text: text
                }
            }
        )
    };



    return (
        <>
            <FormHeader />


            <form className="my-3 p-3 bg-white rounded box-shadow" onSubmit={handleSubmit} noValidate >

                <div className="mt-3">
                    <label>Name</label>
                    <input type="text"
                        name="name"
                        className="form-control col-md-6"
                        value={name}
                        onChange={handleInputChange}
                        placeholder="Element name"
                        required
                    />
                </div>
                <div className="mt-3">
                    <label>Type</label>
                    <select
                        name="type"
                        className="form-control col-md-6"
                        value={type}                      
                        onChange={handleInputChange}
                    >
                        {
                            types.map(item =>
                                <option key={`${item.id}_${item.name}`} value={item.id}>{item.name}</option>
                            )
                        }

                    </select>

                </div>
                <div className="mt-3">
                    <label>Expired date</label>

                    <input type="datetime-local"
                        name="expiredDate"
                        className="form-control col-md-6"
                        value={expiredDate}
                        onChange={handleInputChange}
                        placeholder="Element expired date"
                        required
                    />
                </div>

                <button className="btn btn-primary mt-5"  >Save</button>
                {
                    alert.error.title !== "" &&
                    <div className="mt-3 alert alert-danger">
                        <strong>{alert.error.title}</strong>
                        <div className="mt-3">
                            {
                                alert.error.text.split("\n").map(function(item, idx) {
                                    return (
                                        <span key={idx}>
                                            {item}
                                            <br/>
                                        </span>
                                     )
                                })
                            }
                        </div>


                    </div>
                }

                {
                    alert.success.title !== "" &&
                    <div className="mt-3 alert alert-success">
                        <strong>{alert.success.title}</strong>
                        <div className="mt-3">
                        {alert.success.text}
                        </div>
                    </div>
                }

            </form>
        </>
    )
}
