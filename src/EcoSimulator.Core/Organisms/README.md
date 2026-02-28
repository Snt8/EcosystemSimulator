# 🧬 Organism: `src/EcoSimulator.Core`

> **Definition**: This directory contains the logic of every **Organism** in the simulator. Here are the standard classes and the specific Organism classes. Also here are the Organism configuration and reporting.

## 📂 Directory Structure:

* 🌿 `/Organism`: Contains the main logic of `Organism`, `FaunaOrganism`, and `FloraOrganism`.
* 🐺 `/Fauna`: Contains the specific classes that implement the `FaunaOrganism` logic.
* 🌻 `/Flora`: Contains the specific classes that implement the `FloraOrganism` logic.
* ⚙️ `/OrganismDataConfig`: Contains the attribute configuration for the constructor of the `Fauna` and `Flora` classes.
* 📊 `/SpeciesReport`: Contains the report of the Organism species to save it in every turn.

## 🚀 How to use it?

Every file in this directory lives in the `EcoSimulator.Core.Organism` namespace. If you want to use a specific component, you need to write the directory where the file lives also.