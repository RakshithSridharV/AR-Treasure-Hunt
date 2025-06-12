# 🧭 AR Treasure Hunt (Unity + AR Foundation)

AR Treasure Hunt is a mobile Augmented Reality (AR) game built using Unity and AR Foundation. The player explores their environment by scanning surfaces, tapping to place clues, and sequentially finding all clues to reveal a final treasure.

---

## 🚀 Features

- ✨ AR Plane Detection using AR Foundation
- 🔎 Interactive clue discovery system
- 📊 Real-time score and progress tracking
- 🏆 Final treasure reveal after completing all clues
- 🔄 Full game reset functionality
- 🎯 Smooth UI animations with LeanTween
- 🎨 Clean and responsive UI using TextMeshPro

---

## 🛠️ Technologies Used

- **Unity 2022.3 LTS**
- **AR Foundation (ARCore/ARKit compatible)**
- **C#**
- **TextMeshPro**
- **LeanTween** (for smooth UI animations)

---

## 📦 Project Structure

AR_Treasure_Hunt/
│
├── Assets/
│ ├── Scenes/
│ ├── Scripts/
│ ├── Prefabs/
│ ├── Materials/
│ └── UI/
│
├── ProjectSettings/
├── Packages/
└── (Standard Unity files)

---

## 🎮 How to Play

1. **Build and run the app on an ARCore/ARKit supported device.**
2. **Scan your environment to detect horizontal planes.**
3. **Tap on a detected plane to place the first clue.**
4. **Tap on each clue to collect it and reveal the next one.**
5. **After all clues are found, the treasure will be revealed.**
6. **Use the Reset button to restart the treasure hunt.**

---

## 📱 Build Instructions

### Prerequisites:

- Unity 2022.3 LTS
- Android SDK or Xcode (for mobile build)
- AR Foundation package installed

### Building for Android:

1. Open project in Unity.
2. Switch to `Android` platform via `File > Build Settings`.
3. Ensure AR Foundation and ARCore XR Plugin packages are installed.
4. Build and run on a physical Android device with ARCore support.

---

## 🐛 Known Issues

- Reset function requires full scene state reload for perfect reset.
- Clues may occasionally spawn very close together (can be improved with randomized placement).
- Visual and sound effects can be further enhanced.

---

## 📌 Roadmap / TODO

- [ ] Improve clue spawn randomness
- [ ] Add particle effects and sound feedback
- [ ] Implement timer / scoring leaderboard
- [ ] Multiplayer support
- [ ] Complete reset state optimization

---

## 🤝 Contributions

Contributions are welcome!  
Please fork the repository and submit pull requests for review.

---

## 📄 License

This project is for educational purposes. Feel free to modify and use for personal or academic AR projects.

---

## 👨‍💻 Author

Developed by: *[V.Rakshith Sridhar]*  
Date: 2025

---


