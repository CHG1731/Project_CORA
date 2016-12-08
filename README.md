# Project_CORA

# Needed References
SlimDX SDK = https://storage.googleapis.com/google-code-archive-downloads/v2/code.google.com/slimdx/SlimDX%20SDK%20(January%202012).msi

SlimDX .NET 4 lib = https://storage.googleapis.com/google-code-archive-downloads/v2/code.google.com/slimdx/SlimDX%20SDK%20(January%202012).msittps://storage.googleapis.com/google-code-archive-downloads/v2/code.google.com/slimdx/SlimDX%20Runtime%20.NET%204.0%20x64%20(January%202012).msi

# About the code
Written in C# (.NET 4 Environment)

The JoyStickState Class holds the data for the current JoyStick (The one were using is specialized for the ThrustMaster Hotas X, but its interchangeable). Any JoyStick is automatically recognized and connected.
The JoyStickState Class is updated by a background worker, that reads the values using the SlimDX lib.

The Dynamixel and SerialPort2Dynamixel Class provide an API to talk to the CM5 (latest firmware)
The base functions are included, but again this is very easy to expand on.
