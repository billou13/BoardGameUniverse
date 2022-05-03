import React, { Component } from 'react';
import { Grid } from './Grid';

import './LangtonAnt.css';

export class LangtonAnt extends Component {
  static displayName = LangtonAnt.name;

  render() {
    return (
      <div>
        <h1 id="tabelLabel" >Langton's Ant</h1>
        <p>Work in progress...</p>
        <Grid />
      </div>
    );
  }
}
