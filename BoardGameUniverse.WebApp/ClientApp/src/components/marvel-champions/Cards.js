import React, { Component } from 'react';
import { CardRow } from './CardRow';

export class Cards extends Component {
  static displayName = Cards.name;

  constructor(props) {
    super(props);
    this.state = { cards: null };
  }

  componentDidMount() {
    const { pack } = this.props
    this.getAllCards(pack);
  }

  static renderAllCards(cards) {
    return (
      <div>
        <div>count: {cards.length}</div>
        <table className='table table-striped'>
          <thead>
            <tr>
              <th>Name</th>
              <th>Class</th>
              <th>C.</th>
              <th>Type</th>
              <th>Resources</th>
              <th>Traits</th>
              <th>Pack</th>
              <th>Set</th>
            </tr>
          </thead>
          <tbody>
            {cards.map((card) => <CardRow key={`card-${card.code}`} { ...card } />)}
          </tbody>
        </table>
      </div>
    );
  }

  render() {
    const { pack } = this.props

    let contents = (this.state.cards === null)
      ? <p><em>Loading...</em></p>
      : Cards.renderAllCards(this.state.cards);

    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions cards</h1>
        <div className="mc-card">
            <p>pack: {pack}</p>
            {contents}
        </div>
      </div>
    );
  }

  async getAllCards(pack) {
    const response = await fetch(`marvelchampions/cards?pack=${pack}`)
    const data = await response.json()
    this.setState({ cards: data })
  }
}
