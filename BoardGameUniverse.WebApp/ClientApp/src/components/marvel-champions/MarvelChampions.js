import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class MarvelChampions extends Component {
  static displayName = MarvelChampions.name;

  constructor(props) {
    super(props);
    this.state = { packs: null };
  }

  componentDidMount() {
    this.getAllPacks();
  }

  static renderAllPacks(packs) {
    return (
      <ol>
        {packs.map((pack) => <li key={`link-${pack.code}`}><Link to={`/marvel-champions/cards/${pack.code}`}>{pack.name}</Link></li>)}
      </ol>
    );
  }

  render() {
    let contents = (this.state.packs === null)
      ? <p><em>Loading...</em></p>
      : MarvelChampions.renderAllPacks(this.state.packs);

    return (
      <div>
        <h1 id="tabelLabel" >Marvel Champions</h1>
        <div className="mc-card">
            {contents}
        </div>
      </div>
    );
  }

  async getAllPacks() {
    const response = await fetch(`${window.API_GATEWAY_URL}/packs`)
    const data = await response.json()
    this.setState({ packs: data })
  }
}
