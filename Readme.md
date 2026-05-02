# 🧪 Chlor-Alkali Process Simulation (Unity)

An interactive **3D industrial simulation** of the Chlor-Alkali process built using Unity.
This project visualizes electrolysis of brine and demonstrates how **current density affects ion movement and product formation**.

---

## 🎯 Project Overview

This simulation represents a simplified industrial chlor-alkali plant where users can:

* Adjust **current density**
* Observe **ion movement (Na⁺, Cl⁻)**
* Visualize **gas formation (Cl₂, H₂)**
* Monitor **NaOH production**
* Understand electrochemical behavior interactively

---

## ⚙️ Features

### 🔌 Electrolysis Simulation

* Real-time ion movement using particle systems
* Separate visualization for:

  * Sodium ions (Na⁺)
  * Chloride ions (Cl⁻)
  * Electrons

---

### 📊 Dynamic Current Control

* Interactive **slider for current density**

* Predefined values:

  * 2500 A/m²
  * 4000 A/m²
  * 5500 A/m²
  * 7000 A/m²

* Changes affect:

  * Ion speed
  * Particle emission rate
  * Gas generation

---

### 💨 Product Visualization

* Chlorine gas (Cl₂) at anode
* Hydrogen gas (H₂) at cathode
* Sodium hydroxide (NaOH) formation

---

### 🏭 Industrial View

* Full 3D plant layout including:

  * Brine tank
  * Electrolyzer cell
  * Gas storage tanks
  * Pumps and pipelines

---

### 🧑‍🏫 Guided Interface

* UI panels for explanation
* Step-by-step learning support
* Interactive navigation buttons

---

## 🛠️ Tech Stack

* **Engine:** Unity 6
* **Language:** C#
* **UI:** TextMeshPro
* **Rendering:** Built-in Render Pipeline
* **Particles:** Unity Particle System

---

## 🧠 Core Concepts Implemented

* Electrolysis of NaCl solution
* Ion migration under electric field
* Effect of current density on reaction rate
* Gas evolution at electrodes
* Basic industrial process flow

---

## 🚀 How to Run

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/chlor-alkali-simulation.git
   ```

2. Open in Unity Hub:

   * Unity version: **6000.2.12f1 or later**

3. Open scene:

   ```
   Assets → Scenes → Industrial View
   ```

4. Click ▶ Play




## 📁 Project Structure

```
Assets/
│
├── Scenes/
│   ├── Industrial View
│   ├── Cell View
│   └── Welcome Scene
│
├── Scripts/
│   ├── SimulationController.cs
│   ├── ElectronSpawner.cs
│
├── Prefabs/
├── Materials/
├── Objects/
└── UI/
```






