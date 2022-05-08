import React, { Component } from 'react';

export class Card extends Component {
  static displayName = Card.name;

  render() {
    const { code } = this.props

    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions card</h1>
        <div className="mc-card">
            <span>{code}</span>
        </div>
      </div>
    );
  }
}
