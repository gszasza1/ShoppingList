import React, { Component } from 'react';
import { Alert, Button, Form, FormGroup, Input, Label } from "reactstrap";
import "../Meals.css"
import Select from "react-select";

class DeleteBuyList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            items: [],
          
            deleteMeal:"",
        };
        this.handleSubmitDelete=this.handleSubmitDelete.bind(this);

    }

    componentWillMount() {
        fetch("/api/BuyList")
            .then((response) => response.json())
            .then((items) =>
                this.setState({ items }));
    }

    async handleSubmitDelete(ev) {
        ev.preventDefault();
       
        fetch("/api/BuyList/"+this.state.deleteMeal, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
          //  body: JSON.stringify(tempBuylist)
        });
    }

    render() {

        const { items } = this.state;
        return (
        <div>
            <h3>Bevásárló lista törlése</h3>
           <Form onSubmit={this.handleSubmitDelete} className="meals_add">
                    <FormGroup>
                        <Label for="head">Lista neve:</Label>
                        <Select
                            
                            getOptionLabel={option =>  option.creationBuylist.creator + " listája"}
                            getOptionValue={option => option.id}
                            options={items}
                            placeholder="Listák"
                            onChange={opt => this.setState({
                                deleteMeal: opt.id
                            })}
                        />
                    </FormGroup>

                    <FormGroup id="buttonFrom">
                        <Button variant={"success"} color="primary"
                            type="submit">Törlés</Button>
                    </FormGroup>

                </Form>
                </div>
        );
    }
}
export default DeleteBuyList;