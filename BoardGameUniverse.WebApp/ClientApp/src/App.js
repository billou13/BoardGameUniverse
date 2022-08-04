import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { LangtonAnt } from './components/langton-ant/LangtonAnt';
import { MarvelChampions } from './components/marvel-champions/MarvelChampions';
import { CardHook } from './components/marvel-champions/card/CardHook';
import { DeckHook } from './components/marvel-champions/deck/DeckHook';
import { PackHook } from './components/marvel-champions/pack/PackHook';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/langton-ant' component={LangtonAnt} />
        <Route exact path='/marvel-champions' component={MarvelChampions} />
        <Route exact path='/marvel-champions/card/:code' component={CardHook} />
        <Route exact path='/marvel-champions/deck/:guid?' component={DeckHook} />
        <Route exact path='/marvel-champions/pack/:code' component={PackHook} />
      </Layout>
    );
  }
}
