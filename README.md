![deterpat-ezgif com-optimize](https://github.com/user-attachments/assets/87fe5f90-18ca-4c3b-8acf-c71fcc12c9cb)

<h1>Determined Path</h1>

<h3>About This Project</h3>
<p align="justify">Determined Path initially started as a project for Indie Game Ignite (IGI) Showcase. Afterwards, I kept working on this project for another GameToday Indie Game Competition.
This is public repository for public purposes</p>

<h3>Project Info</h3>

| **Role** | **Team Size** | **Development Time** | **Engine** |
|----------|---------------|---------------------|------------|
| Game Programmer | 3 | 1 Month | Unity 2022 |

<h3>Meet the Team</h3>

- Totti Adithana Sunarto (Lead Programmer & Level Designer)
- Juan Xavier Soegiarto (Lead Game Designer & Sound Designer)
- Yohanes Duns Scotus (Lead 3D Artist & 3D Animator)

<h3>Game Description</h3>
<p align="justify">"Determined Path" is a video game that depicts the daily life of Andi, a bus driver who works to meet his daily needs. 
The game highlights the dynamic relationship between bus drivers and passengers, emphasizing their mutual dependence. 
To serve the community effectively, buses require drivers who understand road ethics and possess the quick decision-making skills necessary for safety. 
Conversely, bus drivers choose this profession to earn a livelihood, making the relationship between drivers and passengers one of mutual necessity. 
In "Determined Path," players take on the role of the driver, maneuvering the bus, managing the bus environment, and ensuring safe transport of passengers. 
The game was envisioned to teach the players the importance of safety on the road, obeying traffic laws, and ensuring everyone on the road is having a great time.
</p>

<h3>Target Gameplay</h3>
<p align="justify">Casual players who want to use their free time to relax and unwind without having to think too much, while still maintaining the realistic aspects of being a public bus driver. 
To achieve this realism, Determined Path features a variety of mechanics that represent the experience of a bus driver to the players. Additionally, players are provided with eye-catching 
3D visual experiences to depict an immersive world from the perspective of a bus driver. To meet this goal, Determined Path will be designed for PC players.</p>

# Game Mechanics I Created
<h3>Simple Transaction System</h3>
<p align="justify">The Simple Transaction System allows players to simulate real-world transactions between passengers and the bus driver. Players are responsible for collecting fares, giving the correct change, and ensuring that each passenger’s payment is handled efficiently. This system adds a layer of realism and interactivity, enhancing the overall experience of managing daily bus operations.</p>

```
private void HandleTransaction()
{
    int fare = 10;  
    int passengers = Random.Range(1, currcap + 1);  
    int totalFare = passengers * fare;

    text_notif.text = passengers + " passengers paid " + totalFare + " coins.";
    //PlayerAccount.instance.AddCoins(totalFare);  
}
```

<h3>Occlusion and Level of Detail Optimization</h3>
<p align="justify">The Occlusion and Level of Detail Optimization improves game performance by dynamically adjusting the visibility and detail of objects based on the player’s perspective. This technique reduces rendering overhead, maintains high frame rates, and ensures that only relevant elements are fully rendered, providing a smoother gameplay experience without sacrificing visual quality.</p>

![Karantin_oklusion](https://github.com/user-attachments/assets/483ce7e5-308f-4f3d-84b5-d24c6c8ec178)

-> this gif is from another project, just to visualize what occlusion culling means

<h3>What I Learned From Make This Game</h3>
<p align="justify">Working on Determined Path has provided valuable insights into simulating realistic traffic systems and developing engaging gameplay mechanics that focus on player decision-making. I enhanced my understanding of pathfinding and AI behavior, ensuring that both the bus and surrounding vehicles followed realistic traffic patterns. Additionally, balancing the gameplay to maintain a sense of responsibility while keeping the experience fun was a rewarding challenge. I also refined my approach to creating player interactions, emphasizing how small decisions impact both the driver’s and passengers’ experiences. Initially, I tended to overcomplicate systems by trying to account for every potential scenario. However, while developing Determined Path, I embraced a more practical mindset, focusing on building the core mechanics first and gradually layering in complexity. This shift allowed me to deliver a more cohesive game and provided greater flexibility for refining the experience as new ideas emerged. Moving forward, I aim to continue prioritizing clarity and simplicity in my designs, improving efficiency without sacrificing depth.</p>

## Files description

```
├── DeterminedPath                     # In this Folder, containing all the Unity project files, to be opened by a Unity Editor
   ├── ...
   ├── Assets                         #  In this Folder, it contains all our code, assets, scenes, etcwas not automatically created by Unity
      ├── ...
      ├── 3rdParty                   # In this folder, there are several packages that you must add via Unity Package Manager
      ├── Scenes                     # In this folder, there are scenes. You can open these scenes to play the game via Unity
      ├── ....
   ├── ...
      
```
<br>

## Game controls

The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,S,A,D          | Movement|
| F           | Bus Light |
| E           | Honk |
| Space          | Brake |

<h3>Download Game</h3>
<p width="500px" align="left"><a href="https://juan-xavier.itch.io/determined-path">Determined Path Itch Page</p>

If you encounter problem, feel free to contact me
Thank you

3rd party assets:
- BOXOPHOBIC Free Skybox Extended Shader : https://assetstore.unity.com/packages/vfx/shaders/free-skybox-extended-shader-107400
- City Background Voxel : https://assetstore.unity.com/packages/3d/environments/urban/city-voxel-pack-136141
- Simple City Pack Plain : https://assetstore.unity.com/packages/3d/environments/urban/simple-city-pack-plain-100348
- TT Lakes Neue Font : https://www.dafont.com/tt-lakes-neue.font
- UI Icons : https://assetstore.unity.com/packages/2d/gui/icons/ux-flat-icons-free-202525
- Controller Icons : https://assetstore.unity.com/packages/2d/gui/icons/game-input-controller-icons-free-285953
- City Package : https://assetstore.unity.com/packages/3d/environments/urban/city-package-107224
- Low Poly Nature Pack : https://assetstore.unity.com/packages/3d/environments/landscapes/simple-low-poly-nature-pack-157552
- Yughues Free Bushes : https://assetstore.unity.com/packages/3d/vegetation/plants/yughues-free-bushes-13168
- Street Lights Pack : https://assetstore.unity.com/packages/3d/props/exterior/street-lights-pack-31644
- City Traffic Lights Pack Free Low Poly 3D : https://assetstore.unity.com/packages/3d/environments/urban/city-traffic-lights-pack-free-low-poly-3d-art-154053
- Tap In Sounds : https://pixabay.com/sound-effects/card-payment-machine-1-103738/
- Door Open : https://pixabay.com/sound-effects/ding-47489/
- Suara alarm Reputation 0 : https://pixabay.com/sound-effects/alarm-car-or-home-62554/
- Car Acceleration : https://www.youtube.com/watch?v=psbwY0TKwYo
- Crowd Sound : https://www.youtube.com/watch?v=yPtwbpByPds
