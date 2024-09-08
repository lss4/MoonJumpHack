## Rayman 2 Moon Jump Hack Revised
---
This is an attempt to address some issues I noticed with szymski's original Moon Jump Hack which can be found [here](https://raymanpc.com/forum/viewtopic.php?t=23420).

The code targets .NET Framework 2.0 so it should be able to run on older Windows versions such as Windows XP.

You need Visual Studio 2022 Community if you want to build the project by yourself.

### Instructions and notes

If you're using the retail CD version without any No-CD patch, you need to check the "Retail CD" checkbox before starting. In other cases (patched, or using the GOG version), the "Retail CD" checkbox must remain unchecked.

If the hack does not work due to incorrect "Retail CD" checkbox setting, exit the game, correct it and start the game again.

The way to use it is the same as szymski's original hack. Use F3 to activate, and F4 to deactivate.

When activated, you'll fly up when using helicopter, as well as being able to jump higher than usual.

You can only activate the hack when the program has detected your game's process. When the game exits, the hack will be disabled automatically.

Memory is now touched only when the hack is enabled and when the address holding the necessary data has been successfully read. This hopefully fixes the issue with the original hack that the player may be randomly teleported to unknown locations regardless of whether the hack is enabled or not.

Unlike the original hack, when the game exits, the program will continue to run after cleaning up, and can be used again when you restart the game. However, it is not advised to keep the hack process running for too long while the game is not running, as the call to scan for the game's process (`Process.GetProcessesByName`) can lead to the program's memory footprint grow continuously over time. For that reason I've reduced the process scanning frequency a bit in hope to slow down the growth.