import React, { Component } from 'react';
import "./Meals.css"
import UpdateMeal from './1_Foods/UpdateMeal'
import AddMeal from './1_Foods/AddMeal'
import DeleteMeal from './1_Foods/DeleteMeal'

class Foods extends Component {
  displayName = Foods.name

  constructor(props) {
    super(props);
    this.state = {
      currentCount: 0,
      item: "",
      items:[]
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  handleChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;
    let item = { ...this.state.item };
    item[name] = value;
    this.setState({ item });
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  componentWillMount() {

    fetch("/api/Food")
        .then((response) => response.json())
        .then((items) =>
            this.setState({ items }));
}

  async handleSubmit(event) { }
  render() {
    const { items } = this.state;
    return (
      <div>
        <h1>Étel kezelő</h1>

        <ul>
          <li className="meals_add">
            <h3>Étel felvétel</h3>
            <AddMeal></AddMeal>
          </li>
          <li className="meals_add">
            <h3>Étel Változtatás</h3>
            <UpdateMeal></UpdateMeal>
          </li>
          <li className="meals_add">
            <h3>Étel Törlés</h3>
            <DeleteMeal/>
          </li>
          <li><ul className="meals_add">
          <h3>Összes étel</h3>
            {items.map(item =><li className="meals_flex">
              <p className="meals_strong"> Étel ID:</p>
              <p> {item.id}</p>
              <p className="meals_strong"> Étel neve:</p>
              <p> {item.name}</p>
              <p className="meals_strong"> Étel Ára:</p>
              <p> {item.unitPrice}</p>
              </li>
            )}</ul>
          </li>

        </ul>
      </div>
    );
  }
}
export default Foods;