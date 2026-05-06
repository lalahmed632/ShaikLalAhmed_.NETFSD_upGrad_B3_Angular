let contacts = [];

// Load existing contacts (simulate API)
document.addEventListener("DOMContentLoaded", () => {
    loadContacts();
});

function loadContacts() {
    try {
        const stored = localStorage.getItem("contacts");
        if (stored) {
            contacts = JSON.parse(stored);
        }
        renderContacts();
    } catch (err) {
        console.error("Error loading contacts:", err);
    }
}

function addContact() {
    const name = document.getElementById("name").value.trim();
    const phone = document.getElementById("phone").value.trim();

    if (name === "" || phone === "") {
        alert("Please fill all fields");
        return;
    }

    const newContact = { name, phone };

    contacts.push(newContact);

    saveContacts();
    renderContacts();

    document.getElementById("name").value = "";
    document.getElementById("phone").value = "";
}

function saveContacts() {
    try {
        localStorage.setItem("contacts", JSON.stringify(contacts));
    } catch (err) {
        console.error("Error saving contacts:", err);
    }
}

function renderContacts() {
    const list = document.getElementById("contactList");
    list.innerHTML = "";

    contacts.forEach((contact, index) => {
        const li = document.createElement("li");
        li.innerHTML = `
            <strong>${contact.name}</strong> - ${contact.phone}
            <button onclick="deleteContact(${index})">Delete</button>
        `;
        list.appendChild(li);
    });
}

function deleteContact(index) {
    contacts.splice(index, 1);
    saveContacts();
    renderContacts();
}