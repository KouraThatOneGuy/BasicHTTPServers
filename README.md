# BasicHTTPServers

This repository contains implementations of basic HTTP servers in various programming languages. The primary goal of this project is to serve as a learning exercise, providing semi-advanced projects to facilitate the correct learning of these languages. Please note that these servers may not function correctly; if they don't work, um, whoops :b

## Implemented Languages

The repository includes HTTP server implementations in the following languages:

- C
- C++
- C#
- Go
- Java
- JavaScript (Node.js)
- Python
- R
- V

## Prerequisites

To run the servers, ensure you have the appropriate runtime environments or compilers installed for each language:

- **C**: GCC or any standard C compiler
- **C++**: G++ or any standard C++ compiler
- **C#**: .NET SDK
- **Go**: Go compiler and runtime (version 1.16 or higher)
- **Java**: JDK
- **JavaScript**: Node.js
- **Python**: Python interpreter
- **R**: R programming environment
- **V**: V compiler

## Usage

Instructions for running each server are as follows:

### C

1. **Compile the server:**

   ```bash
   gcc HTTPServer.c -o http_server
   ```



2. **Run the server:**

   ```bash
   ./http_server
   ```



### C++

1. **Compile the server:**

   ```bash
   g++ HTTPServer.cpp -o http_server
   ```



2. **Run the server:**

   ```bash
   ./http_server
   ```



### C#

1. **Compile the server:**

   ```bash
   csc HTTPServer.cs
   ```



2. **Run the server:**

   ```bash
   mono HTTPServer.exe
   ```



### Go

1. **Navigate to the Go server directory:**

   ```bash
   cd GoServer
   ```



2. **Run the server:**

   ```bash
   go run HTTPServer.go
   ```



   Alternatively, you can build and run the server:

   ```bash
   go build HTTPServer.go
   ./HTTPServer
   ```



   The server will start and listen for incoming HTTP requests.

### Java

1. **Compile the server:**

   ```bash
   javac HTTPServer.java
   ```



2. **Run the server:**

   ```bash
   java HTTPServer
   ```



### JavaScript (Node.js)

1. **Run the server:**

   ```bash
   node HTTPServer.js
   ```



### Python

1. **Run the server:**

   ```bash
   python HTTPServer.py
   ```



### R

1. **Install the `servr` package** (if not already installed):

   The `servr` package provides a simple HTTP server in R. You can install it from CRAN:

   ```r
   install.packages("servr")
   ```



2. **Run the server:**

   Use the `httd()` function from the `servr` package to serve files from the current directory:

   ```r
   servr::httd()
   ```



   By default, the server listens on port 4321. You can specify a different port if needed:

   ```r
   servr::httd(port = 8080)
   ```



   The server will start and serve files from the specified directory. You can access it by navigating to `http://localhost:8080` in your web browser.

### V

1. **Navigate to the V server directory:**

   ```bash
   cd VServer
   ```



2. **Compile the server:**

   ```bash
   v HTTPServer.v
   ```



3. **Run the server:**

   ```bash
   ./HTTPServer
   ```



   The server will start and listen for incoming HTTP requests.

## Notes

- These implementations are intended for educational purposes and may not adhere to production-level standards.
- Ensure you have the necessary permissions to run servers on your machine.
- Test the servers in a controlled environment before deploying them in any production scenario.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
