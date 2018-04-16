
///*
// * �Software License Agreement
// *
// *�Copyright (C) Cross The Road Electronics.� All rights
// *�reserved.
// *�
// *�Cross The Road Electronics (CTRE) licenses to you the right to�
// *�use, publish, and distribute copies of CRF (Cross The Road) firmware files (*.crf) and Software
// *API Libraries ONLY when in use with Cross The Road Electronics hardware products.
// *�
// *�THE SOFTWARE AND DOCUMENTATION ARE PROVIDED "AS IS" WITHOUT
// *�WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT
// *�LIMITATION, ANY WARRANTY OF MERCHANTABILITY, FITNESS FOR A
// *�PARTICULAR PURPOSE, TITLE AND NON-INFRINGEMENT. IN NO EVENT SHALL
// *�CROSS THE ROAD ELECTRONICS BE LIABLE FOR ANY INCIDENTAL, SPECIAL,�
// *�INDIRECT OR CONSEQUENTIAL DAMAGES, LOST PROFITS OR LOST DATA, COST OF
// *�PROCUREMENT OF SUBSTITUTE GOODS, TECHNOLOGY OR SERVICES, ANY CLAIMS
// *�BY THIRD PARTIES (INCLUDING BUT NOT LIMITED TO ANY DEFENSE
// *�THEREOF), ANY CLAIMS FOR INDEMNITY OR CONTRIBUTION, OR OTHER
// *�SIMILAR COSTS, WHETHER ASSERTED ON THE BASIS OF CONTRACT, TORT
// *�(INCLUDING NEGLIGENCE), BREACH OF WARRANTY, OR OTHERWISE
// */
using System;
using Microsoft.SPOT;
using CTRE.Phoenix.LowLevel;

namespace CTRE
{
    namespace Phoenix
    {
        namespace Sensors
        {
            /** 
             * Pigeon IMU Class.
             * Class supports communicating over CANbus and over ribbon-cable (CAN Talon SRX).
             */
            public class PigeonIMU
            {
                private PigeonIMU_LowLevel _ll;

                

                private int m_deviceNumber = 0;

                private float[] _generalStatus = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                private float[] _fusionStatus = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                /**
                 * Create a Pigeon object that communicates with Pigeon on CAN Bus.
                 *
                 * @param deviceNumber
                 *            CAN Device Id of Pigeon [0,62]
                 */
                public PigeonIMU(int deviceNumber)
                {
                    _ll = new PigeonIMU_LowLevel(0x15000000| deviceNumber);
                    m_deviceNumber = deviceNumber;
                }

                /**
                 * Create a Pigeon object that communciates with Pigeon through the
                 * Gadgeteer ribbon cable connected to a Talon on CAN Bus.
                 *
                 * @param talonSrx
                 *            Object for the TalonSRX connected via ribbon cable.
                 */
                public PigeonIMU(MotorControl.CAN.TalonSRX talonSrx)
                {
                    m_deviceNumber = talonSrx.GetDeviceID();
                    _ll = new PigeonIMU_LowLevel(0x02000000 | m_deviceNumber);
                }

                /**
	 * Sets the Yaw register to the specified value.
	 *
	 * @param angleDeg  Degree of Yaw [+/- 23040 degrees]
	 * @param timeoutMs
   *            Timeout value in ms. If nonzero, function will wait for
   *            config success and report an error if it times out.
   *            If zero, no blocking or checking is performed.
	 * @return Error Code generated by function. 0 indicates no error.
	 */
                public ErrorCode setYaw(float angleDeg, int timeoutMs)
                {
                    ErrorCode retval = _ll.SetYaw(angleDeg, timeoutMs);
                    return retval;
                }

