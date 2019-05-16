import React, { Component } from 'react';
import { Alert, Button, Form, FormGroup, Input, Label } from "reactstrap";
import "./Meals.css"
import Select from "react-select";

class ModifyBuyList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            items: [],
            item: "",
            modMeal:null,
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
       let newBuyList={
           id:this.state.modMeal.id,
           creator:this.state.item.name,
           orderDate:this.state.modMeal.orderDate,
       }
        fetch("/api/BuyList/"+this.state.modMeal.id, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
           body: JSON.stringify(newBuyList)
        });
    }

    render() {

        const { item } = this.state;
        const { items } = this.state;
        return (
          
             
                <Form onSubmit={this.handleSubmit} className="meals_add">
                    <FormGroup>
                        <Label for="head">Lista neve:</Label>
                        <Select
                            
                            getOptionLabel={option => option.creator + " listája"}
                            getOptionValue={option => option.id}
                            options={items}
                            placeholder="Nevek"
                            onChange={opt => this.setState({
                                modMeal: opt
                            })}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label for="head">Készítő új neve:</Label>
                        
                         <Input type="text" name="name" id="name"
                            value={item.name || ""} onChange={this.handleChange}
                        />
                   </FormGroup>

                    <FormGroup id="buttonFrom">
                        <Button variant={"success"} color="primary"
                            type="submit">Módosítás</Button>
                    </FormGroup>

                </Form>
                
        
        );
    }
}
export default ModifyBuyList;