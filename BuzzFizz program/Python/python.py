def is_prime(n):
    if n < 2:
        return False
    for i in range(2, int(n**0.5) + 1):
        if n % i == 0:
            return False
    return True

def get_valid_input():
    attempts = 0
    while attempts < 3:
        try:
            value = int(input("Enter a number between 10 and 200: "))
            if 10 <= value <= 200:
                return value
            else:
                print("Number not in range 10–200.")
        except ValueError:
            print("Invalid input. Please enter an integer.")
        attempts += 1
    print("Too many invalid attempts. Exiting.")
    exit()

def main():
    name = input("\nEnter your name: ")
    N = get_valid_input()

    output = []
    count_primes = 0
    sum_even = 0
    max_odd = None
    sum_div_by_7 = 0

    for i in range(1, N + 1):
        if i % 15 == 0:
            output.append("FizzBuzz")
        elif i % 3 == 0:
            output.append("Fizz")
        elif i % 5 == 0:
            output.append("Buzz")
        elif is_prime(i):
            output.append(f"[{i}]")
            count_primes += 1
        else:
            output.append(str(i))

        if i % 2 == 0:
            sum_even += i
        if i % 2 == 1:
            if max_odd is None or i > max_odd:
                max_odd = i
        if i % 7 == 0:
            sum_div_by_7 += i

    print(" ".join(output))
    print(f"\nCountPrimes = {count_primes}")
    print(f"SumEven = {sum_even}")
    print(f"MaxOdd = {max_odd}")
    print(f"SumDivBy7 = {sum_div_by_7}")
    
    print(f"Well done, {name}! You combined loops and conditionals successfully.")

if __name__ == "__main__":
    main()

