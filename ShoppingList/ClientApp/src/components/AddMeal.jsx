import React, { Component } from 'react';
import { Alert, Button, Form, FormGroup, Input, Label } from "reactstrap";
import "./Meals.css"

class AddMeal extends Component {

  constructor(props) {
    super(props);
    this.state = {
      currentCount: 0,
      item: ""
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
    let newMeal = {
        name: this.state.item.name,
        unitPrice: this.state.item.Price
        };
    fetch("/api/Food", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(newMeal)
    });
}
  render() {
    const {item} = this.state;
    return (
  
        <Form onSubmit={this.handleSubmit}>
          <FormGroup>
            <Label for="head">Étel neve:</Label>
            <Input className="newsP_title" type="text" name="name" id="name"
              value={item.name || ""} onChange={this.handleChange}
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
export default AddMeal;