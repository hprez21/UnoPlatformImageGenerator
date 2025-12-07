# ImageGenerator

A cross-platform AI image generation application built with **Uno Platform** and **.NET 10**. This demo showcases a beautiful, modern UI for generating AI-powered images with customizable styles and options.

![Uno Platform](https://img.shields.io/badge/Uno%20Platform-5.6-blue)
![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)

## 📱 Platforms

This application runs on multiple platforms from a single codebase:

| Platform | Target Framework |
|----------|-----------------|
| 🌐 WebAssembly | `net10.0-browserwasm` |
| 🖥️ Desktop (Windows/Linux/macOS) | `net10.0-desktop` |
| 📱 Android | `net10.0-android` |
| 🍎 iOS | `net10.0-ios` |

## ✨ Features

- **Dashboard View**: Browse your generated images with a beautiful carousel
- **Profile Management**: View and manage multiple user profiles with photo counts
- **Style Selection**: Choose from 10+ artistic styles (Cartoon, Realistic, Watercolor, Isometric, Pop Art, Surrealism, Minimalism, Funko, Anime, Storybook)
- **Prompt Editor**: Describe what you want to generate with a text prompt
- **Option Tags**: Select multiple generation options (World, Winter, Trees, Fantasy, Nature, Abstract)
- **Loading Animation**: Beautiful Lottie robot animation during generation
- **Material Design**: Consistent theming using Uno Material design system
- **Localization**: Multi-language support (English, Spanish, French, Portuguese)

## 🏗️ Architecture

The application follows the **MVUX** (Model-View-Update-eXtensions) pattern:

```
ImageGenerator/
├── Models/              # Data models
│   ├── Profile.cs       # User profile model
│   ├── ArtStyle.cs      # Art style selection model
│   ├── GeneratedImage.cs
│   └── SelectableOption.cs
├── Presentation/        # Views and ViewModels
│   ├── MainPage.xaml    # Dashboard with image carousel
│   ├── MainModel.cs     # Dashboard ViewModel
│   ├── SecondPage.xaml  # Style & options selection
│   ├── SecondModel.cs   # Selection ViewModel
│   ├── ThirdPage.xaml   # Generation progress/result
│   └── ThirdModel.cs    # Generation ViewModel
├── Services/            # API and business logic
├── Strings/             # Localization resources
└── Styles/              # Theme and styling
```

## 🛠️ Technologies & Uno Features

This project leverages the following Uno Platform features:

| Feature | Description |
|---------|-------------|
| **Material** | Material Design 3 theming and components |
| **MVUX** | Reactive state management pattern |
| **Navigation** | Region-based navigation system |
| **Toolkit** | Extended UI controls and helpers |
| **Lottie** | Vector animations support |
| **HttpKiota** | Modern HTTP client |
| **Localization** | Multi-language support |
| **ThemeService** | Light/Dark theme management |
| **SkiaRenderer** | Cross-platform rendering engine |

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Uno Platform Extension](https://platform.uno/docs/articles/get-started.html) (for Visual Studio or VS Code)
- Run `uno-check` to verify your environment setup

### Build & Run

#### Desktop (Windows/Linux/macOS)
```bash
cd ImageGenerator
dotnet build -f net10.0-desktop
dotnet run -f net10.0-desktop
```

#### WebAssembly
```bash
cd ImageGenerator
dotnet build -f net10.0-browserwasm
dotnet run -f net10.0-browserwasm
```

#### Android
```bash
cd ImageGenerator
dotnet build -f net10.0-android
```

#### iOS (macOS only)
```bash
cd ImageGenerator
dotnet build -f net10.0-ios
```

### VS Code Tasks

Pre-configured tasks are available:
- `build-wasm` - Build for WebAssembly
- `build-desktop` - Build for Desktop
- `publish-wasm` - Publish WebAssembly app
- `publish-desktop` - Publish Desktop app

## 📸 App Flow

1. **Main Page (Dashboard)**
   - View greeting and user profiles
   - Browse generated images in a carousel
   - Tap "Create New" to start image generation

2. **Second Page (Options)**
   - Select generation options (World, Winter, Trees, etc.)
   - Choose an artistic style from the gallery
   - Enter a text prompt describing your image
   - Tap "Generate" to proceed

3. **Third Page (Generation)**
   - Watch the robot Lottie animation while generating
   - See elapsed time counter
   - View the generated image result
   - Tap "Finish" to return to dashboard

## 🎨 Art Styles Available

| Style | Description |
|-------|-------------|
| 🎨 Cartoon | Animated cartoon style |
| 📷 Realistic | Photorealistic rendering |
| 🖌️ Watercolor | Watercolor painting effect |
| 🧊 Isometric | 3D isometric perspective |
| 🎭 Pop Art | Bold pop art style |
| 🌀 Surrealism | Surrealist dreamlike imagery |
| ⬜ Minimalism | Clean minimal design |
| 🧸 Funko | Funko Pop figure style |
| 🎌 Anime | Japanese anime style |
| 📖 Storybook | Children's book illustration |

## 📚 Resources

- [Uno Platform Documentation](https://platform.uno/docs/articles/intro.html)
- [Get Started with Uno Platform](https://aka.platform.uno/get-started)
- [Using Uno SDK](https://aka.platform.uno/using-uno-sdk)
- [MVUX Pattern Guide](https://platform.uno/docs/articles/external/uno.extensions/doc/Overview/Mvux/Overview.html)

## 📄 License

This project is a demo application for educational purposes.

---

Built with ❤️ using [Uno Platform](https://platform.uno)
