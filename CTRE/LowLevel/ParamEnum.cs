using System;
using Microsoft.SPOT;

namespace CTRE.Phoenix.LowLevel
{
    /**
     * Signal enumeration for generic signal access.
     * Although every signal is enumerated, only use this for traffic that must
     * be solicited.
     * Use the auto generated getters/setters at bottom of this header as much as
     * possible.
     */
    public enum ParamEnum
    {
        eQuadFilterEn = 91,
        eQuadIdxPolarity = 108,
        eMotionProfileHasUnderrunErr = 119,
        eMotionProfileTrajectoryPointDurationMs = 120,

        eStatusFramePeriod = 300,
        eOpenloopRamp = 301,
        eClosedloopRamp = 302,
        eNeutralDeadband = 303,

        /** Peak and Nominal Output */
        ePeakPosOutput = 305,
        eNominalPosOutput = 306,
        ePeakNegOutput = 307,
        eNominalNegOutput = 308,

        /** PID Configuration */
        eProfileParamSlot_P = 310,
        eProfileParamSlot_I = 311,
        eProfileParamSlot_D = 312,
        eProfileParamSlot_F = 313,
        eProfileParamSlot_IZone = 314,
        eProfileParamSlot_AllowableErr = 315,
        eProfileParamSlot_MaxIAccum = 316,
        eProfileParamSlot_PeakOutput = 317,

        eClearPositionOnLimitF = 320,
        eClearPositionOnLimitR = 321,
        eClearPositionOnQuadIdx = 322,

        /** Velocity Averaging */
        eSampleVelocityPeriod = 325,
        eSampleVelocityWindow = 326,

        /** Sensor Configuration */
        eFeedbackSensorType = 330,      // feedbackDevice_t
        eSelectedSensorPosition = 331,
        eFeedbackNotContinuous = 332,
        eRemoteSensorSource = 333,      // RemoteSensorSource_t
        eRemoteSensorDeviceID = 334,    // [0,62] DeviceID
        eSensorTerm = 335,              // feedbackDevice_t (ordinal is the register)
        eRemoteSensorClosedLoopDisableNeutralOnLOS = 336,
        ePIDLoopPolarity = 337,
        ePIDLoopPeriod = 338,
        eSelectedSensorCoefficient = 339,

        /** Soft Limits */
        eForwardSoftLimitThreshold = 340,
        eReverseSoftLimitThreshold = 341,
        eForwardSoftLimitEnable = 342,
        eReverseSoftLimitEnable = 343,

        /** Voltage Compensation */
        eNominalBatteryVoltage = 350,
        eBatteryVoltageFilterSize = 351,

        /** Current Limit */
        eContinuousCurrentLimitAmps = 360,
        ePeakCurrentLimitMs = 361,
        ePeakCurrentLimitAmps = 362,

        eClosedLoopIAccum = 370,

        eCustomParam = 380,

        eStickyFaults = 390,

        /** Encoder Position */
        eAnalogPosition = 400,
        eQuadraturePosition = 401,
        ePulseWidthPosition = 402,

        /** Motion Magic */
        eMotMag_Accel = 410,
        eMotMag_VelCruise = 411,

        /** Limit Switches */
        eLimitSwitchSource = 421,           // ordinal (fwd=0,reverse=1), @see LimitSwitchSource_t
        eLimitSwitchNormClosedAndDis = 422, // ordinal (fwd=0,reverse=1). @see LimitSwitchNormClosedAndDis_t
        eLimitSwitchDisableNeutralOnLOS = 423,
        eLimitSwitchRemoteDevID = 424,
        eSoftLimitDisableNeutralOnLOS = 425,

        /** PWM Encoder */
        ePulseWidthPeriod_EdgesPerRot = 430,
        ePulseWidthPeriod_FilterWindowSz = 431,

        /** Pigeon */
        eYawOffset = 160,
        eCompassOffset = 161,
        eBetaGain = 162,
        eEnableCompassFusion = 163,
        eGyroNoMotionCal = 164,
        eEnterCalibration = 165,
        eFusedHeadingOffset = 166,
        eStatusFrameRate = 169,
        eAccumZ = 170,
        eTempCompDisable = 171,
        eMotionMeas_tap_threshX = 172,
        eMotionMeas_tap_threshY = 173,
        eMotionMeas_tap_threshZ = 174,
        eMotionMeas_tap_count = 175,
        eMotionMeas_tap_time = 176,
        eMotionMeas_tap_time_multi = 177,
        eMotionMeas_shake_reject_thresh = 178,
        eMotionMeas_shake_reject_time = 179,
        eMotionMeas_shake_reject_timeout = 180,
    };

    public static class MotionProf_DurationMs
    {
        public static readonly int[] List = { 0, 5, 10, 20, 30, 40, 50, 100 };
    }
}
