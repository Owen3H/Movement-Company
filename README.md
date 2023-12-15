# MovementCompany-Enhanced
A maintained version of 2018's [Movement-Company](https://github.com/u-2018/Movement-Company).<br>
PRs welcome :)

# Installation
1. Install [BepInEx](https://github.com/BepInEx/BepInEx/releases) v5 into your game.
2. Install the [LC API](https://thunderstore.io/c/lethal-company/p/2018/LC_API/) into your game.
3. Download `MovementCompanyEnhanced.dll` and drop it into `Lethal Company\BepInEx\plugins`.

## Goals
- Option for bhopping to drain stamina.
- Air crouching
- Sliding?
  
## Changelog
- Hardcoded values were replaced with a config file. (Synchronized with host)
  > Automatically generated at `BepInEx/config` when the game launches.
- Current coords + velocity now displayed. To turn it off, set `bDisplayDebugInfo` to `false`.
- Removed jump delay.
- Improved maintainability.
    - Harmony initialization now wrapped in a try-catch.
    - Re-organized project and made use of abstraction with aptly named methods.
    - Plugin metadata now has its own class - no longer hidden deep in `/obj/../../`.
    - Made it easier to PR (post-build event, gitignore)
- Code optimizations.
    - MovementAdder removed. Movement script is now given on player spawn instead of each frame.
- Misc
    - Fixed player spawning mid-air which caused them to fly around the ship.
    - Base player speed slightly increased. `4f` -> `4.2f`
