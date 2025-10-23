# PLC 上位机控制系统

# ENGLISH VERSION SEE BELOW

## 概述

本项目是一款基于 **C# WinForm + SQLite** 开发的 **PLC 上位机控制软件**，运行于 **Windows 10 / 11** 平台。  
系统用于对生产线中的 PLC（可编程逻辑控制器）进行实时监控、数据采集、参数下发、配方管理与权限控制。

支持以下 PLC 型号：

- 三菱 FX 系列（通过串口通信）
- 西门子 Smart-200 系列（通过以太网通信）

---

## 系统架构

| 模块             | 功能说明                                                                                                            |
| ---------------- | ------------------------------------------------------------------------------------------------------------------- |
| **通信管理模块** | 基于 [HslCommunication](https://github.com/dathlin/HslCommunication) 实现，支持多线程异步通信、断线检测与自动重连。 |
| **数据存储模块** | 使用 SQLite 存储通信配置、监控地址、配方数据、用户信息与日志。                                                      |
| **监控界面模块** | 提供实时监控界面，用户可自定义 PLC 地址并实时查看寄存器值。                                                         |
| **配方管理模块** | 支持保存与加载生产参数，实现快速切换生产线。                                                                        |
| **权限控制模块** | 提供三层权限体系（超级管理员、管理员、操作员），限制关键操作。                                                      |
| **日志管理模块** | 记录系统运行与操作日志，可筛选、导出 PDF 文档。                                                                     |

---

## PLC 通信机制

### 三菱 FX 系列

- 通信方式：串口（RS-232 / RS-485）
- 实现类：`HslCommunication.Melsec.MelsecFxSerial`

### 西门子 Smart-200 系列

- 通信方式：以太网（S7 协议）
- 实现类：`HslCommunication.Siemens.SiemensS7Net`

### 通信特性

- 支持自定义通信参数（端口号、波特率、站号、超时等）
- 周期性扫描机制，实时刷新监控数据
- 自动断线检测与重连机制
- 多线程异步通信，界面操作流畅无卡顿

---

## 用户与权限系统

| 角色           | 权限说明                                                                                             |
| -------------- | ---------------------------------------------------------------------------------------------------- |
| **超级管理员** | 最高权限，可修改监控地址、通信参数、用户配置、导出日志等。此账户在数据库中存在，但在实际应用中隐藏。 |
| **管理员**     | 可管理配方、查看监控数据、导出日志。                                                                 |
| **操作员**     | 仅可查看实时数据、加载配方。                                                                         |

> 登录信息及权限存储在 SQLite 数据库中。  
> 系统启动后需登录验证。

---

## 配方与数据管理

- 每个配方包含一组生产参数及对应的 PLC 地址。
- 用户可保存、修改、加载配方，实现不同生产线参数的快速切换。
- 数据修改可实时写入 PLC。
- 配方存储于 SQLite 数据库中，可导出 / 导入。

---

## 日志与通信状态

- 系统自动记录用户操作与运行状态日志。
- 日志可按时间段筛选、导出为 CSV / Excel。
- 通信状态实时显示（在线 / 断线），断线自动尝试重连。

---

## 系统特性总结

| 特性         | 说明                                   |
| ------------ | -------------------------------------- |
| **运行环境** | Windows 10 / 11                        |
| **开发框架** | .NET WinForm                           |
| **数据库**   | SQLite                                 |
| **通信框架** | HslCommunication（开源版本）           |
| **PLC 支持** | 三菱 FX Serial / 西门子 Smart-200      |
| **主要功能** | 实时监控、配方管理、权限控制、日志导出 |
| **安全机制** | 登录认证、操作权限、日志追踪           |
| **稳定性**   | 通信状态检测、断线重连、多线程刷新机制 |

---

## 开发与运行

### 依赖项

- .NET Framework 4.8 或更高版本
- SQLite 驱动程序（System.Data.SQLite）
- HslCommunication（开源版）

### 编译与运行

1. 使用 Visual Studio 打开解决方案
2. 恢复 NuGet 依赖
3. 编译并运行主程序
4. 配置 PLC 通信参数并登录系统

---

## 许可证

本项目使用 **HslCommunication 开源版本**，遵循其开源协议。  
其余代码版权归本项目作者所有。

# PLC Upper Computer Control System

## Overview

This project is a **PLC upper computer control software** developed based on **C# WinForm + SQLite**, running on **Windows 10 / 11**.  
It is designed for real-time monitoring, data acquisition, parameter control, recipe management, and user permission control for PLCs (Programmable Logic Controllers) in industrial production lines.

Supported PLC models:

- Mitsubishi FX Series (via Serial Communication)
- Siemens Smart-200 Series (via Ethernet Communication)

---

## System Architecture

| Module                              | Description                                                                                                                                                                          |
| ----------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Communication Management Module** | Built on [HslCommunication](https://github.com/dathlin/HslCommunication), supporting multi-threaded asynchronous communication, disconnection detection, and automatic reconnection. |
| **Data Storage Module**             | Uses SQLite to store communication settings, monitoring addresses, recipe data, user information, and operation logs.                                                                |
| **Monitoring Interface Module**     | Provides a real-time monitoring interface where users can customize PLC addresses and view register values in real time.                                                             |
| **Recipe Management Module**        | Supports saving and loading of production parameters for quick production line switching.                                                                                            |
| **Permission Control Module**       | Implements a three-level permission system (Super Admin, Admin, Operator) to restrict critical operations.                                                                           |
| **Log Management Module**           | Records system runtime and user operations, with filtering and PDF export support.                                                                                                   |

---

## PLC Communication Mechanism

### Mitsubishi FX Series

- Communication Type: Serial (RS-232 / RS-485)
- Class Used: `HslCommunication.Melsec.MelsecFxSerial`

### Siemens Smart-200 Series

- Communication Type: Ethernet (S7 Protocol)
- Class Used: `HslCommunication.Siemens.SiemensS7Net`

### Communication Features

- Supports custom communication parameters (port, baud rate, station number, timeout, etc.)
- Periodic scanning mechanism for real-time data refresh
- Automatic disconnection detection and reconnection
- Multi-threaded asynchronous communication for smooth UI operation

---

## User and Permission System

| Role                    | Description                                                                                                                                                                         |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Super Administrator** | Highest privilege level; can modify monitoring addresses, communication parameters, user settings, and export logs. The account exists in the database but is hidden in actual use. |
| **Administrator**       | Can manage recipes, view monitoring data, and export logs.                                                                                                                          |
| **Operator**            | Can only view real-time data and load recipes.                                                                                                                                      |

> Login information and permissions are stored in the SQLite database.  
> The system requires user login before accessing the main interface.

---

## Recipe and Data Management

- Each recipe contains a set of production parameters and corresponding PLC addresses.
- Users can save, edit, and load recipes for quick production line switching.
- Parameter changes are written to the PLC in real time.
- Recipes are stored in SQLite and can be exported/imported.

---

## Log and Communication Status

- The system automatically records user operations and runtime events.
- Logs can be filtered by time range and exported to CSV / Excel.
- Real-time communication status display (online/offline) with automatic reconnection on failure.

---

## System Features Summary

| Feature                     | Description                                                               |
| --------------------------- | ------------------------------------------------------------------------- |
| **Operating Environment**   | Windows 10 / 11                                                           |
| **Development Framework**   | .NET WinForm                                                              |
| **Database**                | SQLite                                                                    |
| **Communication Framework** | HslCommunication (Open Source Version)                                    |
| **Supported PLCs**          | Mitsubishi FX Serial / Siemens Smart-200                                  |
| **Main Functions**          | Real-time Monitoring, Recipe Management, Permission Control, Log Export   |
| **Security Mechanisms**     | Login Authentication, Permission Control, Operation Logging               |
| **Stability**               | Connection State Detection, Auto Reconnection, Multithreaded Data Refresh |

---

## Development and Execution

### Dependencies

- .NET Framework 4.8 or higher
- SQLite Driver (`System.Data.SQLite`)
- HslCommunication (Open Source Version)

### Build and Run

1. Open the solution in Visual Studio
2. Restore NuGet dependencies
3. Build and run the main project
4. Configure PLC communication parameters and log in

---

## License

This project uses the **open-source version of HslCommunication**, following its respective license.  
All other code and resources are © owned by the project author.
