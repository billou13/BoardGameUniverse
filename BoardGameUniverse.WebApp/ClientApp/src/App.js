import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { LangtonAnt } from './components/langton-ant/LangtonAnt';
import { MarvelChampions } from './components/marvel-champions/MarvelChampions';
import { CardsHook } from './components/marvel-champions/CardsHook';
import { CardHook } from './components/marvel-champions/CardHook';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/langton-ant' component={LangtonAnt} />
        <Route exact path='/marvel-champions' component={MarvelChampions} />
        <Route path='/marvel-champions/cards/:pack' component={CardsHook} />
        <Route path='/marvel-champions/card/:pack/:code' component={CardHook} />
      </Layout>
    );
  }
}
