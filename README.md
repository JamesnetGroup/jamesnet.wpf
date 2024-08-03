# Jamesnet.Wpf [![English](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![한국어](https://img.shields.io/badge/Language-한국어-red.svg)](README.ko.md)

A comprehensive WPF framework library for .NET Core-based applications, extending Prism and CommunityToolkit.Mvvm

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/Jamesnet.Wpf.svg)](https://www.nuget.org/packages/Jamesnet.Wpf/)
[![Downloads](https://img.shields.io/nuget/dt/Jamesnet.Wpf.svg)](https://www.nuget.org/packages/Jamesnet.Wpf/)
[![Stars](https://img.shields.io/github/stars/jamesnet214/jamesnetwpf.svg)](https://github.com/jamesnet214/jamesnetwpf/stargazers)

## Project Overview

Jamesnet.Wpf is a powerful WPF framework library designed for modern .NET Core-based applications. It builds upon and extends the capabilities of key libraries to provide a comprehensive solution for building robust, maintainable, and scalable WPF applications in the .NET Core ecosystem.

## Key Features and Implementations
#### 1. .NET Core Optimized
- [x] Fully compatible with .NET Core's dependency management system
- [x] Leverages .NET Core's enhanced performance and cross-platform capabilities

#### 2. Advanced Dependency Injection
- [x] Builds upon Prism.Unity for a streamlined dependency injection system
- [x] Efficient management of singleton instances and types

#### 3. Enhanced MVVM Architecture
- [x] Extends CommunityToolkit.Mvvm with additional MVVM utilities
- [x] Simplified view registration and view/viewmodel connections
- [x] Region management for view injection

#### 4. Resource Management
- [x] Dynamic resource binding capabilities
- [x] Integrated theming and localization structures

#### 5. UI Components and Utilities
- [x] Geometry Path icons for vector graphics
- [x] Enhanced Grid functionalities leveraging WpfAutoGrid.Core
- [x] Custom controls like JamesPanel, JamesContent, JamesWindow

#### 6. Application Framework
- [x] Extended Application class (JamesApplication) based on PrismApplication
- [x] Comprehensive WPF framework architecture design for .NET Core

## Technology Stack
- .NET 8.0+ (Core-based)
- WPF (Windows Presentation Foundation)

## Core Dependencies
Jamesnet.Wpf leverages the following key libraries:

#### 1. Prism.Unity
- Provides a powerful MVVM framework and modular architecture
- Enables loosely coupled, testable, and maintainable applications
 - Offers advanced features like dependency injection and event aggregation

#### 2. CommunityToolkit.Mvvm
- Simplifies MVVM pattern implementation
- Provides source generators for boilerplate reduction
- Offers a rich set of helpers and base classes for viewmodels

#### 3. WpfAutoGrid.Core
- Enhances WPF's Grid control with auto-layout capabilities
- Simplifies complex grid definitions
- Improves readability and maintainability of XAML layouts

## Getting Started
### Prerequisites
- [x] Visual Studio 2022 or later
- [x] Jetbrains Rider
- [x] .NET 8.0 SDK or later
- [x] Windows 11 recommended

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

### Installation
Install the Jamesnet.Wpf NuGet package in your .NET Core WPF project:

```
dotnet add package Jamesnet.Wpf
```

Or via the NuGet Package Manager:

```
Install-Package Jamesnet.Wpf
```

## Usage in .NET Core Projects
Jamesnet.Wpf is specifically designed for .NET Core-based WPF applications. It takes full advantage of .NET Core's dependency management system, allowing for more flexible and efficient application architecture.

Key benefits in .NET Core:
- Simplified dependency management
- Enhanced performance
- Better compatibility with modern .NET ecosystems

Jamesnet.Wpf is used in numerous GitHub projects, including:
- [WPF: League of Legends](https://github.com/jamesnet214/leagueoflegends)
- [Reflector](https://github.com/jamesnet214/reflector)
- [ColorPicker](https://github.com/jamesnet214/colorpicker)
- [ICommander](https://github.com/jamesnet214/icommander)
- [DevFlow](https://github.com/jamesnet214/devflow)
- [WPF Explorer](https://github.com/jamesnet214/wpf-explorer)
- [Theme Switch](https://github.com/jamesnet214/themeswitch)
- [Riot Play Button](https://github.com/vickyqu115/riotplaybutton)
- [Magic Navigation](https://github.com/vickyqu115/navigationbar)
- [Riot Slider](https://github.com/vickyqu115/riotslider)
- [Smart Date](https://github.com/vickyqu115/smartdate)
- [Cupertino TreeView](https://github.com/vickyqu115/cupertino-treeview)

## Key Components
- JamesPanel
- JamesGrid : AutoGrid
- JamesContent : ContentControl
- JamesWindow : Window
- JamesApplication : PrismApplication
- JamesDataGrid : DataGrid
- ViewModelLocationScenario
- WireDataContext
- ObservableBase : ObservableObject
- IViewable, IViewLoadable, IViewCreatable
- SmartField, TextField, ComboField, DateField, CheckField

## Contributing
Contributions to Jamesnet.Wpf are welcome! Please feel free to submit issues, create pull requests, or suggest improvements.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
- Website: https://jamesnet.dev
- Email: james@jamesnet.dev, lukewire129@ghamil.com, vickyqu115@hotmail.com

Enhance your .NET Core WPF development experience with Jamesnet.Wpf!

