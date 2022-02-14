<p align="right">
  Ler em <a href="README.pt-br.md"> Português do Brasil </a>
</p>

# Ryzen Sandbox - Studying 2D Unity Game Dev

This project is a 2D Platformer sandbox created in order to test and study 2D features using Unity. Feel free to fork and test it out.

![Ryzen Running Animation](https://img.itch.zone/aW1hZ2UvOTA2NjA3LzUxMjExMTAuZ2lm/original/pxapC%2B.gif)

I see you've met Ryzen already. He is our sharpshooter never missing arcane archer. At least he likes us to treat him that way. Err... let me tell me more about the project:

## Features so far

Here are some of the features working already.

###### **NEW** Coded State Machine

We have built an State Machine for Ryzen and it works really well as we tested.

I believe it could save many hours of dealing with Unity's Animator Controller transitions cause it turns scaling the project much easier. Feel free to give it a try.

You can find it's code under [Assets/\_Scripts/State Management](Assets/_Scripts/State%20Management) and all Ryzen's code under [Assets/\_Scripts/Playable%20Characters/Ryzen](Assets/_Scripts/Playable%20Characters/Ryzen).

###### General

- [Unity Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html)
- Pixel Perfect Camera
- Canvas visual affordance for power shooting throug a Slider
- Character events prepared to be triggered. Currently as of Ryzen starts a jump a visual affordance of that event will be set off through a blinking diamond positioned on the right upper corner of the screen.
- CineMachine used so camera will follow ryzen's steps.
- We now have a multiple layers scenario.
- We can now experience an "parallax effect" while moving Ryzen around.

###### Ryzen (Archer)

- "Loading to Shoot" time
- Power Shooting if attack button is pressed for a minimum given amount of time
- Arrow projectile being instantiated and destroyed upon collision detected
- Idle, Running, Loading Shoot, Shoot, Ascending and Descending animations
- Ryzen can now Dash (rolling on the ground). He can only do this if grounded.
- Case Primary Attack Button is pressed during dash or jumping time (and remains this way upon finishing the action) he will automatically engage on attack.
- Dashes and Jumps Cancel attacks in progress
- Both jump and dash actions trigger events wich can be listened to any other game entity.

## Used Assets

Huge thanks and shout out to my dear artists listed bellow. You guys are angels providing
assets for us crazy coders who need to test stuff out. For real. Thanks.

- astrobob's [Arcane Archer](https://astrobob.itch.io/arcane-archer)
- [Free Pixel Art Forest](https://edermunizz.itch.io/free-pixel-art-forest) by edermunizz

## Unity Version

Tested on [2020.3.25f1 LTS](https://unity3d.com/pt/unity/whats-new/2020.3.25)

## Where to find me

- Join our friendly [Discord](https://discord.gg/uvgWxNPk) server
- Streaming on [Twitch](https://twitch.tv/indiegabo_dev)
- [Instagram](https://instagram.com/indiegabo)
- [Twitter](https://twitter.com/indiegabo)
