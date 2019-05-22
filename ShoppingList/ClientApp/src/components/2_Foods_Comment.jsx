import React, { Component } from 'react';
import { Form, FormGroup, Label } from "reactstrap";
import "./Meals.css"
import Select from "react-select";

class FoodComment extends Component {

    constructor(props) {
        super(props);
        this.state = {
            currentCount: 0,
            item: null,
            items: [],
            mealUpdate: null,
            Messages: [],
            total: "",
            Rating: [],
            SingleMessage:{
               messages:"" ,
               rating:"",
            }
        };
        this.handleChange = this.handleChange.bind(this);
        this.getdetails = this.getdetails.bind(this);
        this.getallMessageData = this.getallMessageData.bind(this);

    }
    componentWillMount() {

        fetch("/api/RatingMessage/count")
            .then((response) => response.json())
            .then((total) =>
                this.setState({ total }));

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
   async getallMessageData(opt) {
        fetch("/api/RatingMessage/" + opt.id)
            .then((response) => response.json())
            .then((SingleMessage) =>
                this.setState({ SingleMessage }));
    }

    getdetails(opt) {
        fetch("/api/RatingMessage/" + opt.id + "/messages")
            .then((response) => response.json())
            .then((Messages) =>
                this.setState({ Messages }));

        fetch("/api/RatingMessage/" + opt.id + "/rating")
            .then((response) => response.json())
            .then((Rating) =>
                this.setState({ Rating }));
    }


    render() {

        const { items } = this.state;
        const { total } = this.state;
        const { Messages } = this.state;
        const { SingleMessage } = this.state;
        const { Rating } = this.state;
        return (
            <div>
                <h1>Étel értékelések</h1>
                <h3>Összes eddigi értékelés: {total}</h3>
                <h3>Kérlek válassz egyet listázáshoz</h3>
                <Form>
                    <FormGroup>
                        <Label for="head">Étel neve:</Label>
                        <Select

                            getOptionLabel={option => option.name}
                            getOptionValue={option => option.id}
                            options={items}
                            placeholder="Ételek"
                            onChange={opt => this.getdetails(opt)}
                        />
                    </FormGroup>

                </Form>
                <Form>
                    <FormGroup>
                        <Label for="head">Teljes koment:</Label>
                        <Select

                            getOptionLabel={option => option.id}
                            getOptionValue={option => option.id}
                            options={Messages}
                            placeholder="Ételek"
                            onChange={opt => this.getallMessageData(opt)}
                        />
                    </FormGroup>

                </Form>
                <div className="options_asd">
                    <p>
                         Sorszám: {SingleMessage.id}
                    </p>
                    <p>
                        Üzenet: {SingleMessage.messages.text}
                    </p>
                    
                    <p>
                       Értékelés:  {SingleMessage.rating.stars}
                    </p>
                    <p>
                       Dátum:  {SingleMessage.creation}
                    </p>
                </div>
               
                <h3>Üzenetek</h3>
                <ul >

                    {Messages.map(item => <li className="meals_messages">
                        <p className="meals_messages_strong"> {item.messages.id}. </p>
                        <p className="meals_messages_strong_v2"> {item.creation}</p>
                        <p className="meals_messages_individualText"> {item.messages.text}</p>
                    </li>

                    )}</ul>
                <h3>Összes csillag</h3>
                <ul >

                    {Rating.map(item => <li className="meals_messages">
                        <p className="meals_messages_strong"> {item.rating.id}. </p>
                        <p className="meals_messages_individualText"> {item.rating.stars}</p>
                    </li>

                    )}</ul>

            </div>
        );
    }
}
export default FoodComment;