# ⚙️ OS Process Scheduler Simulator (SRTF)

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-13.0-239120?style=flat-square&logo=csharp)
![JSON](https://img.shields.io/badge/Data-Newtonsoft.Json-000000?style=flat-square)
![Architecture](https://img.shields.io/badge/Design-SOLID%20%26%20Strategy%20Pattern-blue?style=flat-square)

A console-based Operating System CPU Scheduling Simulator built with **C# (.NET 9)** that models process execution across a discrete timeline using the **Shortest Remaining Time First (SRTF)** preemptive scheduling algorithm.

---

## 🎯 Project Overview & Engineering Goals

Rather than writing a tightly coupled script for a single scheduling formula, this project was engineered to demonstrate **Object-Oriented Design**, **Abstraction**, and **Data Integrity** in system simulations:

* **Extensible Architecture (`ISchedualProcess`):** Decouples the simulation timeline engine (`Program.cs`) from the scheduling algorithm (`ShortestProcess.cs`), enabling seamless integration of future algorithms (e.g., FCFS, Round Robin, Priority Scheduling) via polymorphism without modifying the core execution loop.
* **Non-Destructive Data Modeling (`Processes.cs`):** Separates the immutable original `BurstTime` from the mutable `RemainingBurstTime` during property initialization, preserving baseline execution data for post-simulation performance analytics.
* **External Configuration via JSON:** Reads dynamic process workloads from `processes.json` using `Newtonsoft.Json` deserialization.

---

## 🏗️ Project Structure

```text
ProcessSchedulerSimulator/
└── SchedualProcessOS/
    ├── BL/                         # Business Logic Layer
    │   ├── ISchedualProcess.cs     # Scheduling contract & queue definitions
    │   ├── ShortestProcess.cs      # SRTF preemptive scheduling implementation
    │   └── Processes.cs            # Process entity model (Arrival, Burst, Remaining)
    ├── Program.cs                  # Discrete timeline simulation engine & entry point
    └── processes.json              # Input workload configuration
```

---

## ⚙️ How It Works (Simulation Pipeline)

1. **Ingestion & Deserialization:** Loads process definitions (`processName`, `ArivalTime`, `BurstTime`) from `processes.json` into strongly typed `Processes` objects.
2. **Discrete Timeline Loop:** Advances a chronological counter (`nTimeLineIndex`) representing CPU time units.
3. **Dual-Check Preemption Logic:** At every time unit, the engine:
   * Evaluates newly arriving processes (`IncomingProcesses`) against the currently executing process.
   * Re-evaluates the `WaitingProcesses` queue (`IncomingQueue`) to guarantee that the process with the shortest remaining execution time always holds the CPU.
4. **Completion Tracking:** Moves finished processes (`RemainingBurstTime == 0`) into `EndedProcesses` until all scheduled workloads complete.

---

## 🚀 Getting Started

### Prerequisites
* [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* Visual Studio 2022 (v17.12+) or VS Code / .NET CLI

### Running Locally
1. **Clone the repository:**
   ```bash
   git clone [https://github.com/MoThabet20/ProcessSchedulerSimulator.git](https://github.com/MoThabet20/ProcessSchedulerSimulator.git)
   cd ProcessSchedulerSimulator/SchedualProcessOS
   ```
2. **Configure `processes.json`** (Ensure *Copy to Output Directory* is set to `Copy always` in Visual Studio):
   ```json
   [
     { "processName": "p1", "ArivalTime": 0, "BurstTime": 8 },
     { "processName": "p2", "ArivalTime": 3, "BurstTime": 3 },
     { "processName": "p3", "ArivalTime": 7, "BurstTime": 6 },
     { "processName": "p4", "ArivalTime": 11, "BurstTime": 2 }
   ]
   ```
3. **Build and run:**
   ```bash
   dotnet run
   ```

---

## 🗺️ Future Roadmap
* [ ] Calculate and display post-execution metrics (**Completion Time**, **Turnaround Time**, **Waiting Time**, and **Average Waiting Time**).
* [ ] Implement additional scheduling strategies (`FCFS`, `RoundRobin`, `SJF` Non-Preemptive) implementing `ISchedualProcess`.
* [ ] Add CPU Idle state handling for workloads where no process arrives at `t = 0`.

---

## 👨‍💻 Author
**Mohamed Thabet Hussein**  
Full Stack .NET Developer  
[GitHub](https://github.com/MoThabet20)
