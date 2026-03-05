import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import React, { useState, useEffect } from "react";
import axios from "axios";

const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {
  const [contacts, setContacts] = useState([]);

  const url = `${baseApiUrl}/contacts`;
  useEffect(() => {
    axios.get(url).then((res) => setContacts(res.data));
  }, []);
  const addContact = (contactName, contactEmail) => {
    let newId = 0;
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
    axios.post(url, item);
    setContacts([...contacts, item]);
  };

  const deleteContact = (id) => {
    axios.delete(`${url}/${id}`);
    setContacts(contacts.filter((item) => item.id !== id));
  };

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact contacts={contacts} deleteContact={deleteContact} />
          <FormContact addContact={addContact} />
        </div>
      </div>
    </div>
  );
};

export default App;
