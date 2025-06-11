# 🎮 Color Dash – A Fast-Paced Color Matching Runner

**Color Dash** is a 2D endless side-scrolling mobile game made in Unity, where the player must change their character’s color to match incoming gates. With increasing difficulty and satisfying visuals like particle effects and sound feedback, it's a reflex-based arcade experience optimized for mobile devices.

---

## 📱 Controls

- **Auto-Run**: The player character moves automatically from left to right.
- **Change Color**: Tap on one of the three color buttons (Red, Green, Blue) at the bottom of the screen to switch the character's color.
- **Retry**: Tap "Retry" on the Game Over screen to restart the game.

---

## 🧠 Game Logic

### Core Mechanics:
- **Match the Color**: The player must pass through gates of the same color as their character.
- **Mismatch Ends Game**: If the player hits a gate of a different color, the game ends.
- **Scoring**: Each correctly passed gate adds +1 to the score.

### Difficulty Progression:
- The game becomes harder over time as the gate speed gradually increases.
---

## 🌟 Features

| Feature                      | Description                                                |
|-----------------------------|------------------------------------------------------------|
| ✅ Endless Runner            | Auto-run gameplay with continuous gate spawning            |
| ✅ Color Matching Mechanic   | Tap to switch player color to match gates                  |
| ✅ Score & High Score        | Track current and highest scores using `PlayerPrefs`       |
| ✅ Touch-Based UI            | Mobile-optimized controls using Unity's UI system          |
| ✅ Object Pooling            | Gates are efficiently spawned and reused                   |
| ✅ Increasing Speed          | Game difficulty increases over time                        |
| ✅ Particle Effects          | Unique effects for Red, Green, and Blue gate passes        |
| ✅ Sound Effects             | Tap, success, and game over audio cues                     |

---

## ✨ Particle Effects

- Each correct gate pass triggers a matching **color-specific particle effect**:
  - 🔴 **Red Particle** for red gate
  - 🟢 **Green Particle** for green gate
  - 🔵 **Blue Particle** for blue gate
- Particles are either instantiated or played from scene objects depending on setup.

---

## 🎯 Project Structure (Core Scripts)

| Script             | Responsibility                                |
|--------------------|-----------------------------------------------|
| `PlayerController` | Handles color switching, gate detection, particle triggering |
| `GateSpawner`      | Spawns gates using object pooling             |
| `Gate`             | Defines gate behavior and color               |
| `GameManager`      | Manages score, high score, and game state     |
| `UIManager`        | Updates UI and handles game over / retry flow |
| `AudioManager`     | Centralized audio player (singleton)          |
| `ObjectPooler`     | Efficient object reuse for gates              |

---


## 👤 Author

- **Chitransh Nishad**
- Submission for: *Game Developer Role Task*

---
