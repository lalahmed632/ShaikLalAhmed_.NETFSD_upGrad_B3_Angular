// ─── 1. Models ───────────────────────────────────────────────

interface User {
  id: number;
  name: string;
}

interface Product {
  id: number;
  title: string;
  price: number;
}

// ─── 2. Generic Interface ────────────────────────────────────

interface Repository<T> {
  add(item: T): void;
  getAll(): T[];
  getById(id: number): T | undefined;
  remove(id: number): boolean;
}

// ─── 3. Generic Class ────────────────────────────────────────

class DataManager<T extends { id: number }> implements Repository<T> {
  private items: T[] = [];

  add(item: T): void {
    const exists = this.items.find(i => i.id === item.id);
    if (exists) {
      console.warn(`Item with id ${item.id} already exists.`);
      return;
    }
    this.items.push(item);
    console.log(` Added item with id ${item.id}`);
  }

  getAll(): T[] {
    return [...this.items]; // return a copy
  }

  getById(id: number): T | undefined {
    return this.items.find(i => i.id === id);
  }

  remove(id: number): boolean {
    const index = this.items.findIndex(i => i.id === id);
    if (index === -1) return false;
    this.items.splice(index, 1);
    return true;
  }

  count(): number {
    return this.items.length;
  }
}

// ─── 4. Generic Functions ────────────────────────────────────

// Returns the first element from any typed array
function getFirstElement<T>(items: T[]): T | undefined {
  if (items.length === 0) return undefined;
  return items[0];
}

// Returns the last element from any typed array
function getLastElement<T>(items: T[]): T | undefined {
  if (items.length === 0) return undefined;
  return items[items.length - 1];
}

// Filters an array based on a predicate — works for any type
function filterItems<T>(items: T[], predicate: (item: T) => boolean): T[] {
  return items.filter(predicate);
}

// Displays items in a formatted way
function displayItems<T>(label: string, items: T[]): void {
  console.log(`\n ${label} (${items.length} item(s)):`);
  items.forEach((item, index) => {
    console.log(`  [${index + 1}]`, JSON.stringify(item));
  });
}

// ─── 5. Use Case: User Management ────────────────────────────;

const userManager = new DataManager<User>();

userManager.add({ id: 1, name: "Alice Johnson" });
userManager.add({ id: 2, name: "Bob Smith" });
userManager.add({ id: 3, name: "Carol White" });
userManager.add({ id: 4, name: "David Brown" });
userManager.add({ id: 2, name: "Duplicate Bob" }); // duplicate warning

displayItems<User>("All Users", userManager.getAll());

const firstUser = getFirstElement<User>(userManager.getAll());
console.log("\n First User:", firstUser);

const lastUser = getLastElement<User>(userManager.getAll());
console.log(" Last User:", lastUser);

const userById = userManager.getById(3);
console.log("\n User with id=3:", userById);

console.log("\n Removing user with id=2:", userManager.remove(2));
displayItems<User>("Users after removal", userManager.getAll());

// ─── 6. Use Case: Product Management ─────────────────────────

const productManager = new DataManager<Product>();

productManager.add({ id: 101, title: "Laptop",     price: 75000 });
productManager.add({ id: 102, title: "Mouse",      price: 1200  });
productManager.add({ id: 103, title: "Keyboard",   price: 2500  });
productManager.add({ id: 104, title: "Monitor",    price: 18000 });
productManager.add({ id: 105, title: "Headphones", price: 3500  });

displayItems<Product>("All Products", productManager.getAll());

const firstProduct = getFirstElement<Product>(productManager.getAll());
console.log("\n First Product:", firstProduct);

// Filter products under ₹5000 using generic filterItems
const budget = filterItems<Product>(
  productManager.getAll(),
  p => p.price < 5000
);
displayItems<Product>("Products under ₹5000", budget);

// Filter products over ₹10000
const premium = filterItems<Product>(
  productManager.getAll(),
  p => p.price >= 10000
);
displayItems<Product>("Products ₹10,000 and above", premium);

console.log("\n Total products:", productManager.count());

// ─── 7. Demonstrate Type Safety ───────────────────────────────

// Same generic function works for strings
const fruits = ["Apple", "Banana", "Mango"];
console.log("\n First fruit:", getFirstElement<string>(fruits));
console.log(" Last fruit:", getLastElement<string>(fruits));

// Same generic function works for numbers
const scores = [87, 45, 92, 60, 78];
console.log("\n First score:", getFirstElement<number>(scores));
const highScores = filterItems<number>(scores, s => s >= 80);
console.log(" High scores (>=80):", highScores);
