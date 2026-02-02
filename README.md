# Clipboard Queue 🧠📋

Clipboard Queue is a modern, efficient **Windows clipboard manager** built with **WPF** and **.NET 10.0**. It quietly captures your clipboard history, organizes it by category, and allows for instant retrieval, ensuring you never lose a copied item again.

![License](https://img.shields.io/badge/license-MIT-blue.svg) ![Platform](https://img.shields.io/badge/platform-Windows-lightgrey.svg) ![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)

---

## ✨ Features

### Smart Clipboard Management
*   **📋 Live Capture**: Automatically records Text, RichText, and Images.
*   **📂 Categorization**: Auto-sorts content into **General**, **Code**, **Work**, and **Personal** bins.
*   **📌 Pinning**: Keep frequently used items at the top of your list.
*   **🔍 Search**: Instant search filter to find buried clips.
*   **🗑️ Easy Cleanup**: Delete individual items or **Clear All** with a single click.

### Modern User Experience
*   **🎨 Card Design**: Beautiful, modern UI with clear typography and hover effects.
*   **🌗 Theming**: Native Dark and Light mode support (`Ctrl + D`, `Ctrl + L`).
*   **🪟 Stealth Mode**: Minimizes to the System Tray to stay out of your way.
*   **⌨️ Global Hotkeys**:
    *   `Ctrl + Alt + V`: Show/Hide App
    *   `Ctrl + D`: Dark Mode
    *   `Ctrl + L`: Light Mode
*   **💾 Auto-Save**: History persists across reboots (saved to `%TEMP%\clipboard.json`).

---

## 🛠️ Technology Stack

*   **Framework**: [Microsoft .NET 10.0](https://dotnet.microsoft.com/)
*   **UI Library**: Windows Presentation Foundation (WPF)
*   **Architecture**: MVVM (Model-View-ViewModel)
*   **Pattern**: Command Pattern for UI interactions (RelayCommand)
*   **Data Format**: JSON (System.Text.Json)

---

## 🚀 Getting Started

### Prerequisites

*   Windows 10 or Windows 11.
*   [.NET 10.0 Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (or SDK for development).

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
├── Models/             # Data models (ClipboardItem, Enums)
├── Services/           # Core logic (Clipboard monitoring, Storage, Hotkeys)
├── ViewModels/         # MainViewModel with filtering, sorting, and commands
├── Views/              # MainWindow with modern XAML templates and styles
├── Commands/           # Reusable ICommand implementations (RelayCommand)
├── Themes/             # Styling resources (Light.xaml, Dark.xaml)
├── docs/               # Documentation
└── App.xaml            # Application entry point
```

---

## ⚙️ Configuration

The application stores its data in your temporary directory:
`%TEMP%\clipboard.json`

Clear this file if you wish to reset your clipboard history manually, or use the **Clear All** button in the app.

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

---

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.
