import React, { Component } from 'react';
import { Cell } from './Cell';

export class Grid extends Component {
    static displayName = Grid.name;

    render() {
        let cells = [];
        for (let x = 0; x < this.props.columnSize; x++) {
            for (let y = 0; y < this.props.rowSize; y++) {
                cells.push({ x, y });
            }
        }

        const style = {
            gridTemplateColumns: Array(this.props.columnSize).fill(this.props.cellSize).join(" ")
        };

        return (
            <div className="grid" style={style}>
                { cells.map(cell => { return (<Cell key={"cell".concat(cell.x, "-", cell.y)} size={this.props.cellSize} x={cell.x} y={cell.y} />) }) }
            </div>
        );
    }
}
