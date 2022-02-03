# GamePad Intercepts
GamePad Intercepts is a project that aims to make Windows fully gamepad friendly.

## Project Modules

- GamePad Intercepts Windows Logon

A Windows Credential Provider that enables logging into Windows using a gamepad.

![Login Greeting](https://1.bp.blogspot.com/--cfFmk1S8nw/X8kT4vvw94I/AAAAAAAADs8/YqvQiAIA0H47Gkuxs1QMPngKeSvDPD5pwCLcBGAsYHQ/s1920/GPI%2B-%2BLogin%2BGreeting.png)

![Login On Screen Keyboard](https://1.bp.blogspot.com/-z8V8Eg8l5Tw/X8kT4hutz6I/AAAAAAAADtA/krbh5BMa_mMxagjoISvcRoEm009jGQMtACLcBGAsYHQ/s1920/GPI%2B-%2BLogin%2B%2BOn%2BScreen%2BKeyboard.png)

![Login Pin Pad](https://1.bp.blogspot.com/-VFa4rqsE5K8/X8kT40cfRWI/AAAAAAAADtE/FjTqAaqqbmI6Z5_Nyd9Ojk8vivRR7v8PwCLcBGAsYHQ/s1920/GPI%2B-%2BLogin%2BPin%2BPad.png)

- GamePad Imtercepts Bootstrapper

This module is responsible for starting up all necessary applications and services required by the GamePad Intercepts ecosystem.

- GamePad Intercepts

This is the core of the project. It provides a streamlined user interface to control the important gaming related aspects of the PC. This is also where most controller quality of life features are implemented (ie: button combinations mapped to useful actions like Alt+Tab, volume control, etc...)

![Home Screen](https://1.bp.blogspot.com/-f-pUeneKA44/X8kT4UqZCaI/AAAAAAAADs4/-yCyTsuHD8EL_gJV34SyC3CinfFjL5bSgCLcBGAsYHQ/s1920/GPI%2B-%2BHome%2BScreen%2B1.png)

## Controller Support List
- DualShock 4
- XInput (Xbox 360 + Xbox One)

## Todo List
- UI overhaul
- C# code clean up + face lift (most of the code was written "proof of concept" style and may not respect best C# practices)

## Third Party Libraries

- CoreAudio
- [DS4Windows](https://github.com/Jays2Kings/DS4Windows)
- [XInputDotNet](https://github.com/speps/XInputDotNet)
- [MessageBus](https://github.com/rolandzpl/MessageBus)
- [InputSimulator](https://github.com/michaelnoonan/inputsimulator)

