import React, { Component } from 'react';
import {Button, Form, FormGroup, Input, Label } from "reactstrap";
import "../Meals.css"

class AddBuyList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            item: "",
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

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

    async handleSubmit(ev) {
        ev.preventDefault();
        let tempBuylist = {
            CreationBuylist:{
                
            Creator: this.state.item.name,
            curTime : new Date()
            }
        }
        fetch("/api/BuyList", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(tempBuylist)
        });
    }
  

    render() {

        const { item } = this.state;
        return (
            <div>
               
                <h3>Új bevásárló lista</h3>
                <Form onSubmit={this.handleSubmit} className="meals_add">
                    <FormGroup>
                        <Label for="head">Készítő neve:</Label>
                        <Input type="text" name="name" id="name"
                            value={item.name || ""} onChange={this.handleChange}
                        />
                    </FormGroup>

                    <FormGroup id="buttonFrom">
                        <Button variant={"success"} color="primary"
                            type="submit">Felvétel</Button>
                    </FormGroup>

                </Form>
            
            </div>
        );
    }
}
export default AddBuyList;