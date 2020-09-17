# GamePad Intercepts
GamePad Intercepts is a project that aims to make Windows fully gamepad friendly.

![Login - Idle](https://drive.google.com/file/d/11a4ydxxTV0aK9Z6AKJN5Tn9OvT1KZHfD/view?usp=sharing)
![Login - Pin](https://drive.google.com/file/d/1hEvBfVqWDkG_rpe4Qmz0CsvO2rVXWYUJ/view?usp=sharing)
![Home Screen](https://drive.google.com/file/d/1_910RnCB349e9dHZZQcbWBc0JHWTd_ly/view?usp=sharing)

## Project Modules

- GamePad Intercepts
This is the core of the project. It provides a streamlined user interface to control the important gaming related aspects of the PC. This is also where most controller quality of life features are implemented (ie: button combinations mapped to useful actions like Alt+Tab, volume control, etc...)

- GamePad Imtercepts Bootstrapper
This module is responsible for starting up all necessary applications and services required by the GamePad Intercepts ecosystem.

- GamePad Intercepts Windows Logon
A Windows Credential Provider that enables logging into Windows using a gamepad.

## Controller Support List
- DualShock 4
- (WISHLIST) Xbox One Contrller
- (WISHLIST) Steam Controller (partial support)

## TODO
- UI overhaul
- C# code clean up + face lift (most of the code was written "proof-of-concept-style and may not respect best C# practices)
- Add Xbox controller support
- Add Steam controller support

## Third Party Libraries

- CoreAudio
- DS4Windows
- MessageBus
- WindowsInput

