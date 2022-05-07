
export function Cell(props) {
    const { size, x, y, color, highlight } = props

    const style = {
        width: size,
        height: size
    }

    return (
        <div className={"cell " + (highlight ? "highlight" : color)} style={style} x={x} y={y} />
    );
}
