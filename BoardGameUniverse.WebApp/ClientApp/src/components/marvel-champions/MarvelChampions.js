import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class MarvelChampions extends Component {
  static displayName = MarvelChampions.name;

  constructor(props) {
    super(props);
    this.state = { packs: null, decks: null };
  }

  componentDidMount() {
    this.getAllPacks();
    this.getAllDecks();
  }

  static renderAllPacks(packs) {
    return (
      <div>
        <ol>
          {packs.map((pack) => <li key={`pack-${pack.code}`}><Link to={`/marvel-champions/pack/${pack.code}`}>{pack.name}</Link></li>)}
        </ol>
      </div>
    );
  }

  static renderAllDecks(decks) {
    return (
      <div>
        <ul>
          {decks.map((deck) => <li key={`deck-${deck.guid}`}><Link to={`/marvel-champions/deck/${deck.guid}`}>{deck.name}</Link></li>)}
        </ul>
      </div>
    );
  }

  render() {
    let packsContent = (this.state.packs === null)
      ? <p><em>Loading...</em></p>
      : MarvelChampions.renderAllPacks(this.state.packs);

    let decksContent = (this.state.decks === null)
      ? ''
      : MarvelChampions.renderAllDecks(this.state.decks);

    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions</h1>
        <div className='d-flex justify-content-around'>
            {packsContent}
            {decksContent}
        </div>
      </div>
    );
  }

  async getAllPacks() {
    const response = await fetch(`${window.API_GATEWAY_URL}/packs`)
    const data = await response.json()
    this.setState({ packs: data })
  }

  async getAllDecks() {
    const response = await fetch(`${window.API_GATEWAY_URL}/decks`)
    const data = await response.json()
    this.setState({ decks: data })
  }
}
