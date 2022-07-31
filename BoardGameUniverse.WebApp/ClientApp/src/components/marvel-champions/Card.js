import React, { Component } from 'react';

export class Card extends Component {
  static displayName = Card.name;

  constructor(props) {
    super(props);
    this.state = { card: null };
  }

  componentDidMount() {
    const { pack, code } = this.props
    this.getCard(pack, code);
  }

  static renderCard(card) {
    return (
      <div>
        <div>name: {card.name}</div>
        <div>type_code: {card.type_code}</div>
        <div>octgn_id: {card.octgn_id}</div>
        <div dangerouslySetInnerHTML={{__html: card.text}} />
      </div>
    );
  }

  render() {
    const { pack, code } = this.props

    let contents = (this.state.card === null)
      ? <p><em>Loading...</em></p>
      : Card.renderCard(this.state.card);

    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions card</h1>
        <div className="mc-card">
            <p>pack: {pack} - code: {code}</p>
            {contents}
        </div>
      </div>
    );
  }

  async getCard(pack, code) {
    const response = await fetch(`marvelchampions/card?code=${code}`)
    const data = await response.json()
    this.setState({ card: data })
  }
}
