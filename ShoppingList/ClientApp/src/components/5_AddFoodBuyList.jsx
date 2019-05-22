import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import "./Meals.css"
import Select from "react-select";
import AddFood from "./5_AddFood_Buylist/AddFood"
import UpdateFood from "./5_AddFood_Buylist/UpdateFood"

class AddFoodToBuyList extends Component {
    render() {

        return (


            <div>
                <h1>Étel listához</h1>
                <AddFood></AddFood>
               <UpdateFood></UpdateFood>

            </div>
        );
    }
}
export default AddFoodToBuyList;