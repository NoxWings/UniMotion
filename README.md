UniMotion
=========

Simple unified API for using various trackers and motion controllers in Unity3D.
UniMotion is a project intented to provide unified motion tracking for multiple input devices.
This support is divided in 2 different abstract classes:
- UM_Tracker: Provides an abstract class to be extended to support a new tracking device.
- UM_Controller: Derived from the Tracker class, provides additional function prototypes for controllers such as buttons and trigger input.

Currently supported devices are:

- FreeTrack

Planned supported devices are:

- PlayStation Move
- Razer Hydra
- WiiMote plus (we need gyro input)


UniMotion-FreeTrack
-------------------
UniMotion FreeTrack support. Provides the FreeTrack implementation of the UM_Tracker class. It can be used in conjuntion with FreePIE and Android devices since it provides additional modes for Landscape and Portrait alignment.


UniMotion-PS
------------
UniMotion-PS is the PlayStation Move support implementation of this project wich provides an Unity wrapper for the psmove api created by Thomas Perl [1]

This project will be focused on creating a simple wrapper for the psmove api 3.0 to be used in conjuntion with unity 3D. I've tried using UniMove project [2] but it lacks some recent changes such as the AHRS IMU sensor fusion and positional tracking.

So this project will cover the next topics:

  1.- Providing a simple wrapper similar to UniMove (button and sensor information)
  
  2.- Provide hooks to the sensor fusion already used in ps move api.

  3.- (maybe) Provide positional tracking.


[1] https://github.com/thp/psmoveapi

[2] https://github.com/CopenhagenGameCollective/UniMove
