<p align="right">
  Ler em <a href="README.pt-br.md"> Português do Brasil </a>
</p>

# Ryzen Sandbox - Studying 2D Unity Game Dev

This project is a 2D Platformer sandbox created in order to test and study 2D features using Unity. Feel free to fork and test it out.

![Ryzen Running Animation](https://img.itch.zone/aW1hZ2UvOTA2NjA3LzUxMjExMTAuZ2lm/original/pxapC%2B.gif)

I see you've met Ryzen already. He is our sharpshooter never missing arcane archer. At least he likes us to treat him that way. Err... let me tell me more about the project:

## Features so far

Here are some of the features working already.

###### General

- [Unity Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html)
- Animation states being changed through script avoiding animator hell
- Decoupled Character Controller delegating responsabilities in order to ease possible project scaling
- Pixel Perfect Camera
- Canvas visual affordance for power shooting throug a Slider

  ** New **

- Character events prepared to be triggered. Currently as of Ryzen starts a jump a visual affordance of that event will be set off through a blinking diamond positioned on the right upper corner of the screen.

###### Ryzen (Archer)

- "Loading to Shoot" time
- Power Shooting if attack button is pressed for a minimum given amount of time
- Arrow projectile being instantiated and destroyed upon collision detected
- Idle, Running, Loading Shoot, Shoot, Ascending and Descending animations

  ** New **

- Ryzen can now Dash (rolling on the ground). He can only do this if grounded.
- Case Primary Attack Button is pressed during dash or jumping time (and remains this way upon finishing the action) he will automatically engage on attack.
- Dashes and Jumps Cancel attacks in progress

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
