import React, { Component } from 'react';
import { Settings } from './Settings';
import { Grid } from './Grid';

import './LangtonAnt.css';

export class LangtonAnt extends Component {
  static displayName = LangtonAnt.name;
  
  constructor(props) {
    super(props);
    
    const defaultProps = {
      cellSize: "10px",
      columnSize: 100,
      rowSize: 50
    };
    
    this.state = { ...defaultProps, ...props };
  }

  onColumnSizeChange(e) {
    this.setState({
      columnSize: parseInt(e.target.value)
    })
  }

  onRowSizeChange(e) {
    this.setState({
      rowSize: parseInt(e.target.value)
    })
  }

  render() {
    return (
      <div>
        <h1 id="tabelLabel" >Langton's Ant</h1>
        <p>Work in progress...</p>
        <div className="board">
          <Settings
            columnSize={this.state.columnSize} onColumnSizeChange={(e) => this.onColumnSizeChange(e) }
            rowSize={this.state.rowSize} onRowSizeChange={(e) => this.onRowSizeChange(e) } />
          <Grid cellSize={this.state.cellSize} columnSize={this.state.columnSize} rowSize={this.state.rowSize} />
        </div>
      </div>
    );
  }
}
