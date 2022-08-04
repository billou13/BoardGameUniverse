import { Pack } from './Pack';
import { useParams } from 'react-router-dom';

export function PackHook() {
    const { code } = useParams();
    return (<Pack code={code} />);
}
