import React from 'react';
import Navbar from "../Navbar/Navbar";
import SearchForm from "../SearchForm/SearchForm";
import "./Header.css";

const Header = () => {
  return (
    <div className='holder'>
      <header className='header'>
        <Navbar />
        <div className='header-content flex flex-c text-center text-white'>
          <h2 className='header-title text-capitalize'>Znajdź tytuł, który warto poznać</h2><br />
          <p className='header-text fs-18 fw-3'>Znajdź swoją następną ulubioną książkę, odkryj nowe tytuły, polecane przez społeczność miłośników literatury. Przeglądaj recenzje, oceniaj i dołącz do rozmowy o książkach!</p>
          <SearchForm />
        </div>
      </header>

    </div>
  )
}

export default Header