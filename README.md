PoeHud
======

Beware, this is a Standalone derivate from the ast Public source by Evozer/Coyl.

### Watch the change in the License to GPL 3, wich means that every fork, or changes have to be distributed as Sourcecode. The License CANT  be changed at will and stays forever !


Reads data from Path of Exile client application and displays it on transparent overlay, while you play PoE.

### Requirements
* .NET framerwork v.4 or newer (you already have it on Windows 8+, otherwise here's your dowload link)
* Slim DX ([download link](http://slimdx.org/download.php) - pick version 4.0, for x86 platform) **Do not install x64 version**
* Windows Vista or newer (XP won't work)
* Path of Exile should be running in Windowed or Windowed Fullscreen mode (the pure Fullscreen mode does not let PoeHUD draw anything over the game window)
* Windows Aero transparency effects must be enabled. (If you get a black screen this is the issue)

### Item alert settings
The file config/crafting_bases.txt has the following syntax:
`Name,[Level],[Quality],[Rarity1,[Rarity2,[Rarity3]]]`

Examples of valid declarations:
```
Vaal Regalia,78
Corsair Sword,78,10
Gold Ring,75,,White,Rare
Ironscale Gauntlets,,10,White,Magic
Quicksilver Flask,1,5
Portal Scroll
Iron Ring
```


As im not good at offset finding it may be that this derivate wont work in the future without help from others 
(who can handle new offsets and/or even new structures).
so everyone who likes to put some work on it is welcome !!

Initial Version and idea by Evozer (still most of the structure is by him)

Enhancements by Coyl -> ([his compiled version can be found here](https://github.com/max-mtg/PoeHud)
thanks to both of you 
