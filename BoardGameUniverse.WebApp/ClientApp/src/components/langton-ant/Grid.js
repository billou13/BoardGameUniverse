import React, { Component } from 'react';
import { Cell } from './Cell';

export class Grid extends Component {
    static displayName = Grid.name;

    constructor(props) {
        super(props);

        this.state = {
            cellSize: "50px"
        };
    }

    render() {
        const style = {
            gridTemplateColumns: this.state.cellSize + " " + this.state.cellSize
        }

        return (
            <div className="grid" style={style}>
                <Cell size={this.state.cellSize} />
                <Cell size={this.state.cellSize} />
                <Cell size={this.state.cellSize} />
                <Cell size={this.state.cellSize} />
            </div>
        );
    }
}
