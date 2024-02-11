#include <iostream>
#include <cstdlib>
#include <ctime>
#include <string>

using namespace std;

int gcd(int a, int b) {
    if (b == 0)
        return a;
    else
        return gcd(b, a % b);
}

bool is_prime(int num) {
    if (num <= 1) {
        return false;
    }
    for (int i = 2; i < num; i++) {
        if (num % i == 0) {
            return false;
        }
    }
    return true;
}

long long mod_exp(long long base, int exp, int mod) {
    long long result = 1;
    base %= mod;
    while (exp > 0) {
        if (exp % 2 == 1) {
            result = (result * base) % mod;
        }
        exp >>= 1;
        base = (base * base) % mod;
    }
    return result;
}

long long encrypt(long long m, int e, int n) {
    return mod_exp(m, e, n);
}

long long decrypt(long long c, int count_key, int n) {
    return mod_exp(c, count_key, n);
}

int main() {
    int n, phi, e, count_key;

    srand(time(NULL));
    int count = 0;
    int arr1[2] = {};
    while (count < 2) {
        int num = rand() % 400 + 100; // generate a random number between 2 and 50
        if (is_prime(num)) {
            cout << num << endl;
            arr1[count] = num;
            if (count == 1) {
                n = arr1[0] * arr1[1];
                phi = (arr1[0] - 1) * (arr1[1] - 1);
            }
            count++;
        }
    }

    cout << "n is: " << n << endl;
    cout << "phi is: " << phi << endl;

    for (int i = 2; i < phi; i++) {
        if (gcd(i, phi) == 1) {
            e = i;
            cout << "e is: " << e << endl;
            break;
        }
    }

    for (count_key = 1; (count_key * e) % phi != 1; count_key++);
    cout << "Decryption key is: " << count_key;

    int choice;
    while (true) {
        cout << "Enter 1 to encrypt a number, 2 to decrypt a number, or -1 to exit: ";
        cin >> choice;

        if (choice == -1) {
            break;
        }

        if (choice == 1) {
            cout << "Enter the number to encrypt: ";
            long long number;
            cin >> number;

            long long encrypted_number = encrypt(number, e, n);
            cout << "Encrypted number: " << encrypted_number << endl;
        }
        else if (choice == 2) {
            cout << "Enter the number to decrypt: ";
            long long number;
            cin >> number;

            long long decrypted_number = decrypt(number, count_key, n);
            cout << "Decrypted number: " << decrypted_number << endl;
        }
        else {
            cout << "Invalid choice. Please enter either 1, 2, or -1." << endl;
        }
    }

    return 0;
}
