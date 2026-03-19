import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import React, { useState, useEffect } from "react";
import axios from "axios";
import { Route, Routes, useLocation } from "react-router-dom";
import ContactDetails from "./layout/ContactDetails/ContactDetails";

const baseApiUrl = process.env.REACT_APP_API_URL;
const url = `${baseApiUrl}/contacts`;
const App = () => {
  const [contacts, setContacts] = useState([]);
  const location = useLocation();

  useEffect(() => {
    axios.get(url).then((res) => setContacts(res.data));
  }, [location]);

  const addContact = (contactName, contactEmail) => {
    const item = {
      name: contactName,
      email: contactEmail,
    };

    axios
      .post(url, item)
      .then((responce) => setContacts([...contacts, responce.data]));
  };

  return (
    <div className="container mt-5">
      <Routes>
        <Route
          path="/"
          element={
            <div className="card">
              <div className="card-header">
                <h1>Список контактов</h1>
              </div>
              <div className="card-body">
                <TableContact contacts={contacts} />
                <FormContact addContact={addContact} />
              </div>
            </div>
          }
        />
        <Route path="/contact/:id" element={<ContactDetails />} />
      </Routes>
    </div>
  );
};

export default App;
