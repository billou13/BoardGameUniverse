import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class MarvelChampions extends Component {
  static displayName = MarvelChampions.name;

  render() {
    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions</h1>
        <div className="mc">
          <ul>
            <li><Link to="/marvel-champions/card/01001a">Spider-Man</Link></li>
            <li><Link to="/marvel-champions/card/01052">Chase Them Down</Link></li>
            <li><Link to="/marvel-champions/card/01074">Inspired</Link></li>
            <li><Link to="/marvel-champions/card/01092">Helicarrier</Link></li>
          </ul>
        </div>
      </div>
    );
  }
}
