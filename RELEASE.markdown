Incremental release to improve performance and handling.

# Unicode

- Additional work to handle Unicode characters with navigation and mouse clicking. +Changed
- Moved the UTF-8 processing into MfGames.GtkExt

# Improvements

- Added some locking around the cached renderer to allow it to handle getting events from other threads more gracefully, in specific the line changed events. +Changed

# Dependencies

- MfGames.GtkExt 0.2.0
