import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import  ListBuyLists from './components/ListBuyLists';
import  BuyListOptions from './components/BuyListOptions';
import  AddFoodBuyList from './components/AddFoodBuyList';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/meals' component={Counter} />
        <Route path='/shoppinglists' component={ListBuyLists} />
        <Route path='/shoppinglistsoptions' component={BuyListOptions} />
        <Route path='/addfoodtolist' component={AddFoodBuyList} />
        <Route path='/peoples' component={FetchData} />
      </Layout>
    );
  }
}
