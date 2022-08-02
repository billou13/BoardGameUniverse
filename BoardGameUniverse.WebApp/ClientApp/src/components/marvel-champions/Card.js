import React, { Component } from 'react';
import { Link } from 'react-router-dom';

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
    let attributes = new Array()
    if (card.cost) attributes.push('Cost: ' + card.cost)
    if (card.thwart) attributes.push('Thwart: ' + card.thwart + ' - Attack: ' + card.attack + (card.defense ? ' - Defense: ' + card.defense : ''))
    if (card.health) attributes.push('Health: ' + card.health + (card.handSize ? ' - Hand size: ' + card.handSize : ''))

    return (
      <div className='d-flex'>
        <div className='flex-shrink-0 w-25'>
          <img src={`marvelchampions/cardimage?code=${card.code}`} alt={card.name} className='img-thumbnail' />
        </div>
        <div className='flex-grow-1 ms-3 card bg-light'>
          <h5 className='card-header text-primary'>{card.name}</h5>
          <div className='card-body'>
            <p className="card-text text-capitalize fw-bold">{card.typeCode}<br />{card.traits}</p>
            {attributes.map((attribute) => <p className='card-text m-0 fs-6'>{attribute}</p>)}
            <p className="card-text border-primary border-start mt-3 ps-2" dangerouslySetInnerHTML={{__html: card.text}} />
            <p className="card-text text-secondary fst-italic"><Link to={`/marvel-champions/cards/${card.packCode}`}>#{card.packCode}</Link></p>
            {card.backLink ? (<Link to={`/marvel-champions/card/${card.backLink}`}>Back</Link>) : ''}
          </div>
        </div>
      </div>
    );
  }

  render() {
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
