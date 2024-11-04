import { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import BookList from './Components/BookList/BookList';
import Search from './Components/Search/Search';

function App() {

  const [search, setSearch] = useState<string>();
    
  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
      setSearch(e.target.value);
      console.log(e);
  };

  const onClick = (e: SyntheticEvent) => {
    console.log(e);

  };

  return (
    <div className="App">
      <Search onClick={onClick} search={search} handleChange={handleChange} />
      <BookList />
    </div>
  );
}

export default App;
