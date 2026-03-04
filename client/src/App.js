import TableContact from "./layout/TableContact/TableContact";

const contacts = [
  { id: 1, name: "Имя Фамилия 1", email: "q1@e.rt" },
  { id: 2, name: "Имя Фамилия 2", email: "q2@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
  { id: 3, name: "Имя Фамилия 3", email: "q3@e.rt" },
];

const App = () => {
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact contacts={contacts} />
        </div>
      </div>
    </div>
  );
};

export default App;
