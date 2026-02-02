# Architecture Overview

## Tech Stack
- WPF (.NET)
- WinForms (NotifyIcon only)

---

## Core Components

### ClipboardService
- Hooks into Windows clipboard events
- Emits clipboard items safely

### HotkeyService
- Registers global hotkey
- Restores app window

### TrayService
- Handles system tray icon

### ThemeService
- Switches ResourceDictionaries

### MainViewModel
- Holds clipboard items
- Search filtering

---

## Design Notes
- Event-driven
- No background threads
- UI thread safe
- Offline-first
