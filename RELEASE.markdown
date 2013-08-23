Incremental release to improve performance and handling.

# Signatures

- Exposed the margin rendererer collection as a property. +Changed

# Unicode

- Additional work to handle Unicode characters with navigation and mouse clicking. +Changed
- Moved the UTF-8 processing into MfGames.GtkExt

# Improvements

- Significantly improved performance with larger documents. +New
- Up/Down key navigation now works with left padding of styles. +New
- Added some locking around the cached renderer to allow it to handle getting events from other threads more gracefully, in specific the line changed events. +Changed
- Added a background line cacher to speed up scrolling performance and line calculations. +New
- If the popup menu callback removes all items, then the popup isn't shown. +Changed
- If there is a selection while typing, the selection is replaced with text. +New

# Dependencies

- MfGames.GtkExt 0.2.0
