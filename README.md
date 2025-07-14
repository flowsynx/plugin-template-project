# FlowSynx plugin template

This is a ready-to-use **Class Library template** for .NET, designed to help you quickly set up a clean and consistent starting point for your plugin.

You can use it with both the **.NET CLI** and **Visual Studio**.

---

## 🚀 Getting Started

### Install the Template

To use this template, you first need to install it:

```bash
dotnet new -i FlowSynx.PluginTemplate::1.0.0
```

---

### Create a New plugin Library

Run the following command to create a new plugin from this template:

```bash
dotnet new fxplugin -n MyPlugin
```

Replace `MyPlugin` with your desired plugin name.

This will create a folder with a pre-configured **C# Class Library project** ready for development.

---

## 🎨 Visual Studio Support

This template works in Visual Studio. After installation:

1. Open **Visual Studio**
2. Go to **File > New > Project**
3. Search for: `FlowSynx Plugin Template`
4. Select the template and click **Next**

---

## 🛠 Updating the Template

If a new version of the template is available, you can update it by running:

```bash
dotnet new -u FlowSynx.PluginTemplate
dotnet new -i FlowSynx.PluginTemplate::1.1.0
```

---

## 📦 Template Features

✅ Clean Class Library structure  
✅ Compatible with .NET 6, 7, and 8+  
✅ Works with both the CLI and Visual Studio  

---

## 📂 Project Structure

When you create a project, the following structure is generated:

```
MyPlugin/
│
├── Models/
│   ├── InputParameter.cs
│   └── MathPluginSpecifications.cs
├── flowsynx.png
├── MathPlugin.cs
└── README.md
```
---

## ❓ Need Help?

If you run into issues using this template:

- Make sure you have the latest version of the .NET SDK installed.
- Try uninstalling and reinstalling the template:

```bash
dotnet new -u FlowSynx.PluginTemplate
dotnet new -i FlowSynx.PluginTemplate
```

- Restart Visual Studio after installation to refresh the template list.

---

## Copyright
© FlowSynx. All rights reserved.