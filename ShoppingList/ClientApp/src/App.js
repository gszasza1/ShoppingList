import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import  Foods from './components/1_Foods';
import  FoodComment from './components/2_Foods_Comment';
import  ListBuyLists from './components/3_Buylist';
import  BuyListOptions from './components/4_BuyListOptions';
import  AddFoodBuyList from './components/AddFoodBuyList';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/meals' component={Foods} />
        <Route path='/mealsoptions' component={FoodComment} />
        <Route path='/shoppinglists' component={ListBuyLists} />
        <Route path='/shoppinglistsoptions' component={BuyListOptions} />
        <Route path='/addfoodtolist' component={AddFoodBuyList} />
        <Route path='/peoples' component={FetchData} />
      </Layout>
    );
  }
}