                /**
                 * Atomically add to the Yaw register.
                 *
                 * @param angleDeg  Degrees to add to the Yaw register.
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode addYaw(float angleDeg, int timeoutMs)
                {
                    ErrorCode retval = _ll.AddYaw(angleDeg, timeoutMs);
                    return retval;
                }
                /**
                 * Sets the Yaw register to match the current compass value.
                 *
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setYawToCompass(int timeoutMs)
                {
                    ErrorCode retval = _ll.SetYawToCompass(timeoutMs);
                    return retval;
                }

                /**
	 * Sets the Fused Heading to the specified value.
	 *
	 * @param angleDeg  Degree of heading [+/- 23040 degrees]
	 * @param timeoutMs
   *            Timeout value in ms. If nonzero, function will wait for
   *            config success and report an error if it times out.
   *            If zero, no blocking or checking is performed.
	 * @return Error Code generated by function. 0 indicates no error.
	 */
                public ErrorCode setFusedHeading(float angleDeg, int timeoutMs)
                {
                    ErrorCode retval = _ll.SetFusedHeading(angleDeg, timeoutMs);
                    return retval;
                }
                /**
                 * Atomically add to the Fused Heading register.
                 *
                 * @param angleDeg  Degrees to add to the Fused Heading register.
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode addFusedHeading(float angleDeg, int timeoutMs)
                {
                    ErrorCode retval = _ll.AddFusedHeading(angleDeg, timeoutMs);
                    return retval;
                }
                /**
                 * Sets the Fused Heading register to match the current compass value.
                 *
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setFusedHeadingToCompass(int timeoutMs)
                {
                    ErrorCode retval = _ll.SetFusedHeadingToCompass(timeoutMs);
                    return retval;
                }
                /**
                 * Sets the AccumZAngle.
                 *
                 * @param angleDeg  Degrees to set AccumZAngle to.
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setAccumZAngle(float angleDeg, int timeoutMs)
                {
                    ErrorCode retval = _ll.SetAccumZAngle(angleDeg, timeoutMs);
                    return retval;
                }

                /**
                 * Enable/Disable Temp compensation. Pigeon defaults with this on at boot.
                 *
                 * @param bTempCompEnable Set to "True" to enable temperature compensation.
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode configTemperatureCompensationEnable(bool bTempCompEnable, int timeoutMs)
                {
                    ErrorCode retval = _ll.ConfigTemperatureCompensationEnable(bTempCompEnable, timeoutMs);
                    return retval;
                }

                /**
                 * Set the declination for compass. Declination is the difference between
                 * Earth Magnetic north, and the geographic "True North".
                 *
                 * @param angleDegOffset  Degrees to set Compass Declination to.
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setCompassDeclination(float angleDegOffset, int timeoutMs)
                {
                    ErrorCode retval = _ll.SetCompassDeclination(angleDegOffset, timeoutMs);
                    return retval;
                }

                /**
                 * Sets the compass angle. Although compass is absolute [0,360) degrees, the
                 * continuous compass register holds the wrap-arounds.
                 *
                 * @param angleDeg  Degrees to set continuous compass angle to.
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setCompassAngle(float angleDeg, int timeoutMs)
                {
                    ErrorCode retval = _ll.SetCompassAngle(angleDeg, timeoutMs);
                    return retval;
                }

                // ----------------------- Calibration routines -----------------------//
                /**
                 * Enters the Calbration mode.  See the Pigeon IMU documentation for More
                 * information on Calibration.
                 *
                 * @param calMode  Calibration to execute
                 * @param timeoutMs
               *            Timeout value in ms. If nonzero, function will wait for
               *            config success and report an error if it times out.
               *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode enterCalibrationMode(CalibrationMode calMode, int timeoutMs)
                {
                    ErrorCode retval = _ll.EnterCalibrationMode(calMode, timeoutMs);
                    return retval;
                }

                /**
                 * Get the status of the current (or previousley complete) calibration.
                 *
                 * @param toFill Container for the status information.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode getGeneralStatus(GeneralStatus toFill)
                {
                    ErrorCode retval = _ll.GetGeneralStatus((GeneralStatus)toFill);
                    return toFill.lastError;
                }

                // ----------------------- General Error status -----------------------//
                /**
                 * Call GetLastError() generated by this object.
                 * Not all functions return an error code but can
                 * potentially report errors.
                 *
                 * This function can be used to retrieve those error codes.
                 *
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode getLastError()
                {
                    ErrorCode retval = _ll.GetLastError();
                    return retval;
                }

                // ----------------------- Strongly typed Signal decoders
                // -----------------------//
                /**
                 * Get 6d Quaternion data.
                 *
                 * @param wxyz Array to fill with quaternion data w[0], x[1], y[2], z[3]
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode get6dQuaternion(float[] wxyz)
                {
                    ErrorCode retval = _ll.Get6dQuaternion(wxyz);
                    return retval;
                }
                /**
                 * Get Yaw, Pitch, and Roll data.
                 *
                 * @param ypr_deg Array to fill with yaw[0], pitch[1], and roll[2] data
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode getYawPitchRoll(float[] ypr_deg)
                {
                    ErrorCode retval = _ll.GetYawPitchRoll(ypr_deg);
                    return retval;
                }
                /**
                 * Get AccumGyro data.
                 * AccumGyro is the integrated gyro value on each axis.
                 *
                 * @param xyz_deg Array to fill with x[0], y[1], and z[2] AccumGyro data
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode getAccumGyro(float[] xyz_deg)
                {
                    ErrorCode retval = _ll.GetAccumGyro(xyz_deg);
                    return retval;
                }

                /**
                 * Get the absolute compass heading.
                 * @return compass heading [0,360) degrees.
                 */
                public float getAbsoluteCompassHeading()
                {
                    float retval;
                    _ll.GetAbsoluteCompassHeading(out retval);
                    return retval;
                }

