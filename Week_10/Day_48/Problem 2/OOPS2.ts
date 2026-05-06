// 1. Function with Required Parameter
function getWelcomeMessage(name: string): string {
  return `Welcome ${name}!`;
}

// 2. Optional Parameter
function getUserInfo(name: string, age?: number): string {
  if (age !== undefined) {
    return `User ${name} is ${age} years old`;
  }
  return `User ${name}`;
}

// 3. Default Parameter
function getSubscriptionStatus(name: string,isSubscribed: boolean = false): string {
  return isSubscribed ? `${name} is subscribed` : `${name} is not subscribed`;
}

// 4. Function returning boolean
function isEligibleForPremium(age: number): boolean {
  return age > 18;
}

// 5. Arrow Function (rewrite)
const getWelcomeMessageArrow = (name: string): string => {
  return `Welcome ${name} (arrow)!`;
};

// 6. Lexical `this` with arrow function
const NotificationService = {
  appName: "MyApp",

  // arrow function preserves `this`
  sendNotification: (user: string): string => {
    return `Hello ${user}, welcome to ${NotificationService.appName}`;
  }
};

// 7. Execution
console.log(getWelcomeMessage("Lal"));
console.log(getUserInfo("Lal", 25));
console.log(getUserInfo("Lal"));
console.log(getSubscriptionStatus("Lal"));
console.log(getSubscriptionStatus("Lal", true));
console.log(isEligibleForPremium(20));
console.log(getWelcomeMessageArrow("Lal"));
console.log(NotificationService.sendNotification("Lal"));