# Unity 2D Platformer

A 2D platformer game built with Unity as part of my game development learning journey.

## 🎮 Controls (PC)

- **A / D** - Move left/right
- **Space** - Jump (hold for higher jump!)
- **Escape** - Pause

## 🏆 Win / Lose Conditions

- **Win:** Collect all coins → Level Complete
- **Lose:** Health reaches 0 → Game Over

## ✅ Current Features

### Movement & Physics
- Player Movement: Horizontal movement with air control (reduced in-air mobility)
- Jump Mechanics: Variable jump height (tap vs hold)
- Better Jump: Faster falling + responsive short jumps
- Coyote Time: 0.1s grace period after leaving platform edge
- Jump Buffer: 0.1s input memory for forgiving timing
- Raycast Ground Detection: Accurate ground checking
- Physics-based Controls: Proper FixedUpdate implementation

### Camera
- Cinemachine: Virtual camera with smooth damping
- Rigidbody2D Interpolation: Jitter-free camera follow

### Enemy AI
- Idle / Patrol / Chase state machine
- Contact damage with cooldown
- Dynamic Rigidbody2D (Gravity Scale 0)

### Game Flow
- Game Over screen + restart
- Level Complete screen + restart
- Pause / Game Over / Win conflict resolved

### UI & Menus
- Pause Menu: ESC to pause/resume
- Game Over Panel
- Level Complete Panel
- Score UI: Real-time score display
- Health UI: Real-time health display + hit flash
- Debug HUD: F1 toggle (grounded state + velocity display)

### Gameplay
- Collectible System: Coin pickup with trigger detection
- Score Manager: Singleton pattern with win condition check
- Prefab Workflow: Reusable Player and Obstacle prefabs

## 🛠️ Technical Details

- **Engine:** Unity 6.3 LTS
- **Language:** C#
- **Platform:** PC (Windows + macOS builds)
- **Camera:** Cinemachine 3.x
- **Physics:** Rigidbody2D with Interpolation
- **Input:** New Input System (Player) + Legacy (UI)

## 📹 Demo

- **v0.1 Release** - Basic movement + jump
- **v0.2 Release** - Coin system + pause menu + UI
- **v0.3 Release** - Enemy AI + Game Over + Level Complete

## 🚀 Development Progress

Following a 7-month learning plan toward Junior Unity Developer position.

### Month 1 — Completed
**Week 2:**
- ✅ Movement + Jump mechanics
- ✅ Git workflow + GitHub repo
- ✅ Build pipeline (macOS)

**Week 3:**
- ✅ Camera system (CameraFollow + Cinemachine)
- ✅ UI systems (DebugHUD + Pause Menu + Score UI)
- ✅ Prefab workflow
- ✅ Collectible coin system with score tracking

### Month 2 — In Progress
**Week 1:**
- ✅ New Input System setup
- ✅ Player movement refactor

**Week 2:**
- ✅ Enemy idle / patrol / chase AI
- ✅ Contact damage system + cooldown
- ✅ Game Over flow
- ✅ Level Complete flow
- ✅ Pause conflict fixes
- ✅ Mini level v1

## 👨‍💻 Developer

- **Developer:** Ömer F. Arıkbuğa
- **GitHub:** @omerarkbua01
- **Learning Plan:** v4.5 - 7-month Unity game development roadmap
