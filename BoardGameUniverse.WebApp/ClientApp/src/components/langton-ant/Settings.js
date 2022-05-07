import React, { Component } from 'react';

export class Settings extends Component {
    static displayName = Settings.name;

    render() {
        const { gridSize, onGridSizeChange, 
            nbSteps, onNbStepsChange,
            interval, onIntervalChange,
            onStartClick, onStopClick, onResetClick } = this.props

        return (
            <div className="settings">
                <div>
                    Grid size:
                    <select value={gridSize} onChange={onGridSizeChange}>
                        <option value="50">50</option>
                        <option value="100">100</option>
                        <option value="150">150</option>
                    </select>
                </div>
                <div>
                    Interval (in ms):
                    <select value={interval} onChange={onIntervalChange}>
                        <option value="10">10</option>
                        <option value="50">50</option>
                        <option value="100">100</option>
                        <option value="200">200</option>
                        <option value="300">300</option>
                    </select>
                </div>
                <div>
                    Steps:<input type="number" min="1" max="1000" value={nbSteps} onChange={onNbStepsChange} />
                </div>
                <div>
                    <button onClick={onStartClick}>Start</button>
                    &nbsp;
                    <button onClick={onStopClick}>Stop</button>
                    &nbsp;
                    <button onClick={onResetClick}>Reset</button>
                </div>
            </div>
        );
    }
}
