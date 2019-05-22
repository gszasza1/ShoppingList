import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import "../Meals.css"
import Select from "react-select";

class UpdateFoodToBuyList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            BuyList: [],
            
            FoodCounter: [],
            item: "",
            updateMeal:"0",
            updateBuyList:null,
            updateCounter:"",

        };
        this.handleChangeUpdate = this.handleChangeUpdate.bind(this);
        this.handleSubmitUpdate = this.handleSubmitUpdate.bind(this);
        this.getbuylistdetails = this.getbuylistdetails.bind(this);
        this.getNumber = this.getNumber.bind(this);
        
    }

    componentWillMount() {
        fetch("/api/BuyList")
            .then((response) => response.json())
            .then((BuyList) =>
                this.setState({ BuyList }));

       
    }

    getbuylistdetails(opt){
        fetch("/api/FoodCounter/Buylistdetails?id="+opt.id)
        .then((response) => response.json())
        .then((FoodCounter) =>
            this.setState({ FoodCounter }));
    }

    handleChangeUpdate(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        let item = { ...this.state.updateCounter };
        item[name] = value;
        this.setState({ updateCounter:item });
    }
    getNumber(event){
        this.setState({updateMeal:event})
    }

   
    async handleSubmitUpdate(ev) {
        ev.preventDefault();
        let newFoodCounter = {
            id:this.state.updateMeal.id,
            Counter: this.state.updateCounter.name,
            FoodId: this.state.updateMeal.foodId,
            BuyListId: this.state.updateMeal.buyListId,
            Modification: this.state.updateMeal.modification,
        }
        fetch("/api/FoodCounter", {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newFoodCounter)
        });
    
    }

    render() {

        const { updateCounter } = this.state;
        const { updateMeal } = this.state;
        const { BuyList } = this.state;
        const { FoodCounter } = this.state;
        return (


            <div>
                <h3>Darabszám módosítás</h3>
                <Form onSubmit={this.handleSubmitUpdate} className="meals_add">
                    <FormGroup>
                        <Label for="head">Lista neve:</Label>
                        <Select

                            getOptionLabel={option => option.creationBuylist.creator + " listája"}
                            getOptionValue={option => option.id}
                            options={BuyList}
                            placeholder="Nevek"
                            onChange={opt => this.getbuylistdetails(opt)}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label for="head">Ételei:</Label>
                        <Select

                            getOptionLabel={option => option.foods.name}
                            getOptionValue={option => option.id}
                            options={FoodCounter}
                            placeholder="Ételek"
                            onChange={opt => this.getNumber(opt)}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label for="head">Darabszám jelenleg: {updateMeal.counter}</Label>

                        <Input type="number" name="name" id="name"
                            value={updateCounter.name || ""} onChange={this.handleChangeUpdate}
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
export default UpdateFoodToBuyList;