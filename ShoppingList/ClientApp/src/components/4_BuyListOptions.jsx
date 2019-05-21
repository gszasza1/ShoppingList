import React, { Component } from 'react';
import { Button, Form, FormGroup, Label } from "reactstrap";
import "./Meals.css"
import Select from "react-select";
import ModifyBuyList from "./4_BuyList_Options/ModifyBuyList";
import AddBuyList from "./4_BuyList_Options/AddBuyList"
import DeleteBuyList from "./4_BuyList_Options/DeleteBuyList"

class BuyListOptions extends Component {

    constructor(props) {
        super(props);
        this.state = {
            items: [],
            item: "",
            deleteMeal:"",
        };
        this.handleSubmitDelete=this.handleSubmitDelete.bind(this);

    }

    componentWillMount() {
        fetch("/api/BuyList")
            .then((response) => response.json())
            .then((items) =>
                this.setState({ items }));
    }
    handleChange(event) {
        const target = event.target;
        const value = target.value;

        const name = target.name;
        let item = { ...this.state.item };
        item[name] = value;
        this.setState({ item });
    }

    async handleSubmitDelete(ev) {
        ev.preventDefault();
       
        fetch("/api/BuyList/"+this.state.deleteMeal, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
          //  body: JSON.stringify(tempBuylist)
        });
    }

    render() {

        const { items } = this.state;
        return (
            <div>
           
                <h1>Bevásárló lista opciók</h1>
                <AddBuyList></AddBuyList>
                <DeleteBuyList></DeleteBuyList>
                
                <ModifyBuyList></ModifyBuyList>
            </div>
        );
    }
}
export default BuyListOptions;