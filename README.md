# RSA-Based Secure Data Handling with GUI

## Project Overview

This project implements a secure data encryption and decryption system using the RSA algorithm, complemented by a user-friendly graphical interface. It is designed to handle sensitive information with high security by leveraging RSA for cryptographic operations.

## Key Features

### RSA Encryption and Decryption
- Utilizes the RSA algorithm, a widely-recognized asymmetric encryption technique, to ensure robust data security.
- Encrypts data with a public key and decrypts data with the corresponding private key, providing a secure method for data protection.

### Key Management
- Automatically generates RSA key pairs (public and private keys) essential for the encryption and decryption processes.

### User Interface
- Developed an intuitive graphical user interface (GUI) in C# to facilitate seamless user interaction with the encryption and decryption functions.
- Allows users to easily manage RSA keys, and perform encryption or decryption operations.

## Technical Implementation

### RSA Algorithm
- **Public Key Encryption**: Encrypts data using the RSA public key, ensuring that only the holder of the corresponding private key can decrypt the data.
- **Private Key Decryption**: Decrypts data using the RSA private key, restoring the original data securely.

### C# Application
- The primary GUI is developed in C# to provide a user-friendly experience. It handles key management, and integrates with the RSA cryptographic functions implemented in C++.

### C++ Library
- Implements the RSA algorithm in a C++ library, performing core cryptographic operations. This library is invoked by the C# application to handle encryption and decryption tasks.

## Workflow

1. Key Generation

2. Encryption Process

3. Decryption Process
