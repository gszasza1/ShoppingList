import React, { Component } from 'react';
import { Button, Form, FormGroup, Label } from "reactstrap";
import "../Meals.css"
import Select from "react-select";

class DeleteMeal extends Component {

    constructor(props) {
        super(props);
        this.state = {
            currentCount: 0,
            item: null,
            items: [],
            mealUpdate:null,
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.reloadState = this.reloadState.bind(this);
    }
    reloadState(){
        fetch("/api/Food")
        .then((response) => response.json())
        .then((items) =>
            this.setState({ items }));
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

    async handleSubmit(ev) {
        ev.preventDefault();
        
        fetch("/api/Food/"+this.state.mealUpdate.id, {
            method: "DELETE",
            headers: {"Content-Type": "application/json"},
           // body: JSON.stringify(newMeal)
        });
    }
    render() {
     
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
                       // onMenuOpen={this.reloadState()}
                        placeholder="Ételek"
                        onChange={opt => this.setState({
                        mealUpdate: opt
                        })}
                    />
                </FormGroup>

                <FormGroup id="buttonFrom">
                    <Button variant={"success"} color="primary"
                        type="submit">Törlés</Button>
                </FormGroup>

            </Form>

        );
    }
}
export default DeleteMeal;