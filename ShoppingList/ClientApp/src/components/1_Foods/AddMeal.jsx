import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import "../Meals.css"

import Select from "react-select";
class AddMeal extends Component {

  constructor(props) {
    super(props);
    this.state = {
      currentCount: 0,
      item: "",
      category: categoryType,
      currentCategory: null,
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
      unitPrice: this.state.item.Price,
      category: this.state.currentCategory.value
    };
    fetch("/api/Food", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newMeal)
    });
  }
  render() {
    const { item } = this.state;
    const { category } = this.state;
    return (

      <Form onSubmit={this.handleSubmit}>
        <FormGroup>
          <Label for="head">Étel neve:</Label>
          <Input type="text" name="name" id="name"
            value={item.name || ""} onChange={this.handleChange}
          />
        </FormGroup>


        <FormGroup>
          <Label for="head">Ára:</Label>
          <Input type="number" name="Price" id="Price"
            value={item.Price || ""} onChange={this.handleChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="head">Kategória:</Label>
          <Select

            getOptionLabel={option => option.name}
            getOptionValue={option => option.value}
            options={category}
            placeholder="Listák"
            onChange={opt => this.setState({
              currentCategory: opt
            })}
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
const categoryType = [{
  name: "Drink",
  value: 1
}, {
  name: "Meal",
  value: 2
}, {
  name: "Sweets",
  value: 4
}, {
  name: "Others",
  value: 8
},]
export default AddMeal;