
export function Cell(props) {
    const settings = {...{
            size: "30px"
        }, ...props
    }

    const style = {
        width: settings.size,
        height: settings.size
    }

    return (
        <div className="cell" style={style} x={props.x} y={props.y} />
    );
}
