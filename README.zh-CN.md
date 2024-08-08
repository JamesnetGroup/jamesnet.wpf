
# Jamesnet.Wpf [![英文](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![中文](https://img.shields.io/badge/Language-中文-red.svg)](README.zh-CN.md) [![韩文](https://img.shields.io/badge/Language-한국어-green.svg)](README.ko.md)

基于 .NET Core 的应用程序的综合性 WPF 框架库，扩展了 Prism 和 CommunityToolkit.Mvvm

[![许可证: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/Jamesnet.Wpf.svg)](https://www.nuget.org/packages/Jamesnet.Wpf/)
[![下载量](https://img.shields.io/nuget/dt/Jamesnet.Wpf.svg)](https://www.nuget.org/packages/Jamesnet.Wpf/)
[![星标](https://img.shields.io/github/stars/jamesnet214/jamesnetwpf.svg)](https://github.com/jamesnet214/jamesnetwpf/stargazers)

## 项目概述

Jamesnet.Wpf 是一个为现代 .NET Core 应用程序设计的强大 WPF 框架库。它在主要库的功能基础上进行扩展，为在 .NET Core 生态系统中构建健壮、易维护和可扩展的 WPF 应用程序提供了全面的解决方案。

## 主要特性和实现

#### 1. .NET Core 优化
- [x] 与 .NET Core 的依赖管理系统完全兼容
- [x] 利用 .NET Core 的增强性能和跨平台功能

#### 2. 高级依赖注入
- [x] 基于 Prism.Unity 的简化依赖注入系统
- [x] 单例实例和类型的高效管理

#### 3. 增强的 MVVM 架构
- [x] 扩展 CommunityToolkit.Mvvm 以提供额外的 MVVM 实用工具
- [x] 简化的视图注册和视图/视图模型连接
- [x] 用于视图注入的区域管理

#### 4. 资源管理
- [x] 动态资源绑定功能
- [x] 集成的主题和本地化结构

#### 5. UI 组件和实用工具
- [x] 用于矢量图形的 Geometry Path 图标
- [x] 利用 WpfAutoGrid.Core 的增强型 Grid 功能
- [x] 自定义控件如 JamesPanel、JamesContent、JamesWindow 等

#### 6. 应用程序框架
- [x] 基于 PrismApplication 的扩展 Application 类 (JamesApplication)
- [x] 为 .NET Core 设计的综合性 WPF 框架架构

## 技术栈
- .NET 8.0+ (基于 Core)
- WPF (Windows Presentation Foundation)

## 核心依赖
Jamesnet.Wpf 利用以下主要库：

#### 1. Prism.Unity
- 提供强大的 MVVM 框架和模块化架构
- 可实现松耦合、可测试和易维护的应用程序
- 提供高级功能如依赖注入和事件聚合

#### 2. CommunityToolkit.Mvvm
- 简化 MVVM 模式实现
- 提供源生成器以减少样板代码
- 为视图模型提供各种辅助工具和基类

#### 3. WpfAutoGrid.Core
- 通过自动布局功能增强 WPF 的 Grid 控件
- 简化复杂的网格定义
- 提高 XAML 布局的可读性和可维护性

## 入门指南
### 先决条件
- [x] Visual Studio 2022 或更高版本
- [x] Jetbrains Rider
- [x] .NET 8.0 SDK 或更高版本
- [x] 推荐 Windows 11

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

### 安装
在 .NET Core WPF 项目中安装 Jamesnet.Wpf NuGet 包：

```
dotnet add package Jamesnet.Wpf
```

或通过 NuGet 包管理器：

```
Install-Package Jamesnet.Wpf
```

## 在 .NET Core 项目中使用
Jamesnet.Wpf 专为基于 .NET Core 的 WPF 应用程序设计。它充分利用 .NET Core 的依赖管理系统，实现更灵活、更高效的应用程序架构。

.NET Core 的主要优势：
- 简化的依赖管理
- 性能提升
- 与现代 .NET 生态系统更好的兼容性

Jamesnet.Wpf 在多个 GitHub 项目中使用，包括：
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

## 主要组件
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

## 贡献
欢迎对 Jamesnet.Wpf 做出贡献！请提交问题、创建拉取请求或提出改进建议。

## 许可证
本项目基于 MIT 许可证发布。详情请参阅 [LICENSE](LICENSE) 文件。

## 联系方式
- 网站：https://jamesnet.dev
- 电子邮件：james@jamesnet.dev, lukewire129@ghamil.com, vickyqu115@hotmail.com

使用 Jamesnet.Wpf 来提升您的 .NET Core WPF 开发体验！
