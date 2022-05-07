import React, { Component } from 'react';
import { Settings } from './Settings';
import { Grid } from './Grid';
import { Ant } from './Ant';

import './LangtonAnt.css';

const CELL_SIZE = "4px";
const GRID_SIZE = 100;
const INTERVAL = 100;
const NB_STEPS = 1;

export class LangtonAnt extends Component {
  static displayName = LangtonAnt.name;

  constructor(props) {
    super(props);
    
    const mergeProps = {
      ...{
        cellSize: CELL_SIZE,
        gridSize: GRID_SIZE,
        interval: INTERVAL,
        nbSteps: NB_STEPS
      },
      ...props
    };

    const newState = {
      cellSize: mergeProps.cellSize,
      interval: mergeProps.interval,
      nbSteps: mergeProps.nbSteps,
      cells: this.createCells(mergeProps.gridSize)
    };

    this.repopAntOn(newState.cells);

    this.state = newState;
  }

  createCells(gridSize) {
    let cells = Array.from({ length: gridSize }, (e, x) => {
      return Array.from({ length: gridSize}, (e, y) => ({ x, y, color: 'white', highlight: false }));
    });

    return cells;
  }

  repopAntOn(cells) {
    const x = Math.round(cells.length / 2);
    this.Ant = new Ant(x, x);
    cells[this.Ant.Y][this.Ant.X].highlight = true
  }

  depopAnt() {
    this.Ant = null
  }

  moveAnt(cells) {
    if (this.Ant === null) {
      return
    }

    cells[this.Ant.Y][this.Ant.X].highlight = false
    if (cells[this.Ant.Y][this.Ant.X].color === 'white') {
      cells[this.Ant.Y][this.Ant.X].color = 'black'
      this.Ant.turnLeft().moveForward()
    }
    else {
      cells[this.Ant.Y][this.Ant.X].color = 'white'
      this.Ant.turnRight().moveForward()
    }

    if (this.Ant.Y < 0 || this.Ant.Y >= cells.length || this.Ant.X < 0 || this.Ant.X >= cells.length) {
      this.depopAnt()
      return
    }
    
    cells[this.Ant.Y][this.Ant.X].highlight = true
    // console.log(`moveAnt (x:${this.Ant.X}, y:${this.Ant.Y}, d:${this.Ant.Direction})`);
  }

  moveAntUntil(cells, nbSteps) {
    for (var i=0; i < nbSteps; i++) {
      this.moveAnt(cells);
    }
  }

  onGridSizeChange(e) {
    const size = parseInt(e.target.value)
    const cells = this.createCells(size)
    this.repopAntOn(cells);
    this.setState({ cells });
  }

  onNbStepsChange(e) {
    const nbSteps = parseInt(e.target.value)
    this.setState({ nbSteps });
  }

  onIntervalChange(e) {
    const interval = parseInt(e.target.value)
    this.setState({ interval });
  }

  moveNext() {
    if (!this.IsRunning) {
      return
    }

    const { interval, nbSteps, cells } = this.state
    this.moveAntUntil(cells, nbSteps)
    this.setState({ cells });

    // https://upmostly.com/tutorials/setinterval-in-react-components-using-hooks
    // https://sebhastian.com/setinterval-react/
    setTimeout(() => this.moveNext(), interval)
  }

  stop() {
    this.IsRunning = false
  }

  start() {
    if (this.IsRunning) {
      return
    }

    this.IsRunning = true
    this.moveNext()
  }

  reset() {
    this.stop()

    const cells = this.createCells(this.state.cells.length)
    this.repopAntOn(cells);
    this.setState({ cells });
  }

  render() {
    const { cellSize, interval, nbSteps, cells } = this.state

    return (
      <div>
        <h1 id="tabelLabel" >Langton's Ant</h1>
        <div className="board">
          <Settings gridSize={cells.length} onGridSizeChange={(e) => this.onGridSizeChange(e) }
            nbSteps={nbSteps} onNbStepsChange={(e) => this.onNbStepsChange(e) }
            interval={interval} onIntervalChange={(e) => this.onIntervalChange(e) }
            onStartClick={() => this.start() } onStopClick={() => this.stop() } onResetClick={() => this.reset() } />
          <Grid cellSize={cellSize} cells={cells} />
        </div>
      </div>
    );
  }
}
