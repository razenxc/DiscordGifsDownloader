# Discord Gifs Downloader
## I created this console app because I wanted to download all my favourite GIFs from Discord

# How to use it
## 1. Get a list of URLs using JS code down below(Control + Shift + I in Web Discord or Desktop Discord) and put them to a txt file
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
## 2. Put ffmpeg and ffprobe executables into ./bin directory (if the release does not have one)
- https://ffbinaries.com/downloads

or

- https://ffmpeg.zeranoe.com/builds/

## 3. Move and drop the txt file to the console app

## 4. Get files in the current directory of the app(./Discord Gifs Export)

# Thirdparty
[FFMpegCore](https://github.com/rosenbjerg/FFMpegCore)