                /**
                 * Get the continuous compass heading.
                 * @return continuous compass heading [-23040, 23040) degrees. Use
                 *         SetCompassHeading to modify the wrap-around portion.
                 */
                public float getCompassHeading()
                {
                    float retval;
                        _ll.GetCompassHeading(out retval);
                    return retval;
                }

                /**
                 * Gets the compass' measured magnetic field strength.
                 * @return field strength in Microteslas (uT).
                 */
                public float getCompassFieldStrength()
                {
                    float retval;
                    _ll.GetCompassFieldStrength(out retval);
                    return retval;
                }
                /**
                 * Gets the temperature of the pigeon.
                 *
                 * @return Temperature in ('C)
                 */
                public float getTemp()
                {
                    float retval;
                    _ll.GetTemp(out retval);
                    return retval;
                }

                /**
                 * Gets the current Pigeon state
                 *
                 * @return PigeonState enum
                 */
                public PigeonState getState()
                {
                    return _ll.GetState();
                }

                /**
                 * Gets the current Pigeon uptime.
                 *
                 * @return How long has Pigeon been running in whole seconds. Value caps at
                 *         255.
                 */
                public int getUpTime()
                {
                    int retval;
                    _ll.GetUpTime(out retval);
                    return retval;
                }
                /**
                 * Get Raw Magnetometer data.
                 *
                 * @param rm_xyz Array to fill with x[0], y[1], and z[2] data
                 * 				Number is equal to 0.6 microTeslas per unit.
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode getRawMagnetometer(short[] rm_xyz)
                {
                    ErrorCode retval = _ll.GetRawMagnetometer(rm_xyz);
                    return retval;
                }
                /**
                 * Get Biased Magnetometer data.
                 *
                 * @param bm_xyz Array to fill with x[0], y[1], and z[2] data
                 * 				Number is equal to 0.6 microTeslas per unit.
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode getBiasedMagnetometer(short[] bm_xyz)
                {
                    ErrorCode retval = _ll.GetBiasedMagnetometer(bm_xyz);
                    return retval;
                }
                /**
                 * Get Biased Accelerometer data.
                 *
                 * @param ba_xyz Array to fill with x[0], y[1], and z[2] data.
                 * 			These are in fixed point notation Q2.14.  eg. 16384 = 1G
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode getBiasedAccelerometer(short[] ba_xyz)
                {
                    ErrorCode retval = _ll.GetBiasedAccelerometer(ba_xyz);
                    return retval;
                }
                /**
                 * Get Raw Gyro data.
                 *
                 * @param xyz_dps Array to fill with x[0], y[1], and z[2] data in degrees per second.
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode getRawGyro(float[] xyz_dps)
                {
                    ErrorCode retval = _ll.GetRawGyro(xyz_dps);
                    return retval;
                }
                /**
                 * Get Accelerometer tilt angles.
                 *
                 * @param tiltAngles Array to fill with x[0], y[1], and z[2] angles in degrees.
                 * @return The last ErrorCode generated.
                 */
                public ErrorCode getAccelerometerAngles(float[] tiltAngles)
                {
                    ErrorCode retval = _ll.GetAccelerometerAngles(tiltAngles);
                    return retval;
                }
                /**
                 * Get the current Fusion Status (including fused heading)
                 *
                 * @param toFill 	object reference to fill with fusion status flags.
                 *					Caller may pass null if flags are not needed.
                 * @return The fused heading in degrees.
                 */
                public float getFusedHeading(FusionStatus toFill)
                {
                    float retval;
                    ErrorCode errorCode = _ll.GetFusedHeading(toFill, out retval);
                    
                    return retval;
                }
                /**
                 * Gets the Fused Heading
                 *
                 * @return The fused heading in degrees.
                 */
                public float getFusedHeading()
                {
                    float retval;
                    _ll.GetFusedHeading(out retval);

                    return retval;
                }

