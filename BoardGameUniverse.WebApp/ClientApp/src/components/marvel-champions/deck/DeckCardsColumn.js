
export function DeckCardsColumn(props) {
    const { title, cards } = props

    let zIndex = 500;
    let top = 2;
    
    return (
      <div className='position-relative w-20'>
        <div>{title}</div>
        {cards.map((card) => {
          let style = {
            left: 0,
            top: top + 'rem',
            zIndex: zIndex++
          };

          top = top + 3.5;

          return (
            <div key={`card-${card.code}`} className='mc-deck-card position-absolute' style={style}>
              <img src={`${window.API_GATEWAY_URL}/image/card?code=${card.code}`} className='img-fluid' />
            </div>
          );
        })}
      </div>
    );
}
