# Clipboard Queue 🧠📋

Clipboard Queue is a modern, efficient **Windows clipboard manager** built with **WPF** and **.NET 10.0**. It quietly captures your clipboard history, organizes it by category, and allows for instant retrieval, ensuring you never lose a copied item again.

![License](https://img.shields.io/badge/license-MIT-blue.svg) ![Platform](https://img.shields.io/badge/platform-Windows-lightgrey.svg) ![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)

---

## ✨ Features

*   **📋 Smart Capture**: Automatically listens to and stores clipboard changes (Text, RichText, Images).
*   **📂 Categorization**: Organize items into **General**, **Code**, **Work**, and **Personal** categories.
*   **💾 Auto-Persistence**: seamless saving to `%TEMP%\clipboard.json` for lightweight persistence.
*   **⌨️ Global Hotkeys**:
    *   `Ctrl + Alt + V`: Toggle the application window.
    *   `Ctrl + D`: Switch to Dark Mode.
    *   `Ctrl + L`: Switch to Light Mode.
*   **📌 Pinning**: Pin important items to keep them accessible.
*   **🔍 Search**: Quickly filter your history to find what you need.
*   **🪟 System Tray**: Minimizes to the system tray to run unobtrusively in the background.
*   **🎨 Theming**: Built-in support for Dark and Light themes.

---

## 🛠️ Technology Stack

*   **Framework**: [Microsoft .NET 10.0](https://dotnet.microsoft.com/)
*   **UI Library**: Windows Presentation Foundation (WPF)
*   **Architecture**: MVVM (Model-View-ViewModel)
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
├── ViewModels/         # MVVM ViewModels (MainViewModel)
├── Views/              # UI Components (MainWindow)
├── Themes/             # Resource dictionaries for specific themes
├── docs/               # Documentation
└── App.xaml            # Application entry point & resource merging
```

---

## ⚙️ Configuration

The application stores its data in your temporary directory:
`%TEMP%\clipboard.json`

Clear this file if you wish to reset your clipboard history manually, or use the in-app controls if available.

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
