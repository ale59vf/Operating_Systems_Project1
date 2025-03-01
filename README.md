Project Overview: This project demonstrates IPC using pipes in C\#, implementing a producer-consumer model for real-time data transfer. The goal was to establish reliable communication between processes, ensuring synchronization and error handling while exploring IPC concepts.

Step-by-Step instructions: 
  - Install .NET SDK 6.0 or later.
  - Use an IDE like Visual Studio.
  - Producer writes structured JSON data to an anonymous pipe.
  - Consumer reads, deserializes, and processes the data.
  - Run dotnet build to compile.
  - Start the producer, then launch the consumer.

Required Dependencies:
  - .NET SDK 6.0+ – Install from official .NET website.
  - Newtonsoft.Json – Required for JSON serialization/deserialization.
Installation Instructions:
  - Install .NET SDK:
    - Download and install from the official .NET website.
    - Verify installation with dotnet --version in the command line.
  - Install Newtonsoft.Json:
    - Open a terminal or command prompt in the project directory.
    - Run dotnet add package Newtonsoft.Json to install the package.
