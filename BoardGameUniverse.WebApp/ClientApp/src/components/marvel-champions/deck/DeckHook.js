import { Deck } from './Deck';
import { useParams } from 'react-router-dom';

export function DeckHook() {
    const { guid } = useParams();
    return (<Deck key={`deck-${guid}`} guid={guid} />);
}
