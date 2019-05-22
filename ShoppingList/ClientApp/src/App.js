import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import  Foods from './components/1_Foods';
import  FoodComment from './components/2_Foods_Comment';
import  ListBuyLists from './components/3_Buylist';
import  BuyListOptions from './components/4_BuyListOptions';
import  AddFoodBuyList from './components/5_AddFoodBuyList';
import  FoodMessages from './components/2_Food_Message';

export default class App extends Component {
  displayName = App.name
  
  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/meals' component={Foods} />
        <Route path='/mealsoptions' component={FoodMessages} />
        <Route path='/mealsmessage' component={FoodComment} />
        <Route path='/shoppinglists' component={ListBuyLists} />
        <Route path='/shoppinglistsoptions' component={BuyListOptions} />
        <Route path='/addfoodtolist' component={AddFoodBuyList} />
      </Layout>
    );
  }
}
