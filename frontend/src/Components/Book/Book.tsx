import React from 'react'
import "./Book.css"

interface Props  {
  BookTitle: string;
  Author: string;
  Rating: number;
}

const Book = ({BookTitle, Author, Rating}: Props) => {
  return (
  <div className='book'>
     <img 
        src="https://images.unsplash.com/photo-1612428978260-2b9c7df20150?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80"
        alt="Image"
    />

    <div className='details'>
        <h2>{BookTitle}</h2>
        <h3>{Author}</h3>
        <p>Ocena {Rating}*</p>
    </div>
    <p className='info'>
        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Consequatur, repudiandae.
    </p>
  </div>
);
}
export default Book