                /**
                 * Gets the firmware version of the device.
                 *
                 * @return param holds the firmware version of the device. Device must be powered
                 * cycled at least once.
                 */
                public int getFirmwareVersion()
                {
                    int k = _ll.GetFirmwareVersion();
                    return k;
                }

                /**
                 * @return true iff a reset has occurred since last call.
                 */
                public bool hasResetOccurred()
                {
                    bool k = _ll.HasResetOccurred();
                    return k;
                }

                /**
                 * Sets the value of a custom parameter. This is for arbitrary use.
               *
               * Sometimes it is necessary to save calibration/declination/offset
               * information in the device. Particularly if the
               * device is part of a subsystem that can be replaced.
                 *
                 * @param newValue
                 *            Value for custom parameter.
                 * @param paramIndex
                 *            Index of custom parameter. [0-1]
                 * @param timeoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode configSetCustomParam(int newValue, int paramIndex, int timeoutMs)
                {
                    ErrorCode retval = _ll.ConfigSetCustomParam(newValue, paramIndex, timeoutMs);
                    return retval;
                }

                /**
                 * Gets the value of a custom parameter. This is for arbitrary use.
               *
               * Sometimes it is necessary to save calibration/declination/offset
               * information in the device. Particularly if the
               * device is part of a subsystem that can be replaced.
                 *
                 * @param paramIndex
                 *            Index of custom parameter. [0-1]
                 * @param timoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Value of the custom param.
                 */
                public int configGetCustomParam(int paramIndex, int timoutMs)
                {
                    int retval;
                    _ll.ConfigGetCustomParam(out retval, paramIndex, timoutMs);
                    return retval;
                }

