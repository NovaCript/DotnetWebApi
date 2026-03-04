import React from "react";
import RowContact from "./components/RowContact";


const TableContact = () => {
    return (
        <table className="table table-hover">
            <thead>
              <tr>
                <th>#</th>
                <th>Имя контакта</th>
                <th>E-mail</th>
              </tr>
            </thead>
            <tbody>
              <RowContact/>
              <RowContact/>
              <RowContact/>
            </tbody>
          </table>
    );
}


export default TableContact;