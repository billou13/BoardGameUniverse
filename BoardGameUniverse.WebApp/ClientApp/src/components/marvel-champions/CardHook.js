import { Card } from './Card';
import { useParams } from 'react-router-dom';

export function CardHook() {
    const { pack, code } = useParams();
    return (<Card pack={pack} code={code} />);
}
