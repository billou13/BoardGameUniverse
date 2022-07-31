import React, { Component } from 'react';

export class Card extends Component {
  static displayName = Card.name;

  constructor(props) {
    super(props);
    this.state = { card: null };
  }

  componentDidMount() {
    const { code } = this.props
    this.getCard(code);
  }

  static renderCard(card) {
    return (
      <div className='d-flex'>
        <div className='flex-shrink-0'>
          <img src={`marvelchampions/cardimage?code=${card.code}`} alt={card.name} className='img-thumbnail' />
        </div>
        <div className='flex-grow-1 ms-3 card'>
          <div className='card-body'>
            <h5 className='card-title'>{card.name}</h5>
            <p class="card-text">pack: {card.pack_code}</p>
            <p class="card-text">quantity: {card.quantity}</p>
            <p class="card-text">type_code: {card.type_code}</p>
            <p class="card-text">octgn_id: {card.octgn_id}</p>
            <p class="card-text" dangerouslySetInnerHTML={{__html: card.text}} />
          </div>
        </div>
      </div>
    );
  }

  render() {
    const { code } = this.props

    let contents = (this.state.card === null)
      ? <p><em>Loading...</em></p>
      : Card.renderCard(this.state.card);

    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions card</h1>
        <div className="mc-card">
            {contents}
        </div>
      </div>
    );
  }

  async getCard(code) {
    const response = await fetch(`marvelchampions/card?code=${code}`)
    const data = await response.json()
    this.setState({ card: data })
  }
}
