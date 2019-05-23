import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import "./Meals.css"

class Price extends Component {

    constructor(props) {
        super(props);
        this.state = {
            item: "",
            allPriceCount: [],
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

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
       
        fetch("/api/Food/more/" +this.state.item.name)
            .then((response) => response.json())
            .then((allPriceCount) =>
                this.setState({ allPriceCount }));
    }
   


    render() {

        const { item } = this.state;
        const { allPriceCount } = this.state;
        return (
            <div>

                <h1>Drága étel válogatás</h1>
                <h3>Index teszteléshez</h3>
                <Form onSubmit={this.handleSubmit} >
                <FormGroup>
                        <Label for="head">Válassz:</Label>
                        <Input type="text" name="name" id="name" required
                            value={item.name || ""} onChange={this.handleChange}
                        />
                   </FormGroup>

                    <FormGroup id="buttonFrom">
                        <Button variant={"success"} color="primary"
                            type="submit">Keresés</Button>
                    </FormGroup>

                </Form>



                <ul >
                    {allPriceCount.map(item => <li className="meals_messages">
                        <p className="meals_messages_individualText">Étel neve: {item.name}</p>
                        <p className="meals_messages_individualText">Ára: {item.unitPrice}</p>
                    </li>

                    )}</ul>
            </div>



        );
    }
}

export default Price;