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

public abstract class UM_Tracker : MonoBehaviour {

	#region Member Variables
	// Unity Editor Varibles (public)
	public bool autoUpdate = true;

	// Private Variables
	private UM_Device vendor;
	private UM_Capabilities capabilities;

	// Unity related variables
	private Vector3 lastPositionOffset = Vector3.zero;
	#endregion

	#region Constructors
	public UM_Tracker() {
		SetDeviceInfo(UM_Device.UM_VENDOR_UNKNOWN,
		        UM_Capabilities.UM_ORIENTATION_NONE 
		        | UM_Capabilities.UM_POSITION_NONE );
	}

	/// <summary>
	/// Sets the device info.
	/// </summary>
	/// <param name="d">Device id vendor</param>
	/// <param name="c">Device capabilities flags</param>
	protected void SetDeviceInfo(UM_Device d, UM_Capabilities c) {
		vendor = d;
		SetCapabilities(c);
	}
	#endregion

	#region Tracking Capabilities
	/* 
	 * Capabilities Setting
	 */
	public void SetCapabilities(UM_Capabilities c) {
		this.capabilities = c;
	}

	public UM_Capabilities GetCapabilities() {
		return this.capabilities;
	}

	/* 
	 * Orientation Capabilities Check
	 */
	public bool HasOrientation() {
		return (HasOrientationSimple() || HasOrientationAuto());
	}
	public bool HasOrientationSimple() {
		return CheckCapabilities(UM_Capabilities.UM_ORIENTATION_SIMPLE);
	}
	public bool HasOrientationAuto() {
		return CheckCapabilities(UM_Capabilities.UM_ORIENTATION_AUTO);
	}
	
	/* 
	 * Positioning Capabilities Check
	 */
	public bool HasPosition() {
		return (HasPositionDirectional() || HasPositionAbsolute());
	}
	public bool HasPositionDirectional() {
		return CheckCapabilities(UM_Capabilities.UM_POSITION_DIRECTIONAL);
	}
	public bool HasPositionAbsolute() {
		return CheckCapabilities(UM_Capabilities.UM_POSITION_ABSOLUTE);
	}
	
	/// <summary>
	/// Checks if the devices has all the capability flags specified as a parameter
	/// </summary>
	/// <returns><c>true</c>, if every specified capability is present in the device, <c>false</c> otherwise.</returns>
	/// <param name="features">Capability features.</param>
	public bool CheckCapabilities(UM_Capabilities features) {
		return (capabilities & features) == features;
	}
	#endregion

	#region Tracker Functions
	// Optional implementation
	public virtual float Battery     { get { return 0f; } }
	public virtual float Temperature { get { return 0f; } }

	public virtual Vector3 Accelerometer    { get{ return Vector3.zero;} }
	public virtual Vector3 Gyroscope        { get{ return Vector3.zero;} }
	public virtual Vector3 Magnetometer     { get{ return Vector3.zero;} }
	public virtual Vector3 RawAccelerometer { get{ return Vector3.zero;} }
	public virtual Vector3 RawGyroscope     { get{ return Vector3.zero;} }
	public virtual Vector3 RawMagnetometer  { get{ return Vector3.zero;} }

	// Mandatory implementation
	public abstract Quaternion Orientation { get; }
	public abstract void ResetOrientation();

	public abstract Vector3 Position { get; }
	public abstract void ResetPosition();
	#endregion

	#region Update Related Functions
	/// <summary>
	/// Updates the internal tracking values and possible buttons etc.
	/// </summary>
	protected abstract void UpdateValues();

	/// <summary>
	/// Updates the game object. 
	/// Syncs the game object position and rotation with the last updated values.
	/// </summary>
	protected virtual void UpdateGameObject() {
		// Set orientation
		this.transform.rotation = this.Orientation;

		// Undo the last position offset
		this.transform.position -= lastPositionOffset;

		// Set the new position
		lastPositionOffset = this.Position;
		this.transform.position += lastPositionOffset;
	}

	/// <summary>
	/// Update this instance.
	/// This function is called every frame, and updates the internal values
	/// and syncs the unity game object if <c>autoUpdate</c> is set to true.
	/// </summary>
	protected virtual void Update () {
		if (autoUpdate) {
			UpdateValues();
			UpdateGameObject();
		}
	}
	#endregion
}
