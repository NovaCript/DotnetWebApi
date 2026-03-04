import TableContact from "./layout/TableContact/TableContact";
import React, { useState } from "react";
const App = () => {
  const [contacts, setContacts] = useState([
    { id: 1, name: "Имя Фамилия 1", email: "q1@e.rt" },
    { id: 2, name: "Имя Фамилия 2", email: "q2@e.rt" },
    { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  ]);
  const addContact = () => {
    const item = {
      id: Math.floor(Math.random() * 10) + 1,
      name: "Имя Фамилия 3",
      email: "q3@e.rt",
    };
    const exists = contacts.some((contact) => contact.id === item.id);
    if (!exists) {
      setContacts([...contacts, item]);
    } else {
      alert(`Ошибка: Контакт с ID ${item.id} уже существует!`);
    }
  };

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact contacts={contacts} />
          <div>
            <button
              className="btn btn-primary"
              onClick={() => {
                addContact();
              }}
            >
              Добавить контакт
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default App;
