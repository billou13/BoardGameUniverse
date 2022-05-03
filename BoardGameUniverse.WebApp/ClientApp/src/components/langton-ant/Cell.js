
export function Cell(props) {
    const settings = {...{
            size: "30px"
        }, ...props
    }

    console.log(settings.size)

    const style = {
        width: settings.size,
        height: settings.size
    }

    return (
        <div className="cell" style={style} />
    );
}
