import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import "../Meals.css"
import Select from "react-select";

class AddFoodToBuyList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            BuyList: [],
            Food: [],
            FoodCounter: [],
            item: "",
            modMeal: null,
            modBuyList: null,

        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmitAdd = this.handleSubmitAdd.bind(this);

    }

    componentWillMount() {
        fetch("/api/BuyList")
            .then((response) => response.json())
            .then((BuyList) =>
                this.setState({ BuyList }));

        fetch("/api/Food")
            .then((response) => response.json())
            .then((Food) =>
                this.setState({ Food }));
    }

    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        let item = { ...this.state.item };
        item[name] = value;
        this.setState({ item });
    }

    async handleSubmitAdd(ev) {
        ev.preventDefault();
        let newBuyList = {
            BuyListId: this.state.modBuyList.id,
            FoodId: this.state.modMeal.id,
            Counter: this.state.item.name,
        }
        fetch("/api/FoodCounter", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newBuyList)
        });
    }


    render() {


        const { item } = this.state;
        const { BuyList } = this.state;
        const { Food } = this.state;
        return (


            <div>

                <h3>Hozzáadás</h3>
                <Form onSubmit={this.handleSubmitAdd} className="meals_add">
                    <FormGroup>
                        <Label for="head">Lista neve:</Label>
                        <Select

                            getOptionLabel={option => option.creationBuylist.creator + " listája"}
                            getOptionValue={option => option.id}
                            options={BuyList}
                            placeholder="Nevek"
                            onChange={opt => this.setState({
                                modBuyList: opt
                            })}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label for="head">Étel neve:</Label>
                        <Select

                            getOptionLabel={option => option.name}
                            getOptionValue={option => option.id}
                            options={Food}
                            placeholder="Ételek"
                            onChange={opt => this.setState({
                                modMeal: opt
                            })}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label for="head">Darabszám:</Label>

                        <Input type="number" name="name" id="name"
                            value={item.name || ""} onChange={this.handleChange}
                        />
                    </FormGroup>

                    <FormGroup id="buttonFrom">
                        <Button variant={"success"} color="primary"
                            type="submit">Módosítás</Button>
                    </FormGroup>

                </Form>

            </div>
        );
    }
}
export default AddFoodToBuyList;