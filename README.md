# Board Game Universe

## Website
[Click here](https://boardgameuniverse.herokuapp.com) to enjoy the latest commit version.

## Technical information
Website has been initialized as following:
- [React with ASP.NET core](https://docs.microsoft.com/fr-fr/aspnet/core/client-side/spa/react?view=aspnetcore-6.0&tabs=visual-studio)
- [CircleCI as CI/CD platform](https://circleci.com)
- [Heroku as cloud platform](https://heroku.com)
    - [Heroku Postgres](https://elements.heroku.com/addons/heroku-postgresql)
    - [Heroku Redis](https://elements.heroku.com/addons/heroku-redis)

## To-do lists

### Features
- [X] [Fourmi de Langton en React](https://youtu.be/qZRYGxF6D3w)
- [ ] Marvel Champions (_work in progress_)
- [ ] Board Game Crawler
- [ ] other ideas...

### Technical tasks
- [x] Initialize project
- [x] CI/CD integration
- [ ] Architecture diagram ([work in progress](.diagrams/README.md))
- [ ] Deck service unit tests
- [ ] Include unit tests in CI/CD
- [ ] Ocelot caching
- [ ] Use [Auth0 authentication](https://blog.devgenius.io/how-to-build-a-net-core-api-secured-with-auth0-and-deploy-to-heroku-1b9df6bbd8b8) system

## Functional information

### Fourmi de Langton
- [grid in react](https://stackoverflow.com/questions/61625766/how-to-create-a-grid-in-react)
- [game of life](https://www.freecodecamp.org/news/create-gameoflife-with-react-in-one-hour-8e686a410174/)
- [pixel grid react](https://codesandbox.io/examples/package/pixel-grid-react)
- [isomectric grid](https://design.tutsplus.com/tutorials/quick-tip-how-to-create-an-isometric-grid-in-less-than-2-minutes--vector-3831)
- [react-isometric-grid](https://www.npmjs.com/package/react-isometric-grid)

### Marvel Champions
- [marvelsdb-json-data](https://github.com/zzorba/marvelsdb-json-data)
- [DragnCards](https://github.com/seastan/DragnCards)

### Board Game Crawler
Seek for specific board games on [Okkazeo](https://www.okkazeo.com), enriching data with [BoardGameGeek](https://boardgamegeek.com) API ([see here](https://boardgamegeek.com/wiki/page/BGG_XML_API2))

See also: [.NET library for interacting with the BGG XML API2](https://github.com/Cobster/BoardGamer.BoardGameGeek)

# Usefull links
- [react-chessboard](https://www.npmjs.com/package/react-chessboard)
- [mreishus spades](https://github.com/mreishus/spades)
- [Create a Card Game in Canvas with React Components](https://html5hive.org/create-a-card-game-in-canvas-with-react-components)
- [hexagonal grid in react with canvas](https://medium.com/swlh/how-to-draw-a-hexagonal-grid-in-react-with-canvas-d94f04d287ec)
- [react-grid-draw-ui](https://www.npmjs.com/package/react-grid-draw-ui)