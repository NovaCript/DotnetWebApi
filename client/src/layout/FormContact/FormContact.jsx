import React, {use, useState} from "react";

const FormContact = (props) => {

    const [contactName, setContactName] = useState("");
    const [contactEmail, setContactEmail] = useState("");

    const submit = () => {
        if (!contactName.trim()) return alert("Введите Имя контакта");
        if (!contactEmail.trim()) return alert("Введите Email контакта")
        props.addContact(contactName, contactEmail);
    }

  return (
    <div>
      <div className="mb-3">
        <form>
          <div className="mb-3">
            <label className="form-label"></label>
                      <input className="form-control" type="text" placeholder="Введите имя:"
                      onChange={(e) => {setContactName(e.target.value)}}/>
          </div>
          <div className="mb-3">
            <label className="form-label"></label>
            {/* <input className="form-control" type="text" /> */}
                      <textarea className="form-control" rows={2} placeholder="Введите email:"
                      onChange={(e) => {setContactEmail(e.target.value)}}></textarea>
          </div>
        </form>
      </div>

      <div>
        <button className="btn btn-primary" onClick={() => {submit()}}>
          Добавить контакт
        </button>
      </div>
    </div>
  );
};

export default FormContact;
