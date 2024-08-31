# RSA-Based Secure Data Handling with GUI

This project implements a secure file encryption and decryption system using the RSA algorithm, featuring a user-friendly graphical interface.

## Key Features

- **RSA Encryption/Decryption:** Encrypt files with a public key and decrypt with a private key to ensure secure data protection.
- **Key Management:** Automatically generate and securely store RSA key pairs.
- **File Handling:**
  - **Encryption:** Select and encrypt files, saving them securely.
  - **Decryption:** Retrieve and decrypt files to restore original content.
- **User Interface:** An intuitive C# GUI for easy file selection and key management, interfacing with C++ for RSA operations.

## Technical Implementation

- **RSA Algorithm:** Utilizes public key encryption and private key decryption.
- **C# Application:** Provides the graphical user interface for file operations and integrates with the C++ RSA library.
- **C++ Library:** Implements core RSA cryptographic functions.

## Workflow

1. **Generate RSA Key Pairs:** Create and store RSA public and private keys.
2. **Encrypt Files:** Select a file, encrypt it using the RSA public key, and save it.
3. **Decrypt Files:** Select an encrypted file, decrypt it with the RSA private key to restore the original content.

## Getting Started

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/yourusername/rsa-secure-data-handling.git
