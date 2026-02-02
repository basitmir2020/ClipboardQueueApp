# Clipboard Queue 🧠📋

Clipboard Queue is a **production-ready Windows clipboard manager** built with **WPF** and **.NET 10.0**. It offers a premium user experience with smart history management, live feedback, and robust editing capabilities.

![License](https://img.shields.io/badge/license-MIT-blue.svg) ![Platform](https://img.shields.io/badge/platform-Windows-lightgrey.svg) ![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)

---

## ✨ Features

### Smart Clipboard Management
*   **📋 Live Capture**: Automatically records Text, RichText, and Images.
*   **📂 Categorization**: Sorting for **General**, **Code**, **Work**, and **Personal** items.
*   **🧠 Intelligent Deduplication**: Re-copying an item moves it to the top instead of duplicating it.
*   **📌 Pinning**: Keep frequently used clips at the top.
*   **✎ Editing**: Modify clipboard text directly within the app.

### Premium User Experience
*   **🎨 Production UI**: Beautiful card-based design with hover effects and smooth typography.
*   **💬 Live Feedback**: Snackbar notifications confirm actions (e.g., "Copied to clipboard").
*   **🌑 Theming**: Native Dark and Light mode support (`Ctrl + D`, `Ctrl + L`).
*   **🪟 Stealth Mode**: Minimizes to the System Tray.
*   **⌨️ Global Hotkeys**:
    *   `Ctrl + Alt + V`: Show/Hide App
    *   `Ctrl + D`: Dark Mode
    *   `Ctrl + L`: Light Mode

---

## 🛠️ Technology Stack

*   **Framework**: [Microsoft .NET 10.0](https://dotnet.microsoft.com/)
*   **UI Library**: Windows Presentation Foundation (WPF)
*   **Architecture**: MVVM (Model-View-ViewModel)
*   **Design Patterns**: Command Pattern, Event Aggregation (Lite)
*   **Data Format**: JSON (System.Text.Json)

---

## 🚀 Getting Started

### Prerequisites

*   Windows 10 or Windows 11.
*   [.NET 10.0 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0).

### Installation & Run

```bash
# Clone the repository
git clone https://github.com/YOUR_USERNAME/ClipboardQueueApp.git

# Navigate to the project directory
cd ClipboardQueueApp

# Run the application
dotnet run
```

---

## 📁 Project Structure

```text
ClipboardQueueApp
├── Models/             # Data models (ClipboardItem)
├── Services/           # Background services (Hotkey, Tray, Storage)
├── ViewModels/         # Application logic (MainViewModel)
├── Views/              # UI (MainWindow, EditWindow)
├── Commands/           # RelayCommand implementation
├── Themes/             # Styling resources
└── App.xaml            # Entry point
```

---

## ⚙️ Configuration

The application stores its data in: `%TEMP%\clipboard.json`.
You can clear this history anytime using the **Clear All** button in the app.

---

## 🤝 Contributing

Contributions are welcome!
1.  Fork the Project
2.  Create your Feature Branch
3.  Commit your Changes
4.  Push to the Branch
5.  Open a Pull Request

---

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.
