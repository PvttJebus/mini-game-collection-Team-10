# Interstellar Air Hockey - Game Design Document

### Team Members
- Matthew Barrameda
- Makayla Harrison
- Trevor (TJ) Beckham

___

## Game Overview

**Description:** IAH transports players into a high-energy space arena where they face off in intense quick rounds. Quick reflexes and smart decision-making are essential to come out on top. Combining competitive sports action with a sci-fi environment, the game is designed to be engaging and replayable.

**Genre:** Competitive, Arcade Sports

**Setting:** Futuristic Space Arena

**Platform:** Arcade Cabinet

**Objective:** Outscore your opponent in fast-paced, action-packed rounds set in a dynamic, sci-fi environment.


![IAH Mood Board](https://imgur.com/AvvBi31.jpg)
___

## Controls
- Joystick: Move the player’s ship
- Primary Action(Button 1): Activate the tractor beam to capture and launch the puck
- Secondary Action(Button 2): Dash in the direction the ship is facing

___

## Gameplay Mechanics

### Tractor Beam

**Description:** The player can capture and position the puck for strategic shots.
**Impact:** Adds a more strategic depth, as players can use it to surprise their opponent with creative moves.
**Purpose:** Allows players to capture the puck and launch it with precision, adding a strategic layer to gameplay.
**Use Case:** Players can aim their shots creatively, positioning the puck to catch their opponent off-guard.


### Dash Feature

**Description:** Enables players to dodge in their facing direction quickly.
**Impact:** Adds a layer of skill and timing, letting players evade obstacles or close in on the puck.
**Purpose:** Offers a quick escape or movement boost for players to avoid obstacles and reposition themselves.
**Use Case:** Players will need to time their dash carefully to maximize its impact in competitive situations.

### Debris _(Scrapped)_

**Description:** Random debris occasionally flies across the field, creating obstacles.
**Impact:** Introduces unpredictability, requiring players to adapt on the fly and use the environment to their advantage.
**Purpose:** Random obstacles appear in the arena to create additional challenges.
**Use Case:** Players must adapt to the unpredictability of debris flying across their screen, using it to their advantage or avoiding it skillfully.

___

## Objective Statement

### Purpose:

Deliver a unique twist on air hockey by combining competitive mechanics within an interstellar environment, creating an engaging, high-energy experience for players of all skill levels.

### How Did We Plan to Achieve This?

Our goal is to take the gameplay of classic air hockey and elevate it with a futuristic, sci-fi setting and exciting new mechanics. By introducing unique features like the tractor beam, dash abilities, and random debris obstacles, we’re providing players with creative ways to interact with the game. These mechanics are designed to add layers of strategy and excitement, encouraging players to think on their feet and adapt to unpredictable situations.

### Emotional Engagement

We want the players to feel adrenaline rush as they compete in fast-paced, high-stakes rounds, with the tractor beam and dash mechanic enabling quick decisions and more skillful moves. The addition of random debris will increase the intensity and add unpredictability, keeping players on their toes. Each match is designed to spark a competitive spirit and give the players the excitement of scoring goals, dodging obstacles, and outsmarting opponents, creating more memorable moments and making them want to play “just one more game”.

### Why This Design?

We believe that combining competitive sports gameplay with our theme allows for a visually and mechanically fascinating experience. The interstellar environment serves as not just a backdrop but enhances the feeling of a futuristic showdown, contributing to the overall excitement.

### Intended Player Reactions

Excitement and Adrenaline - Quick rounds, intense gameplay, and high-stakes decisions bring thrilling pace to each match.
Competitive Drive - Players will want to maneuver and outscore their opponent, creating a natural sense of rivalry and determination.
Satisfaction and Mastery - The game’s accessible controls and unique mechanics allow players to improve their skills over time, giving a rewarding sense of mastery as they develop strategies.

### Questions

Use of Experience: Does the tractor beam add an engaging layer of control for the players?
Interaction with Environment: How do the dash and debris mechanics enhance the game’s unpredictability?
Impact on Strategy: How do the unique abilities and obstacles influence player strategy and competitiveness? 

___

## Design Rationale

As we’re building off the existing game of air hockey, we had to balance between adding our own features to the game without losing the core experience of the original game. The team approached each feature with the goal of adding excitement without confusion. 

## Tractor Beam
The tractor beam mechanic will allow players to grab the puck with the tractor beam and launch/choose the desired direction. The player can also use the tractor beam to outmanoeuvre/confuse opponents.Similar to holding the mallet in air hockey, but in IAH players use their ship movement to alter the movement/direction of the puck.

The core feature, the one that eventually led to IAH is the tractor beam, so we knew getting this right was a priority. As we started to prototype the mechanic, we found there were some difficulties ensuring the players could ONLY pick up the puck, and not things like walls or the floor. To streamline the process, we leveraged the tag system to ensure that only the puck could be picked up by our beam. 

## Player Movement

From the start we knew player movement was going to be similar to air hockey and space/zero-g games, and initially used a script from an air hockey game for the initial movement. After getting movement setup, we realised the arcade cabinet had two fewer buttons than we thought, so how we were handling player rotation was not going to work. 

Our solution was having the ship start rotating towards the direction the player is moving. While it may look wonky at first, we found this to be a great balance between ensuring players can rotate to aim the tractor beam while adding some challenge to getting the perfect angle with the beam. 

## Dash

Implementing a dash mechanic tool that both players can use effectively, but can lead to game changing moments when used at the right time. Players will need to strategically choose when to use their dash mechanic, as each player will only be allowed a certain number of uses.

Our initial plan for the Dash feature was to have it so the player would get a short burst of speed in the direction they were moving. This would give the opportunity for exciting last minute saves or out-manoeuvring your opponent to get a goal. After implementing it, we realised we had a few issues,
- We wouldn’t be able to convey the cooldown of the dash ability without adding UI which we’re unable to do. 
- As we’re going for a space-like feel, dashing would send the player veering in one direction, not causing many interesting moments. 
- It ultimately didn’t feel interesting to use. 

So we adjusted our approach and implemented a new dash mechanic, which acts like a temporary speed boost. Here’s how the revised mechanic works
- Either player will press the appropriate action button to activate dash. 
- While dash is activated, the green player’s cockpit turns blue, red player’s turns magenta. 
- During the 5-ish second duration, ship movement speed is multiplied by 10, allowing for overall faster movement in all directions during the time. 
- Once the dash is done, the player speed and colours return to normal

We felt this was not only more enjoyable, and provides some additional strategic options to players, but it eliminated our need for UI as now each player has 3 dash uses. Once they are used, they cannot dash unless they start a new game. 

### Debris

The third, final, and biggest change from air hockey that we wanted to add was the chance debris could randomly cross the arena and be used to assist/hinder the players. We love this concept and think it would make a great addition to the game in different circumstances, but after getting the game setup, we evaluated how debrits would impact the game as is and realised: 

- Given limitations of the hardware and assets, adding debris could cause confusion
- As the game time is 60 seconds, adding debris could make the game more complicated than it needs to be
- The game is fun without it!

So we decided to scrap the debris mechanic, at least for the time being.

___

## Resources

- [Air hockey Game - Github](https://github.com/Andrei-Lapusteanu/3D-AirHockey/tree/master)
  - [Leveraged initial movement script](https://github.com/Andrei-Lapusteanu/3D-AirHockey/blob/master/Assets/Scripts/Move_P1.cs) 

- [ChatGPT o1-preview](https://chatgpt.com/)
  - Leveraged code in following scripts
    - green-goal.cs, Lines 79 - 87
    - p2-movmeent.cs, Lines 83 - 91
    - red-goal.cs, Line 79 - 87
    - p1-movmeent.cs, Lines 81 - 91
  -Helped explain/troubleshoot coding concepts
    - No code was directly used from these instances

- [Unity manual](https://docs.unity3d.com/2023.1/Documentation/Manual/rigidbody-physics-section.html)

- Unity forums (troubleshooting)
  - [Ignore Collisions by Tag SOLVED! - Unity Engine - Unity Discussions](https://discussions.unity.com/t/ignore-collisions-by-tag-solved/423057)
  - [Transform.left? - Unity Engine - Unity Discussions](https://discussions.unity.com/t/transform-left/405475)
  - [How do i get some objects to ignore collision with a specific object? - Questions & Answers - Unity Discussions](https://discussions.unity.com/t/how-do-i-get-some-objects-to-ignore-collision-with-a-specific-object/102308)

- Stackoverflow (troubleshooting)
  - [c# - Unity - determine items collision with different "tags" - Stack Overflow](https://stackoverflow.com/questions/50700559/unity-determine-items-collision-with-different-tags)
