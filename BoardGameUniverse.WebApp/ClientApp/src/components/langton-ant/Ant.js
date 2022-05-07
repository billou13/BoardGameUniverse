
const Direction = Object.freeze({
    Up: 0,
    Right: 1,
    Down: 2,
    Left: 3
})

export class Ant {
    constructor(x, y) {
        this.X = x
        this.Y = y
        this.Direction = Direction.Right
    }

    isAt(x, y) {
        return x === this.X && y === this.Y;
    }

    moveForward() {
        if (this.Direction === Direction.Up) this.Y -= 1;
        else if (this.Direction === Direction.Right) this.X += 1;
        else if (this.Direction === Direction.Down) this.Y += 1;
        else if (this.Direction === Direction.Left) this.X -= 1;
        return this;
    }

    turnLeft() {
        if (this.Direction === Direction.Up) this.Direction = Direction.Left;
        else if (this.Direction === Direction.Right) this.Direction = Direction.Up;
        else if (this.Direction === Direction.Down) this.Direction = Direction.Right;
        else if (this.Direction === Direction.Left) this.Direction = Direction.Down;
        return this;
    }

    turnRight() {
        if (this.Direction === Direction.Up) this.Direction = Direction.Right;
        else if (this.Direction === Direction.Right) this.Direction = Direction.Down;
        else if (this.Direction === Direction.Down) this.Direction = Direction.Left;
        else if (this.Direction === Direction.Left) this.Direction = Direction.Up;
        return this;
    }
}
