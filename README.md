# Clipboard Queue 🧠📋

Clipboard Queue is a **Windows clipboard manager** built with **WPF (.NET)**.  
It captures everything you copy and lets you reuse clipboard history instantly.

---
## Folder Structure
## Folder Structure

```text
ClipboardQueueApp
├── ClipboardQueueApp.sln
├── ClipboardQueueApp
│   ├── Models/
│   ├── Services/
│   ├── ViewModels/
│   ├── Views/
│   ├── Themes/
│   ├── App.xaml
│   ├── MainWindow.xaml
│   └── ClipboardQueueApp.csproj
├── installer/
│   └── ClipboardQueueInstaller.iss
├── docs/
│   ├── INSTALL.md
│   ├── TESTING.md
│   └── ARCHITECTURE.md
├── README.md
├── LICENSE
└── .gitignore 
```


---

## ✨ Features

- 📋 Live clipboard capture
- 🔁 Restore clipboard items on double-click
- ⌨️ Global hotkey: `Ctrl + Alt + V`
- 🌙 Dark / Light mode (`Ctrl + D`, `Ctrl + L`)
- 🔍 Search clipboard history
- 🪟 Minimize to system tray
- 🚀 Single EXE build
- 🔒 Fully offline (no cloud, no tracking)

---

## 🧠 How It Works

1. Listens to Windows clipboard events
2. Stores clipboard items in memory
3. Displays them in a searchable list
4. Double-click → copies item back to clipboard
5. Runs quietly in the system tray

---

## 🖥️ Requirements

- Windows 10 / 11
- .NET SDK 8.0+ (for development only)

---

## 🚀 Run Locally

```bash
git clone https://github.com/YOUR_USERNAME/ClipboardQueueApp.git
cd ClipboardQueueApp
dotnet run 
```
---

## ⌨️ Keyboard Shortcuts

| Shortcut       | Action     |
| -------------- | ---------- |
| Ctrl + Alt + V | Show app   |
| Ctrl + D       | Dark mode  |
| Ctrl + L       | Light mode |
| Double-click   | Copy item  |