                /**
                 * Sets a parameter. Generally this is not used.
               * This can be utilized in
               * - Using new features without updating API installation.
               * - Errata workarounds to circumvent API implementation.
               * - Allows for rapid testing / unit testing of firmware.
                 *
                 * @param param
                 *            Parameter enumeration.
                 * @param value
                 *            Value of parameter.
                 * @param subValue
                 *            Subvalue for parameter. Maximum value of 255.
                 * @param ordinal
                 *            Ordinal of parameter.
                 * @param timeoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode configSetParameter(ParamEnum param, float value, int subValue, int ordinal, int timeoutMs)
                {
                    return _ll.ConfigSetParameter(param, value, (byte)subValue, ordinal, timeoutMs);
                }
                /**
                 * Sets a parameter. Generally this is not used.
               * This can be utilized in
               * - Using new features without updating API installation.
               * - Errata workarounds to circumvent API implementation.
               * - Allows for rapid testing / unit testing of firmware.
                 *
                 * @param param
                 *            Parameter enumeration.
                 * @param value
                 *            Value of parameter.
                 * @param subValue
                 *            Subvalue for parameter. Maximum value of 255.
                 * @param ordinal
                 *            Ordinal of parameter.
                 * @param timeoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode configSetParameter(int param, float value, int subValue, int ordinal, int timeoutMs)
                {
                    ErrorCode retval = _ll.ConfigSetParameter((ParamEnum)param, value, (byte)subValue, ordinal,
                            timeoutMs);
                    return retval;
                }
                /**
                 * Gets a parameter. Generally this is not used.
               * This can be utilized in
               * - Using new features without updating API installation.
               * - Errata workarounds to circumvent API implementation.
               * - Allows for rapid testing / unit testing of firmware.
                 *
                 * @param param
                 *            Parameter enumeration.
                 * @param ordinal
                 *            Ordinal of parameter.
                 * @param timeoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Value of parameter.
                 */
                public float configGetParameter(ParamEnum param, int ordinal, int timeoutMs)
                {
                    float retval;
                    _ll.ConfigGetParameter(param, out retval, ordinal, timeoutMs);
                    return retval;
                }
                /**
                 * Gets a parameter.
                 *
                 * @param param
                 *            Parameter enumeration.
                 * @param ordinal
                 *            Ordinal of parameter.
                 * @param timeoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Value of parameter.
                 */
                public float configGetParameter(int param, int ordinal, int timeoutMs)
                {
                    float retval;
                    _ll.ConfigGetParameter((ParamEnum)param, out retval, ordinal, timeoutMs);
                    return retval;
                }
                /**
                 * Sets the period of the given status frame.
                 *
                 * @param statusFrame
                 *            Frame whose period is to be changed.
                 * @param periodMs
                 *            Period in ms for the given frame.
                 * @param timeoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setStatusFramePeriod(PigeonIMU_StatusFrame statusFrame, int periodMs, int timeoutMs)
                {
                    ErrorCode retval = _ll.SetStatusFramePeriod(statusFrame, periodMs, timeoutMs);
                    return retval;
                }
                /**
                 * Sets the period of the given status frame.
                 *
                 * @param statusFrame
                 *            Frame whose period is to be changed.
                 * @param periodMs
                 *            Period in ms for the given frame.
                 * @param timeoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setStatusFramePeriod(int statusFrame, int periodMs, int timeoutMs)
                {
                    ErrorCode retval = _ll.SetStatusFramePeriod((PigeonIMU_StatusFrame)statusFrame, periodMs, timeoutMs);
                    return retval;
                }

                /**
                 * Gets the period of the given status frame.
                 *
                 * @param frame
                 *            Frame to get the period of.
                 * @param timeoutMs
             *            Timeout value in ms. If nonzero, function will wait for
             *            config success and report an error if it times out.
             *            If zero, no blocking or checking is performed.
                 * @return Period of the given status frame.
                 */
                public int getStatusFramePeriod(PigeonIMU_StatusFrame frame, int timeoutMs)
                {
                    int retval;
                    _ll.GetStatusFramePeriod(frame, out retval, timeoutMs);
                    return retval;
                }
                /**
                 * Sets the period of the given control frame.
                 *
                 * @param frame
                 *            Frame whose period is to be changed.
                 * @param periodMs
                 *            Period in ms for the given frame.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setControlFramePeriod(PigeonIMU_ControlFrame frame, int periodMs)
                {
                    //ErrorCode retval = _ll.SetControlFramePeriod(frame, periodMs);
                    //return retval;
                    return ErrorCode.NotImplemented;
                }
                /**
                 * Sets the period of the given control frame.
                 *
                 * @param frame
                 *            Frame whose period is to be changed.
                 * @param periodMs
                 *            Period in ms for the given frame.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode setControlFramePeriod(int frame, int periodMs)
                {
                    //ErrorCode retval = _ll.SetControlFramePeriod(frame, periodMs);
                    //return retval;
                    return ErrorCode.NotImplemented;
                }

                // ------ Faults ----------//
                /**
                 * Gets the fault status
                 *
                 * @param toFill
                 *            Container for fault statuses.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode getFaults(PigeonIMU_Faults toFill)
                {
                    return _ll.GetFaults(toFill);
                }
                /**
                 * Gets the sticky fault status
                 *
                 * @param toFill
                 *            Container for sticky fault statuses.
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode getStickyFaults(PigeonIMU_StickyFaults toFill)
                {
                    return _ll.GetStickyFaults(toFill);
                }
                /**
                 * Clears the Sticky Faults
                 *
                 * @return Error Code generated by function. 0 indicates no error.
                 */
                public ErrorCode clearStickyFaults(int timeoutMs)
                {
                    ErrorCode retval = _ll.ClearStickyFaults(timeoutMs);
                    return retval;
                }

                /**
                 * @return The Device Number
                 */
                public int getDeviceID()
                {
                    return m_deviceNumber;
                }
            }
        }
    }
}
