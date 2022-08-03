import { Card } from './Card';
import { useParams } from 'react-router-dom';

export function CardHook() {
    const { code } = useParams();
    return (<Card key={`card-${code}`} code={code} />);
}
