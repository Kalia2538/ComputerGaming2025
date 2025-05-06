# Grounds for Catastrophe

<img width="300" alt="CoverImg" src="https://github.com/user-attachments/assets/f8ce35c3-166f-4002-aa95-e3d85df061fb" />


## Team Members

- [Kalia2538](https://github.com/Kalia2538)
- [hana-ismaiel](https://github.com/hana-ismaiel)
- [ely-hi](https://github.com/ely-hi)

## Game Summary

A cozy, single-player game that allows you to step into the role of a barista. Players receive customer orders and prepare meals in a connected kitchen space. The goal is to fulfill each recipe with accuracy and care to keep customers happy and earn points. The overall experience focuses on relaxed, rewarding gameplay.

## Genres

Cooking Simulation, Co-op, Casual, Time Management

## Inspiration

### Good Pizza, Great Pizza

A cozy cooking game where players complete orders and grow their restaurant. The core mechanics of the game include task-based gameplay and a simple progression system, as well as fun storylines and side tasks the player can choose to engage with. The a focus on serving customers and upgrading the pizza shop are influences to our game design.


<img src = "https://www.nintendo-insider.com/wp-content/uploads/2020/09/good_pizza_great_pizza_review_screenshot_1.jpg" alt="Good Pizza Great Pizza Order w/ Customer" width="500"/>


### Overcooked

A fast-paced cooking game where players work together to prepare meals under time pressure. The core mechanics of the game include this cooperative aspect-- however, our game but will focus on calmer, more strategic teamwork with a lighter sense of urgency. The stylistic choices will also follow with this game dynamic to adhere to the 3D game style. Our main inspiration from Overcooked is the 3rd-position perspective of the kitchen and restaurant layout. 

<img src = "https://static1.thegamerimages.com/wordpress/wp-content/uploads/2022/11/plateup.jpeg" alt="Overcooked Layout" width="500"/>

### Papa's Mocharia

A game centered around preparing customized coffee orders to customers. The inspiration here is the way that the player must accurately fulfill the customer's order, and will recieve points based on how accurate the order is. 

<img src="https://i.redd.it/bt8m8s4bijk61.jpg" alt="Papa's Mocharia Customer/Order Delivery" width="500"/>


### Good Coffee Great Coffee

A game that focuses on brewing and serving coffee with various machine interactions. Our inspiration comes from its detailed approach to preparing drinks and having upgrades as the game progresses to improve efficiency of drink-making.

<img src="https://play-lh.googleusercontent.com/5Mqit1U5yYRDIerlm_VFRy6BXZjSjVSFwXy_89rFZfX0wZLEW4AkINt14LM9w9iMTA=w526-h296-rw" alt="Good Coffee Great Coffee Espresso Machine" width="500"/>

## Gameplay

### Player Interactions

- **Order Taking & Memory Challenge**  
  - At the start of the day (or when resuming), the player begins in the main café. When a customer arrives, the player interacts with them to take their order.  
  - Players can choose to write down the order using a notepad UI for reference — or skip writing it down for an added memory challenge.

- **Kitchen Prep**  
  - After taking the order, the player enters the kitchen to prepare the requested items. Orders may include:
    - **Espresso**, **stovetop coffee**, or **tea**
    - **Baked goods** like pastries or muffins  
  - The kitchen contains interactive appliances linked to specific drink or food types. Players must perform these tasks in the correct sequence to fulfill the order accurately.

- **Day Progression**
   - Each in-game day consists of helping **8 customers**. As the player completes orders, a visual clock on the screen tracks their progress. When the player reaches the halfway mark (after serving **4 customers**), the clock begins to **shake** as a subtle signal that the day is more than halfway complete. Once 8 customers are served, the day ends and can reset or continue via the **DayTransition** scene. This structure gives the player a clear gameplay loop while adding visual feedback to encourage pacing.

### Expected UI

- A **semi-realistic 3D café environment**, viewed from a top down perspective, allowing the player to navigate the closed space.
- A **scene transition button** enables the player to move between the café and the kitchen.
  - Pressing the button transitions to a **first-person view** inside the kitchen to allow for immersive preparation of orders.


### Game Controls

**Movement:**
- Use the **WASD** or **Arrow Keys** to move your character around the café and kitchen environments.

**Interactions:**
- The player interacts with appliances and items using **mouse clicks and drag mechanics**:
  - In the kitchen, clicking specific parts of drink machines (e.g., the top of the espresso machine, the tea kettle, or the coffee pot) will initiate drink creation.
  - Clicking on a requested baked good will automatically place it on a plate.
  - Once prepared, drinks must be **dragged and snapped** into the designated serving area. This allows the player to complete and deliver the order.

- You can use the **left and right arrow buttons** on the screen to scroll across the kitchen counter for easier access to machines and items.

**Pause Menu:**
- Press the **Escape key** or click the **pause button** in the top corner of the screen to open the pause menu.
- From the pause menu, players can adjust volume settings or return to the home screen.

## Development Plan

### Project Checkpoint 1-2: Basic Mechanics and Scripting (Ch 5-9)
* ~~Player proximity to the appliances~~
* ~~Basic player interactions with their environment (e.g., player movement and interacting with the environment)~~
* ~~Spawning of Customers to the counter~~
* ~~Set up cooking tasks e.g., making coffee~~
#### Additions
* Implemented a basic Keurig-style machine for making hot coffee in different cup sizes.
* Clicking the cup now correctly places it under the coffee machine.

### Project Part 2: 3D Scenes and Models (Ch 3+4, 10)
Complete the cafe and kitchen layout with interactive furniture and appliances. The materials should be complete, and decent lighting should be added.

Environment and Layout
* ~~Create cafe and kitchen with probuilder~~
* ~~Overall layout as before– something manageable by user/player~~

Assets + basic functionality 
* ~~Importing and adding 3D models~~
* Making sure the colliders for these models work properly 
* Set up interacting with appliances, like making the liquid dispense and grabbing cups
  
Visual effects and Scene Management 
* Scene transition from dining area to kitchen area
* ~~Lighting and shaders are implemented~~

#### Additions
* Created prefabs for customers and player

#### Justificaitons
* We did not do the scene transitioning (outside the scope of the assigned chapters)
* We did not set up interacting with appliances (outside of the scope of the assigned chapters)
* We did not test the colliders (outside of the scope of the assigned chapters)


### Project Part 3: Visual Effects (Ch 11, 12, & 13)
* ~~Simulation of liquid/fluid effects for pouring coffee~~  
* ~~Steam and smoke effects when brewing coffee~~  
* ~~Apply shadows and lighting to cafe and kitchen scenes~~  
* Use light probes for accurate lighting in cafe and kitchen scenes  
* Use high dynamic range (HDR) to cafe and kitchen scenes  
* ~~Scene transition~~ and realistic lighting changes when transitioning between scenes

#### Additions
* Player movement has been improved, using arrow keys
* The player can take the customer’s order by clicking UI buttons, and write down the order on a “notepad” UI input element
* We have experimented with various post-processing effects in the kitchen scene, including Morning Light, Night Mode, Rainy Day, and Warm Cafe Profile. To test this, in the kitchen scene, press "m", which will switch between the different views.
  * In our next iteration, we will make these profiles more robust, translating to the cafe scene as well.
  * We also hope to make the background more detailed so the user is not just placed "in a void" but in some scenery context. We hope these profiles will coincide with the background as well. 
* We have implemented various visual effects, including steam and smoke for making coffee, and sparkle effects in the kitchen and during customer interaction

#### Justifications
* We did not use light probes for lighting, because point lighting was sufficient for making the cafe well-lit
* We did not use HDR, because standard lighting and shading techniques were sufficient for the visual style of our game
* We have some scene transition (from cafe to kitchen), but we did not use lighting changes for transitions because it is outside the scope of the covered chapters


### Project Checkpoint 3-4: Music, UI and Animations
* ~~Background music for the cafe~~
* ~~Editing the volume of the music when inside of the kitchen~~
* ~~Adding sounds for kitchen appliances and timers~~
* ~~Adding UI elements for keeping track of orders,~~ customers, time, etc.
* Create walking and sitting animations
* ~~Animate the doors~~
* ~~Animations for kitchen appliances~~

#### Additions
* Added cash register soundeffects
* Added sound effects for UI elements
* Added speech bubbles for customer orders
* Improved UI design for buttons, notepad, text, etc.
* The game mechanics have been improved, including scene switching to and from the cafe
* The notepad persists between scenes
* The camera scroll bar is working in the kitchen
* Enhanced menu options in the kitchen: you can spawn a drink and a bakery item


#### Justifications
* We had trouble with doing the character/player animations. Our models did not come rigged, and using an auto-rigger wasn't possible due to the structure of our characters (no knees or elbows). We really liked the style of our current characters, so we tried to look for other solutions, but we did not have any success. We are considering picking new models for our characters.
* We did not use implement a timer in this iteration because we were focused on higher-priority mechanics (scene switching, customer ordering)


### Project Part 4: Finishing Touches (Ch 18 & 19)
In our final iteration, we plan to implement performance optimization and build polishing as mentioned in Chapters 18 and 19.

#### Planned Optimization (Ch 18)
- Use Unity's Frame Debugger to analyze draw calls and identify performance bottlenecks
- Use the Profiler to determine whether the game is CPU-bound or GPU-bound
-  ~~Apply batching for static GameObjects that share materials to reduce draw calls~~
(which was attempted with the customer instantiation when each scene are in 1 view. however, not present in current, where we use scene management.)
- Begin testing occlusion culling for walls and static props to improve rendering performance
- ~~Review and limit `Debug.Log` statements to prevent runtime performance issues, especially during pouring interactions~~

#### Planned Build Preparation (Ch 19)
- Adjust build settings: resolution, fullscreen mode, splash screen
- Enable script debugging and use the Profiler to monitor the built game
~~- Add a main menu scene to serve as the initial entry point~~
~~- Add a pause screen~~
- Test the executable on multiple systems and check for consistency between build and Editor

#### Additional Planned Features
~~- Complete and test full customer order flow (arrival → order → kitchen prep → serve)~~
~~- Display the written order note in the kitchen when switching scenes~~
- Finalize UI polish, including tooltips, prompts, feedback indicators, as well as final scenery additions

#### Justifications
While we initially planned to implement optimization and advanced build settings, we decided to prioritize our core game loop mechanics and UI polish in this final iteration. We focused on solidifying the customer order flow (order --> preparation --> serving) and visual feedback systems, as we believed that having a working game with engaging player feedback was more critical to address first. This focus on the mechanics ensures that our game is now fully playable.

#### Additions
* The main additions in this iteration were addressing feedback from the course staff, enhancing the UI with “juice” elements, and improving our game loop. These additions are discussed in more detail in the “Development” section, and include:
   * Improved customer and player models
   * Score system and customer reactions
   * Start/pause menu
   * Day tracking

### Final Project Submission
For our final submission, we will continue to work on refining the game flow and improving the player experience.
~~* Make sure customer movement matches the game state (e.g., customer lingers in cafe while order is being prepared, doesn't leave until order is served, have some way to indicate that the customer is walking away with their order)~~
* Add more features for score system besides accuracy (e.g., additional points for espresso brewed the right amount)
* Customer queue system: Customers can line up, and you can lose points the longer they wait
* Level progression based on points (e.g., new drink types or food items unlocked past a certain point threshold)

## Development
### Project Checkpoint 1-2
This deliverable consists of three main components:
1. Player movement and interaction system
* The player can move around the cafe environment using either WASD or arrow keys

2. Basic cafe and kitchen environment
* The dining area consists of tables, chairs, a service counter, and a kitchen area
* The counter will serve as the interaction point where customers place orders
* Players can interact with a Keurig machine--click the cup size to place under the machine, and click buttons to dispense coffee

3. Customer spawning and basic order request system
* Customers can dynamically enter and exit the area
* Customers generate order requests

<img width="500" alt="Cafe Scene" src="https://github.com/user-attachments/assets/3194be0e-d145-4629-b18a-2a7baf293721" />
<img width="500" alt="Kitchen Scene" src="https://github.com/user-attachments/assets/a4e5fecd-1eb4-428f-91ff-b86bc45c34a4" />

### Project Part 2: 3D Scenes and Models 
#### Cafe

Our cafe has ample seating, with wooden tables, stools, chairs, couches and sofas. The green and cream two-tone walls and windows gives the cafe a vibrant atmosphere. 

<img src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/Cafe_img.jpg" alt="Cafe-Topview" width="500"/>

The counter area has black and white tiling. We also added a register that is used to collect payment from the customers.

<img src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/Cafe_Sitting_Area.png" alt="Cafe Sitting Area" width="500"/>

#### Kitchen
We designed our kitchen area with red and white tiling, along with white painted bricks for the walls. Our kitchen has an espresso machine, a coffee pot and a kettle for making drinks. We also have an oven and a bakery display case for making baked goods. The user can click on one of the drink machines and one of the bakery items to spawn a drink and plated food item on the counter.
<img src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/kitchen_layout.png" alt="Kitchen Layout" width="500"/>

#### Characters
We chose characters that match with the style of our cafe. We chose characters that have a cartoonish look and a wide range of diversity! Below are some pictures with our characters inside some of our scenes:

<img src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/c1.jpg" alt="Character 1" width="500"/>

<img src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/c5.jpg" alt="Character 2" width="500"/>

<img src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/cafe_w_people_closer%20view.jpg" alt="Customer/Player at the Register" width="500"/>

<img src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/cafe_with_people.jpg" alt="Cafe with People Inside" width="500"/>

<img src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/character_2.jpg" alt="Angry Character" width="500"/>

#### Links to Assets Used
Assets for the kitchen:
[https://assetstore.unity.com/packages/3d/props/coffeeshop-starter-pack-160914] (https://assetstore.unity.com/packages/3d/props/coffeeshop-starter-pack-160914)

Cash register: 
[https://www.cgtrader.com/free-3d-models/various/various-models/funny-cash-register] (https://www.cgtrader.com/free-3d-models/various/various-models/funny-cash-register)

Restaurant tables: 
[https://kaylousberg.itch.io/restaurant-bits] (https://kaylousberg.itch.io/restaurant-bits)

Other table and couch styles: 
[https://kaylousberg.itch.io/furniture-bits] (https://kaylousberg.itch.io/furniture-bits)

Floor: 
[https://kaylousberg.itch.io/prototype-bits] (https://kaylousberg.itch.io/prototype-bits)

Characters:
[https://kenney.nl/assets/mini-characters-1] (https://kenney.nl/assets/mini-characters-1)

### Project Part 3: Visual Effects
 * Lighting and shadows have been added to the cafe
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/lighting_cafe3.png" alt="Lighting 3" width="500"/>
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/lighting_cafe2.png" alt="Lighting 2" width="500"/>
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/lighting_cafe1.png" alt="Lighting 1" width="500"/>
 
 * We have experimented with various post-processing effects in the kitchen scene, including Morning Light, Night Mode, Rainy Day, and Warm Cafe Profile
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/morning_pp_effect.png" alt="Morning" width="500"/>
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/night_mode_pp_effect.png" alt="Night" width="500"/>
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/warm_cafe_pp_effect.png" alt="Warm cafe" width="500"/>
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/rainy_day_pp_effect.png" alt="Rainy" width="500"/>
 
 * We have implemented some visual effects, including steam for making coffee, and sparkle effects in the kitchen and during customer interaction
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/steam_visual_effect.png" alt="Steam" width="500"/>
 <img src="https://github.com/Kalia2538/ComputerGaming2025/blob/checkpoint3_readme_updates/Readme_pics/sparkle_effect1.png" alt="Sparkles" width="500"/>

### Project Checkpoint 3-4: Sound, UI, and Animation
* Added background music to cafe and the kitchen
* Added sound effects in the cafe
   * Cash register sound when a customer places an order
   * UI sound effect for button clicks
* Added sound effects in the kitchen
   * Coffee/liquid pouring noises when a drink is poured
* Added animations to mocha pot and tea pot in the kitchen


https://github.com/user-attachments/assets/19c9092e-26f3-44ae-95db-42fa9d58a927

* Polished the UI using unity store assets
   * Speech bubble to represent customer order
   * Improved design of buttons, notepad, and text

<img width="500" alt="Screenshot 2025-04-16 at 10 52 39 PM" src="https://github.com/user-attachments/assets/d6c11306-edc7-4c85-870f-b284d48ab5b8" />

* Added an open and closing animation for the door in the cafe whenever the scene is loaded

https://github.com/user-attachments/assets/1ce22d76-4524-457f-8b2d-eff88173f02d

#### Links to Assets Used
Cash register sound effect:
[https://pixabay.com/sound-effects/cash-register-purchase-87313/] (https://pixabay.com/sound-effects/cash-register-purchase-87313/)

GUI components in the cafe:
[https://assetstore.unity.com/packages/2d/gui/sweet-land-gui-208285] (https://assetstore.unity.com/packages/2d/gui/sweet-land-gui-208285)

Speech bubble:
[https://assetstore.unity.com/packages/2d/environments/2d-atlas-speech-bubbles-alphabet-numbers-88398#content] (https://assetstore.unity.com/packages/2d/environments/2d-atlas-speech-bubbles-alphabet-numbers-88398#content)

Button click sound effects:
[https://assetstore.unity.com/packages/audio/sound-fx/free-ui-click-sound-pack-244644] (https://assetstore.unity.com/packages/audio/sound-fx/free-ui-click-sound-pack-244644)

Coffee and Tea sounds: 
https://assetstore.unity.com/packages/audio/sound-fx/free-pop-sound-effects-pack-263821
https://assetstore.unity.com/packages/audio/ambient/nature/free-water-stream-sounds-226371

Cafe Music: 
https://assetstore.unity.com/packages/audio/music/tabletop-jazz-cafe-free-music-224462

### Project Part 4: Finishing Touches
* Improved player and customer models
   * Customer walks up to the counter, and waits at the counter after placing an order
<img width="300" alt="New Players" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/new_players.png" />
 
* Tracking of score and order rating
   * Points for accuracy and timing of order (50 points per accurate item)
   * We have set up a way to monitor the precision for brewing of espresso

* Customer reactions with sound effects
   * Heart + celebration sound effects for perfect order
   * Exclamation mark + fail sound effects for inaccurate order
   * Money icon + cash register sound when order is placed

<img width="100" alt="Heart Icon" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/heart_icon.png" /> <img width="100" alt="Bad Order" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/bad_order_reaction.png" /> <img width="100" alt="Money Icon" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/money_icon.png" />

* Day progression
   * A transition scene appears at the start of each day, displaying the current day number
   * Currently, a “day” in the game consists of serving 8 customers
   * Clock object has a shake animation added when the day is halfway or more completed (≥4 customers served)
<img width="500" alt="Start Menu" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/start_menu.png" />

* Pause menu
   * Includes a button to return to the game
   * Our pause menu and pause button have been created as prefabs and are set to be integrated with the cafe and kitchen scenes
<img width="500" alt="Pause Menu" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/pause_menu.png" />

* Character models
   * We chose to update our character models mid-project to allow for more dynamic interaction. Our new characters include walk cycles, facial expressions, and more animation flexibility. This enhances immersion and gives us greater creative freedom to express mood, emotion, and interaction in the scene—making the game world feel more alive.
   * <img width="500" alt="Player" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/player_model.jpg" />
   * <img width="500" alt="New Character" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/new_character.jpg" />
   * <img width="500" alt="Customization" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/character_customization.jpg" />

#### Links to Assets Used
Icons for customer reactions:
[https://assetstore.unity.com/packages/3d/props/modular-low-poly-letters-and-icons-296956] (https://assetstore.unity.com/packages/3d/props/modular-low-poly-letters-and-icons-296956)

Clock game object:
[https://assetstore.unity.com/packages/3d/props/interior/clock-free-44164#content] (https://assetstore.unity.com/packages/3d/props/interior/clock-free-44164#content)

Successful order sound effect:
[https://pixabay.com/sound-effects/success-fanfare-trumpets-6185/] (https://pixabay.com/sound-effects/success-fanfare-trumpets-6185/)

Failed order sound effect:
[https://pixabay.com/sound-effects/cartoon-fail-trumpet-278822/] (https://pixabay.com/sound-effects/cartoon-fail-trumpet-278822/)

New player/customer models:
[https://assetstore.unity.com/packages/3d/characters/humanoids/creative-characters-free-animated-low-poly-3d-models-304841#version-original)

### Final Project Submission

- **Customer scene persistence and interactions** have been enhanced so that their state remains consistent when transitioning between scenes.
- **Fixed the music restart issue** that was occurring due to the volume slider in the pause menu. We chose to remove the slider entirely, as it did not significantly improve the user experience.

     * <img width="500" alt="Pause" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/new_pause.jpg" />
  

- Replaced Unity’s default **gray background** with a custom **city landscape** to create a more immersive and polished visual environment.

  * <img width="500" alt="CityBackground" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/CityBackground.png" />
  * <img width="500" alt="GameTopView" src="https://github.com/Kalia2538/ComputerGaming2025/blob/main/Readme_pics/GameTopView.png" />


#### Links to Assets Used
City Background for the Cafe, elimantes the Unity Gray default background:
https://assetstore.unity.com/packages/3d/environments/urban/toon-city-pack-234785

### How to Play
* You can move the player around using WASD/input - (you have to use this function with the "Updated Player" prefab)
* You can use the customer spawning by clicking the screen when the customer gets to the counter to leave the counter.
* Click through the UI buttons to handle taking and serving orders, and navigating between the cafe and kitchen scenes.
* In the current kitchen scene, users can make an espresso, tea, and stovetop coffee. You can also spawn bakery items by clicking them.
  * To make an espresso, the user clicks once on the top of the espresso machine to spawn an empty cup. Next, clicking the red circle on the machine dispenses the liquid. Once the process is complete, steam rises from the cup, and the mug visibly fills with coffee.
  * The user can then press and hold the mug's handle to drag it across the counter. When the mug is hovered over the designated white area of the counter, it will automatically snap into place.
- The `camera slider` has also been enhanced:
  - You can now use the **Left and Right arrow keys** to scroll the camera across the cafe.
  - Pointer input on the slider has been **disabled**, preventing click/drag interaction.

Note: As we work on this functionality, we will also work to address a more intuitive mechanism for player movement, which, combined with animation, will be robust enough for the user to control. This will also coincide with UI elements to help navigate the player through the initial gameplay, including prompts to signal for the user to move behind the counter to take an order or toggle the ‘coffee dispense button’ to dispense coffee. Finally, we will work to add a way for the game to switch between the cafe scene and the kitchen prep scene.

Further:

In response to the notes:

* We now have a working **scene transition system** that allows the player to go between the `kitchen` and `cafe` using dedicated buttons.
* We have main/start and pause menus with buttons to control the game flow.
*  We've implemented a **notepad system with persistent text**, which saves order details and redisplays them in the kitchen after switching scenes.
* The **core gameplay loop** (customer walking, seating, multi-order handling, etc.) is still in development, and will be the **main focus of the next submission** now that our foundational systems are in place.
*  We're planning to add more **scenic elements and UI enhancements** based on **Chapters 18 and 19** of the textbook.

### Instructions for Testing the Project

To test the project locally, follow these steps after cloning and opening the repository in the Unity Editor:

#### Scenes to Test:

1. **DayTransition Scene**
   - This is the **start menu**.
   - Allows the player to start a new day or **reset their progress** back to the beginning.

2. **Cafe Scene**
   - This is where players can:
     - Take a customer's order
     - Move the character around the café using the movement controls
     - Use the **notebook** to write down orders (optional memory challenge)
     - Navigate to the **kitchen** scene via button interaction
     - Monitor the **day timer** and customer progress
   - The **pause menu** is accessible in this scene.

3. **Kitchen Scene**
   - This is where players **prepare drinks and baked goods**, following the gameplay mechanics.
   - The player can:
     - Use interactive appliances (espresso machine, tea pot, stovetop, etc.)
     - Drag items to the serving zone
     - Navigate back to the café scene
     - Access the **notepad** (it persists across scenes)
   - The **pause menu** is also accessible in this scene.

Arrow keys can be used to scroll the kitchen counter.

#### Developer Tips

For those testing or debugging the project, here are a few helpful commands and behaviors to be aware of:

#### In the Cafe Scene:
- **Spawn a customer**: A customer will appear automatically. Click on them to start the order interaction.
- **Order taking**: Use the **notepad UI** to write down the order, or skip it for a memory challenge.
- **Navigate to Kitchen**: Click the button near the counter labeled “Go to Kitchen” to transition scenes.
- **Pause Menu**: Press `ESC` or click the pause icon in the corner to access volume control or return to the main menu.

#### In the Kitchen Scene:
- **Espresso machine**:
  - Click the top of the espresso machine to **spawn a cup**.
  - Click the red button to **dispense coffee**.
  - Hold and drag the cup to the serving spot (white circle on the counter).
- **Tea and Stovetop Coffee**:
  - Click the kettle or pot to spawn the drink.
- **Baked goods**:
  - Click the pastry of choice to spawn a plated item.
- **Scene Navigation**: Use the on-screen button to return to the **Cafe**.
- **Camera Slider**: Use the **left/right arrow keys** to scroll across the kitchen counter.
- **Pause Menu**: Press `ESC` or click the pause icon.

#### General Notes:
- The **notepad persists** between scenes—test this by writing an order in the café and checking for it in the kitchen.
- Day progress is tracked through a **day transition screen**, with visual cues and a shake animation on the clock after 4+ customers are served.
- You can test **scene transitions and core game flow** by starting at `DayTransition`, moving into `Cafe`, then into `Kitchen`, and back.

### Demo

Watch a playthrough of our game, showcasing key gameplay elements such as order taking, kitchen mechanics, and scene transitions:

[![Watch the demo]()]

---

### Download

Play the WebGL version of our game here:  
[**Grounds for Catastrophe on Itch.io**] (https://hana-ismaiel.itch.io/grounds-for-catastrophe)

If you'd like to download and play the desktop version:
- [Download for Windows (.zip)]()
- [Download for Mac (.zip)]()

### Future Work

There are several features we hope to implement in future iterations:

- **Appliance Upgrade System**  
  While we originally planned a robust system for upgrading appliances (increasing speed, drink quality, and visual aesthetics), this feature is currently not functional. However, our appliance prefabs were designed with modularity in mind to support upgrades in the future.

- **Order Complexity & Timing**  
  We'd like to flesh out the order system further by adding:
  - More detailed multi-step orders (e.g., double shots, specific milk types)
  - Ratings that factor in **timing**, not just accuracy

- **Expanded Customer Logic & Queueing**  
  Customers would queue up and be penalized for long wait times, and we’d include special customer types (critics, speed-focused guests, etc.).

- **Technical Challenges / Known Issues**  
  Unity-specific challenges, particularly **scene persistence** and managing object states between transitions, delayed many of our “nice-to-have” features. These complications made us prioritize a fully working MVP over more ambitious mechanics, but we’ve laid strong groundwork for their addition.

### Member Contributions

**Elysa**
- Designed the **background and café interior**
- Created the **pause screen** and scene transitions
- Implemented **kitchen mechanics** including logic for successful orders (matches request, score system)
- Developed:
  - Basic **player movement**
  - **Drag-and-snap** interactions for cups
  - **Camera scrollbar** navigation
- Added:
  - Sound effects for kitchen appliances (e.g., coffee pouring)
  - Animations for mocha pot and tea pot interactions

**Kalia**
- Created and rigged **player and customer character models**
- Implemented:
  - **Advanced movement** for characters (walk-in, exit, idle)
  - **Customer spawning** and **basic order request system**
  - **Partical System** for food items.
- Added:
  - **Background music** for café
  - Dynamic volume change when transitioning to the kitchen

**Hana**
- Designed the **home/start menu**
- Built the **kitchen environment layout**
- Implemented:
  - Initial food and drink mechanics (click to spawn)
  - **Lighting and shadows**
  - **Basic kitchen layout**
- Polished UI:
  - Integrated Unity Store assets
  - Designed **speech bubbles**, **buttons**, and **notepad UI**
- Expanded:
  - **Advanced order system** (randomized drink + food pairings)
  - **Point system** (built on Elysa’s matching logic)
  - **Customer feedback sounds** (success/fail cues)
  - **Day progression logic** (8-customer system, clock animation)

Many elements (such as customer reactions, kitchen layout tweaks, and UI cohesion) were developed collaboratively during group sessions, with each member contributing both design feedback and code debugging. 
