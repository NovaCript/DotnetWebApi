import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import React, { useState, useEffect } from "react";
import axios from "axios";

const baseApiUrl = process.env.REACT_APP_API_URL;
const url = `${baseApiUrl}/contacts`;
const App = () => {
  const [contacts, setContacts] = useState([]);

  useEffect(() => {
    axios.get(url).then((res) => setContacts(res.data));
  }, []);

  const addContact = (contactName, contactEmail) => {
    const item = {
      name: contactName,
      email: contactEmail,
    };

    axios
      .post(url, item)
      .then((responce) => setContacts([...contacts, responce.data]));
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
