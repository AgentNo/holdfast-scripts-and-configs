# CHANGELOG

# 20th October 2023
- Updated CSHO mod to release version
- Removed 'Freeze!' mod as this is no longer needed with CSHO

# 14th October 2023
- Removed Faction replacement mod from all CSHO configs. This will be added back in at a later date.
- Updated CSHO frontlines config to use Alexaroth's new CSHO economy mod (DEV - this will need replaced for the actual event)

# 2nd April 2023
- Fixed factions in CSHO master config being incorrectly set to NaW factions
- Added awp_india (1.6) as an alternate lobby map
- Added Faction and Sound replacer mod to all CSHO configs. This mod replaces the old sound mod on NaW configs

# 13th November 2022
- Fixed weather and game mode on Cannon Racing config

# 12th November 2022
- Added Cannon Racing config

# 24th October 2022
- Improved faction class overriding in Spammy's Class HP Manager (v. 1.0.8)

# 12th October 2022
- Updated all Melee Arena configs to use the new `melee_weapons_only false` comamnd rather than `rc set meleeArenaAllowShooting`

# 1st October 2022
- Added faction override ability to Spammy's Class HP Manager (v. 1.0.4)
- Added an attempted fix at HP bar display issues (v. 1.0.6)

# 30th September 2022
- Fixed issue in Spammy's Chat Filter where output logs for players leaving were incorrectly formatted (v. 1.0.6)
- Added Spammy's Class HP Manager (v. 1.0.5)

# 18th September 2022
- Fixed mod_variable handling in CSHO master configs

# 16th September 2022
- Updated Spammy's Chat Filter to v. 1.0.5

# 15th September 2022 
- Updated all CSHO configs to use the new weapon and ammo override system
- Re-named `OfficerOrderType` to `HighCommandOrderType` in line with v.2.8 IHoldfastSharedMethods2 updates. This affects the following scripts:
    - BlankInterface
    - Freeze!
    - No UwU/OwO Allowed!
- Fixed an issue where some CSHO maps were omitted from map voting

# 27th July 2022
- Added master Battlefield and Melee Arena configs for CSHO Frontlines
- Adding missing rules to de_mirage (CSHO NaW master config)

# 2nd July 2022
- Updated Spammy's Chat Filter with new interface methods

# 30th June 2022
- Added `CS 1.6 Sound Pack (NaW)` to the Nations At War CSHO maps

# 26th June 2022
- Removed `CS 1.6 Sound Pack` from de_train (1.6) config
- Added Fronlines AB configs for CSHO maps

# 25th June 2022
- Upped max slots of all CSHO maps to 50
- Fixed a typo in the master configs
- Added server welcome messages to master configs (NaW) 

# 27th May 2022
- Updated implementation of No OwO/UwU Allowed!
- Added No OwO/UwU Allowed! to master config

# 26th May 2022
- Updated interface template to `IHoldfastSharedMethods2` API
- Updated implementation of Freeze! script
- Re-added new Freeze! script to config

# 17th May 2022
- Completly replaced the other weather config commands with the new Frontlines weather presets
- Fixed an issue where the map load directive was accidentally removed from `de_survivor (1.6)`
- Removed deprecation notice on `README.md`
- Fixed multiple discrepencies between master and individual configs, especially with Army Battlefield configs
- Re-added placeholder in `configs/holdfast-offensive/frontlines` directory

# 12th March 2022
- Removed `CS 1.6 Sound Pack` and `Freeze!` mods temporarily

# 19th February 2022
- Created Changelog. We'll pretend that this repo never existed before this point ;)
- TODO for future updates:
    - Configure Frontlines version of CSHO configs
    - Adjust movement speed and spawn overrides