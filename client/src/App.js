import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import React, { useState } from "react";
const App = () => {
  const [contacts, setContacts] = useState([
    { id: 21, name: "Имя Фамилия 21", email: "q21@e.rt" },
    { id: 12, name: "Имя Фамилия 12", email: "q12@e.rt" },
    { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
    { id: 6, name: "Имя Фамилия 6", email: "q6@e.rt" },
  ]);
  const addContact = (contactName, contactEmail) => {
    let newId = -1;
    // let maxId = Math.max(...contacts.map(e => e.id)) + 1;
    // contacts.sort((x, y) => x.id - y.id)[contacts.length - 1].id + 1;
    for (let i = 0; i < contacts.length; i++) {
      const elementId = contacts[i].id;
      if (newId < elementId) {
        newId = elementId;
      }
    }
    newId++;
    const item = {
      id: newId,
      name: contactName,
      email: contactEmail,
    };
    setContacts([...contacts, item]);
  };

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact contacts={contacts} />
          <FormContact addContact={addContact} />
        </div>
      </div>
    </div>
  );
};

export default App;
