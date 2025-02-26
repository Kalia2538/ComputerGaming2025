# PlaceHolder- Grounds for Catastrophe

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
* Task-Based Cooking: Players complete cooking tasks like picking up the cub, grinding the coffee beans, add milk, syrup, or ice. Each task is connected to a specific appliance where the person will move to the station and interact with the machine.
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
* A semi-realistic 3D cafe environment that allows players to move around the closed space. The cafe environment will [] with the camera positioned above and angled downwards. 
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
1. Player proximity to the appliances
2. Basic player interactions with their environment (e.g., player movement and interacting with the environment)
3. Spawning of Customers to the counter
4. Set up cooking tasks e.g., making coffee

### Additions
* Implemented a basic Keurig-style machine for making hot coffee in different cup sizes.
* Clicking the cup now correctly places it under the coffee machine.

### Project Part 2: 3D Scenes and Models (Ch 3+4, 10)

Complete the cafe and kitchen layout with interactive furniture and appliances. The materials should be complete, and decent lighting should be added.

Environment and Layout
* Create cafe and kitchen with probuilder 
* Overall layout as before– something manageable by user/player
Assets + basic functionality 
* Importing and adding 3D models
* Making sure the colliders for these models work properly 
* Set up interacting with appliances, like making the liquid dispense and grabbing cups
Visual effects and Scene Management 
* Scene transition from dining area to kitchen area
* Lighting and shaders are implemented

## Development

### Project Checkpoint 1-2

