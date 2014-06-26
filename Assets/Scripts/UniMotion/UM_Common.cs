/**
 * UniMotion 
 * Copyright (c) 2014, 
 * David 'NoxWings' Garcia Miguel ( noxwings@gmail.com ), 
 * All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 **/

using UnityEngine;
using System.Collections;

/*
 * Enum of supported devices
 */ 
public enum UM_Device {
	UM_VENDOR_UNKNOWN = 0,
	UM_HYDRA,
	UM_PRIOVR,
	UM_PSMOVE,
	UM_FREETRACK,
	UM_NUM_DEVICES,
	UM_DEFAULT_DEVICE = UM_HYDRA
};

public enum UM_Capabilities {
	UM_ORIENTATION_NONE = 0 << 0x00,
	UM_ORIENTATION_SIMPLE = 1 << 0x00,   /* Featuring Accelerometer and Gyroscope */
	UM_ORIENTATION_AUTO = 1 << 0x01,     /* Featuring Accelerometer, Gryroscope and Magnetometer */
	UM_POSITION_NONE = 0 << 0x02,        /* No positional tracking (like Smartphone devices) */
	UM_POSITION_DIRECTIONAL = 1 << 0x02, /* Directional based positional tracking (like the PS Move) */
	UM_POSITION_ABSOLUTE = 1 << 0x03     /* Absolute positioning (Razer-Hydra, STEM ...) */
};