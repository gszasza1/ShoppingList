import React, { Component } from 'react';
import { Alert, Button, Form, FormGroup, Input, Label } from "reactstrap";
import "./Meals.css"
import Select from "react-select";
import ModifyBuyList from "./ModifyBuyList";

class BuyListOptions extends Component {

    constructor(props) {
        super(props);
        this.state = {
            items: [],
            item: "",
            deleteMeal:"",
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
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

    async handleSubmit(ev) {
        ev.preventDefault();
        let tempBuylist = {
            Creator: this.state.item.name
        }
        fetch("/api/BuyList", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(tempBuylist)
        });
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

        const { item } = this.state;
        const { items } = this.state;
        return (
            <div>
                <h1>Bevásárló lista opciók</h1>
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
                <h3>Bevásárló lista törlése</h3>
                <Form onSubmit={this.handleSubmitDelete} className="meals_add">
                    <FormGroup>
                        <Label for="head">Lista neve:</Label>
                        <Select
                            
                            getOptionLabel={option => option.creator + " listája"}
                            getOptionValue={option => option.id}
                            options={items}
                            placeholder="Listák"
                            onChange={opt => this.setState({
                                deleteMeal: opt.id
                            })}
                        />
                    </FormGroup>

                    <FormGroup id="buttonFrom">
                        <Button variant={"success"} color="primary"
                            type="submit">Törlés</Button>
                    </FormGroup>

                </Form>
                <h3>Bevásárló lista módosítása</h3>
                <ModifyBuyList></ModifyBuyList>
            </div>
        );
    }
}
export default BuyListOptions;