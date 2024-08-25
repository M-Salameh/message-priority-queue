import http from 'k6/http';
import { check, sleep } from 'k6';

// Function to generate a random integer between min and max (inclusive)
function randomIntBetween(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

// Function to generate a random string of lowercase letters of a given length
function randomString() {
    const characters = 'abcdefghijklmnopqrstuvwxyz';
    return characters[randomIntBetween(0, 25)];
}

// Function to generate a random client ID (between 1 and 20)
function randomClientID() {
    return randomIntBetween(1, 20).toString(); // Convert to string
}

// Function to randomly select a tag
function randomTag() {
    return Math.random() < 0.5 ? 'mtn' : 'syr';
}

export const options = {
    
    stages: [
        { duration: '20s', target: 20 },
        { duration: '30s', target: 100 },
        { duration: '120s', target: 100 },
        { duration: '10s', target: 0 }
      ],
    };
export default function () {
    const url = 'http://localhost:7095/queue-msg';

    const localPriority = randomIntBetween(1, 5);
    const tag = randomTag();
    const apiKey = randomString();
    const clientID = randomClientID();

    const payload = JSON.stringify({
        clientID: clientID,
        apiKey: apiKey,
        msgId: '',
        phoneNumber: 'some gateway',
        localPriority: localPriority,
        text: 'Hello, this is a test message!',
        tag: tag,
        year: 2024,
        month: 8,
        day: 25,
        hour: 10,
        minute: 30,
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    // Send the POST request
    let response = http.post(url, payload, params);

    // Check if the response status is 200
    check(response, {
        'is status 200': (r) => r.status === 200,
        'response time < 200ms': (r) => r.timings.duration < 200,
    });

    sleep(1); // Sleep for 1 second between iterations
}

/*
stages: [
        { duration: '20s', target: 100 },
        { duration: '30s', target: 1000 },
        { duration: '120s', target: 2000 },
        { duration: '10s', target: 0 }
      ],
    };
*/