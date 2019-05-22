import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import "./Meals.css"
import Select from "react-select";

class AddBuyList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            item: "",
            items: stars,
            foods: [],
            foodId: null,
            starCount: 5,
            bestCount: [],
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.bestCounter = this.bestCounter.bind(this);

    }
    componentWillMount() {
        fetch("/api/Food")
            .then((response) => response.json())
            .then((foods) =>
                this.setState({ foods }));
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
            "foodId": this.state.foodId,
            "rating": {
                "stars": this.state.starCount
            },
            "messages": {
                "text": this.state.item.name
            }
        }
        console.log(tempBuylist);
        fetch("/api/RatingMessage", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(tempBuylist)
        });
    }
    async bestCounter(opt) {
        fetch("/api/RatingMessage/" + opt + "/better")
            .then((response) => response.json())
            .then((bestCount) =>
                this.setState({ bestCount }));
    }


    render() {

        const { item } = this.state;
        const { foods } = this.state;
        const { items } = this.state;
        const { bestCount } = this.state;
        return (
            <div>

                <h1>Étel értékelés</h1>
                <h3>Új értékelés</h3>
                <Form onSubmit={this.handleSubmit} className="meals_add">
                    <FormGroup>

                        <Label for="head">Ételek:</Label>
                        <Select

                            getOptionLabel={option => option.name}
                            getOptionValue={option => option.id}
                            options={foods}
                            placeholder="Étel választás"
                            onChange={opt => this.setState({ foodId: opt.id })}
                        />

                        <Label for="head">Csillagok:</Label>
                        <Select

                            getOptionLabel={option => option.name}
                            getOptionValue={option => option.value}
                            options={items}
                            placeholder="Csillagok száma"
                            onChange={opt => this.setState({ starCount: opt.value })}
                        />
                        <Label for="head">Komment:</Label>
                        <Input type="text" name="name" id="name" required
                            value={item.name || ""} onChange={this.handleChange}
                        />
                    </FormGroup>

                    <FormGroup id="buttonFrom">
                        <Button variant={"success"} color="primary"
                            type="submit">Felvétel</Button>
                    </FormGroup>

                </Form>

                <h3>Legjobb értékelések</h3>
                <Label for="head">Jobb, mint:</Label>
                <Select

                    getOptionLabel={option => option.name}
                    getOptionValue={option => option.value}
                    options={items}
                    placeholder="Csillagok száma"
                    onChange={opt => this.bestCounter(opt.value)}
                />


                <ul >
                    {bestCount.map(item => <li className="meals_messages">
                        <p className="meals_messages_strong"> {item.messages.id}. </p>
                        <p className="meals_messages_individualText"> {item.foods.name}</p>
                        <p className="meals_messages_individualText"> {item.messages.text}</p>
                        <p className="meals_messages_individualText"> {item.rating.stars}</p>
                    </li>

                    )}</ul>
            </div>



        );
    }
}

const stars = [{
    name: "hellish",
    value: 1
}, {
    name: "really bad",
    value: 2
}, {
    name: "bad",
    value: 3
}, {
    name: "not so bad",
    value: 4
}, {
    name: "normal",
    value: 5
}, {
    name: "good",
    value: 6
}, {
    name: "really good",
    value: 7
}, {
    name: "super",
    value: 8
}, {
    name: "godly",
    value: 9
},]
export default AddBuyList;