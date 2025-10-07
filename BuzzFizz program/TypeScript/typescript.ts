import * as readline from 'readline';

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

function askQuestion(query: string): Promise<string> {
    return new Promise(resolve => rl.question(query, resolve));
}

function isPrime(n: number): boolean {
    if (n < 2) return false;
    for (let i = 2; i <= Math.sqrt(n); i++) {
        if (n % i === 0) return false;
    }
    return true;
}

async function getValidInput(): Promise<number> {
    let attempts = 0;

    while (attempts < 3) {
        const answer = await askQuestion("Enter a number between 10 and 200: ");
        const num = parseInt(answer);

        if (!isNaN(num) && num >= 10 && num <= 200) {
            return num;
        } else {
            console.log("Invalid input. Please enter an integer between 10 and 200.");
            attempts++;
        }
    }

    console.log("Too many invalid attempts. Exiting.");
    rl.close();
    process.exit(1);
}

async function main() {
    const name = await askQuestion("\nEnter your name: ");
    const N = await getValidInput();

    let output: string[] = [];
    let countPrimes = 0;
    let sumEven = 0;
    let maxOdd = Number.NEGATIVE_INFINITY;
    let sumDivBy7 = 0;

    for (let i = 1; i <= N; i++) {
        if (i % 15 === 0) {
            output.push("FizzBuzz");
        } else if (i % 3 === 0) {
            output.push("Fizz");
        } else if (i % 5 === 0) {
            output.push("Buzz");
        } else if (isPrime(i)) {
            output.push(`[${i}]`);
            countPrimes++;
        } else {
            output.push(i.toString());
        }

        if (i % 2 === 0) {
            sumEven += i;
        }

        if (i % 2 === 1 && i > maxOdd) {
            maxOdd = i;
        }

        if (i % 7 === 0) {
            sumDivBy7 += i;
        }
    }

    console.log("\n" + output.join(" "));

    console.log(`\nCountPrimes = ${countPrimes}`);
    console.log(`SumEven = ${sumEven}`);
    console.log(`MaxOdd = ${maxOdd}`);
    console.log(`SumDivBy7 = ${sumDivBy7}`);

    console.log(`Well done, ${name}! You combined loops and conditionals successfully.`);

    rl.close();
}

main();

