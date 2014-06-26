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

public abstract class UM_Controller : UM_Tracker {

	#region Constructors
	public UM_Controller() {
	}
	#endregion

	#region Controller Member Functions
	public abstract bool  GetButtonDown(uint button);
	public abstract bool  GetButtonUp  (uint button);
	public abstract bool  GetButton    (uint button);
	public abstract float GetTrigger   (uint trigger);
	#endregion
}
