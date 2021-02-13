import { useState } from 'react';
import './App.css';
import { Form } from './components/Form';
import { List } from './components/List'; 
import { UserContext } from './components/UserContext';

function App() {

  const [elements, setElements] = useState([]);  

  const data = {
    elements,
    setElements
  }; 

 
  return (
    <UserContext.Provider value={data}>
      <div className="App">
        <main role="main" className="container">
          <Form/>
          <List elements={elements}/>           
        </main>
      </div>
    </UserContext.Provider>

  );
}

export default App;