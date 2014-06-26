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
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class UM_FreeTrack : UM_Tracker {

	#region Custom types & structs
	[StructLayout(LayoutKind.Sequential)]
	public struct FreeTrackData {
		public int dataid;
		public int camwidth, camheight;
		public Single Yaw, Pitch, Roll, X, Y, Z;
		public Single RawYaw, RawPitch, RawRoll;
		public Single RawX, RawY, RawZ;
		public Single x1, y1, x2, y2, x3, y3, x4, y4;          
	}
	public enum UM_FreeTrack_Align {
		FREETRACK_REGULAR,
		ANDROID_LANDSCAPE_LEFT,
		ANDROID_LANDSCAPE_RIGHT,
		ANDROID_PORTRAIT_UP,
		ANDROID_PORTRAIT_DOWN
	}
	#endregion

	#region Member Variables
	// Unity Editor Varibles (public)
	public float rotationSpeed = 60f;
	public UM_FreeTrack_Align align = UM_FreeTrack_Align.FREETRACK_REGULAR;
	
	// Private Variables
	private FreeTrackData ftData;
	// Orientation
	private Quaternion orientation;
	private Quaternion resetOrientation;
	// Postition
	private Vector3 position;
	private Vector3 resetPosition;
	#endregion

	#region Constructor 
	public UM_FreeTrack() 
	: base() {
		SetDeviceInfo(UM_Device.UM_FREETRACK,
		              UM_Capabilities.UM_ORIENTATION_AUTO |
		              UM_Capabilities.UM_POSITION_DIRECTIONAL);
		ftData = new FreeTrackData();
		resetOrientation = Quaternion.identity;
	}
	#endregion

	#region UM_Tracker inherited functions
	public override Quaternion Orientation { 
		get { 
			// CurrentOrientation = Q2 * Q1^(-1)
			return orientation * Quaternion.Inverse(resetOrientation);
		}
	}
	public override void ResetOrientation() {
		resetOrientation = this.orientation;
	}

	public override Vector3 Position {
		get {
			return position - resetPosition;
		}
	}

	public override void ResetPosition() {
		resetPosition = this.position;
	}


	protected override void UpdateValues() {
		// Update the internal values
		if (!UM_FreeTrack.FTGetData(ref ftData)) {
			// return if FreeTrack returns no data back
			return;
		}

		// Update orientation
		switch (align) {
		case UM_FreeTrack_Align.FREETRACK_REGULAR:
			orientation = Quaternion.Euler(ftData.Pitch*rotationSpeed,
			                               ftData.Yaw*rotationSpeed,
			                               ftData.Roll*rotationSpeed);
			break;
		case UM_FreeTrack_Align.ANDROID_LANDSCAPE_LEFT:
			orientation = Quaternion.Euler(ftData.Roll*rotationSpeed, 
			                               ftData.Yaw*rotationSpeed,
			                               -ftData.Pitch*rotationSpeed);
			break;
		case UM_FreeTrack_Align.ANDROID_LANDSCAPE_RIGHT:
			orientation = Quaternion.Euler(-ftData.Roll*rotationSpeed, 
			                               ftData.Yaw*rotationSpeed,
			                               -ftData.Pitch*rotationSpeed);
			break;
		case UM_FreeTrack_Align.ANDROID_PORTRAIT_UP:
			orientation = Quaternion.Euler(-ftData.Pitch*rotationSpeed,
			                               ftData.Yaw*rotationSpeed,
			                               -ftData.Roll*rotationSpeed);
			break;
		case UM_FreeTrack_Align.ANDROID_PORTRAIT_DOWN:
			orientation = Quaternion.Euler(ftData.Pitch*rotationSpeed,
			                               ftData.Yaw*rotationSpeed,
			                               -ftData.Roll*rotationSpeed);
			break;
		default:
			break;
		};

		// Update position
		position.x = ftData.X;
		position.y = ftData.Y;
		position.z = ftData.Z;
	}
	#endregion

	#region Import Functions
	[DllImport("FreeTrackClient")]
	private static extern bool FTGetData(ref FreeTrackData data);
	
	[DllImport("FreeTrackClient")]
	private static extern string FTGetDllVersion();
	
	[DllImport("FreeTrackClient")]
	private static extern void FTReportID(Int32 name);
	
	[DllImport("FreeTrackClient")]
	private static extern string FTProvider();
	#endregion
}