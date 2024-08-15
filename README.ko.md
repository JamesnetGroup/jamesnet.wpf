# Jamesnet.Wpf [![英文](https://img.shields.io/badge/Language-English-blue.svg)](README.md) [![中文](https://img.shields.io/badge/Language-中文-red.svg)](README.zh-CN.md) [![韩文](https://img.shields.io/badge/Language-한국어-green.svg)](README.ko.md)

Prism과 CommunityToolkit.Mvvm을 확장한 .NET Core 기반 애플리케이션을 위한 종합적인 WPF 프레임워크 라이브러리

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/Jamesnet.Wpf.svg)](https://www.nuget.org/packages/Jamesnet.Wpf/)
[![Downloads](https://img.shields.io/nuget/dt/Jamesnet.Wpf.svg)](https://www.nuget.org/packages/Jamesnet.Wpf/)
[![Stars](https://img.shields.io/github/stars/jamesnet214/jamesnetwpf.svg)](https://github.com/jamesnet214/jamesnetwpf/stargazers)

## 프로젝트 개요

Jamesnet.Wpf는 현대적인 .NET Core 기반 애플리케이션을 위해 설계된 강력한 WPF 프레임워크 라이브러리입니다. 주요 라이브러리의 기능을 기반으로 확장하여 .NET Core 생태계에서 견고하고 유지보수가 용이하며 확장 가능한 WPF 애플리케이션을 구축하기 위한 종합적인 솔루션을 제공합니다.

## 주요 기능 및 구현 사항
#### 1. .NET Core 최적화
- [x] .NET Core의 의존성 관리 시스템과 완벽하게 호환
- [x] .NET Core의 향상된 성능과 크로스 플랫폼 기능 활용

#### 2. 고급 의존성 주입
- [x] Prism.Unity를 기반으로 한 간소화된 의존성 주입 시스템
- [x] 싱글톤 인스턴스 및 타입의 효율적인 관리

#### 3. 향상된 MVVM 아키텍처
- [x] CommunityToolkit.Mvvm을 추가 MVVM 유틸리티로 확장
- [x] 간소화된 뷰 등록 및 뷰/뷰모델 연결
- [x] 뷰 주입을 위한 리전 관리

#### 4. 리소스 관리
- [x] 동적 리소스 바인딩 기능
- [x] 통합된 테마 및 지역화 구조

#### 5. UI 컴포넌트 및 유틸리티
- [x] 벡터 그래픽을 위한 Geometry Path 아이콘
- [x] WpfAutoGrid.Core를 활용한 향상된 Grid 기능
- [x] JamesPanel, JamesContent, JamesWindow 등의 커스텀 컨트롤

#### 6. 애플리케이션 프레임워크
- [x] PrismApplication을 기반으로 한 확장 Application 클래스 (JamesApplication)
- [x] .NET Core를 위한 종합적인 WPF 프레임워크 아키텍처 설계

## 기술 스택
- .NET 8.0+ (Core 기반)
- WPF (Windows Presentation Foundation)

## 핵심 의존성
Jamesnet.Wpf는 다음과 같은 주요 라이브러리를 활용합니다:

#### 1. Prism.Unity
- 강력한 MVVM 프레임워크 및 모듈식 아키텍처 제공
- 느슨하게 결합되고 테스트 가능하며 유지보수가 용이한 애플리케이션 구현 가능
- 의존성 주입 및 이벤트 집계와 같은 고급 기능 제공

#### 2. CommunityToolkit.Mvvm
- MVVM 패턴 구현 간소화
- 상용구 코드 감소를 위한 소스 생성기 제공
- 뷰모델을 위한 다양한 헬퍼 및 기본 클래스 제공

#### 3. WpfAutoGrid.Core
- 자동 레이아웃 기능으로 WPF의 Grid 컨트롤 향상
- 복잡한 그리드 정의 간소화
- XAML 레이아웃의 가독성 및 유지보수성 개선

## 시작하기
### 필요 조건
- [x] Visual Studio 2022 이상
- [x] Jetbrains Rider
- [x] .NET 8.0 SDK 이상
- [x] Windows 11 권장

<img src="https://github.com/user-attachments/assets/af70f422-7057-4e77-a54d-042ee8358d2a" width="32%"/>
<img src="https://github.com/user-attachments/assets/e4feaa10-a107-4b58-8d13-1d8be620ec62" width="32%"/>
<img src="https://github.com/user-attachments/assets/5ff487f6-55e4-43e1-9abf-f8d419ee6943" width="32%"/>

### 설치
.NET Core WPF 프로젝트에 Jamesnet.Wpf NuGet 패키지를 설치하세요:

```
dotnet add package Jamesnet.Wpf
```

또는 NuGet 패키지 관리자를 통해:

```
Install-Package Jamesnet.Wpf
```

## .NET Core 프로젝트에서의 사용
Jamesnet.Wpf는 .NET Core 기반 WPF 애플리케이션을 위해 특별히 설계되었습니다. .NET Core의 의존성 관리 시스템을 최대한 활용하여 더욱 유연하고 효율적인 애플리케이션 아키텍처를 가능하게 합니다.

.NET Core의 주요 이점:
- 간소화된 의존성 관리
- 향상된 성능
- 현대적인 .NET 생태계와의 더 나은 호환성

Jamesnet.Wpf는 다음을 포함한 다수의 GitHub 프로젝트에서 사용됩니다:
- [WPF: League of Legends](https://github.com/jamesnet214/leagueoflegends)
- [Reflector](https://github.com/jamesnet214/reflector)
- [ColorPicker](https://github.com/jamesnet214/colorpicker)
- [ICommander](https://github.com/jamesnet214/icommander)
- [DevFlow](https://github.com/jamesnet214/devflow)
- [WPF Explorer](https://github.com/jamesnet214/wpf-explorer)
- [Theme Switch](https://github.com/jamesnet214/themeswitch)
- [Riot Play Button](https://github.com/jamesnetgroup/riotplaybutton)
- [Magic Navigation](https://github.com/jamesnetgroup/navigationbar)
- [Riot Slider](https://github.com/jamesnetgroup/riotslider)
- [Smart Date](https://github.com/jamesnetgroup/smartdate)
- [Cupertino TreeView](https://github.com/jamesnetgroup/cupertino-treeview)

## 주요 구성 요소
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

## 기여하기
Jamesnet.Wpf에 대한 기여를 환영합니다! 이슈를 제출하거나, 풀 리퀘스트를 생성하거나, 개선 사항을 제안해 주세요.

## 라이선스
이 프로젝트는 MIT 라이선스 하에 배포됩니다. 자세한 내용은 [LICENSE](LICENSE) 파일을 참조하세요.

## 연락처
- 웹사이트: https://jamesnet.dev
- 이메일: james@jamesnet.dev, lukewire129@ghamil.com, vickyqu115@hotmail.com

Jamesnet.Wpf로 .NET Core WPF 개발 경험을 향상시켜 보세요!
