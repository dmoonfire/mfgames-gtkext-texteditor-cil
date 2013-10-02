Development to remove technical debt and artifacts associated with the migration to MfGames.Commands.

# Changes

- Removed legency references to BufferPosition and the integer-based system for MfGames.Commands.TextEditing LinePosition and CharacterPosition. +Changed
- Various corrections to get `Select All`, copying, and pasting working properly. +Changed
- Corrections to get the abstract text commands working with end of buffers and lines. +Changed
- Added extension methods to wrap the GetCharacterIndex and GetLineIndex in LineBuffer-specific calls. +Changed

# Dependencies

- MfGames.Command 0.2.0
