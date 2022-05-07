import React, { Component } from 'react';
import { Cell } from './Cell';

export class Grid extends Component {
    static displayName = Grid.name;

    render() {
        const { cellSize, cells } = this.props

        const style = {
            gridTemplateColumns: Array(cells.length).fill(cellSize).join(" ")
        };

        const renderRow = (row) => row.map(cell => (<Cell key={"cell".concat(cell.x, "-", cell.y)} size={cellSize} x={cell.x} y={cell.y} color={cell.color} highlight={cell.highlight} />));

        return (
            <div className="grid" style={style}>
                {cells.map((row) => renderRow(row))}
            </div>
        );
    }
}
