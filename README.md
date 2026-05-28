# Backyard Roast

Backyard Roast is an interactive mobile gaming experience built with the Unity Engine and C#. Developed over a multi-year software engineering lifecycle, the project serves as a production-grade demonstration of modular mobile architecture, deterministic game loops, and continuous mobile delivery systems.

## ✨ Features & Gameplay Experience
* **Predictable Gameplay Systems:** A robust mobile game loop designed for fluid runtime interactions and reliable mechanics.
* **Responsive Multi-Platform UI:** A unified user interface layout built to natively scale and handle dynamic asset presentation across diverse mobile device aspect ratios.
* **Analytics & Performance Tracking:** Integrated background telemetry to monitor engine performance, application stability, and target user interaction during live sessions.

## 🛠️ Architecture & Technical Stack
For engineering reviewers, the codebase implements strict structural patterns to isolate subsystems and maintain absolute control over the execution state.

* **Core Engine & Scripting:** Driven entirely by C# scripts interacting with the Unity Engine API.
* **State Management:** Core gameplay state transitions are managed using rigid Finite State Machines (FSM) to ensure bug-free execution between global menus, gameplay states, and resource unloading.
* **Telemetry & Integration:** Abstracted third-party SDK integrations to separate analytical data collection and ad-delivery mechanics from core physics and rendering pipelines.
* **DevOps & Lifecycle Management:** Built and deployed directly through the Google Play Console to drive closed-beta test environments, handle production app bundle packaging, and manage targeted device distribution lists.

## 🚀 Getting Started

### Beta Access & Installation
Backyard Roast is distributed exclusively via a managed closed-beta testing pipeline[cite: 2]:
1. Whitelisted testers can download and install the current active build directly through their Google Play Store account.
2. Over-the-air updates and minor patch distributions are managed automatically via the Google Play Console testing track.

### Local Development Environment
To open and explore the project files locally, you require:
* **Unity Hub** & **Unity Editor** (Matching the designated project version)
* **Visual Studio** or **Rider** with game development workflows enabled

1. Clone this repository locally.
2. Open Unity Hub, select `Add project from disk`, and target the root repository folder.
3. Allow the editor to import assets and compile project assembly files before launching the primary Scene.
