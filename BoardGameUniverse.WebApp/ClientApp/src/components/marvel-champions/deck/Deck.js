import React, { Component } from 'react';
import { Button, Form, Input, InputGroup } from 'reactstrap';
import { DeckCardsColumn } from './DeckCardsColumn';

export class Deck extends Component {
  static displayName = Deck.name;

  constructor(props) {
    super(props);
    this.state = { deck: null, cards: null, addCode: '', removeCode: '' };
  }

  componentDidMount() {
    const { guid } = this.props;
    if (guid) {
      this.getDeck(guid);
      this.getAllCards(guid);
    }
  }

  static renderDeckCardsColumns(cards) {
    let splitCards = Deck.splitCardsByFactionCode(cards);
    let factionCodes = Object.keys(splitCards);
    return factionCodes.map((factionCode) => <DeckCardsColumn title={factionCode} cards={splitCards[factionCode].cards} />);
  }

  render() {
    let content = (this.state.cards === null)
      ? <p><em>Loading...</em></p>
      : Deck.renderDeckCardsColumns(this.state.cards);

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
    this.setState({ cards: data });
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

    const responseAddCard = await fetch(`${window.API_GATEWAY_URL}/deck/cards`, options);
    if (responseAddCard.status !== 200) {
      return;
    }

    const responseCardDetail = await fetch(`${window.API_GATEWAY_URL}/card?code=${code}`);
    const card = await responseCardDetail.json()

    let newCards = [...this.state.cards, card];
    this.setState({ addCode: '', cards: newCards });
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

    let newCards = [...this.state.cards];
    let index = newCards.map((c) => c.code).indexOf(code);
    if (index >= 0) {
      newCards.splice(index, 1);
    }

    this.setState({ removeCode: '', cards: newCards });
  }

  static splitCardsByFactionCode(cards) {
    let splitCards = {};
    cards.forEach(card => {
      if (!Object.hasOwn(splitCards, card.factionCode)) {
        splitCards[card.factionCode] = {
          name: card.factionCode,
          cards: []
        };
      }

      splitCards[card.factionCode].cards.push(card);
    });

    return splitCards;
  }
}
