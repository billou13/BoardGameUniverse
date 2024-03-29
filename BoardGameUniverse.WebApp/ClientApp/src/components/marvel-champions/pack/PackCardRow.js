import { Link } from 'react-router-dom';

export function PackCardRow(props) {
    const { packCode, code, name, factionCode, cost, typeCode, traits, setCode } = props

    return (
        <tr>
            <td data-th="Name"><Link to={`/marvel-champions/card/${code}`}>{name ?? code}</Link></td>
            <td data-th="Class">{factionCode}</td>
            <td data-th="Cost">{cost}</td>
            <td data-th="Type">{typeCode}</td>
            <td data-th="Resources">&nbsp;</td>
            <td data-th="Traits">{traits}</td>
            <td data-th="Pack">{packCode}</td>
            <td data-th="Set">{setCode}</td>
        </tr>
    );
}
