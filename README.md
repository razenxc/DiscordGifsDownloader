# Discord Gifs Downloader
## I created this console app because I wanted to download all my favourite GIFs from Discord

# How to use it
## 1. Get a txt file with URLs of GIFs with JS code down below(Control + Shift + I in Web Discord or Desktop Discord)
```js
allow pasting
```
```js
let wpRequire;
window.webpackChunkdiscord_app.push([[ Math.random() ], {}, (req) => { wpRequire = req; }]);
    
let FrecencyUserSettings = Object.values(wpRequire.c).find(x => x?.exports?.DZ?.updateAsync).exports.DZ
let gifsList = FrecencyUserSettings.getCurrentValue().favoriteGifs.gifs
console.log(Object.values(gifsList).map(gif => gif.src.startsWith("//") ? "https:" + gif.src : gif.src).join('\n'))
```
```js
// Credits to u/Zuuxie from reddit
// The code works at the moment of 4 April 2024
// The code could stop working at any time
```

## 2. Move and drop the file to the console app

## 3. Get files in the current directory of the app(./Discord Gifs Export)

# To-Do
- Auto convert .mp4/.bin to .gif