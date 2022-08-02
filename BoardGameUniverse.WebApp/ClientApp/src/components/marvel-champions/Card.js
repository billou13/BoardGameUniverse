import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Card extends Component {
  static displayName = Card.name;

  constructor(props) {
    super(props);
    this.state = { card: null, pack: null, previousCard: null, nextCard: null };
  }

  componentDidMount() {
    const { code } = this.props
    
    this.getCard(code);
    this.getPreviousCard(code);
    this.getNextCard(code);
  }

  static createNavLink(url, text) {
    return (<Link to={url} className='btn btn-primary justify-content-start'>{text}</Link>);
  }

  static createCardNavLink(card) {
    return Card.createNavLink(`/marvel-champions/card/${card.code}`, card.name);
  }

  static createPackNavLink(pack) {
    return Card.createNavLink(`/marvel-champions/cards/${pack.code}`, pack.name);
  }

  static renderCard(card) {
    let attributes = []
    if (card.cost) attributes.push('Cost: ' + card.cost)
    if (card.thwart) attributes.push('Thwart: ' + card.thwart + ' - Attack: ' + card.attack + (card.defense ? ' - Defense: ' + card.defense : ''))
    if (card.health) attributes.push('Health: ' + card.health + (card.handSize ? ' - Hand size: ' + card.handSize : ''))

    return (
      <div className='mc-card d-flex'>
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
    let previousCardButton = (this.state.previousCard == null)
      ? ''
      : Card.createCardNavLink(this.state.previousCard)
    
    let packButton = (this.state.pack == null)
      ? ''
      : Card.createPackNavLink(this.state.pack)

    let nextCardButton = (this.state.nextCard == null)
      ? ''
      : Card.createCardNavLink(this.state.nextCard)

    let cardContents = (this.state.card === null)
      ? <p><em>Loading...</em></p>
      : Card.renderCard(this.state.card);

    return (
      <div>
        <div className='mb-2 d-flex justify-content-between'>
          {previousCardButton}
          {packButton}
          {nextCardButton}
        </div>
        {cardContents}
      </div>
    );
  }

  async getCard(code) {
    const response = await fetch(`${window.API_GATEWAY_URL}/card?code=${code}`)
    const data = await response.json()
    this.setState({ card: data })
    this.getPack(data.packCode)
  }

  async getPack(code) {
    const response = await fetch(`${window.API_GATEWAY_URL}/pack?code=${code}`)
    const data = await response.json()
    this.setState({ pack: data })
  }

  async getPreviousCard(code) {
    const response = await fetch(`${window.API_GATEWAY_URL}/card/previous?code=${code}`)
    const data = await response.json()
    this.setState({ previousCard: data })
  }

  async getNextCard(code) {
    const response = await fetch(`${window.API_GATEWAY_URL}/card/next?code=${code}`)
    const data = await response.json()
    this.setState({ nextCard: data })
  }
}
