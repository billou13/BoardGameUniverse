import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class MarvelChampions extends Component {
  static displayName = MarvelChampions.name;

  render() {
    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions</h1>
        <div className="mc">
            <Link to="/marvel-champions/card/01001a">Spider-Man</Link>
        </div>
      </div>
    );
  }
}
