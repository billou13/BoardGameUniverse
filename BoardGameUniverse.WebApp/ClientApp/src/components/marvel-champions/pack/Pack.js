import React, { Component } from 'react';
import { PackCardRow } from './PackCardRow';

export class Pack extends Component {
  static displayName = Pack.name;

  constructor(props) {
    super(props);
    this.state = { cards: null };
  }

  componentDidMount() {
    const { code } = this.props
    this.getAllCards(code);
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
            {cards.map((card) => <PackCardRow key={`card-${card.code}`} { ...card } />)}
          </tbody>
        </table>
      </div>
    );
  }

  render() {
    let contents = (this.state.cards === null)
      ? <p><em>Loading...</em></p>
      : Pack.renderAllCards(this.state.cards);

    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions cards</h1>
        <div className="mc-card">
            {contents}
        </div>
      </div>
    );
  }

  async getAllCards(code) {
    const response = await fetch(`${window.API_GATEWAY_URL}/cards/pack?code=${code}`)
    const data = await response.json()
    this.setState({ cards: data })
  }
}
