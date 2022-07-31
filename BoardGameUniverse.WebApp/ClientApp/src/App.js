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
        <Route exact path='/langton-ant' component={LangtonAnt} />
        <Route exact path='/marvel-champions' component={MarvelChampions} />
        <Route exact path='/marvel-champions/cards/:pack' component={CardsHook} />
        <Route exact path='/marvel-champions/card/:code' component={CardHook} />
      </Layout>
    );
  }
}
