import { Cards } from './Cards';
import { useParams } from 'react-router-dom';

export function CardsHook() {
    const { pack } = useParams();
    return (<Cards pack={pack} />);
}
