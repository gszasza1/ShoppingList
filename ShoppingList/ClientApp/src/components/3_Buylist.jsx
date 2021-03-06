import React, { Component } from 'react';
import { Form, FormGroup, Label } from "reactstrap";
import "./Meals.css"
import Select from "react-select";

class ListBuylists extends Component {

    constructor(props) {
        super(props);
        this.state = {
            currentCount: 0,
            item: null,
            items: [],
            mealUpdate: null,
            FoodCounter: [{
                foods:{id:"",name:"",unitprice:0},
                counter:0
                }],
            total: "",
        };
        this.handleChange = this.handleChange.bind(this);
        this.totalnumber = this.totalnumber.bind(this);
        this.getdetails = this.getdetails.bind(this);

    }
totalnumber(){
    var totalSum=0;
    for (var  i = 0; i < this.state.FoodCounter.length; i++) {
        totalSum +=  this.state.FoodCounter[i].counter*this.state.FoodCounter[i].foods.unitPrice ;
      }
      this.setState({total:totalSum});
}
    componentWillMount() {

        fetch("/api/BuyList", { 
            method: 'get', 
            headers: new Headers({
              "api-version":1.0
            })})
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

    getdetails(opt) {
        fetch("/api/FoodCounter/Buylistdetails?id=" + opt.id)
            .then((response) => response.json())
            .then((FoodCounter) =>
                this.setState({ FoodCounter }, () => this.totalnumber()));
    }


    render() {

        const { items } = this.state;
        const { FoodCounter } = this.state;
        return (
            <div>
                <h1>Bevásárlólisták</h1>
                <h3>Kérlek válassz egyet listázáshoz</h3>
                <Form>
                    <FormGroup>
                        <Label for="head">Étel neve:</Label>
                        <Select
                            className="extra_info change_lab"
                            getOptionLabel={option => option.creationBuylist.creator + " listája.   Készítés ideje: " + option.creationBuylist.orderDate }
                            getOptionValue={option => option.id}
                            options={items}
                            placeholder="Ételek"
                            onChange={opt => this.getdetails(opt)}
                        />
                    </FormGroup>

                </Form>
                <ul >
                    <h3>Összes étel</h3>
                    {FoodCounter.map(item => <li className="meals_flex">
                        <p className="meals_strong"> Étel ID:</p>
                        <p className="meals_individualID"> {item.foods.id}</p>
                        <p className="meals_strong"> Étel neve:</p>
                        <p> {item.foods.name}</p>
                        <p className="meals_strong"> Étel egységára:</p>
                        <p> {item.foods.unitPrice}</p>
                        <p className="meals_strong"> Étel darabszám:</p>
                        <p className="meals_individualID"> {item.counter}</p>
                        <p className="meals_strong"> Teljes ár:</p>
                        <p> {item.counter * item.foods.unitPrice}</p>
                    </li>

                    )}</ul>
                <h1> Total: {this.state.total}</h1>
            </div>
        );
    }
}
export default ListBuylists;