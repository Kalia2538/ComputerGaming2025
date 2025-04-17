# PlaceHolder - Grounds for Catastrophe

## Team Members
- [Kalia2538](https://github.com/Kalia2538)
- [hana-ismaiel](https://github.com/hana-ismaiel)
- [ely-hi](https://github.com/ely-hi)

## Game Summary

A relaxing cooking game where up to two players run a cafe together. Players recieve orders from customers and prepare meals in a kitchen. The goal is to complete each recipe with speed and quality to keep customers happy, allowing the player to upgrade appliances and unlock new recipes. 

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

### Player Interactions: 

Counter Interaction & Order Mechanism:
* Customer Interaction: Customers walk up to the counter and place their orders. Players interact with the customers by clicking on them to receive and verify the order. Customers will state their order, and the player will confirm.
* Order Taking: Players write down the customer’s order using a notepad system. They can either click items from a menu or type in the request to ensure accuracy.

Food Prep:
* Task-Based Cooking: Players complete cooking tasks like picking up the cup, grinding the coffee beans, add milk, syrup, or ice. Each task is connected to a specific appliance where the person will move to the station and interact with the machine.
* Appliance Upgrades: As players progress, they can purchase upgrades for their appliances, improving either speed (how quickly food is prepared) or quality (how visually appealing drinks are).
* Time-Related Upgrades: Appliances like coffee machines can be upgraded to dispense the coffee faster
* Quality Upgrades: Appliances like espresso machines can be upgraded to improve the visual presentation of food and drinks (e.g., latte art).

Different Ranks of Customers:
* Regular Customers: Familiar faces who tend to order the same meals and expect consistent quality.
* Guest Customers: e.g., food critics who require quality heavily, customers who require speed over quality, etc. These are high-paying customers.

Progression & Cafe Growth:
* New recipes: Unlocking new, more complex recipes as the cafe expands.
* Cafe upgrades: Players can use their earnings to buy new appliances, decor, and kitchen tools to enhance both functionality and appearance.

### Expected UI
* A semi-realistic 3D cafe environment that allows players to move around the closed space. The cafe environment will appear with the camera positioned above and angled downwards. 
* A door leads the player to the kitchen, from the counter, and vice versa. When the player enters the door to the kitchen, the scene will switch to a first-person POV 
* Proximity can trigger a subtle visual cue, like an outline or glow around the object, to make interactions intuitive.

### Game Controls
Movement:
* Mouse or use of keys (e.g, WASD or Arrow Keys): Move the character around the cafe and kitchen. The player will use these to navigate through the cafe environment.
* Proximity-Based Interactions when a player approaches an interaction object: so when the player moves near certain objects or stations (e.g., a drink counter, milk fridge), the game detects their proximity to the item.
  * The player would then press Space (or another button) to activate the station's function, such as dispensing a drink from the counter.
  * When approaching an object, a prompt is displayed like "Click to Dispense Drink" to let the player know which action can be taken.


## Development Plan

### Project Checkpoint 1-2: Basic Mechanics and Scripting (Ch 5-9)
~~1. Player proximity to the appliances~~
~~2. Basic player interactions with their environment (e.g., player movement and interacting with the environment)~~
~~3. Spawning of Customers to the counter~~
~~4. Set up cooking tasks e.g., making coffee~~

### Additions
* Implemented a basic Keurig-style machine for making hot coffee in different cup sizes.
* Clicking the cup now correctly places it under the coffee machine.

### Project Part 2: 3D Scenes and Models (Ch 3+4, 10)

Complete the cafe and kitchen layout with interactive furniture and appliances. The materials should be complete, and decent lighting should be added.

Environment and Layout
~~* Create cafe and kitchen with probuilder~~
~~* Overall layout as before– something manageable by user/player~~


Assets + basic functionality 
~~* Importing and adding 3D models~~
* Making sure the colliders for these models work properly 
* Set up interacting with appliances, like making the liquid dispense and grabbing cups

  
Visual effects and Scene Management 
* Scene transition from dining area to kitchen area
~~* Lighting and shaders are implemented~~

### Additions
* created prefabs for customers and player

### Justificaitons
* We did not do the scene transitioning (outside the scope of the assigned chapters)
* We did not set up interacting with appliances (outside of the scope of the assigned chapters)
* We did not test the colliders (outside of the scope of the assigned chapters)

### Project Part 3: Visual Effects (Ch 11, 12, & 13)
~~* Simulation of liquid/fluid effects for pouring coffee~~
~~* Steam and smoke effects when brewing coffee~~
~~* Apply shadows and lighting to cafe and kitchen scenes~~
* Use light probes for accurate lighting in cafe and kitchen scenes
* Use high dynamic range (HDR) to cafe and kitchen scenes
~~* Scene transition~~ and realistic lighting changes when transitioning between scenes

### Additions
* Player movement has been improved, using arrow keys
* The player can take the customer’s order by clicking UI buttons, and write down the order on a “notepad” UI input element
* We have experimented with various post-processing effects in the kitchen scene, including Morning Light, Night Mode, Rainy Day, and Warm Cafe Profile. To test this, in the kitchen scene, press "m", which will switch between the different views.
  * In our next iteration, we will make these profiles more robust, translating to the cafe scene as well.
  * We also hope to make the background more detailed so the user is not just placed "in a void" but in some scenery context. We hope these profiles will coincide with the background as well. 
* We have implemented various visual effects, including steam and smoke for making coffee, and sparkle effects in the kitchen and during customer interaction


### Justifications
* We did not use light probes for lighting, because point lighting was sufficient for making the cafe well-lit
* We did not use HDR, because standard lighting and shading techniques were sufficient for the visual style of our game
* We have some scene transition (from cafe to kitchen), but we did not use lighting changes for transitions because it is outside the scope of the covered chapters


### Checkpoint 3-4: Music, UI and Animations
~~* Background music for the cafe~~

* Editing the volume of the music when inside of the kitchen
  
* Adding sounds for kitchen appliances and timers

~~* Adding UI elements for  keeping track of orders, customers, time, etc.~~

* Create walking and sitting animations

~~* Animate the doors~~

~~* Animations for kitchen appliances~~

### Additions
* Other sound effects have been added in the cafe (UI button clicks, cash register)
* The game mechanics have been improved, including scene switching to and from the cafe
* The notepad persists between scenes

### Justifications
* 

### Project Part 4: Finishing Touches (Ch 18 & 19)

In our final iteration, we plan to implement performance optimization and build polishing as mentioned in HCChapters 18 and 19.

#### Planned Optimization (Ch 18)
- Use Unity's Frame Debugger to analyze draw calls and identify performance bottlenecks
- Use the Profiler to determine whether the game is CPU-bound or GPU-bound
- Apply batching for static GameObjects that share materials to reduce draw calls
- Begin testing occlusion culling for walls and static props to improve rendering performance
- Review and limit `Debug.Log` statements to prevent runtime performance issues, especially during pouring interactions

#### Planned Build Preparation (Ch 19)
- Adjust build settings: resolution, fullscreen mode, splash screen
- Enable script debugging and use the Profiler to monitor the built game
- Add a main menu scene to serve as the initial entry point
- Add a pause screen.
- Test the executable on multiple systems and check for consistency between build and Editor

#### Additional Planned Features
- Complete and test full customer order flow (arrival → order → kitchen prep → serve)
- Display the written order note in the kitchen when switching scenes
- Finalize UI polish including tooltips, prompts, feedback indicators, as well as final scenery additions.

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
* 

#### Links to Assets Used
Cash register sound effect:
[https://pixabay.com/sound-effects/cash-register-purchase-87313/] (https://pixabay.com/sound-effects/cash-register-purchase-87313/)

GUI components in the cafe:
[https://assetstore.unity.com/packages/2d/gui/sweet-land-gui-208285] (https://assetstore.unity.com/packages/2d/gui/sweet-land-gui-208285)

Speech bubble:
[https://assetstore.unity.com/packages/2d/environments/2d-atlas-speech-bubbles-alphabet-numbers-88398#content] (https://assetstore.unity.com/packages/2d/environments/2d-atlas-speech-bubbles-alphabet-numbers-88398#content)

Button click sound effects:
[https://assetstore.unity.com/packages/audio/sound-fx/free-ui-click-sound-pack-244644] (https://assetstore.unity.com/packages/audio/sound-fx/free-ui-click-sound-pack-244644)

### How to Play
Our game is not in the most playable format (we aren't at the animations chapter), but here are the mechanics that you can do as of now:
* You can move the player around using WASD/input - (you have to use this function with the "Updated Player" prefab)
* You can use the customer spawning (linked to a regular capsule) by clicking the screen when the customer gets to the counter to leave the counter.
* In the current kitchen scene, users can make an espresso. In the next iteration, this feature will be expanded to include additional options such as tea, drip (stovetop) coffee, and various food items.
  * To make an espresso, the user clicks once on the top of the espresso machine to spawn an empty cup. Next, clicking the red circle on the machine dispenses the liquid. Once the process is complete, steam rises from the cup, and the mug visibly fills with coffee.
  * The user can then press and hold the mug's handle to drag it across the counter. When the mug is hovered over the designated white area of the counter, it will automatically snap into place.


Note: As we work on this functionality, we will also work to address a more intuitive mechanism for player movement, which, combined with animation, will be robust enough for the user to control. This will also coincide with UI elements to help navigate the player through the initial gameplay, including prompts to signal for the user to move behind the counter to take an order or toggle the ‘coffee dispense button’ to dispense coffee. Finally, we will work to add a way for the game to switch between the cafe scene and the kitchen prep scene.
