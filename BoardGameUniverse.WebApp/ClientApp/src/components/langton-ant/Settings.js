import React, { Component } from 'react';

export class Settings extends Component {
    static displayName = Settings.name;

    render() {
        return (
            <div className="settings">
                <div><input type="number" value={this.props.columnSize} onChange={this.props.onColumnSizeChange} /></div>
                <div><input type="number" value={this.props.rowSize} onChange={this.props.onRowSizeChange} /></div>
            </div>
        );
    }
}
