UniMotion
=========

Simple unified API for using various motion controllers in Unity3D

UniMotion is a project intented to provide unified motion tracking for multiple input devices. 
First supported input devices will be:

- PlayStation Move

- WiiMote plus (we need gyro input)



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
