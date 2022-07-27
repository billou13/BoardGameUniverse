import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Board Game Universe</h1>
        <p>Enjoy the following pages:</p>
        <ul>
          <li><Link to="/langton-ant">Langton's Ant</Link></li>
          <li><Link to="/marvel-champions">Marvel Champions</Link></li>
        </ul>
      </div>
    );
  }
}
