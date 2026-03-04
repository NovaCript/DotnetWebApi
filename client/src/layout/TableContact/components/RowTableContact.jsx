import React from "react";

const RowTableContact = (props) => {
  return (
    <tr>
      {/* <td>{props.contact.id}</td>
      <td>{props.contact.name}</td>
      <td>{props.contact.email}</td> */}
      <td>{props.id}</td>
      <td>{props.name}</td>
      <td>{props.email}</td>
    </tr>
  );
};

export default RowTableContact;
