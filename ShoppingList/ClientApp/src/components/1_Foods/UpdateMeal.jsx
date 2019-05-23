import React, { Component } from 'react';
import {Button, Form, FormGroup, Input, Label } from "reactstrap";
import "../Meals.css"
import Select from "react-select";

class UpdateMeal extends Component {

    constructor(props) {
        super(props);
        this.state = {
            numb:0,
            currentCount: 0,
            item: "",
            items: [],
            mealUpdate:null,
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.reloadState = this.reloadState.bind(this);
     
    }

    componentWillMount() {

        fetch("/api/Food")
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
    reloadState(opt){
       this.setState({mealUpdate:opt});
            
        fetch("/api/Food")
        .then((response) => response.json())
        .then((items) =>
            this.setState({ items }));
           
        }
    

    async handleSubmit(ev) {
        ev.preventDefault();
        let newMeal = {
            id: this.state.mealUpdate.id,
            name: this.state.mealUpdate.name,
            unitPrice: this.state.item.Price,
            rowVersion:this.state.mealUpdate.rowVersion,
            category:this.state.mealUpdate.category,
            };
        fetch("/api/Food", {
            method: "PUT",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify(newMeal)
        });
    }
    render() {
        const { item } = this.state;
        const { items } = this.state;
        return (

            <Form onSubmit={this.handleSubmit}>
                <FormGroup>
                    <Label for="head">Étel neve:</Label>
                    <Select
                        className="extra_info change_lab"
                        getOptionLabel={option => option.name}
                        getOptionValue={option => option.id}
                        options={items}
                        placeholder="Ételek"
                        onChange={opt => this.reloadState(opt)}
                    />
                </FormGroup>

                <FormGroup>
                    <Label for="head">Ára:</Label>
                    <Input className="newsP_title" type="number" name="Price" id="Price"
                        value={item.Price || ""} onChange={this.handleChange}
                    />
                </FormGroup>

                <FormGroup id="buttonFrom">
                    <Button variant={"success"} color="primary"
                        type="submit">Feltöltés</Button>
                </FormGroup>

            </Form>

        );
    }
}
export default UpdateMeal;