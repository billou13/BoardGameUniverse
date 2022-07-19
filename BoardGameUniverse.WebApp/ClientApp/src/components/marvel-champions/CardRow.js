import { Link } from 'react-router-dom';

export function CardRow(props) {
    const { pack_code, code, name, faction_code, cost, type_code, traits, set_code } = props

    const href = `/marvel-champions/card/${pack_code}/${code}`
    
    return (
        <tr>
            <td data-th="Name"><Link to={href}>{name}</Link></td>
            <td data-th="Class">{faction_code}</td>
            <td data-th="Cost">{cost}</td>
            <td data-th="Type">{type_code}</td>
            <td data-th="Resources">&nbsp;</td>
            <td data-th="Traits">{traits}</td>
            <td data-th="Pack">{pack_code}</td>
            <td data-th="Set">{set_code}</td>
        </tr>
    );
}
