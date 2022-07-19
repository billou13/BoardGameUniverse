import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class MarvelChampions extends Component {
  static displayName = MarvelChampions.name;

  render() {
    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions</h1>
        <div className="mc">
          <ol>
            <li><Link to="/marvel-champions/cards/core">Core Set</Link></li>
          </ol>
        </div>
      </div>
    );
  }
}
