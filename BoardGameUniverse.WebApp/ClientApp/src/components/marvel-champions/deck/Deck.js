import React, { Component } from 'react';
import { Button, Form, Input, InputGroup } from 'reactstrap';

export class Deck extends Component {
  static displayName = Deck.name;

  constructor(props) {
    super(props);
    this.state = { deck: null, cardCodes: [], addCode: '', removeCode: '' };
  }

  componentDidMount() {
    const { guid } = this.props;
    if (guid) {
      this.getDeck(guid);
      this.getAllCards(guid);
    }
  }

  static renderDeckCardsColumn(title, cardCodes) {
    let zIndex = 500;
    let top = 2;
    
    return (
      <div className='position-relative w-25'>
        <div>{title}</div>
        {cardCodes.map((cardCode) => {
          let style = {
            left: 0,
            top: top + 'rem',
            zIndex: zIndex++
          };

          top = top + 3.5;

          return (
            <div key={`card-${cardCode}`} className='mc-deck-card position-absolute' style={style}>
              <img src={`${window.API_GATEWAY_URL}/image/card?code=${cardCode}`} className='img-fluid' />
            </div>
          );
        })}
      </div>
    );
  }

  render() {
    let content = (this.state.cardCodes === null)
      ? <p><em>Loading...</em></p>
      : Deck.renderDeckCardsColumn('Cards', this.state.cardCodes);

    return (
      <div>
        <Form onSubmit={this.onAddSubmit}>
          <InputGroup>
            <Input type='search' value={this.state.addCode} onChange={e => this.setState({ addCode: e.target.value })} />
            <Button type='submit' color='primary'>add</Button>
          </InputGroup>
        </Form>
        <Form className='mt-3' onSubmit={this.onRemoveSubmit}>
          <InputGroup>
            <Input type='search' value={this.state.removeCode} onChange={e => this.setState({ removeCode: e.target.value })} />
            <Button type='submit' color='primary'>remove</Button>
          </InputGroup>
        </Form>
        <div className='mt-3 d-flex justify-content-around'>
          {content}
          <div className='w-25'>
            <Form onSubmit={this.onDeckSubmit}>
              <div className='mb-3'>
                <Input defaultValue={this.state.deck ? this.state.deck.name : ''} />
              </div>
              <Button type='submit' color='primary' className='float-end'>Save</Button>
            </Form>
          </div>
        </div>
      </div>
    );
  }

  onAddSubmit = (e) => {
    e.preventDefault();
    this.addCard(this.state.addCode);
  }

  onRemoveSubmit = (e) => {
    e.preventDefault();
    this.removeCard(this.state.removeCode);
  }

  onDeckSubmit = (e) => {
    e.preventDefault();
  }

  async getDeck(guid) {
    const response = await fetch(`${window.API_GATEWAY_URL}/deck?guid=${guid}`);
    const data = await response.json();
    this.setState({ deck: data });
  }

  async getAllCards(guid) {
    const response = await fetch(`${window.API_GATEWAY_URL}/deck/cards?guid=${guid}`);
    const data = await response.json();
    this.setState({ cardCodes: data });
  }

  async addCard(code) {
    const bodyData = {
      'deckGuid': this.props.guid,
      'cardCode': code
    };

    const json = JSON.stringify(bodyData)

    const options = {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: json
    };

    const response = await fetch(`${window.API_GATEWAY_URL}/deck/cards`, options);
    if (response.status !== 200) {
      return;
    }

    let newCardCodes = [...this.state.cardCodes, code];
    this.setState({ addCode: '', cardCodes: newCardCodes });
  }

  async removeCard(code) {
    const bodyData = {
      'deckGuid': this.props.guid,
      'cardCode': code
    };

    const json = JSON.stringify(bodyData)

    const options = {
      method: 'DELETE',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: json
    };

    const response = await fetch(`${window.API_GATEWAY_URL}/deck/cards`, options);
    if (response.status !== 200) {
      return;
    }

    let newCardCodes = [...this.state.cardCodes];
    let index = newCardCodes.indexOf(code);
    if (index >= 0) {
      newCardCodes.splice(index, 1);
    }

    this.setState({ addCode: '', cardCodes: newCardCodes });
  }

  splitCardsByFactionCode(cards) {
    let splitCards = {};
    cards.forEach(card => {
      if (!Object.hasOwn(splitCards, card.FactionCode)) {
        splitCards[card.FactionCode] = {
          name: card.FactionCode,
          cards: []
        };
      }

      splitCards[card.FactionCode].cards.push(card);
    });

    return splitCards;
  }
}
